using ItAintBoring.EZChange.Common;
using ItAintBoring.EZChange.Common.Packaging;
using ItAintBoring.EZChange.Common.Storage;
using ItAintBoring.EZChange.Core.Packaging;
using ItAintBoring.EZChange.Core;
using ItAintBoring.EZChange.Core.Actions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ItAintBoring.EZChange
{
    public partial class MainForm : Form
    {
        public IPackageStorage storageProvider = null;

        private IChangePackage package = null;
        public IChangePackage Package
        {
            get
            {
                return package;
            }
            set
            {
                if (package != value)
                {
                    package = value;
                    if (Package == null)
                    {
                        tcPackage.TabPages.Remove(tpSolutions);
                        tcPackage.TabPages.Remove(tpSource);
                        tcPackage.TabPages.Remove(tpLogo);
                        tcPackage.TabPages.Add(tpLogo);
                    }
                    else
                    {
                        tcPackage.TabPages.Remove(tpSolutions);
                        tcPackage.TabPages.Remove(tpSource);
                        tcPackage.TabPages.Remove(tpLogo);
                        tcPackage.TabPages.Add(tpSource);
                        tcPackage.TabPages.Add(tpSolutions);
                    }
                    ReSetUI();
                }
                

            }
        }

        public ISolution SelectedSolution {
            get
            {
                if (lbSolutions.SelectedItem != null)
                {
                    return (ISolution)lbSolutions.SelectedItem;
                }
                else return null;
            }
        }

        public object ProjectFactory { get; private set; }

        public MainForm()
        {
            InitializeComponent();

            var storageList = StorageFactory.GetStorageList();
            storageProvider = storageList[0];
            ReSetUI();
        }

        public void ReSetUI()
        {
            btnAddPostAction.Enabled = lbSolutions.SelectedItem != null;
            btnAddPreAction.Enabled = lbSolutions.SelectedItem != null;
            btnRemovePreAction.Enabled = lbPreActions.SelectedItem != null;
            btnRemovePostAction.Enabled = lbPostActions.SelectedItem != null;
            btnDeleteSolution.Enabled = lbSolutions.SelectedIndex > -1;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private bool SaveIfRequired()
        {
            if (Package == null) return true;

            bool result = true;
            if (Package.HasUnsavedChanges)
            {
                var confirmResult = MessageBox.Show("There are unsaved changes - do you want to save them now?", this.Text,
                                     MessageBoxButtons.YesNoCancel);
                if (confirmResult == DialogResult.Yes)
                {
                    storageProvider.SavePackage(Package);
                }
                else if (confirmResult == DialogResult.No)
                {
                    storageProvider.SavePackage(Package);
                }
                else result = false;
            }
            return result;
        }



        private void tbSaveProject_Click(object sender, EventArgs e)
        {
            storageProvider.SavePackage(Package);
            
        }

        private void tbOpenProject_Click(object sender, EventArgs e)
        {
            if (SaveIfRequired())
            {
                Package = storageProvider.LoadPackage();
            }
        }

        private void tbSaveAsProject_Click(object sender, EventArgs e)
        {
            storageProvider.SavePackageAs(Package);
        }

        private void NewPackage()
        {
            if (SaveIfRequired())
            {
                ItemSelector selector = new ItemSelector();
                selector.Initialize(PackageFactory.GetPackageList().ToList<object>(), "Package Type");
                if (selector.ShowIfMultiple() == DialogResult.OK && selector.SelectedItem != null)
                {

                    IChangePackage pkg = PackageFactory.CreatePackage((IChangePackage)selector.SelectedItem);
                    pkg.HasUnsavedChanges = false;
                    pkg.PackageLocation = "NewPackage.ecp";
                    ComponentControl ac = new ComponentControl();

                    if (pkg is INamedComponent)
                    {
                        ((INamedComponent)pkg).Name = "New Change Package";
                        ac.Setup((INamedComponent)pkg, "Package Properties");

                        if (ac.ShowDialog() == DialogResult.OK)
                        {
                            ac.UpdateComponent((INamedComponent)pkg);
                        }
                        Package = pkg;
                    }
                    else ShowError("This action does not support INamedComponent interface");
                }
            }
            
        }

        private void tbNew_Click(object sender, EventArgs e)
        {
            NewPackage();
            
        }

        private void tbExit_Click(object sender, EventArgs e)
        {
            if (SaveIfRequired())
            {
                Close();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lbSolutions_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReSetUI();
        }

        private void NewAction(bool preAction)
        {
            ItemSelector selector = new ItemSelector();
            selector.Initialize(ActionFactory.GetActionList(SelectedSolution).ToList<object>(), "Action Type");
            if (selector.ShowIfMultiple() == DialogResult.OK && selector.SelectedItem != null)
            {
                IAction da = ActionFactory.CreateAction((IAction)selector.SelectedItem);
                ComponentControl ac = new ComponentControl();

                if (da is INamedComponent)
                {
                    ac.Setup((INamedComponent)da, "Action Properties");

                    if (ac.ShowDialog() == DialogResult.OK)
                    {
                        ac.UpdateComponent((INamedComponent)da);
                        if (SelectedSolution != null)
                        {
                            if (preAction) SelectedSolution.PreImportActions.Add(da);
                            else SelectedSolution.PostImportActions.Add(da);
                        }
                    }
                }
                else ShowError("This action does not support INamedComponent interface");
            }
        }


        public void ShowError(string message)
        {
            MessageBox.Show(message, Text);
        }
        private void btnAddPreAction_Click(object sender, EventArgs e)
        {
            NewAction(true);
        }

        private void btnAddPostAction_Click(object sender, EventArgs e)
        {
            NewAction(false);
        }

        private void NewSolution()
        {
            ItemSelector selector = new ItemSelector();
            selector.Initialize(SolutionFactory.GetSolutionList(Package).ToList<object>(), "Solution Type");
            if (selector.ShowIfMultiple() == DialogResult.OK && selector.SelectedItem != null)
            {
                ISolution sln = SolutionFactory.CreateSolution((ISolution)selector.SelectedItem);
                if (sln is INamedComponent)
                {
                    ComponentControl ac = new ComponentControl();
                    ac.Setup((INamedComponent)sln, "Solution Properties");

                    if (ac.ShowDialog() == DialogResult.OK)
                    {
                        ac.UpdateComponent((INamedComponent)sln);
                        lbSolutions.Items.Add(sln);
                        lbSolutions.SelectedIndex = lbSolutions.Items.Count - 1;
                    }
                }
                else ShowError("This solution does not support INamedComponent interface");
            }
        }

        private void btnAddSolution_Click(object sender, EventArgs e)
        {
            NewSolution();
        }
    }
}
