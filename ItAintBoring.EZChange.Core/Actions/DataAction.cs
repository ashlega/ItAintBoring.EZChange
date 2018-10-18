using ItAintBoring.EZChange.Common;
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
        public string XML { get; set; }
        public string Name { get { return "Data Action"; } }

        public string Description { get { return "Data Action"; } }

        public UserControl UIControl => throw new NotImplementedException();

        public void ApplyUIUpdates()
        {
            throw new NotImplementedException();
        }

        public void DoAction()
        {
            throw new NotImplementedException();
        }
    }
}
