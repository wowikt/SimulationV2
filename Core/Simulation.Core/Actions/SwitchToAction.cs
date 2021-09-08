using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulation.Core.Coroutines;
using Simulation.Core.Runners;

namespace Simulation.Core.Actions
{
    public class SwitchToAction : ISimulationAction
    {
        public SwitchToAction(Coroutine coroutine, Coroutine nextCoroutine)
        {
            Coroutine = coroutine;
            NextCoroutine = nextCoroutine;
        }

        public Coroutine Coroutine { get; private set; }

        public Coroutine NextProc => NextCoroutine;

        private Coroutine NextCoroutine { get; set; }

        public void ProcessAction()
        {
            GlobalRunner.SwitchTo(NextCoroutine);
        }
    }
}
