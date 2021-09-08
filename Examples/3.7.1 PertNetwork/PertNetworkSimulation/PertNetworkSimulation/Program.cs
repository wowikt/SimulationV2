using PertNetworkSimulation.App;
using PertNetworkSimulation.App.Simulation;
using Simulation.Core.RandomGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PertNetworkSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            PertNetworkSimulationComponent.ArcRandom = new RandomGenerator();
            for (int i = 0; i < Parameters.RunCount; i++)
            {
                if (i % 5 == 0)
                {
                    Console.Write(".");
                }

                var simulation = new PertNetworkSimulationComponent();
                simulation.Start();
                simulation.Finish();
            }

            Console.WriteLine();

            for (int i = 1; i < Parameters.NodeCount; i++)
            {
                Console.WriteLine(PertNetworkSimulationComponent.NodeStatistics[i]);
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
