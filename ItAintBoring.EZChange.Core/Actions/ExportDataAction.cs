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
    public class ExportDataAction : BaseAction
    {


        public override string Version { get { return "1.0"; } }
        public override string Id { get { return "Export Data Action"; } }
        public override string Description { get { return "Export Data Action"; } }

        public override string Name { get; set; }

        private List<Type> supportedSolutionTypes = null;
        [XmlIgnore]
        public override List<Type> SupportedSolutionTypes { get { return supportedSolutionTypes; } }

        public string XML { get; set; }

        public ExportDataAction(): base()
        {
            supportedSolutionTypes = new List<Type>();
            supportedSolutionTypes.Add(typeof(DynamicsSolution));
        }

        
        public override void ApplyUIUpdates()
        {
            XML = EscapeXml(((XMLEditor)uiControl).XML);
        }

        private UserControl uiControl = new XMLEditor();
        [XmlIgnore]
        public override UserControl UIControl
        {
            get
            {
                ((XMLEditor)uiControl).XML = UnescapeXML(XML);
                return uiControl;
            }
        }



        public override void DoAction(BaseSolution solution)
        {
            DynamicsSolution ds = (DynamicsSolution)solution;

            var results = ds.Service.Service.RetrieveMultiple(new FetchExpression(UnescapeXML(XML)));
            var list = results.Entities.ToList();
            var json = ItAintBoring.EZChange.Core.Dynamics.Common.SerializeEntityList(list);
            ds.SaveActionData(this, json);
        }
    }
}
/*
 <action type="delete" target="entity/attribute/workflow/pluginstep/plugin/businessrule/webresource" attribute="" entity="" plugin="">
 </action>
 * */
