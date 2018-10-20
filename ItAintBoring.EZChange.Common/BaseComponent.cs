using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ItAintBoring.EZChange.Common
{
    public abstract class BaseComponent
    {
        public abstract string Version { get; }
        public virtual string Id { get; }
        public virtual string Description { get; }

        abstract public string Name { get; set; }

        

        abstract public UserControl UIControl { get; }
        virtual public void ApplyUIUpdates() { }

        public override string ToString()
        {
            if (Name != null) return Name;
            else if (Id != null) return Id;
            else return base.ToString();
        }
    }
}
