using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItAintBoring.EZChange.Common.Packaging
{
    public class Solution
    {
        public string Name { get; set; }

        public List<AttributeDeleteAction> AttributeActions;
        public List<EntityDeleteAction> EntityActions;
        public List<DataAction> DataActions;
    }
}
