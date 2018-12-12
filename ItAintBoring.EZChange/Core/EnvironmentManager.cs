using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Collections;
using System.Xml.Linq;

namespace ItAintBoring.EZChange.Core
{
    public class EnvironmentManager
    {
        public static List<string> LoadVariableSets(string folder)
        {
            List<string> result = new List<string>();
            string varFile = System.IO.Path.Combine(folder, "variables.xml");
            if (System.IO.File.Exists(varFile))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(varFile);
                var variableSetNodes = doc.SelectNodes($"//variableSet");
                foreach (XmlNode v in variableSetNodes)
                {
                    result.Add(v.Attributes["name"].Value);
                }
            }
            return result;
        }

        public static Hashtable LoadVariables(string folder, string targetEnvironment)
        {
            Hashtable ht = new Hashtable();
            XmlDocument doc = new XmlDocument();
            doc.Load(System.IO.Path.Combine(folder, "variables.xml"));
            var variableNodes = doc.SelectNodes($"//variableSet[@name='{targetEnvironment}']/variable");
            foreach (XmlNode v in variableNodes)
            {
                ht.Add(v.Attributes["name"].Value, v.FirstChild.Value.Trim());
            }
            return ht;
        }

        static public List<EnvironmentSet> GetAllEnvironments(string folder)
        {
            List<EnvironmentSet> result = new List<EnvironmentSet>();
            var environments = LoadVariableSets(folder);
            foreach (var e in environments)
            {
                EnvironmentSet es = new EnvironmentSet();
                es.Name = e;
                result.Add(es);
                es.Variables = LoadVariables(folder, e);
            }
            return result;
        }

        static public void SaveAllEnvironments(string folder, List<EnvironmentSet> environments)
        {
            XDocument doc = new XDocument();
            var varSets = new XElement("variableSets");
            foreach (var e in environments)
            {
                var varSet = new XElement("variableSet");
                varSet.SetAttributeValue("name", e.Name);
                foreach(var v in e.Variables.Keys)
                {
                    var variable = new XElement("variable");
                    variable.SetAttributeValue("name", v);
                    variable.SetValue(e.Variables[v]);
                    varSet.Add(variable);
                }
                varSets.Add(varSet);
            }
            doc.Add(varSets);
            doc.Save(System.IO.Path.Combine(folder, "variables.xml"));
        }
    }
}
