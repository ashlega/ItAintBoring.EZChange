using ItAintBoring.EZChange.Common;
using ItAintBoring.EZChange.Common.Packaging;
using ItAintBoring.EZChange.Core.Dynamics;
using ItAintBoring.EZChange.Core.UI;
using Microsoft.Crm.Sdk.Messages;
using System;
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
                if (uiControl == null) uiControl = new SimpleEditor("External File Name", false, this);
                               
                ((SimpleEditor)uiControl).SimpleText = ExternalFileName;

                return uiControl;
            }
        }

        public override void ApplyUIUpdates()
        {
            ExternalFileName = ((SimpleEditor)uiControl).SimpleText;
        }

        private string solutionFolder = null;

        public string GetActionsDataFolder(BaseAction action)
        {
            if (solutionFolder == null) return null;
            string path = System.IO.Path.Combine(solutionFolder, "Actions");
            System.IO.Directory.CreateDirectory(path);
            return path;

        }

        private string GetActionFileName(BaseAction action, string fileName)
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

        public override void PrepareSolution(BaseComponent package)
        {
            if(service == null)
            {
                service = new DynamicsService(((DynamicsChangePackage)package).ConnectionString);
            }
            else service.ConnectionString = ((DynamicsChangePackage)package).ConnectionString;

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
            else service.ExportSolution(Name, solutionFolder, false);
        }

        public void ImportSolution()
        {
            string[] files = System.IO.Directory.GetFiles(solutionFolder, "*zip");
            if (files.Length > 0)
            {
                service.ImportSolution(files[0]);
            }
        }

        public override void DeploySolution(BaseComponent package)
        {
            ProcessingStarted();
            if (service == null)
            {
                service = new DynamicsService(((DynamicsChangePackage)package).DestinationConnectionString);
            }
            else service.ConnectionString = ((DynamicsChangePackage)package).DestinationConnectionString;

            solutionFolder = package.GetDataFolder() + "\\" + GetDataFolder();

            foreach (var action in DeployActions)
            {
                action.DoAction(this);
            }

            ProcessingCompleted();
        }
    }
}
