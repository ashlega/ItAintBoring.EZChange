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
    public partial class WorkflowActionEditor : UserControl
    {

        BaseComponent component = null;

        public WorkflowActionEditor()
        {
            InitializeComponent();
        }

        public WorkflowActionEditor(string workflowId, string fetchXml, BaseComponent component)
        {
            InitializeComponent();
            this.component = component;
            WorkflowId = workflowId;
            FetchXml = fetchXml;
        }
        public string WorkflowId
        {
            get
            {
                return tbWorkflowId.Text;
            }
            set
            {
                tbWorkflowId.Text = value;
            }
        }

        public string FetchXml
        {
            get
            {
                return tbFetchXml.Text;
            }
            set
            {
                tbFetchXml.Text = value;
            }
        }

        private void tbFetchXml_TextChanged(object sender, EventArgs e)
        {
            if (component != null) component.ApplyUIUpdates();
        }

        private void tbWorkflowId_TextChanged(object sender, EventArgs e)
        {
            if (component != null) component.ApplyUIUpdates();
        }
    }
}
