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

        public void Setup(INamedComponent component, string title)
        {
            Text = title;
            UseControl(component.UIControl);
            tbName.Text = component.Name;
        }

        public void UpdateComponent(INamedComponent component)
        {
            component.Name = tbName.Text;
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
    }
}
