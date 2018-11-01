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
using Microsoft.Crm.Sdk.Messages;
using System.Reflection;

namespace ItAintBoring.EZChange.Core.Actions
{
    public class CustomCodeAction : BaseAction
    {


        public override string Version { get { return "1.0"; } }
        public override string Id { get { return "Custom Code Action"; } }
        public override string Description { get { return "Custom Code Action"; } }

        public override string Name { get; set; }

        private List<Type> supportedSolutionTypes = null;
        [XmlIgnore]
        public override List<Type> SupportedSolutionTypes { get { return supportedSolutionTypes; } }

        public Guid FileActionId { get; set; }

        public CustomCodeAction() : base()
        {
            supportedSolutionTypes = new List<Type>();
            supportedSolutionTypes.Add(typeof(DynamicsSolution));
        }




        public override void ApplyUIUpdates()
        {
            if (((ActionSelectorEditor)uiControl).SelectedAction != null)
            {
                FileActionId = ((ActionSelectorEditor)uiControl).SelectedAction.ComponentId;
            }
            else FileActionId = Guid.Empty;
        }

        private UserControl uiControl = null;
        [XmlIgnore]
        public override UserControl UIControl
        {
            get
            {
                if(uiControl == null)
                {
                    uiControl = new ActionSelectorEditor(this, null, Solution.FindAction(FileActionId));
                }
                ((ActionSelectorEditor)uiControl).PopulateActions(Solution.BuildActions.FindAll(x => x is AddFileAction));
                ((ActionSelectorEditor)uiControl).SelectedAction = Solution.FindAction(FileActionId);
                return uiControl;
            }
        }



        public override void DoAction(BaseSolution solution)
        {
            ActionStarted();
            
            var a = Solution.FindAction(FileActionId);
            if(a != null)
            {
                ((DynamicsSolution)solution).ReconnectService(true);
                AddFileAction action = (AddFileAction)a;

                string path = ((DynamicsSolution)solution).GetActionsDataFolder(this);
                string file = System.IO.Path.Combine(path, System.IO.Path.GetFileName(action.FileName));
                var DLL = Assembly.LoadFile(file);
                foreach (Type type in DLL.GetExportedTypes())
                {
                    if (typeof(IChangeAction).IsAssignableFrom(type))
                    {
                       var codeAction = (IChangeAction)Activator.CreateInstance(type);
                       codeAction.DoAction(solution);
                    }
                }

            }
            /*
            DynamicsSolution ds = (DynamicsSolution)solution;
            string json = ds.LoadActionData(this, ds.GetActionsDataFolder(this) + "\\" + FileName);
            if (json != null)
            {
                try
                {
                    var list = ItAintBoring.EZChange.Core.Dynamics.Common.DeSerializeEntityList(ds.Service.Service, json);
                    ds.Service.DeserializeData(list, CreateOnly);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error deserializing data for " + Name + ". " + ex.Message);
                }
            }
            */
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
