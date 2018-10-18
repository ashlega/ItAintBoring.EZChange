using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItAintBoring.EZChange.Common.Packaging
{
    public class ChangePackage
    {
        public string PackageLocation { get; set; } //Storage specific

        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public string ConnectionString { get; set; }

        public List<Solution> Solutions;

        public bool HasUnsavedChanges {get;set;}
        
    }
}
