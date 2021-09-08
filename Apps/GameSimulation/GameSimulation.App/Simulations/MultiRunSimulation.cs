using Simulation.Core.Histograms;
using Simulation.Core.RandomGenerator;
using Simulation.Core.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.App.Simulations
{
    public class MultiRunSimulation
    {
        public SimpleStatistics ValueStatistics { get; set; } = new SimpleStatistics();

        public Histogram ValueHistogram { get; set; } = new Histogram(0, 100, 20);

        private RandomGenerator _rnd = new RandomGenerator();

        public void Run(int runCount)
        {
            for (int i = 0; i < runCount; i++)
            {
                var simulation = new GameSimulationProcess();
                simulation.Random = _rnd;
                simulation.Start();
                ValueStatistics.AddData(simulation.Player.Value);
                ValueHistogram.AddData(simulation.Player.Value);
            }
        }
    }
}
