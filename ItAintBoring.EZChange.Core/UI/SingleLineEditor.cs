using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ItAintBoring.EZChange.Core.UI
{
    public partial class SingleLineEditor : UserControl
    {
        public SingleLineEditor()
        {
            InitializeComponent();
        }

        public SingleLineEditor(string label)
        {
            SolutionName = label;
        }

        public string SolutionName
        {
            get
            {
                return lbName.Text;
            }
            set
            {
                lbName.Text = value;
            }
        }
    }
}
