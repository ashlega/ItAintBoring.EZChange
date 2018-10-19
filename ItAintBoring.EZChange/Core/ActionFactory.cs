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
    class ActionFactory
    {
        static List<IAction> actionList = null;

        static public List<IAction> GetActionList()
        {
            if (actionList == null)
            {
                actionList = new List<IAction>();

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
                                if (typeof(IAction).IsAssignableFrom(type))
                                {
                                    actionList.Add((IAction)Activator.CreateInstance(type));
                                }
                            }
                        }
                    }

                }
            }


            return actionList;
        }

        static public List<IAction> GetActionList(ISolution sln)
        {
            if (actionList == null)
            {
                GetActionList();
            }
            List<IAction> result = new List<IAction>();
            foreach (var x in actionList)
            {
                if (x.SupportedSolutionTypes.IndexOf(sln.GetType()) > -1) result.Add(x);
            }
            return result;
        }

        static public IAction CreateAction(IAction actionDesecription)
        {
            return (IAction)Activator.CreateInstance(actionDesecription.GetType());
        }
    }
}
