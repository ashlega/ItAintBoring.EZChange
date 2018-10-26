using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItAintBoring.EZChange.Common.Packaging
{
    public class Variable
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
