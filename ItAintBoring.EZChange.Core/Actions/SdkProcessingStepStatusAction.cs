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
using ItAintBoring.EZChange.Core.Dynamics;

namespace ItAintBoring.EZChange.Core.Actions
{
    public class SdkProcessingStepStatusAction : BaseAction
    {


        public override string Version { get { return "1.0"; } }
        public override string Id { get { return "Sdk Processing Step Status"; } }
        public override string Description { get { return "Change Sdk Message Processing Step Status"; } }

        public override string Name { get; set; }

        private List<Type> supportedSolutionTypes = null;
        [XmlIgnore]
        public override List<Type> SupportedSolutionTypes { get { return supportedSolutionTypes; } }

        public string StepName { get; set; }

        public bool Activate { get; set; }

        public SdkProcessingStepStatusAction(): base()
        {
            supportedSolutionTypes = new List<Type>();
            supportedSolutionTypes.Add(typeof(DynamicsSolution));
        }


        public override void ApplyUIUpdates()
        {
            if (((StepSelectorEditor)uiControl).SelectedStep != null)
            {
                StepName = ((StepSelectorEditor)uiControl).SelectedStep;
                Activate = ((StepSelectorEditor)uiControl).Activate;
            }
            else StepName = null;
        }


        private UserControl uiControl = null;
        [XmlIgnore]
        public override UserControl UIControl
        {
            get
            {
                if (uiControl == null)
                {
                    uiControl = new StepSelectorEditor(this, Activate, StepName);
                }
                ((StepSelectorEditor)uiControl).Activate = Activate;
                ((StepSelectorEditor)uiControl).SelectedStep = StepName;
                return uiControl;
            }
        }




        public override void DoAction(BaseSolution solution)
        {
            ActionStarted();


            DynamicsSolution ds = (DynamicsSolution)solution;
            try
            {
                ds.Service.SetMessageStepStatus(StepName, Activate);
            }
            catch (Exception ex)
            {
                throw new Exception("Error setting SDK step status " + Name + ". " + ex.Message);
            }
            
            ActionCompleted();

        }

        public override void UpdateRuntimeData(System.Collections.Hashtable values)
        {
            
        }
    }
}
/*
 <action type="delete" target="entity/attribute/workflow/pluginstep/plugin/businessrule/webresource" attribute="" entity="" plugin="">
 </action>
 * */
