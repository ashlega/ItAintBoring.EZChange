using ItAintBoring.EZChange.Common;
using ItAintBoring.EZChange.Common.Packaging;
using ItAintBoring.EZChange.Core.Packaging;
using ItAintBoring.EZChange.Core.UI;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.Web.Script.Serialization;
using Microsoft.Xrm.Sdk;

namespace ItAintBoring.EZChange.Core.Actions
{
    public class DataAction : BaseAction
    {


        public override string Version { get { return "1.0"; } }
        public override string Id { get { return "Import Data Action"; } }
        public override string Description { get { return "Import Data Action"; } }

        public override string Name { get; set; }

        private List<Type> supportedSolutionTypes = null;
        [XmlIgnore]
        public override List<Type> SupportedSolutionTypes { get { return supportedSolutionTypes; } }

        public string FileName { get; set; } 

        public bool CreateOnly { get; set; }

        public DataAction(): base()
        {
            supportedSolutionTypes = new List<Type>();
            supportedSolutionTypes.Add(typeof(DynamicsSolution));
        }

        


        public override void ApplyUIUpdates()
        {
            FileName = ((ImportActionEditor)uiControl).FileName;
            CreateOnly = ((ImportActionEditor)uiControl).CreateOnly;
        }

        private UserControl uiControl = new ImportActionEditor();
        [XmlIgnore]
        public override UserControl UIControl
        {
            get
            {
                ((ImportActionEditor)uiControl).FileName = FileName;
                ((ImportActionEditor)uiControl).CreateOnly = CreateOnly;
                return uiControl;
            }
        }



        public override void DoAction(BaseSolution solution)
        {
            ActionStarted();
            DynamicsSolution ds = (DynamicsSolution)solution;
            string json = ds.LoadActionData(this, ds.GetActionsDataFolder(this) + "\\"+ FileName);
            if (json != null)
            {
                try
                {
                    var list = ItAintBoring.EZChange.Core.Dynamics.Common.DeSerializeEntityList(ds.Service.Service, json);
                    ds.Service.DeserializeData(list, CreateOnly);
                }
                catch(Exception ex)
                {
                    throw new Exception("Error deserializing data for " + Name + ". " + ex.Message);
                }
            }
            ActionCompleted();

        }
    }
}
/*
 <action type="delete" target="entity/attribute/workflow/pluginstep/plugin/businessrule/webresource" attribute="" entity="" plugin="">
 </action>
 * */
