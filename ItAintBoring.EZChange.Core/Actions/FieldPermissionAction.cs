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
    public class FieldPermissionAction : BaseAction
    {
        public override string Version { get { return "1.0"; } }
        public override string Id { get { return "Field Permission Action"; } }
        public override string Description { get { return "Field Permission Action"; } }

        public string FieldSecurityProfileId { get; set; }
        public string EntityName { get; set; }
        public string AttributeName{ get; set; }

        public bool CanRead { get; set; }
        public bool CanCreate { get; set; }
        public bool CanUpdate { get; set; }



        public override string Name { get; set; }

        private List<Type> supportedSolutionTypes = null;
        [XmlIgnore]
        public override List<Type> SupportedSolutionTypes { get { return supportedSolutionTypes; } }

        public FieldPermissionAction() : base()
        {
            supportedSolutionTypes = new List<Type>();
            supportedSolutionTypes.Add(typeof(DynamicsSolution));
        }


        public override void ApplyUIUpdates()
        {
            FieldSecurityProfileId = ((FieldPermissionEditor)uiControl).ProfileName;
            EntityName = ((FieldPermissionEditor)uiControl).EntityName;
            AttributeName = ((FieldPermissionEditor)uiControl).AttributeName;
            CanCreate = ((FieldPermissionEditor)uiControl).CanCreate;
            CanRead = ((FieldPermissionEditor)uiControl).CanRead;
            CanUpdate = ((FieldPermissionEditor)uiControl).CanUpdate;
        }

        private UserControl uiControl = new FieldPermissionEditor();
        [XmlIgnore]
        public override UserControl UIControl
        {
            get
            {
                ((FieldPermissionEditor)uiControl).ProfileName = FieldSecurityProfileId;
                ((FieldPermissionEditor)uiControl).EntityName = EntityName;
                ((FieldPermissionEditor)uiControl).AttributeName = AttributeName;
                ((FieldPermissionEditor)uiControl).CanCreate = CanCreate;
                ((FieldPermissionEditor)uiControl).CanRead = CanRead;
                ((FieldPermissionEditor)uiControl).CanUpdate = CanUpdate;

                return uiControl;
            }
        }



        public override void DoAction(BaseSolution solution)
        {
            ActionStarted();
            DynamicsSolution ds = (DynamicsSolution)solution;
            ds.Service.SetFieldPermission(FieldSecurityProfileId, EntityName, AttributeName, CanRead, CanCreate, CanUpdate);
            ActionCompleted();
        }

        public override void UpdateRuntimeData(System.Collections.Hashtable values)
        {
            
        }
    }
}
