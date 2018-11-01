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
    public partial class FileSelectorEditor : UserControl
    {
        BaseComponent component = null;
        public FileSelectorEditor()
        {
            InitializeComponent();
        }

        public FileSelectorEditor(BaseComponent component)
        {
            InitializeComponent();
            this.component = component;
        }

        public string FileName
        {
            get
            {
                return tbFile.Text;
            }
            set
            {
                tbFile.Text = value;
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            using (var fd = new System.Windows.Forms.OpenFileDialog())
            {
                fd.DefaultExt = "*";
                fd.Filter = "All files (*.*)|*.*";
                fd.FilterIndex = 1;
                if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    FileName = fd.FileName;
                }
                
            }
        }

        private void tbFile_TextChanged(object sender, EventArgs e)
        {
            if (component != null) component.ApplyUIUpdates();
        }
    }
    
}
