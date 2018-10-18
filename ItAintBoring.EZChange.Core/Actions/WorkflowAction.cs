using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ItAintBoring.EZChange.Common;

namespace ItAintBoring.EZChange.Core.Actions
{
    class WorkflowAction : IAction
    {
        public string XML { get; set; }
        public string Name { get { return "Run Workflow"; } }

        public string Description { get { return "Run Workflow"; } }

        public UserControl UIControl => throw new NotImplementedException();

        public void ApplyUIUpdates()
        {
            throw new NotImplementedException();
        }

        public void DoAction()
        {
            throw new NotImplementedException();
        }
    {
    }
}
