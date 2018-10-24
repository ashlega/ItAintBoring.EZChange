using ItAintBoring.EZChange.Common;
using ItAintBoring.EZChange.Common.Packaging;
using ItAintBoring.EZChange.Core.Packaging;
using ItAintBoring.EZChange.Core.UI;
using Microsoft.Xrm.Sdk.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace ItAintBoring.EZChange.Core.Actions
{
    public class MetaDataAction : BaseAction
    {

        public override string Version { get { return "1.0"; } }
        public override string Id { get { return "MetaData Action"; } }
        public override string Description { get { return "MetaData Action"; } }

        public override string Name { get; set; }

        private List<Type> supportedSolutionTypes = null;
        [XmlIgnore]
        public override List<Type> SupportedSolutionTypes { get { return supportedSolutionTypes; } }

        public MetaDataAction(): base()
        {
            supportedSolutionTypes = new List<Type>();
            supportedSolutionTypes.Add(typeof(DynamicsSolution));
        }

        public string XML { get; set; }
  
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
            foreach(XmlNode a in actions)
            {
                switch(a.Attributes["type"].Value)
                {
                    case "delete":
                        try
                        {
                            switch (a.Attributes["target"].Value)
                            {
                                case "attribute":
                                    DeleteAttributeRequest dar = new DeleteAttributeRequest();
                                    dar.EntityLogicalName = a.Attributes["entity"].Value;
                                    dar.LogicalName = a.Attributes["attribute"].Value;
                                    ds.Service.Service.Execute(dar);
                                    break;
                                case "entity":
                                    DeleteEntityRequest der = new DeleteEntityRequest();
                                    der.LogicalName = a.Attributes["entity"].Value;
                                    ds.Service.Service.Execute(der);
                                    break;
                                case "workflow":
                                    break;
                                case "pluginstep":
                                    break;
                                case "plugin":
                                    break;
                                case "businessrule":
                                    break;
                                case "webresource":
                                    break;
                            }
                        }
                        catch(Exception ex)
                        {
                            if (!ex.Message.ToLower().Contains("could not find")) throw; //Ignore if the "artefact" does not exist
                        }
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
