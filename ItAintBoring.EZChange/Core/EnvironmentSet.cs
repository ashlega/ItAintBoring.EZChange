using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ItAintBoring.EZChange.Core
{
    public class EnvironmentSet
    {
        public Hashtable Variables = null;
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
