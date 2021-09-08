using GameSimulation.App.Components;
using Simulation.Core.Actions;
using Simulation.Core.Histograms;
using Simulation.Core.Processes;
using Simulation.Core.RandomGenerator;
using Simulation.Core.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.App.Simulations
{
    public class MultiGameSimulationProcess : SimProc
    {
        public static int PlayerCount = 10000;

        public List<Player> Players { get; set; } = new List<Player>();

        public RandomGenerator Random { get; set; } = new RandomGenerator();

        public SimpleStatistics Statistics { get; set; } = new SimpleStatistics();

        public Histogram ValueHistogram { get; set; } = new Histogram(0, 100, 20);

        protected override IEnumerator<ISimulationAction> Execute()
        {
            for (int i = 0; i < PlayerCount; i++)
            {
                var player = new Player { Value = 100 };
                Players.Add(player);
                player.Activate();
            }

            yield return Passivate();

            foreach(var player in Players)
            {
                Statistics.AddData(player.Value);
                ValueHistogram.AddData(player.Value);
            }
        }
    }
}
