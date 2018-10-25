using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ItAintBoring.EZChange.Common
{
    public abstract class BaseComponent
    {

        public Guid ComponentId { get; set; }

        public abstract string Version { get; }
        public virtual string Id { get; }
        public virtual string Description { get; }

        abstract public string Name { get; set; }

        public BaseComponent()
        {
            ComponentId = Guid.NewGuid();
        }

        [XmlIgnore]
        abstract public UserControl UIControl { get; }
        virtual public void ApplyUIUpdates() { }

        public override string ToString()
        {
            if (Name != null) return Name;
            else if (Id != null) return Id;
            else return base.ToString();
        }

        public virtual string GetDataFolder()
        {
            return ComponentId.ToString();
        }

        public string EscapeXml(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;
            return s.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;");
        }

        public string UnescapeXML(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;
            s = s.Replace("&apos;", "'");
            s = s.Replace("&quot;", "\"");
            s = s.Replace("&gt;", ">");
            s = s.Replace("&lt;", "<");
            s = s.Replace("&amp;", "&");
            return s;
        }
    }
}
