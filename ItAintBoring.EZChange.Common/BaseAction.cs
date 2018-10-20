using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ItAintBoring.EZChange.Common
{
    public abstract class  BaseAction: BaseComponent
    {
        public string XML { get; set; }

        abstract public void DoAction();
        abstract public List<Type> SupportedSolutionTypes { get; }

        

    }
}
