using ItAintBoring.EZChange.Common.Packaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ItAintBoring.EZChange.Common
{
    public abstract class  BaseAction: BaseComponent, IChangeAction
    {
       // public virtual string XML { get; set; }

        virtual public void DoAction(BaseSolution solution)
        {

        }
        [XmlIgnore]
        public BaseSolution Solution { get; set; }

        [XmlIgnore]
        abstract public List<Type> SupportedSolutionTypes { get; }

        public void ActionStarted()
        {
            LogInfo("Starting action: " + this.Name);
        }

        public void ActionCompleted()
        {
            LogInfo("Action completed: " + this.Name);
        }

    }
}
