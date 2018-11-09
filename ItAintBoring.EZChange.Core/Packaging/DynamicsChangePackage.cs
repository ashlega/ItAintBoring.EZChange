using ItAintBoring.EZChange.Common;
using ItAintBoring.EZChange.Common.Packaging;
using ItAintBoring.EZChange.Core.Dynamics;
using ItAintBoring.EZChange.Core.UI;
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
    public class DynamicsChangePackage: BaseChangePackage
    {
        public override string Version { get { return "1.0"; } }
        public override string Id { get { return "Dynamics Package"; } }
        public override string Description { get { return "Dynamics Package"; } }

        public override string Name { get; set; }
        
        public string ConnectionString { get; set; }


        private bool ignoreUpdates = false;
        public override void ApplyUIUpdates()
        {
            if (ignoreUpdates) return;

            if (((TwoConnections)uiControl).Connection == ConnectionString) return;
            ConnectionString = ((TwoConnections)uiControl).Connection;
            HasUnsavedChanges = true;
        }

        private UserControl uiControl = null;
        [XmlIgnore]
        public override UserControl UIControl
        {
            get
            {
                if(uiControl == null) uiControl = new TwoConnections(this);

                ignoreUpdates = true;
                try
                {
                    ((TwoConnections)uiControl).Connection = ConnectionString;
                }
                finally
                {
                    ignoreUpdates = false;
                }

                return uiControl;
            }
        }

        public override string GetDataFolder()
        {
            string fileName = System.IO.Path.GetFileName(PackageLocation);
            int i = fileName.LastIndexOf(".");
            if (i > 0) fileName = fileName.Substring(0, i);
            return System.IO.Path.GetDirectoryName(PackageLocation)+"\\Build_" + fileName;
        }

        public override void UpdateRuntimeData(Hashtable values)
        {
            base.UpdateRuntimeData(values);
            ConnectionString = ReplaceVariables(ConnectionString, values);
        }

        public override bool IsPackageDeployed()
        {
            var service = new DynamicsService(ConnectionString);
            return service.IsPackageDeployed(System.IO.Path.GetFileName(PackageLocation));
        }

        public override void LogPackageDeployment()
        {
            var service = new DynamicsService(ConnectionString);
            service.LogPackageDeployment(System.IO.Path.GetFileName(PackageLocation));
        }

        public override void Run(BaseAction selectedAction = null)
        {
            base.Run(selectedAction);
        }
    }
}
