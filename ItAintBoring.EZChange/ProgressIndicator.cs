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
    public partial class ProgressIndicator : Form
    {
        public ProgressIndicator()
        {
            InitializeComponent();
        }

        public void StartProgress()
        {
            pbMain.Value = 0;
            ShowDialog();
        }
    }
}
