using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulation.Core.Coroutines;

namespace Simulation.Core.Actions
{
    public class ContinueAction : ISimulationAction
    {
        public Coroutine Coroutine { get; private set; }

        public Coroutine NextProc { get; private set; }

        public ContinueAction(Coroutine coroutine)
        {
            Coroutine = NextProc = coroutine;
        }

        public void ProcessAction()
        {
        }
    }
}
