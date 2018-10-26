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
        
        public string WorkflowId { get; set; }
        public string FetchXml { get; set; }

        

        public override string Name { get; set; }

        private List<Type> supportedSolutionTypes = null;
        [XmlIgnore]
        public override List<Type> SupportedSolutionTypes { get { return supportedSolutionTypes; } }

        public WorkflowAction(): base()
        {
            supportedSolutionTypes = new List<Type>();
            supportedSolutionTypes.Add(typeof(DynamicsSolution));
        }

        
        public override void ApplyUIUpdates()
        {
            WorkflowId = ((WorkflowActionEditor)uiControl).WorkflowId;
            FetchXml = ((WorkflowActionEditor)uiControl).FetchXml;
        }

        private UserControl uiControl = new WorkflowActionEditor();
        [XmlIgnore]
        public override UserControl UIControl
        {
            get
            {
                ((WorkflowActionEditor)uiControl).WorkflowId = WorkflowId;
                ((WorkflowActionEditor)uiControl).FetchXml = FetchXml;
                return uiControl;
            }
        }



        public override void DoAction(BaseSolution solution)
        {
            DynamicsSolution ds = (DynamicsSolution)solution;
            if (!String.IsNullOrEmpty(FetchXml) && !String.IsNullOrEmpty(WorkflowId))
            {
                var results = ds.Service.Service.RetrieveMultiple(new FetchExpression(FetchXml));

                foreach (var r in results.Entities)
                {
                    ExecuteWorkflowRequest ewr = new ExecuteWorkflowRequest();
                    ewr.EntityId = r.Id;
                    ewr.WorkflowId = Guid.Parse(WorkflowId);
                    ds.Service.Service.Execute(ewr);
                }
            }
        }
    }
}

