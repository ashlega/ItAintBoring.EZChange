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

        private BaseChangePackage package = null;
        public BaseChangePackage Package
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
                    
                    ResetSolutions();
                    ResetTabs();
                    ReSetUI();
                }
                

            }
        }

        public void ResetActions()
        {
            lbPreActions.Items.Clear();
            lbPostActions.Items.Clear();

            foreach (var act in SelectedSolution.PreImportActions)
            {
                lbPreActions.Items.Add(act);
            }
            foreach (var act in SelectedSolution.PostImportActions)
            {
                lbPostActions.Items.Add(act);
            }
        }

        public void ResetSolutions()
        {
            if (Package == null) return;
            lbSolutions.Items.Clear();
            foreach (var s in Package.Solutions)
            {
                lbSolutions.Items.Add(s);
                
            }
            if (lbSolutions.Items.Count > 0)
            {
                lbSolutions.SelectedIndex = 0;
                ResetActions();
            }
        }

        public BaseSolution SelectedSolution {
            get
            {
                if (lbSolutions.SelectedItem != null)
                {
                    return (BaseSolution)lbSolutions.SelectedItem;
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
            ResetTabs();
        }

        public void ResetTabs()
        {
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

                    BaseChangePackage pkg = PackageFactory.CreatePackage((BaseChangePackage)selector.SelectedItem);
                    pkg.HasUnsavedChanges = false;
                    pkg.PackageLocation = "NewPackage.ecp";
                    ComponentControl ac = new ComponentControl();

                    pkg.Name = "New Change Package";
                    ac.Setup(pkg, "Package Properties");

                    if (ac.ShowDialog() == DialogResult.OK)
                    {
                        ac.UpdateComponent(pkg);
                    }
                    Package = pkg;
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
                BaseAction da = ActionFactory.CreateAction((BaseAction)selector.SelectedItem);
                ComponentControl ac = new ComponentControl();

                ac.Setup(da, "Action Properties");

                if (ac.ShowDialog() == DialogResult.OK)
                {
                    ac.UpdateComponent(da);
                    if (SelectedSolution != null)
                    {
                        if (preAction)
                        {
                            SelectedSolution.PreImportActions.Add(da);
                            lbPreActions.Items.Add(da);
                            Package.HasUnsavedChanges = true;
                        }
                        else
                        {
                            SelectedSolution.PostImportActions.Add(da);
                            lbPostActions.Items.Add(da);
                            Package.HasUnsavedChanges = true;
                        }
                    }
                }
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
                BaseSolution sln = SolutionFactory.CreateSolution((BaseSolution)selector.SelectedItem);

                ComponentControl ac = new ComponentControl();
                ac.Setup(sln, "Solution Properties");

                if (ac.ShowDialog() == DialogResult.OK)
                {
                    ac.UpdateComponent(sln);
                    Package.HasUnsavedChanges = true;
                    lbSolutions.Items.Add(sln);
                    lbSolutions.SelectedIndex = lbSolutions.Items.Count - 1;
                    ResetActions();
                }
            }
        }

        private void btnAddSolution_Click(object sender, EventArgs e)
        {
            NewSolution();
        }

        private void btnRemovePreAction_Click(object sender, EventArgs e)
        {
            SelectedSolution.PreImportActions.Remove((BaseAction)lbPreActions.SelectedItem);
            lbPreActions.Items.Remove(lbPreActions.SelectedItem);
            Package.HasUnsavedChanges = true;
            ReSetUI();
        }

        private void btnRemovePostAction_Click(object sender, EventArgs e)
        {
            SelectedSolution.PostImportActions.Remove((BaseAction)lbPostActions.SelectedItem);
            lbPostActions.Items.Remove(lbPostActions.SelectedItem);
            Package.HasUnsavedChanges = true;
            ReSetUI();
        }

        private void btnDeleteSolution_Click(object sender, EventArgs e)
        {
            Package.Solutions.Remove(SelectedSolution);
            lbSolutions.Items.Remove(SelectedSolution);
            lbPostActions.Items.Clear();
            lbPreActions.Items.Clear();
            Package.HasUnsavedChanges = true;
            ReSetUI();
        }

        private void lbPostActions_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReSetUI();
        }

        private void lbPreActions_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReSetUI();
        }

        private void EditSolution()
        {
            ComponentControl ac = new ComponentControl();
            ac.Setup(SelectedSolution, "Solution Properties");

            if (ac.ShowDialog() == DialogResult.OK)
            {
                ac.UpdateComponent(SelectedSolution);
                Package.HasUnsavedChanges = true;
            }
        }

        private void EditAction(BaseAction action)
        {
            ComponentControl ac = new ComponentControl();
            ac.Setup(action, "Action Properties");

            if (ac.ShowDialog() == DialogResult.OK)
            {
                ac.UpdateComponent(action);
                Package.HasUnsavedChanges = true;
            }
        }

        private void lbSolutions_DoubleClick(object sender, EventArgs e)
        {
            if (lbSolutions.SelectedItem == null) return;
            EditSolution();
            lbSolutions.Items[lbSolutions.SelectedIndex] = lbSolutions.Items[lbSolutions.SelectedIndex];
        }

        private void lbPreActions_DoubleClick(object sender, EventArgs e)
        {
            if (lbPreActions.SelectedItem == null) return;
            EditAction((BaseAction)lbPreActions.SelectedItem);
            lbPreActions.Items[lbPreActions.SelectedIndex] = lbPreActions.Items[lbPreActions.SelectedIndex];
        }

        private void lbPostActions_DoubleClick(object sender, EventArgs e)
        {
            if (lbPostActions.SelectedItem == null) return;
            EditAction((BaseAction)lbPostActions.SelectedItem);
            lbPostActions.Items[lbPostActions.SelectedIndex] = lbPostActions.Items[lbPostActions.SelectedIndex];
        }
    }
}
