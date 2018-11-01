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

namespace ItAintBoring.EZChange.Core.Actions
{
    public class AddFileAction: BaseAction
    {


        public override string Version { get { return "1.0"; } }
        public override string Id { get { return "Add File Action"; } }
        public override string Description { get { return "Add File Action"; } }

        public override string Name { get; set; }

        private List<Type> supportedSolutionTypes = null;
        [XmlIgnore]
        public override List<Type> SupportedSolutionTypes { get { return supportedSolutionTypes; } }

        public string FileName { get; set; }

        public AddFileAction(): base()
        {
            supportedSolutionTypes = new List<Type>();
            supportedSolutionTypes.Add(typeof(DynamicsSolution));
        }

        
        public override void ApplyUIUpdates()
        {
            FileName = ((FileSelectorEditor)uiControl).FileName;
        }

        private UserControl uiControl = new FileSelectorEditor();
        [XmlIgnore]
        public override UserControl UIControl
        {
            get
            {
                ((FileSelectorEditor)uiControl).FileName = FileName;
                return uiControl;
            }
        }



        public override void DoAction(BaseSolution solution)
        {
            ActionStarted();

            string path = ((DynamicsSolution)solution).GetActionsDataFolder(this);
            System.IO.Directory.CreateDirectory(path);
            System.IO.File.Copy(FileName, System.IO.Path.Combine(path, System.IO.Path.GetFileName(FileName)));


            ActionCompleted();
        }

        public override void UpdateRuntimeData(System.Collections.Hashtable values)
        {
            FileName = ReplaceVariables(FileName, values);
        }
    }
}
/*
 <action type="delete" target="entity/attribute/workflow/pluginstep/plugin/businessrule/webresource" attribute="" entity="" plugin="">
 </action>
 * */
