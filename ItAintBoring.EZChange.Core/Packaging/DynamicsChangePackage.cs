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
    public class DynamicsChangePackage: BaseComponent, IChangePackage, INamedComponent
    {
        public override string Id { get { return "Dynamics Package"; } }
        public override string Description { get { return "Dynamics Package"; } }

        public string PackageLocation { get; set; } //Storage specific

        public string Name { get; set; }
        
        public string Version { get; set; }
        public string ConnectionString { get; set; }

        public List<ISolution> Solutions { get; set; }

        public bool HasUnsavedChanges {get;set;}

        public UserControl UIControl { get { return null; } }

        public void ApplyUIUpdates()
        {
            
        }
    }
}
