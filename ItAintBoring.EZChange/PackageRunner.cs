using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItAintBoring.EZChange
{
    
    public class PackageRunner
    {
        public string FolderPath { get; set; }
        public string EnvironmentList { get; set; }
        public PackageRunner(string folder, string environmentList)
        {
            FolderPath = folder;
        }

        public void RunPackages(string targetEnvironment)
        {
            List<string> packages = new List<string>();
            using (System.IO.StreamReader sr = new System.IO.StreamReader(System.IO.Path.Combine(FolderPath, "orderedpackages.txt")))
            {
                while (!sr.EndOfStream)
                {
                    string data = sr.ReadLine();
                    packages.Add(data);
                }
            }
            int index = 0;
            while(index < packages.Count)
            {
                string[] pair = packages[index].Split('=');
                bool alreadyRun = false;
                 
                if (pair.Length > 1)
                {
                    string[] environments = pair[1].Split(',');
                    alreadyRun = (new List<string>(environments)).IndexOf(targetEnvironment) > 0;
                }
                if (!alreadyRun)
                {
                    break;
                }
                index++;
            }

            while (index < packages.Count)
            {

                //Run the packages from this on
                //Need to read configuration first (per environment)

                if (packages[index].IndexOf("=") > 0)
                {
                    if (packages[index].IndexOf(",") > 0) packages[index] = packages[index] + "," + targetEnvironment;
                    else packages[index] = packages[index] + targetEnvironment;
                }
                else packages[index] = packages[index] + "=" + targetEnvironment;

                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(System.IO.Path.Combine(FolderPath, "orderedpackages.txt")))
                {
                    foreach (var line in packages)
                    {
                        sw.WriteLine(line);
                    }

                }
            }
                                   
        }
    }
}
