using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItAintBoring.EZChange.Common
{
    public interface IVersionedComponent
    {
        string Version { get; set; }
    }
}
