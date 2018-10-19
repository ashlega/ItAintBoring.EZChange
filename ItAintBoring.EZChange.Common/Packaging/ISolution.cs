using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItAintBoring.EZChange.Common.Packaging
{
    public interface ISolution
    {
        List<IAction> PreImportActions { get; set; }
        List<IAction> PostImportActions { get; set; }

        List<Type> SupportedPackageTypes { get; }

    }
}
