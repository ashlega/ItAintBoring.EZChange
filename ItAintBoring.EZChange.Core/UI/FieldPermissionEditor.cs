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
    public partial class FieldPermissionEditor : UserControl
    {
        IUIControlEnabled component = null;
        public FieldPermissionEditor()
        {
            InitializeComponent();
        }

        public FieldPermissionEditor(IUIControlEnabled component)
        {
            InitializeComponent();
            this.component = component;
        }


        public string ProfileName
        {
            get
            {
                return tbProfileName.Text;
            }
            set
            {
                tbProfileName.Text = value;
            }
        }

        public string EntityName
        {
            get
            {
                return tbEntityName.Text;
            }
            set
            {
                tbEntityName.Text = value;
            }
        }

        public string AttributeName
        {
            get
            {
                return tbAttributeName.Text;
            }
            set
            {
                tbAttributeName.Text = value;
            }
        }

        public bool CanRead
        {
            get
            {
                return cbCanRead.Checked;
            }
            set
            {
                cbCanRead.Checked = value;
            }
        }

        public bool CanUpdate
        {
            get
            {
                return cbCanUpdate.Checked;
            }
            set
            {
                cbCanUpdate.Checked = value;
            }
        }

        public bool CanCreate
        {
            get
            {
                return cbCanCreate.Checked;
            }
            set
            {
                cbCanCreate.Checked = value;
            }
        }

        private void tbProfileName_TextChanged(object sender, EventArgs e)
        {
            if (component != null) component.ApplyUIUpdates();
        }

        private void tbEntityName_TextChanged(object sender, EventArgs e)
        {
            if (component != null) component.ApplyUIUpdates();
        }

        private void tbAttributeName_TextChanged(object sender, EventArgs e)
        {
            if (component != null) component.ApplyUIUpdates();
        }

        private void cbCanUpdate_CheckedChanged(object sender, EventArgs e)
        {
            if (component != null) component.ApplyUIUpdates();
        }

        private void cbCanRead_CheckedChanged(object sender, EventArgs e)
        {
            if (component != null) component.ApplyUIUpdates();
        }

        private void cbCanCreate_CheckedChanged(object sender, EventArgs e)
        {
            if (component != null) component.ApplyUIUpdates();
        }
    }
}
