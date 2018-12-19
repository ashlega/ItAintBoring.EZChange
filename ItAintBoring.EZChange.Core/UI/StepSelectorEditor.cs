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
using ItAintBoring.EZChange.Core.Dynamics;

namespace ItAintBoring.EZChange.Core.UI
{
    public partial class StepSelectorEditor : UserControl
    {

        IUIControlEnabled component = null;

        bool disableUpdates = false;
        public StepSelectorEditor()
        {
            InitializeComponent();
        }

        public StepSelectorEditor(IUIControlEnabled component, bool activate, string selectedStep)
        {
            InitializeComponent();
            this.component = component;
            Activate = activate;
            SelectedStep = selectedStep;
        }

        public bool Activate
        {
            get
            {
                return cbActivate.Checked;
            }
            set
            {
                disableUpdates = true;
                cbActivate.Checked = value;
                disableUpdates = false;
            }
        }
        public string SelectedStep
        {
            get
            {
                return tbStepName.Text;
            }
            set
            {

                disableUpdates = true;
                tbStepName.Text = value;
                disableUpdates = false;

            }
        }

        private void cbActivate_CheckedChanged(object sender, EventArgs e)
        {
            if (disableUpdates) return;

            if (component != null) component.ApplyUIUpdates();
        }

        private void tbStepName_TextChanged(object sender, EventArgs e)
        {
            if (disableUpdates) return;

            if (component != null) component.ApplyUIUpdates();

        }
    }
    
}
