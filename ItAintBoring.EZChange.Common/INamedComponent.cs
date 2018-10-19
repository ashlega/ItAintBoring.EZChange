using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ItAintBoring.EZChange.Common
{
    public interface INamedComponent
    {
        string Name { get; set; }

        

        

        UserControl UIControl { get; }
        void ApplyUIUpdates();
    }
}
