using ItAintBoring.EZChange.Common;
using ItAintBoring.EZChange.Common.Packaging;
using ItAintBoring.EZChange.Common.Storage;
using ItAintBoring.EZChange.Core;
using System;
using System.Collections;
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

        

        public static IPackageStorage storageProvider = null;

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
                    bool hasChanges = value != null && value.HasUnsavedChanges;
                    package = value;
                    
                    tbPackageName.Text = package.Name;
                    ShowPackageControl();
                    ResetSolutions();
                    ResetVariables();
                    ResetTabs();
                    ReSetUI();

                    Package.HasUnsavedChanges = hasChanges;
                }
                

            }
        }

        public void ResetActions()
        {
            if (SelectedSolution == null) return;
            lbPreActions.Items.Clear();
            lbPostActions.Items.Clear();

            foreach (var act in SelectedSolution.BuildActions)
            {
                lbPreActions.Items.Add(act);
            }
            foreach (var act in SelectedSolution.DeployActions)
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

        public void ResetVariables()
        {
            if (Package == null) return;
            lbVariables.Items.Clear();
            foreach (var v in Package.Variables)
            {
                lbVariables.Items.Add(v);

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

            Font = SystemFonts.MessageBoxFont;
            InitializeComponent();

            

            

            //tcPackage.Height = Height - tcPackage.Top - 20;
            lbVariables.Height = btnAddVar.Top - 10 - labelVariables.Top - labelVariables.Height;

            ResetTabs();


            System.Net.ServicePointManager
                .ServerCertificateValidationCallback +=
                (sender, cert, chain, sslPolicyErrors) => true;


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
                lbSolutions.Height = btnAddSolution.Top - 10;
                lbPreActions.Height = btnAddPreAction.Top - 10;
                lbPostActions.Height = btnAddPostAction.Top - 10;
            }
        }

        public void ReSetUI()
        {
            btnAddPostAction.Enabled = lbSolutions.SelectedItem != null;
            btnAddPreAction.Enabled = lbSolutions.SelectedItem != null;
            btnRemovePreAction.Enabled = lbPreActions.SelectedItem != null;
            btnRemovePostAction.Enabled = lbPostActions.SelectedItem != null;
            btnDeleteSolution.Enabled = lbSolutions.SelectedIndex > -1;
            btnRemoveVar.Enabled = lbVariables.SelectedIndex > -1;
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
                    ComponentControl ac = new ComponentControl();

                    pkg.Name = "New Change Package";
                    ac.Setup(pkg, "Package Properties");

                    if (ac.ShowDialog() == DialogResult.OK)
                    {
                        ac.UpdateComponent(pkg);
                        Package = pkg;
                    }
                    
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
            ResetActions();
        }

        private void NewAction(bool preAction)
        {
            ItemSelector selector = new ItemSelector();
            selector.Initialize(ActionFactory.GetActionList(SelectedSolution).ToList<object>(), "Action Type");
            if (selector.ShowIfMultiple() == DialogResult.OK && selector.SelectedItem != null)
            {
                BaseAction da = ActionFactory.CreateAction((BaseAction)selector.SelectedItem);
                ComponentControl ac = new ComponentControl();

                ac.Setup(da, da.Id + " - Properties");

                if (ac.ShowDialog() == DialogResult.OK)
                {
                    ac.UpdateComponent(da);
                    if (SelectedSolution != null)
                    {
                        if (preAction)
                        {
                            SelectedSolution.BuildActions.Add(da);
                            lbPreActions.Items.Add(da);
                            Package.HasUnsavedChanges = true;
                        }
                        else
                        {
                            SelectedSolution.DeployActions.Add(da);
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

        public void ShowMessage(string message)
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
                    Package.Solutions.Add(sln);
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
            SelectedSolution.BuildActions.Remove((BaseAction)lbPreActions.SelectedItem);
            lbPreActions.Items.Remove(lbPreActions.SelectedItem);
            Package.HasUnsavedChanges = true;
            ReSetUI();
        }

        private void btnRemovePostAction_Click(object sender, EventArgs e)
        {
            SelectedSolution.DeployActions.Remove((BaseAction)lbPostActions.SelectedItem);
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
            ac.Setup(action, action.Id + " - Properties");

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

        private void tbPackageName_TextChanged(object sender, EventArgs e)
        {
            package.Name = tbPackageName.Text;
            package.HasUnsavedChanges = true;
        }

        public void ShowPackageControl()
        {
            if (Package == null && Package.UIControl == null)
            {
                pnlPackageControl.Controls.Clear();
            }
            else
            {
                //pnlPackageControl.Controls.Clear();
                
                
                Package.UIControl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                Package.UIControl.Parent = pnlPackageControl;
                //pnlPackageControl.Controls.Add(Package.UIControl);
            }
        }


        private object dragItem = null;

        private void lbSolutions_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && lbSolutions.SelectedItem != null && e.Clicks == 1)
            {
                Task.Delay(700).ContinueWith(
                t =>
                {
                    if (Control.MouseButtons == MouseButtons.Left)
                    {
                        dragItem = lbSolutions.SelectedItem;
                        lbSolutions.DoDragDrop(lbSolutions.SelectedItem, DragDropEffects.Move);
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext()
                );
               
            }
        }

        private void lbSolutions_DragOver(object sender, DragEventArgs e)
        {
            if (dragItem is BaseSolution)
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void lbSolutions_DragDrop(object sender, DragEventArgs e)
        {
            Point point = lbSolutions.PointToClient(new Point(e.X, e.Y));
            int index = lbSolutions.IndexFromPoint(point);
            if (index < 0) index = lbSolutions.Items.Count - 1;
            lbSolutions.Items.Remove(dragItem);
            lbSolutions.Items.Insert(index, dragItem);
            Package.Solutions.Clear();
            foreach(var item in lbSolutions.Items)
            {
                Package.Solutions.Add((BaseSolution)item);
            }
            lbSolutions.SelectedIndex = index;
            Package.HasUnsavedChanges = true;
        }

        private void lbPreActions_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && lbPreActions.SelectedItem != null && e.Clicks == 1)
            {
                Task.Delay(700).ContinueWith(
                t =>
                {
                    if (Control.MouseButtons == MouseButtons.Left)
                    {
                        dragItem = lbPreActions.SelectedItem;
                        lbPreActions.DoDragDrop(lbPreActions.SelectedItem, DragDropEffects.Move);
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext()
                );

            }

            
        }

        private void lbPreActions_DragOver(object sender, DragEventArgs e)
        {
            if (lbPreActions.Items.IndexOf(dragItem) > -1)
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void lbPreActions_DragDrop(object sender, DragEventArgs e)
        {
            Point point = lbPreActions.PointToClient(new Point(e.X, e.Y));
            int index = lbPreActions.IndexFromPoint(point);
            if (index < 0) index = lbPreActions.Items.Count - 1;
            lbPreActions.Items.Remove(dragItem);
            lbPreActions.Items.Insert(index, dragItem);
            SelectedSolution.BuildActions.Clear();
            foreach (var item in lbPreActions.Items)
            {
                SelectedSolution.DeployActions.Add((BaseAction)item);
            }
            lbPreActions.SelectedIndex = index;
            Package.HasUnsavedChanges = true;
        }

        private void lbPostActions_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left && lbPostActions.SelectedItem != null && e.Clicks == 1)
            {
                Task.Delay(700).ContinueWith(
                t =>
                {
                    if (Control.MouseButtons == MouseButtons.Left)
                    {
                        dragItem = lbPostActions.SelectedItem;
                        lbPostActions.DoDragDrop(lbPostActions.SelectedItem, DragDropEffects.Move);
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext()
                );

            }


            
        }

        private void lbPostActions_DragOver(object sender, DragEventArgs e)
        {
            if(lbPostActions.Items.IndexOf(dragItem) > -1)
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void lbPostActions_DragDrop(object sender, DragEventArgs e)
        {
            Point point = lbPostActions.PointToClient(new Point(e.X, e.Y));
            int index = lbPostActions.IndexFromPoint(point);
            if (index < 0) index = lbPostActions.Items.Count - 1;
            lbPostActions.Items.Remove(dragItem);
            lbPostActions.Items.Insert(index, dragItem);
            SelectedSolution.DeployActions.Clear();
            foreach (var item in lbPostActions.Items)
            {
                SelectedSolution.DeployActions.Add((BaseAction)item);
            }
            lbPostActions.SelectedIndex = index;
            Package.HasUnsavedChanges = true;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !SaveIfRequired();
        }

        private bool BuildPackage()
        {
            try
            {
                BaseComponent.Log.Info("Starting the build..");
                Package.Build(storageProvider);

            }
            catch (Exception ex)
            {
                BaseComponent.Log.Error(ex.Message);
                ShowError(ex.Message);
                return false;
            }
            finally
            {
                BaseComponent.Log.Info("Done");
            }
            return true;
        }
        private void tbPreparePackage_Click(object sender, EventArgs e)
        {

            if(BuildPackage())
            {
                ShowMessage("Success");
            }

        }

        public bool RunPackage(string location)
        {
            try
            {

                BaseComponent.Log.Info("Starting the package..");
                BaseChangePackage bcp = storageProvider.LoadPackage(location);
                Hashtable variables = new Hashtable();
                foreach(var v in bcp.Variables)
                {
                    variables[v.Name] = v.Value;
                }

                bcp.UpdateRuntimeData(variables);
                BaseComponent.Log.Info("Package loaded: " + bcp.Name);
                bcp.Run();
            }
            catch(Exception ex)
            {
                BaseComponent.Log.Error(ex.Message);
                ShowError(ex.Message);
                return false;
            }
            finally
            {
                BaseComponent.Log.Info("Done");
            }

            return true;
        }

        private void tbRunPackage_Click(object sender, EventArgs e)
        {
            if(RunPackage(Package.PackageLocation))
            {
                ShowMessage("Success");
            }
        }

        private void preparePackageToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About abt = new About();
            abt.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnRemoveVar_Click(object sender, EventArgs e)
        {
            if(lbVariables.SelectedIndex > -1)
            {
                Package.Variables.Remove((Variable)lbVariables.SelectedItem);
                lbVariables.Items.Remove(lbVariables.SelectedItem);
                ResetVariables();
                ReSetUI();
                Package.HasUnsavedChanges = true;
            }
        }

        private void btnAddVar_Click(object sender, EventArgs e)
        {
            VariableEditor ve = new VariableEditor();
            if(ve.ShowDialog() == DialogResult.OK)
            {
                Variable vr = new Variable();
                vr.Name = ve.VariableName;
                vr.Value = ve.DefaultValue;
                Package.Variables.Add(vr);
                lbVariables.Items.Add(vr);
                ResetVariables();
                ReSetUI();
                Package.HasUnsavedChanges = true;
            }
        }

        private void lbVariables_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReSetUI();
        }

        private void lbVariables_DoubleClick(object sender, EventArgs e)
        {
            if (lbVariables.SelectedItem != null)
            {
                Variable vr = (Variable)lbVariables.SelectedItem;
                VariableEditor ve = new VariableEditor(vr.Name, vr.Value);
                if (ve.ShowDialog() == DialogResult.OK)
                {
                    vr.Name = ve.VariableName;
                    vr.Value = ve.DefaultValue;
                    var ind = lbVariables.Items.IndexOf(vr);
                    lbVariables.Items.Remove(vr);
                    lbVariables.Items.Insert(ind, vr);
                    Package.HasUnsavedChanges = true;
                }
            }
        }

        private void pnlPackageControl_Resize(object sender, EventArgs e)
        {
            if (Package != null && Package.UIControl != null)
            {
                Package.UIControl.Top = 5;
                Package.UIControl.Left = 5;
                Package.UIControl.Width = pnlPackageControl.Width - 10;
                Package.UIControl.Height = pnlPackageControl.Height - 10;
            }
        }
    }
}
