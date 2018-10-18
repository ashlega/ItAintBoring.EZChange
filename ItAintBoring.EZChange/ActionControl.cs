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
    public partial class ActionControl : Form
    {
        public ActionControl()
        {
            InitializeComponent();
        }

        public void Setup(IAction action)
        {
            UseControl(action.UIControl);
            tbName.Text = action.Title;
            Text = action.Name;
        }

        public void UpdateAction(IAction action)
        {
            action.Title = tbName.Text;
        }

        public void UseControl(UserControl control)
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
