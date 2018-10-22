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
    public partial class SimpleEditor : UserControl
    {

        BaseComponent component = null;

        public SimpleEditor()
        {
            InitializeComponent();
        }

        public SimpleEditor(string label, bool multiLine, BaseComponent component)
        {
            InitializeComponent();
            this.component = component;
            lbName.Text = label;
            tbText.Multiline = multiLine;
        }

        public string SimpleText
        {
            get
            {
                return tbText.Text;
            }
            set
            {
                tbText.Text = value;
            }
        }

        private void tbText_TextChanged(object sender, EventArgs e)
        {
            if (component != null) component.ApplyUIUpdates();
        }
    }
}
