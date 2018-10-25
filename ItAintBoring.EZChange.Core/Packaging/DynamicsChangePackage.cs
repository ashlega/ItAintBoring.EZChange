using ItAintBoring.EZChange.Common;
using ItAintBoring.EZChange.Common.Packaging;
using ItAintBoring.EZChange.Core.UI;
using System;
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

        public string DestinationConnectionString { get; set; }

        public override bool HasUnsavedChanges {get;set;}


        private bool ignoreUpdates = false;
        public override void ApplyUIUpdates()
        {
            if (ignoreUpdates) return;

            if (((TwoConnections)uiControl).SourceConnection == ConnectionString &&
                ((TwoConnections)uiControl).DestinationConnection == DestinationConnectionString) return;
            ConnectionString = ((TwoConnections)uiControl).SourceConnection;
            DestinationConnectionString = ((TwoConnections)uiControl).DestinationConnection;
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
                    ((TwoConnections)uiControl).SourceConnection = ConnectionString;
                    ((TwoConnections)uiControl).DestinationConnection = DestinationConnectionString;
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
            return AppDomain.CurrentDomain.BaseDirectory + "\\Packages\\" + this.Name.ToString();
        }
    }
}
