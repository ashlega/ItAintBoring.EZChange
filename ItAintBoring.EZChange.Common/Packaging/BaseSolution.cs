using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ItAintBoring.EZChange.Common.Packaging
{
    public abstract class BaseSolution: BaseComponent
    {
        public List<BaseAction> PreImportActions { get; set; }
        public List<BaseAction> PostImportActions { get; set; }

        public BaseSolution(): base()
        {
            
            PreImportActions = new List<BaseAction>();
            PostImportActions = new List<BaseAction>();

        }

        [XmlIgnore]
        abstract public List<Type> SupportedPackageTypes { get; }

        public abstract void PrepareSolution(BaseComponent package);
        

    }
}
