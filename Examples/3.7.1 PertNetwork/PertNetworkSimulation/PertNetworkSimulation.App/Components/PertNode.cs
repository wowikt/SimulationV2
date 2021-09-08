using Simulation.Core.Actions;
using Simulation.Core.Extensions;
using Simulation.Core.Histograms;
using Simulation.Core.Primitives;
using Simulation.Core.Processes;
using Simulation.Core.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PertNetworkSimulation.App.Components
{
    public class PertNode : Process
    {
        public SimulationList OutgoingArcs { get; set; } = new SimulationList();

        public int CompletedIncomeArcCount { get; set; }

        public int MinIncomeArcCount { get; set; }

        public bool IsFirstNode { get; set; }

        public bool IsLastNode { get; set; }

        public SimpleStatistics Statistics { get; set; }

        public Histogram Histogram { get; set; }

        protected override IEnumerator<ISimulationAction> Execute()
        {
            while (CompletedIncomeArcCount < MinIncomeArcCount)
            {
                yield return Passivate();
            }

            if (!IsFirstNode)
            {
                Statistics.AddData(SimTime());
                Histogram.AddData(SimTime());
            }

            if (IsLastNode)
            {
                Parent.Activate();
            }
            else
            {
                OutgoingArcs.ActivateAll();
            }
        }

        public override void Finish()
        {
            OutgoingArcs.Finish();
            base.Finish();
        }
    }
}
