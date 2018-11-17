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
    public partial class DynamicsSolutionEditor : UserControl, IUIControlEnabled
    {

        IUIControlEnabled component = null;
        public DynamicsSolutionEditor()
        {
            InitializeComponent();
            fsEditor.component = this;
        }

        public DynamicsSolutionEditor(IUIControlEnabled component)
        {
            InitializeComponent();
            this.component = component;
            fsEditor.component = this;
            fsEditor.AdjustSize();
        }

        public string SolutionName
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

        public string FileName
        {
            get
            {
                return fsEditor.FileName;
            }
            set
            {
                fsEditor.FileName = value;
            }
        }

        public UserControl UIControl { get { return fsEditor; } }

        public void ApplyUIUpdates()
        {
            if(component != null)  component.ApplyUIUpdates();
        }

        private void tbText_TextChanged(object sender, EventArgs e)
        {
            if (component != null) component.ApplyUIUpdates();
        }
    }
}
