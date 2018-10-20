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
        static List<BaseAction> actionList = null;

        static public List<BaseAction> GetActionList()
        {
            if (actionList == null)
            {
                actionList = new List<BaseAction>();

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
                                if (typeof(BaseAction).IsAssignableFrom(type))
                                {
                                    actionList.Add((BaseAction)Activator.CreateInstance(type));
                                }
                            }
                        }
                    }

                }
            }


            return actionList;
        }

        static public List<BaseAction> GetActionList(BaseSolution sln)
        {
            if (actionList == null)
            {
                GetActionList();
            }
            List<BaseAction> result = new List<BaseAction>();
            foreach (var x in actionList)
            {
                if (x.SupportedSolutionTypes.IndexOf(sln.GetType()) > -1) result.Add(x);
            }
            return result;
        }

        static public BaseAction CreateAction(BaseAction actionDesecription)
        {
            BaseAction result = (BaseAction)Activator.CreateInstance(actionDesecription.GetType());
            result.Name = actionDesecription.Id;
            return result;
        }
    }
}
