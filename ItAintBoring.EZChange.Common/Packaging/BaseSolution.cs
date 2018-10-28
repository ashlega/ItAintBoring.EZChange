using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ItAintBoring.EZChange.Common.Packaging
{
    public abstract class BaseSolution: BaseComponent
    {
        public List<BaseAction> BuildActions { get; set; }
        public List<BaseAction> DeployActions { get; set; }

        public BaseSolution(): base()
        {

            BuildActions = new List<BaseAction>();
            DeployActions = new List<BaseAction>();

        }

        [XmlIgnore]
        abstract public List<Type> SupportedPackageTypes { get; }

        public abstract void PrepareSolution(BaseComponent package);

        public virtual void SaveActionData(BaseAction action, string data)
        {

        }

        public virtual string LoadActionData(BaseAction action, string fileName)
        {
            return null;
        }
        public abstract void DeploySolution(BaseComponent package);

        public void ProcessingStarted()
        {
            LogInfo("Solution: " + this.Name);
        }

        public void ProcessingCompleted()
        {
            //No need to log
        }

        public override void UpdateRuntimeData(Hashtable values)
        {
            foreach (var a in BuildActions)
            {
                a.UpdateRuntimeData(values);
            }
            foreach (var a in DeployActions)
            {
                a.UpdateRuntimeData(values);
            }
        }
    }
}
