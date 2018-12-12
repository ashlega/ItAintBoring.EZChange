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
    public partial class VariableEditor : Form
    {
        public VariableEditor()
        {
            InitializeComponent();
        }

        public VariableEditor(string name, string value)
        {
            InitializeComponent();
            VariableName = name;
            DefaultValue = value;
        }

        public string VariableName
        {
            get
            {
                return tbName.Text;
            }
            set
            {
                tbName.Text = value;
            }
        }

        public string DefaultValue
        {
            get
            {
                return tbDefaultValue.Text;
            }
            set
            {
                tbDefaultValue.Text = value;
            }
        }
    }
}
