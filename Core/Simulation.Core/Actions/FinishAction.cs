using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulation.Core.Coroutines;
using Simulation.Core.Runners;

namespace Simulation.Core.Actions
{
    public class FinishAction : ISimulationAction
    {
        public FinishAction(Coroutine coroutine)
        {
            Coroutine = coroutine;
        }

        public Coroutine Coroutine { get; private set; }

        public Coroutine NextProc => null;

        public void ProcessAction()
        {
            GlobalRunner.SwitchTo(Coroutine.Owner);
        }
    }
}
