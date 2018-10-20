using ItAintBoring.EZChange.Common;
using ItAintBoring.EZChange.Common.Packaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ItAintBoring.EZChange.Core
{
    public class PackageFactory
    {
        static List<BaseChangePackage> packageList = null;

        static public List<BaseChangePackage> GetPackageList()
        {
            if (packageList == null)
            {
                packageList = new List<BaseChangePackage>();

                string[] subFolders = { "Core", "Extensions" };

                foreach (var sf in subFolders)
                {
                    string fullPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, sf);
                    if (Directory.Exists(fullPath))
                    {
                        var dlls = Directory.GetFiles(fullPath, "*.dll");
                        foreach (string file in dlls)
                        {
                            var DLL = Assembly.LoadFile(file);
                            foreach (Type type in DLL.GetExportedTypes())
                            {
                                if (typeof(BaseChangePackage).IsAssignableFrom(type))
                                {
                                    packageList.Add((BaseChangePackage)Activator.CreateInstance(type));
                                }
                            }
                        }
                    }

                }
            }


            return packageList;
        }

        static public BaseChangePackage CreatePackage(BaseChangePackage packageDesecription)
        {
            return (BaseChangePackage)Activator.CreateInstance(packageDesecription.GetType());
        }
    }
}
