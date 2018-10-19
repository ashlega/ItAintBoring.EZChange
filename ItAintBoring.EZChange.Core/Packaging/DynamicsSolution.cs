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
    public class DynamicsSolution: BaseComponent, ISolution, INamedComponent
    {
        public override string Id { get { return "Dynamics Solution"; } }
        public override string Description { get { return "Dynamics Solution"; } }

        public string Name { get; set; }


        public List<Type> supportedPackageTypes = null;
        public List<Type> SupportedPackageTypes { get { return supportedPackageTypes; } }

        public DynamicsSolution()
        {
            supportedPackageTypes = new List<Type>();
            supportedPackageTypes.Add(typeof(DynamicsChangePackage));
        }

        public UserControl UIControl { get { return null; } }

        public void ApplyUIUpdates()
        {

        }


        public List<IAction> PreImportActions { get; set; }
        public List<IAction> PostImportActions { get; set; }

        
        

        


    }
}
