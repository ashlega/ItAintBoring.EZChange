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

        [XmlIgnore]
        public override UserControl UIControl { get { return null; } }


        
        public override void ApplyUIUpdates()
        {
            
        }

        private string solutionFolder = null;

        private string GetActionFileName(BaseAction action, string fileName)
        {
            if (solutionFolder == null) return null;
            string path = System.IO.Path.Combine(solutionFolder, "actions");
            System.IO.Directory.CreateDirectory(path);
            return System.IO.Path.Combine(path, fileName != null ? fileName : action.ComponentId + ".txt");
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
            fileName = GetActionFileName(action, fileName);
            
            if (!System.IO.File.Exists(fileName)) return null;
            using (System.IO.StreamReader sr = new System.IO.StreamReader(fileName))
            {
                return sr.ReadToEnd();
            }
        }

        public override void PrepareSolution(BaseComponent package)
        {
            if(service == null)
            {
                service = new DynamicsService(((DynamicsChangePackage)package).ConnectionString);
            }
            else service.ConnectionString = ((DynamicsChangePackage)package).ConnectionString;

            solutionFolder = package.GetDataFolder() + "\\Solutions\\" + GetDataFolder();

            foreach (var action in PreImportActions)
            {
                action.DoAction(this);
            }
            service.ExportSolution(Name, solutionFolder, false);
        }

        public override void DeploySolution(BaseComponent package)
        {
            
            if (service == null)
            {
                service = new DynamicsService(((DynamicsChangePackage)package).DestinationConnectionString);
            }
            else service.ConnectionString = ((DynamicsChangePackage)package).DestinationConnectionString;
            solutionFolder = package.GetDataFolder() + "\\Solutions\\" + GetDataFolder();

            string[] files = System.IO.Directory.GetFiles(solutionFolder, "*zip");
            if (files.Length > 0)
            {
                

                //service.ImportSolution(files[0]);

                foreach (var action in PostImportActions)
                {
                    action.DoAction(this);
                }
            }
            
        }
    }
}
