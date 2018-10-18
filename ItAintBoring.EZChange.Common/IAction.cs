using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ItAintBoring.EZChange.Common
{
    public interface IAction
    {
        string Title { get; set; }
        string Name { get; }
        string Description { get; }
        UserControl UIControl { get; }


        void ApplyUIUpdates();
        void DoAction();
        
    }
}
