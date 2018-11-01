using ItAintBoring.EZChange.Common.Packaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItAintBoring.EZChange.Common
{
    public interface IChangeAction
    {
        void DoAction(BaseSolution solution);
    }
}
