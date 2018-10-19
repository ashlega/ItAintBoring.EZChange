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
    public class DynamicsSolution: ISolution
    {
        public List<Type> supportedPackageTypes = null;
        public List<Type> SupportedPackageTypes { get { return supportedPackageTypes; } }

        public DynamicsSolution()
        {
            supportedPackageTypes = new List<Type>();
            supportedPackageTypes.Add(typeof(DynamicsChangePackage));
        }

        public string Name { get; set; }

        public List<IAction> PreImportActions { get; set; }
        public List<IAction> PostImportActions { get; set; }

        private UserControl uiControl = new SingleLineEditor();
        public UserControl UIControl { get {
                ((SingleLineEditor)uiControl).SolutionName = Name;
                return uiControl;
            } }


        public void ApplyUIUpdates()
        {
            Name = ((SingleLineEditor)uiControl).SolutionName;
        }


    }
}
