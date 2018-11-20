using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ItAintBoring.EZChange.Common;

namespace ItAintBoring.EZChange.Core.UI
{
    public partial class ActionSelectorEditor : UserControl
    {

        IUIControlEnabled component = null;

        bool disableUpdates = false;
        public ActionSelectorEditor()
        {
            InitializeComponent();
        }

        public ActionSelectorEditor(IUIControlEnabled component, List<BaseAction> actions, BaseAction selectedAction)
        {
            InitializeComponent();
            this.component = component;
            PopulateActions(actions);
            SelectedAction = selectedAction;
        }

        public void PopulateActions(List<BaseAction> actions)
        {
            cbAction.Items.Clear();
            if (actions == null) return;
            foreach(var a in actions)
            {
                cbAction.Items.Add(a);
            }
            cbAction.SelectedIndex = -1;
        }
        public void ShowCreateOnly(bool visible)
        {
            cbCreateOnly.Visible = visible;
        }

        public bool CreateOnly
        {
            get
            {
                return cbCreateOnly.Checked;
            }
            set
            {
                disableUpdates = true;
                cbCreateOnly.Checked = value;
                disableUpdates = false;
            }
        }
        public BaseAction SelectedAction
        {
            get
            {
                if (cbAction.SelectedItem == null) return null;
                else return (BaseAction)cbAction.SelectedItem;
            }
            set
            {
                if (value != null)
                {
                    foreach (var item in cbAction.Items)
                    {
                        var a = (BaseAction)item;
                        if (a.ComponentId == value.ComponentId)
                        {
                            disableUpdates = true;
                            cbAction.SelectedItem = item;
                            disableUpdates = false;
                            break;
                        }
                    }
                }
                else cbAction.SelectedItem = null;
            }
        }

        private void cbAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (disableUpdates) return;

            if (component != null) component.ApplyUIUpdates();
        }
    }
    
}
