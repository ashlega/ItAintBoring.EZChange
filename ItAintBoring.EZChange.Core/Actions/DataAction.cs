using ItAintBoring.EZChange.Common;
using ItAintBoring.EZChange.Core.Packaging;
using ItAintBoring.EZChange.Core.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ItAintBoring.EZChange.Core.Actions
{
    public class DataAction : IAction
    {


        public List<Type> supportedSolutionTypes = null;
        public List<Type> SupportedSolutionTypes { get { return supportedSolutionTypes; } }

        public DataAction()
        {
            supportedSolutionTypes = new List<Type>();
            supportedSolutionTypes.Add(typeof(DynamicsSolution));
        }

        public override string ToString()
        {
            return Name;
        }
        public string Title { get; set; }

        public string XML { get; set; }
        public string Name { get { return "Data Action"; } }

        public string Description { get { return "Data Action"; } }

        private UserControl uiControl = new XMLEditor();
        public UserControl UIControl { get {
                ((XMLEditor)uiControl).XML = XML;
                return uiControl;
            } }

        public void ApplyUIUpdates()
        {
            throw new NotImplementedException();
        }

        public void DoAction()
        {
            XML = ((XMLEditor)uiControl).XML;
        }
    }
}
