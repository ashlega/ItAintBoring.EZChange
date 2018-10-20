using ItAintBoring.EZChange.Common;
using ItAintBoring.EZChange.Common.Packaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ItAintBoring.EZChange.Core.Packaging
{
    public class DynamicsChangePackage: BaseChangePackage
    {
        public override string Version { get { return "1.0"; } }
        public override string Id { get { return "Dynamics Package"; } }
        public override string Description { get { return "Dynamics Package"; } }

        public override string Name { get; set; }
        
        public string ConnectionString { get; set; }

        public override bool HasUnsavedChanges {get;set;}

        public override UserControl UIControl { get { return null; } }

        public override void ApplyUIUpdates()
        {
            
        }
    }
}
