using ItAintBoring.EZChange.Common;
using ItAintBoring.EZChange.Common.Packaging;
using ItAintBoring.EZChange.Common.Storage;
using ItAintBoring.EZChange.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ItAintBoring.EZChange
{
    
    public class PackageRunner
    {


        public Hashtable LoadVariables(string folder, string targetEnvironment)
        {
            Hashtable ht = new Hashtable();
            XmlDocument doc = new XmlDocument();
            doc.Load(System.IO.Path.Combine(folder, "variables.xml"));
            var variableNodes = doc.SelectNodes($"//environment[@name='{targetEnvironment}']/variable");
            foreach (XmlNode v in variableNodes)
            {
                ht.Add(v.Attributes["name"].Value, v.FirstChild.Value.Trim());
            }
            return ht;
        }

        public void RunPackages(string folder, string targetEnvironment)
        {
            var storageList = StorageFactory.GetStorageList();
            var storageProvider = storageList[0];
            try
            {
                Hashtable variableValues = LoadVariables(folder, targetEnvironment);
                List<string> packages = new List<string>();
                using (System.IO.StreamReader sr = new System.IO.StreamReader(System.IO.Path.Combine(folder, "orderedpackages.txt")))
                {
                    while (!sr.EndOfStream)
                    {
                        string data = sr.ReadLine();
                        packages.Add(data);
                    }
                }
                int index = 0;
                while (index < packages.Count)
                {
                    string[] pair = packages[index].Split('=');
                    bool alreadyRun = false;

                    if (pair.Length > 1)
                    {
                        string[] environments = pair[1].Split(',');
                        alreadyRun = (new List<string>(environments)).IndexOf(targetEnvironment) >= 0;
                    }
                    if (!alreadyRun)
                    {
                        break;
                    }
                    index++;
                }

                while (index < packages.Count)
                {
                    string[] pair = packages[index].Split('=');
                    BaseComponent.LogInfo("Importing package: " + pair[0]);
                    BaseChangePackage bcp = storageProvider.LoadPackage(System.IO.Path.Combine(folder, pair[0]));
                    /*
                    foreach(var v in bcp.Variables)
                    {
                        if(variableValues.ContainsKey(v.Name))
                        {
                            v.Value = (string)variableValues[v.Name];
                        }
                    }
                    */
                    bcp.UpdateRuntimeData(variableValues);
                    bcp.Run();

                    if (packages[index].IndexOf("=") > 0)
                    {
                        //if (packages[index].IndexOf("=") > 0) packages[index] = packages[index] + "," + targetEnvironment;
                        //else
                        packages[index] = packages[index] + "," + targetEnvironment;
                    }
                    else packages[index] = packages[index] + "=" + targetEnvironment;

                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(System.IO.Path.Combine(folder, "orderedpackages.txt")))
                    {
                        foreach (var line in packages)
                        {
                            sw.WriteLine(line);
                        }

                    }
                    index++;
                }
            }
            catch(Exception ex)
            {
                BaseComponent.LogError(ex.Message);
            }
                                   
        }
    }
}
