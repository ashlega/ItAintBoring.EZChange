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
    public class MetaDataAction : BaseComponent, IAction, INamedComponent
    {

        public override string Id { get { return "MetaData Action"; } }
        public override string Description { get { return "MetaData Action"; } }

        public string Name { get; set; }

        public List<Type> supportedSolutionTypes = null;
        public List<Type> SupportedSolutionTypes { get { return supportedSolutionTypes; } }

        public MetaDataAction()
        {
            supportedSolutionTypes = new List<Type>();
            supportedSolutionTypes.Add(typeof(DynamicsSolution));
        }

       
        public string Title { get; set; }
        public string XML { get; set; }
        
        private UserControl uiControl = new XMLEditor();
        public UserControl UIControl { get {
                ((XMLEditor)uiControl).XML = XML;
                return uiControl;
            } }

        public void ApplyUIUpdates()
        {
            XML = ((XMLEditor)uiControl).XML;
        }

        public void DoAction()
        {
            throw new NotImplementedException();
        }
    }
}
