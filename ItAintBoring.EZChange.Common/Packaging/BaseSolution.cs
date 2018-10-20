using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItAintBoring.EZChange.Common.Packaging
{
    public abstract class BaseSolution: BaseComponent
    {
        public List<BaseAction> PreImportActions { get; set; }
        public List<BaseAction> PostImportActions { get; set; }

        public BaseSolution()
        {
            PreImportActions = new List<BaseAction>();
            PostImportActions = new List<BaseAction>();

        }

        abstract public List<Type> SupportedPackageTypes { get; }

    }
}
