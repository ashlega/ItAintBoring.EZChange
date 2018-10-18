using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItAintBoring.EZChange.Common.Packaging;

namespace ItAintBoring.EZChange.Common.Storage
{
    public interface IPackageStorage
    {
        string Name { get; }
        string Description { get; }
        string Version { get; }

        bool SavePackageAs(ChangePackage package);
        bool SavePackage(ChangePackage package);
        ChangePackage LoadPackage();
    }
}
