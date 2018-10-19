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
    public class SolutionFactory
    {
        static List<ISolution> solutionList = null;

        static public List<ISolution> GetSolutionList()
        {
            if (solutionList == null)
            {
                solutionList = new List<ISolution>();

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
                                if (typeof(ISolution).IsAssignableFrom(type))
                                {
                                    solutionList.Add((ISolution)Activator.CreateInstance(type));
                                }
                            }
                        }
                    }

                }
            }


            return solutionList;
        }


        static public List<ISolution> GetSolutionList(IChangePackage pkg)
        {
            if (solutionList == null)
            {
                GetSolutionList();
            }
            List<ISolution> result = new List<ISolution>();
            foreach (var x in solutionList)
            {
                if (x.SupportedPackageTypes.IndexOf(pkg.GetType()) > -1) result.Add(x);
            }
            return result;
        }

        static public ISolution CreateSolution(ISolution solutionDesecription)
        {
            return (ISolution)Activator.CreateInstance(solutionDesecription.GetType());
        }
    }
}
