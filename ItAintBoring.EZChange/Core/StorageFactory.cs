using ItAintBoring.EZChange.Common.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;


namespace ItAintBoring.EZChange.Core
{
    public class StorageFactory
    {
        static List<IPackageStorage> storageList = null;

        static public List<IPackageStorage> GetStorageList()
        {
            if (storageList == null)
            {
                storageList = new List<IPackageStorage>();

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
                                if (typeof(IPackageStorage).IsAssignableFrom(type))
                                {
                                    storageList.Add((IPackageStorage)Activator.CreateInstance(type));
                                }
                            }
                        }
                    }

                }
            }

            
            return storageList;
        }

        static public IPackageStorage GetStorage(IPackageStorage storageDescription)
        {
            return storageDescription;
        }
    }
}
