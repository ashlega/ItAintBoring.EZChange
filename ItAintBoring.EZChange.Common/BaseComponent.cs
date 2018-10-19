using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItAintBoring.EZChange.Common
{
    public class BaseComponent
    {
        public virtual string Id { get; }
        public virtual string Description { get; }

        public override string ToString()
        {
            if (this is BaseComponent) return ((BaseComponent)this).Id;
            else return base.ToString();
        }
    }
}
