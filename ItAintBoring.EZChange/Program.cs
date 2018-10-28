using ItAintBoring.EZChange.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ItAintBoring.EZChange
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            var storageList = StorageFactory.GetStorageList();
            var storageProvider = storageList[0];
            List<Type> types = new List<Type>();
            foreach (var obj in PackageFactory.GetPackageList())
            {
                types.Add(obj.GetType());
            }
            foreach (var obj in SolutionFactory.GetSolutionList())
            {
                types.Add(obj.GetType());
            }
            foreach (var obj in ActionFactory.GetActionList())
            {
                types.Add(obj.GetType());
            }

            storageProvider.AddKnownTypes(types);
            MainForm.storageProvider = storageProvider;

            if (args.Length == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            else
            {
                PackageRunner pr = new PackageRunner();
                pr.RunPackages(args[0], args[1]);
            }
        }
    }
}
