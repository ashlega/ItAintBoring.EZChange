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
    public class DeploySolutionAction : BaseAction
    {


        public override string Version { get { return "1.0"; } }
        public override string Id { get { return "Deploy Solution Action"; } }
        public override string Description { get { return "Deploy Solution Action"; } }

        public override string Name { get; set; }

        private List<Type> supportedSolutionTypes = null;
        [XmlIgnore]
        public override List<Type> SupportedSolutionTypes { get { return supportedSolutionTypes; } }

        public string XML { get; set; }

        public DeploySolutionAction(): base()
        {
            supportedSolutionTypes = new List<Type>();
            supportedSolutionTypes.Add(typeof(DynamicsSolution));
        }

        
        

        private UserControl uiControl = null;
        [XmlIgnore]
        public override UserControl UIControl
        {
            get
            {
                return null;
            }
        }



        public override void DoAction(BaseSolution solution)
        {
            ActionStarted();
            DynamicsSolution ds = (DynamicsSolution)solution;
            ds.ImportSolution();
            ActionCompleted();
        }
    }
}
/*
 <action type="delete" target="entity/attribute/workflow/pluginstep/plugin/businessrule/webresource" attribute="" entity="" plugin="">
 </action>
 * */
