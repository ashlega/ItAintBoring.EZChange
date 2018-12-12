using ItAintBoring.EZChange.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ItAintBoring.EZChange.Dialogs
{
    public partial class Variables : Form
    {

        bool updated = false;
        string folder = null;

        public Variables(string folder)
        {
            InitializeComponent();
            this.folder = folder;
            var environments = EnvironmentManager.GetAllEnvironments(folder);
            cbVariableSet.Items.AddRange(environments.ToArray());
        }

        public void RefreshVariablesList()
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            AddEnvironment ae = new AddEnvironment();
            if(ae.ShowDialog() == DialogResult.OK)
            {
                EnvironmentSet es = new EnvironmentSet();
                es.Name = ae.Environment;
                es.Variables = new System.Collections.Hashtable();
                cbVariableSet.Items.Insert(0, es);
                cbVariableSet.SelectedIndex = 0;
                updated = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Do you want to delete this environment?", this.Text,
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                cbVariableSet.Items.Remove(cbVariableSet.SelectedItem);
                updated = true;
                if (cbVariableSet.Items.Count > 0)
                {
                    cbVariableSet.SelectedIndex = 0;
                }
                else
                {
                    lbVariables.Items.Clear();
                    ResetButtons();
                }
            }
        }

        public void ResetButtons()
        {
            btnDelete.Enabled = cbVariableSet.SelectedIndex > -1;
            btnDeleteVariable.Enabled = lbVariables.SelectedItem != null;
            btnAddVariable.Enabled = cbVariableSet.SelectedItem != null;
        }

        private void RefreshLbVariables()
        {
            lbVariables.Items.Clear();
            EnvironmentSet es = (EnvironmentSet)cbVariableSet.SelectedItem;
            foreach (var v in es.Variables.Keys)
            {
                lbVariables.Items.Add(v);
            }
            if (lbVariables.Items.Count > 0) lbVariables.SelectedIndex = 0;
            ResetButtons();
        }

        private void cbVariableSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbVariables.Items.Clear();
            if(cbVariableSet.SelectedItem != null)
            {
                RefreshLbVariables();
            }
        }

        private void btnDeleteVariable_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Do you want to delete this variable?", this.Text,
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                var env = (EnvironmentSet)cbVariableSet.SelectedItem;
                env.Variables.Remove((string)lbVariables.SelectedItem);
                lbVariables.Items.Remove(lbVariables.SelectedItem);
                updated = true;
                if (lbVariables.Items.Count > 0)
                {
                    lbVariables.SelectedIndex = 0;
                }
                else ResetButtons();
            }
        }

        private void lbVariables_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetButtons();
        }

        private void lbVariables_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var env = (EnvironmentSet)cbVariableSet.SelectedItem;
            string varName = (string)lbVariables.SelectedItem;
            VariableEditor ve = new VariableEditor(varName, (string)env.Variables[varName]); 
            if(ve.ShowDialog() == DialogResult.OK)
            {
                env.Variables.Remove(varName);
                env.Variables[ve.VariableName] = ve.DefaultValue;
                updated = true;
                RefreshLbVariables();
            }
        }

        private void btnAddVariable_Click(object sender, EventArgs e)
        {
            var env = (EnvironmentSet)cbVariableSet.SelectedItem;
            VariableEditor ve = new VariableEditor("", "");
            if (ve.ShowDialog() == DialogResult.OK)
            {
                env.Variables[ve.VariableName] = ve.DefaultValue;
                updated = true;
                RefreshLbVariables();
            }
        }

        private void SaveEnvironments()
        {
            List<EnvironmentSet> environments = new List<EnvironmentSet>();
            foreach (EnvironmentSet es in cbVariableSet.Items)
            {
                environments.Add(es);
            }

            EnvironmentManager.SaveAllEnvironments(folder, environments);
            updated = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SaveEnvironments();
        }

        private void Variables_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (updated)
            {
                var confirmResult = MessageBox.Show("There are unsaved changes - do you want to save them now?", this.Text,
                                     MessageBoxButtons.YesNoCancel);
                if (confirmResult == DialogResult.Yes)
                {
                    SaveEnvironments();

                    DialogResult = DialogResult.OK;
                }
                else if(confirmResult == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
            
        }
    }
}
