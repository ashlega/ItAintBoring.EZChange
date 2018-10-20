using ItAintBoring.EZChange.Common;
using ItAintBoring.EZChange.Common.Packaging;
using ItAintBoring.EZChange.Core.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ItAintBoring.EZChange.Core.Packaging
{
    public class DynamicsSolution: BaseSolution
    {
        public override string Version { get { return "1.0"; } }
        public override string Id { get { return "Dynamics Solution"; } }
        public override string Description { get { return "Dynamics Solution"; } }

        public override string Name { get; set; }


        public List<Type> supportedPackageTypes = null;
        public override List<Type> SupportedPackageTypes { get { return supportedPackageTypes; } }

        public DynamicsSolution()
        {
            supportedPackageTypes = new List<Type>();
            supportedPackageTypes.Add(typeof(DynamicsChangePackage));
        }

        public override UserControl UIControl { get { return null; } }

        public override void ApplyUIUpdates()
        {

        }
        

    }
}
