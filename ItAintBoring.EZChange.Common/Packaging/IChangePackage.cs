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

        string Name { get; set; }
        string Description { get; set; }
        string Version { get; set; }
        

        List<ISolution> Solutions { get; set; }

        bool HasUnsavedChanges {get;set;}
        
    }
}
