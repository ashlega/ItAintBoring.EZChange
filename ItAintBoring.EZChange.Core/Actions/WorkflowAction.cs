using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using ItAintBoring.EZChange.Common;
using ItAintBoring.EZChange.Common.Packaging;
using ItAintBoring.EZChange.Core.Packaging;
using ItAintBoring.EZChange.Core.UI;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;

namespace ItAintBoring.EZChange.Core.Actions
{
    public class WorkflowAction : BaseAction
    {
        public override string Version { get { return "1.0"; } }
        public override string Id { get { return "Workflow Action"; } }
        public override string Description { get { return "Workflow Action"; } }

        public override string Name { get; set; }

        private List<Type> supportedSolutionTypes = null;
        [XmlIgnore]
        public override List<Type> SupportedSolutionTypes { get { return supportedSolutionTypes; } }

        public WorkflowAction(): base()
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
                    case "run":
                        string fetchXml = a.InnerText;
                        var results = ds.Service.Service.RetrieveMultiple(new FetchExpression(fetchXml));
                        foreach(var r in results.Entities)
                        {
                            ExecuteWorkflowRequest ewr = new ExecuteWorkflowRequest();
                            ewr.EntityId = r.Id;
                            ewr.WorkflowId = Guid.Parse(a.Attributes["workflowid"].Value);
                            ds.Service.Service.Execute(ewr);
                        }
                        break;
                }
            }
        }
    
    }
}

/*
 <action type="run" workflowid="">
    fetchXml goes here
 </action>
 * */