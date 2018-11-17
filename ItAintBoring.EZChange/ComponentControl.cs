using ItAintBoring.EZChange.Common;
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
    public partial class ComponentControl : Form
    {
        public ComponentControl()
        {
            InitializeComponent();
        }

        public void Setup(BaseComponent component, string title)
        {
            Text = title;
            UseControl(component.UIControl);
            tbName.Text = component.DisplayName;
            tbName.Focus();
        }

        public void UpdateComponent(BaseComponent component)
        {
            component.DisplayName = tbName.Text;
            component.ApplyUIUpdates();
        }

        public void UseControl(UserControl control)
        {
            if (control == null)
            {
                Height = Height - pnlControl.Height;
                Controls.Remove(pnlControl);
            }
            else
            {
                pnlControl.Controls.Clear();
                pnlControl.Controls.Add(control);
                control.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                control.Top = 0;
                control.Left = 1;
                control.Width = pnlControl.Width;
                control.Height = pnlControl.Height;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void ComponentControl_Shown(object sender, EventArgs e)
        {

        }
    }
}
