using ItAintBoring.EZChange.Common.Packaging;
using ItAintBoring.EZChange.Common.Storage;
using ItAintBoring.EZChange.Core.Packaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ItAintBoring.EZChange.Core.Storage
{
    public class FileStorage : IPackageStorage
    {

        public List<Type> KnownTypes { get; set; }

        public string Name { get { return "File System"; } }

        public string Description { get { return "File System Storage"; } }

        public string Version { get { return "1.0.0.0"; } }

        public object PackageFactory { get; private set; }

        public BaseChangePackage LoadPackage()
        {
            BaseChangePackage result = null;
            using (var fd = new System.Windows.Forms.OpenFileDialog())
            {
                fd.DefaultExt = "ecp";
                fd.Filter = "EZChange Files (*.ecp)|*.ecp|All files (*.*)|*.*";
                fd.FilterIndex = 1;
                if(fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    XmlSerializer ser = new XmlSerializer(typeof(BaseChangePackage), KnownTypes.ToArray());
                    TextReader reader = new StreamReader(fd.FileName);
                    result = (BaseChangePackage)ser.Deserialize(reader);
                    reader.Close();
                }
            }
            return result;
        }

        public bool SavePackageAs(BaseChangePackage package)
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

        public void AddKnownTypes(List<Type> knownTypes)
        {
            KnownTypes = new List<Type>();
            KnownTypes.AddRange(knownTypes);
        }

        public bool SavePackage(BaseChangePackage package)
        {
            if (package == null) return true;
            
            XmlSerializer ser = new XmlSerializer(typeof(BaseChangePackage), KnownTypes.ToArray());
            TextWriter writer = new StreamWriter(package.PackageLocation);
            ser.Serialize(writer, package);
            writer.Close();
            package.HasUnsavedChanges = false;
            return true;
        }
    }
}
