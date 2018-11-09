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
    public partial class TwoConnections : UserControl
    {
        BaseComponent component = null;

        public TwoConnections()
        {
            InitializeComponent();
        }


        public TwoConnections(BaseComponent component)
        {
            InitializeComponent();
            this.component = component;
        }

        public string Connection
        {
            get
            {
                return tbSource.Text;
            }
            set
            {
                tbSource.Text = value;
            }
        }

        
        private void tbSource_TextChanged(object sender, EventArgs e)
        {
            if (component != null) component.ApplyUIUpdates();
        }
    }
}
