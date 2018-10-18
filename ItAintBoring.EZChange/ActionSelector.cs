using ItAintBoring.EZChange.Common;
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

namespace ItAintBoring.EZChange
{
    public partial class ActionSelector : Form
    {

        public IAction SelectedAction
        {
            get
            {
                if (lbActions.SelectedItem != null) return (IAction)lbActions.SelectedItem;
                else return null;
            }
        }
        public ActionSelector()
        {
            InitializeComponent();
            lbActions.Items.Clear();
            ActionFactory.GetActionList().ForEach(x => lbActions.Items.Add(x));
            EnableButtons();
        }

        private void EnableButtons()
        {
            btnOk.Enabled = lbActions.SelectedIndex > -1;
        }
        private void lbActions_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableButtons();
            
        }

        private void lbActions_DoubleClick(object sender, EventArgs e)
        {
            if(lbActions.SelectedItem != null)
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
