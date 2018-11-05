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

        public bool RunIndividualPackage(string folder, string targetEnvironment, string package)
        {
            BaseComponent.LogInfo(targetEnvironment + ":" + package);
            Hashtable variableValues = LoadVariables(folder, targetEnvironment);
            return RunIndividualPackage(System.IO.Path.Combine(folder, package), variableValues, null);
        }
        public bool RunIndividualPackage(string location, Hashtable variables, BaseAction selectedAction = null, string selectedActionId = null)
        {
            
            var storageProvider = StorageFactory.GetDefaultProvider(); 
            try
            {
                BaseComponent.Log.Info("Starting the package..");
                BaseChangePackage bcp = storageProvider.LoadPackage(location);
                /*
                if (variables == null)
                {
                    variables = new Hashtable();
                    foreach (var v in bcp.Variables)
                    {
                        variables[v.Name] = v.Value;
                    }
                }
                */
                bcp.UpdateRuntimeData(variables);
                BaseComponent.Log.Info("Package loaded: " + bcp.Name);
                
                if (selectedAction == null && selectedActionId != null)
                {
                    Guid actionId = Guid.Parse(selectedActionId);
                    foreach (var s in bcp.Solutions)
                    {
                        selectedAction = s.FindAction(actionId);
                        if (selectedAction != null) break;
                    }
                }
                bcp.Run(selectedAction);
            }
            catch (Exception ex)
            {
                BaseComponent.Log.Error(ex.Message);
                throw;
            }
            finally
            {
                BaseComponent.Log.Info("Done");
            }

            return true;
        }

        public void RunPackages(string folder, string targetEnvironment)
        {
            
            try
            {
                Hashtable variableValues = LoadVariables(folder, targetEnvironment);
                using (System.IO.StreamReader sr = new System.IO.StreamReader(System.IO.Path.Combine(folder, "orderedpackages.txt")))
                {
                    while (!sr.EndOfStream)
                    {
                        string packageName = sr.ReadLine().Trim();
                        /*
                            BaseComponent.LogInfo($"Starting process: \"{folder}\" \"{targetEnvironment}\" \"{packageName}\"");
                            var process = System.Diagnostics.Process.Start("ItAintBoring.EZChange.exe", $"\"{folder}\" \"{targetEnvironment}\" \"{pair[0]}\"");
                            process.WaitForExit();
                        */
                        if (!String.IsNullOrEmpty(packageName) && !packageName.StartsWith("#"))
                        {
                            RunIndividualPackage(System.IO.Path.Combine(folder, packageName), variableValues);
                        }
                    }
                }
                
            }
            catch(Exception ex)
            {
                BaseComponent.LogError(ex.Message);
            }
                                   
        }
    }
}
