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
    public partial class ImportActionEditor : UserControl
    {

        IUIControlEnabled component = null;
        public ImportActionEditor()
        {
            InitializeComponent();
        }

        public ImportActionEditor(string fileName, bool createOnly, IUIControlEnabled component)
        {
            InitializeComponent();
            this.component = component;
            CreateOnly = createOnly;
            FileName = fileName;
        }

        private void cbCreateOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (component != null) component.ApplyUIUpdates();
        }


        public string FileName
        {
            get
            {
                return tbFileName.Text;
            }
            set
            {
                tbFileName.Text = value;
            }
        }

        public bool CreateOnly
        {
            get
            {
                return cbCreateOnly.Checked;
            }
            set
            {
                cbCreateOnly.Checked = value;
            }
        }

        private void tbFileName_TextChanged(object sender, EventArgs e)
        {
            if (component != null) component.ApplyUIUpdates();
        }
    }
}
