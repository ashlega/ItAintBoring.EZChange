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
    public partial class AddEnvironment : Form
    {
        public AddEnvironment()
        {
            InitializeComponent();
        }

        private void btnAddVar_Click(object sender, EventArgs e)
        {

        }

        public string Environment
        {
            get
            {
                return tbName.Text;
            }
        }
    }
}
