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
    public partial class ItemSelector : Form
    {

        public Object SelectedItem
        {
            get
            {
                if (lbItems.SelectedItem != null) return (Object)lbItems.SelectedItem;
                else return null;
            }
        }
        public ItemSelector()
        {
            InitializeComponent();
            
        }

        public void Initialize(List<object> itemList, string title)
        {
            Text = title;
            lbItems.Items.Clear();
            foreach(var x in itemList)
            {
                lbItems.Items.Add((BaseComponent)x);
            }
            
            EnableButtons();
        }

        private void EnableButtons()
        {
            btnOk.Enabled = lbItems.SelectedIndex > -1;
        }
        private void lbActions_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableButtons();
            
        }

        private void lbActions_DoubleClick(object sender, EventArgs e)
        {
            if(lbItems.SelectedItem != null)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        public DialogResult ShowIfMultiple()
        {
            if (lbItems.Items.Count == 1)
            {
                lbItems.SelectedIndex = 0;
                return DialogResult.OK;
            }
            else
            {
                return ShowDialog();
            }
           
        }

        private void ItemSelector_Shown(object sender, EventArgs e)
        {
            
        }
    }
}
