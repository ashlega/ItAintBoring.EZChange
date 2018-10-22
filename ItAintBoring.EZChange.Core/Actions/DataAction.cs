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
        public override string Id { get { return "Data Action"; } }
        public override string Description { get { return "Data Action"; } }

        public override string Name { get; set; }

        private List<Type> supportedSolutionTypes = null;
        [XmlIgnore]
        public override List<Type> SupportedSolutionTypes { get { return supportedSolutionTypes; } }

        public DataAction(): base()
        {
            supportedSolutionTypes = new List<Type>();
            supportedSolutionTypes.Add(typeof(DynamicsSolution));
        }

        
        public string Title { get; set; }



        public override void ApplyUIUpdates()
        {
            XML = ((XMLEditor)uiControl).XML;
        }

        private UserControl uiControl = new XMLEditor();
        [XmlIgnore]
        public override UserControl UIControl
        {
            get
            {
                ((XMLEditor)uiControl).XML = XML;
                return uiControl;
            }
        }



        public override void DoAction(BaseSolution solution)
        {
            DynamicsSolution ds = (DynamicsSolution)solution;
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(XML);
            var actions = doc.GetElementsByTagName("action");
            foreach (XmlNode a in actions)
            {
                switch (a.Attributes["type"].Value)
                {
                    case "export":
                        string fetchXml = a.InnerText;
                        var results = ds.Service.Service.RetrieveMultiple(new FetchExpression(fetchXml));
                        var list = results.Entities.ToList();
                        var json = ItAintBoring.EZChange.Core.Dynamics.Common.SerializeEntityList(list);
                        ds.SaveActionData(this, json);
                        
                        break;
                    case "import":
                        bool createOnly = a.Attributes["createOnly"] != null && a.Attributes["createOnly"].Value == "true";
                        json = ds.LoadActionData(this, a.Attributes["file"] != null ? a.Attributes["file"].Value : null);
                        if (json != null)
                        {
                            list = ItAintBoring.EZChange.Core.Dynamics.Common.DeSerializeEntityList(json);
                            ds.Service.DeserializeData(list, createOnly);
                        }
                        /*
                        string fetchXml = a.InnerText;
                        var results = ds.Service.Service.RetrieveMultiple(new FetchExpression(fetchXml));
                        foreach (var r in results.Entities)
                        {

                        }
                        */
                        break;
                }

            }
        }
    }
}
/*
 <action type="delete" target="entity/attribute/workflow/pluginstep/plugin/businessrule/webresource" attribute="" entity="" plugin="">
 </action>
 * */
