using ItAintBoring.EZChange.Common.Storage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ItAintBoring.EZChange.Common.Packaging
{
    public abstract class BaseChangePackage : BaseComponent
    {
        private Hashtable runTimeVariables = null;
        [XmlIgnore]
        public Hashtable RunTimeVariables { get { return runTimeVariables; } }

        public string DefaultBuildVariableSet { get; set; }
        public string DefaultRunVariableSet { get; set; }

        public string PackageLocation { get; set; } //Storage specific
        public List<BaseSolution> Solutions { get; set; }
        /*
        private List<Variable> variables = null;
        public virtual List<Variable> Variables
        {
            get
            {
                if(variables == null) variables = new List<Variable>();
                return variables;
            }
        }
        */

        private bool hasUnsavedChanges = false;
        [XmlIgnore]
        virtual public bool HasUnsavedChanges
        {
            get
            {
                return hasUnsavedChanges;
            }
            set
            {
                hasUnsavedChanges = value;
            }
        }

        public BaseChangePackage(): base()
        {
            Solutions = new List<BaseSolution>();
            HasUnsavedChanges = false;
        }

        public override string GetDataFolder()
        {
            return System.IO.Path.Combine(System.IO.Path.GetFullPath(PackageLocation), "Solutions");
        }

        public virtual void Run(BaseAction selectedAction = null)
        {
            string zipFileName = GetDataFolder() + ".zip";
            if (System.IO.File.Exists(zipFileName))
            {
                ZipFile.ExtractToDirectory(GetDataFolder() + ".zip", GetDataFolder());
            }
            
            

            foreach (var s in Solutions)
            {
                s.Package = this;
                s.DeploySolution(this, selectedAction);
            }

            if (System.IO.File.Exists(zipFileName))
            {
                try
                {
                    System.IO.Directory.Delete(GetDataFolder(), true);
                }
                catch(Exception ex)
                {
                    //FIles might be locked
                }
            }
            
        }

        

        public virtual void Build(IPackageStorage storage)
        {
                
            System.IO.Directory.CreateDirectory(GetDataFolder());
            System.IO.Directory.Delete(GetDataFolder(), true);
            System.IO.Directory.CreateDirectory(GetDataFolder());
            System.Threading.Thread.Sleep(500);//The files don't disappear right away it seems
            storage.SavePackage(this);//, System.IO.Path.Combine(GetDataFolder(), Name + ".ecp"));
            foreach (var s in Solutions)
            {
                s.Package = this;
                s.PrepareSolution(this);
            }
            string zipFileName = GetDataFolder() + ".zip";
            if (System.IO.File.Exists(zipFileName))
            {
                System.IO.File.Delete(zipFileName);
            }
            ZipFile.CreateFromDirectory(GetDataFolder(), zipFileName);
            System.IO.Directory.Delete(GetDataFolder(), true);
        }

        public override void UpdateRuntimeData(Hashtable values)
        {
            runTimeVariables = values;
            foreach (var s in Solutions)
            {
                s.UpdateRuntimeData(values);
            }
        }

        public virtual void InitializeComponents()
        {
            foreach(var s in Solutions)
            {
                s.InitializeComponents();
            }
        }

        public virtual bool IsPackageDeployed()
        {
            return false;
        }

        public virtual void LogPackageDeployment()
        {
            
        }

        [XmlIgnore]
        public List<BaseAction> DeployActions
        {
            get
            {
                List<BaseAction> actions = new List<BaseAction>();
                foreach (var s in Solutions)
                {
                    actions.AddRange(s.DeployActions);
                }
                return actions;
            }
        }

        [XmlIgnore]
        public List<BaseAction> BuildActions {
            get
            {
                List<BaseAction> actions = new List<BaseAction>();
                foreach (var s in Solutions)
                {
                    actions.AddRange(s.BuildActions);
                }
                return actions;
            }
        }

        public virtual BaseAction FindAction(Guid actionId)
        {
            BaseAction result = null;
            
            foreach (var s in Solutions)
            {
                result = s.BuildActions.Find(a => a.ComponentId == actionId);

                if (result == null)
                {
                    result = s.DeployActions.Find(a => a.ComponentId == actionId);
                }
                if (result != null)
                {
                    result.Solution = s;//just in case
                    return result;
                }
            }

            return null;
        }




    }
}
