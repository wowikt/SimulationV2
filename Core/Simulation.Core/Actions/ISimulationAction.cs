using Simulation.Core.Coroutines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Core.Actions
{
    public interface ISimulationAction
    {
        Coroutine Coroutine { get; }
        Coroutine NextProc { get; }
        void ProcessAction();
    }
}
