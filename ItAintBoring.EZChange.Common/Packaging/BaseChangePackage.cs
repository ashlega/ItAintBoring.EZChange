using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItAintBoring.EZChange.Common.Packaging
{
    public abstract class BaseChangePackage : BaseComponent
    {
        
        public string PackageLocation { get; set; } //Storage specific
        public List<BaseSolution> Solutions { get; set; }

        abstract public bool HasUnsavedChanges {get;set;}

        public BaseChangePackage()
        {
            Solutions = new List<BaseSolution>();
        }
        
    }
}
