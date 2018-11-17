using ItAintBoring.EZChange.Common;
using ItAintBoring.EZChange.Common.Packaging;
using ItAintBoring.EZChange.Core.Dynamics;
using ItAintBoring.EZChange.Core.UI;
using Microsoft.Crm.Sdk.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ItAintBoring.EZChange.Core.Packaging
{
    public class DynamicsSolution: BaseSolution
    {
        public override string Version { get { return "1.0"; } }
        public override string Id { get { return "Dynamics Solution"; } }
        public override string Description { get { return "Dynamics Solution"; } }


        private string displayName = null;
        public override string DisplayName {
            get
            {
                if (displayName == null) return Name;
                else return displayName;
            }
            set
            {
                displayName = value;
            }
        }

        public override string Name { get; set; }

        public string ExternalFileName { get; set; }


        private List<Type> supportedPackageTypes = null;
        [XmlIgnore]
        public override List<Type> SupportedPackageTypes { get { return supportedPackageTypes; } }

        private DynamicsService service = null;
        [XmlIgnore]
        public DynamicsService Service {
            get
            {
                return service;
            }
        }

        


        public DynamicsSolution(): base()
        {
            supportedPackageTypes = new List<Type>();
            supportedPackageTypes.Add(typeof(DynamicsChangePackage));
        }

        private UserControl uiControl = null;
        [XmlIgnore]
        public override UserControl UIControl
        {
            get
            {
                if (uiControl == null) uiControl = new DynamicsSolutionEditor(this);// ("External File Name", false, this);
                               
                ((DynamicsSolutionEditor)uiControl).SolutionName = Name;
                ((DynamicsSolutionEditor)uiControl).FileName = ExternalFileName;

                return uiControl;
            }
        }

        public override void ApplyUIUpdates()
        {
            ExternalFileName = ((DynamicsSolutionEditor)uiControl).FileName;
            Name = ((DynamicsSolutionEditor)uiControl).SolutionName;
        }

        private string solutionFolder = null;

        public string GetActionsDataFolder(BaseAction action)
        {
            if (solutionFolder == null) return null;
            string path = System.IO.Path.Combine(solutionFolder, "Actions");
            System.IO.Directory.CreateDirectory(path);
            return path;

        }

        public string GetActionFileName(BaseAction action, string fileName)
        {
            if (solutionFolder == null) return null;
            string path = GetActionsDataFolder(action);
            return System.IO.Path.Combine(path, fileName != null ? fileName : action.Name+ ".txt");
        }
        public override void SaveActionData(BaseAction action, string data)
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(GetActionFileName(action, null), false))
            {
                sw.Write(data);
            }
        }

        public override string LoadActionData(BaseAction action, string fileName)
        {
            fileName = System.IO.Path.Combine(GetActionsDataFolder(action), fileName);

            if (!System.IO.File.Exists(fileName)) return null;
            using (System.IO.StreamReader sr = new System.IO.StreamReader(fileName))
            {
                return sr.ReadToEnd();
            }
        }

        public override string GetDataFolder()
        {
            return Name;
        }

        private string currentConnectionString = null;
        public void ReconnectService(bool forceReconnect)
        {
            if (service == null || forceReconnect)
            {
                service = new DynamicsService(currentConnectionString);
            }
            else service.ConnectionString = currentConnectionString;
        }
        public override void PrepareSolution(BaseComponent package)
        {

            currentConnectionString = ((DynamicsChangePackage)package).ConnectionString;
            ReconnectService(true);

            solutionFolder = package.GetDataFolder() + "\\" + GetDataFolder();

            foreach (var action in BuildActions)
            {
                action.DoAction(this);
            }
            if(!String.IsNullOrEmpty(ExternalFileName))
            {
                System.IO.Directory.CreateDirectory(solutionFolder);
                System.IO.File.Copy(ExternalFileName, System.IO.Path.Combine(solutionFolder, System.IO.Path.GetFileName(ExternalFileName)));
            }
            else if(!String.IsNullOrEmpty(Name)) service.ExportSolution(Name, solutionFolder, false);
        }

        public void ImportSolution()
        {
            string[] files = System.IO.Directory.GetFiles(solutionFolder, "*zip");
            if (files.Length > 0)
            {
                service.ImportSolution(files[0]);
            }
        }

        public override void DeploySolution(BaseComponent package, BaseAction selectedAction = null)
        {
            ProcessingStarted();

            currentConnectionString = ((DynamicsChangePackage)package).ConnectionString;
            ReconnectService(true);
            
            solutionFolder = package.GetDataFolder() + "\\" + GetDataFolder();

            foreach (var action in DeployActions)
            {
                if (selectedAction == null || selectedAction.ComponentId == action.ComponentId)
                {
                    action.DoAction(this);
                }
            }

            ProcessingCompleted();
        }

        public override void UpdateRuntimeData(Hashtable values)
        {
            base.UpdateRuntimeData(values);
            ExternalFileName = ReplaceVariables(ExternalFileName, values);
        }

        public override string ToString()
        {
            if (DisplayName == null) return Name;
            else return DisplayName;
        }

        
    }
}
