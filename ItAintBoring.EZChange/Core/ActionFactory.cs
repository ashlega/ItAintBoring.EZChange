using ItAintBoring.EZChange.Common;
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

        static public IAction CreateAction(IAction actionDesecription)
        {
            return (IAction)Activator.CreateInstance(actionDesecription.GetType());
        }
    }
}
