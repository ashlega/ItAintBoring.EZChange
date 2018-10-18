using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItAintBoring.EZChange.Common.Packaging
{
    public class WorkflowAction
    {
        public string Name { get; set; }
        public Guid WorkflowId { get; set; }
        public string TargetFetchXml { get; set; }

        public void DoAction()
        {

        }
    }
}
