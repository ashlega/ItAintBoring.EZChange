using ItAintBoring.EZChange.Common.Packaging;
using ItAintBoring.EZChange.Common.Storage;
using ItAintBoring.EZChange.Core.Packaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItAintBoring.EZChange.Core.Storage
{
    public class FileStorage : IPackageStorage
    {
        public string Name { get { return "File System"; } }

        public string Description { get { return "File System Storage"; } }

        public string Version { get { return "1.0.0.0"; } }

        public IChangePackage LoadPackage()
        {
            DynamicsChangePackage result = null;
            using (var fd = new System.Windows.Forms.OpenFileDialog())
            {
                fd.DefaultExt = "ecp";
                fd.Filter = "EZChange Files (*.ecp)|*.ecp|All files (*.*)|*.*";
                fd.FilterIndex = 1;
                if(fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    result = new DynamicsChangePackage();
                    result.HasUnsavedChanges = false;
                    result.PackageLocation = fd.FileName;
                }
            }
            return result;
        }

        public bool SavePackageAs(IChangePackage package)
        {
            if (package == null) return true;
            using (var fd = new System.Windows.Forms.SaveFileDialog())
            {
                fd.DefaultExt = "ecp";
                fd.Filter = "EZChange Files (*.ecp)|*.ecp|All files (*.*)|*.*";
                fd.FilterIndex = 1;
                if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    package.PackageLocation = fd.FileName;
                    SavePackage(package);
                    return true;
                }
                else return false;
            }

        }

        public bool SavePackage(IChangePackage package)
        {
            if (package == null) return true;
            return true;
        }
    }
}
