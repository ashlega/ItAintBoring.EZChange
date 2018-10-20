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
        static List<BaseSolution> solutionList = null;

        static public List<BaseSolution> GetSolutionList()
        {
            if (solutionList == null)
            {
                solutionList = new List<BaseSolution>();

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
                                if (typeof(BaseSolution).IsAssignableFrom(type))
                                {
                                    solutionList.Add((BaseSolution)Activator.CreateInstance(type));
                                }
                            }
                        }
                    }

                }
            }


            return solutionList;
        }


        static public List<BaseSolution> GetSolutionList(BaseChangePackage pkg)
        {
            if (solutionList == null)
            {
                GetSolutionList();
            }
            List<BaseSolution> result = new List<BaseSolution>();
            foreach (var x in solutionList)
            {
                if (x.SupportedPackageTypes.IndexOf(pkg.GetType()) > -1) result.Add(x);
            }
            return result;
        }

        static public BaseSolution CreateSolution(BaseSolution solutionDescription)
        {
            BaseSolution result = (BaseSolution)Activator.CreateInstance(solutionDescription.GetType());
            result.Name = solutionDescription.Id;
            return result;
        }
    }
}
