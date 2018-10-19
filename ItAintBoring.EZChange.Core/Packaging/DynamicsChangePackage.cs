using ItAintBoring.EZChange.Common.Packaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItAintBoring.EZChange.Core.Packaging
{
    public class DynamicsChangePackage: IChangePackage
    {
        public string PackageLocation { get; set; } //Storage specific

        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public string ConnectionString { get; set; }

        public List<ISolution> Solutions { get; set; }

        public bool HasUnsavedChanges {get;set;}
        
    }
}
