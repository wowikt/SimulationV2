using Simulation.Core.Actions;
using Simulation.Core.Processes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PertNetworkSimulation.App.Components
{
    public class PertArc : Process
    {
        public PertNode EndNode { get; set; }

        public double ActionTime { get; set; }

        protected override IEnumerator<ISimulationAction> Execute()
        {
            yield return Hold(ActionTime);
            EndNode.CompletedIncomeArcCount++;
            EndNode.Activate();
        }
    }
}
