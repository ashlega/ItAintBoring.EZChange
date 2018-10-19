using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItAintBoring.EZChange.Common.Packaging
{
    public interface IChangePackage
    {
        string PackageLocation { get; set; } //Storage specific
        List<ISolution> Solutions { get; set; }

        bool HasUnsavedChanges {get;set;}
        
    }
}
