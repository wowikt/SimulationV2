using LoadingSimulation.App.Simulation;
using Simulation.Core.RandomGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadingSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            LoadingSimulationComponent.RandomBulldozer = new RandomGenerator();
            LoadingSimulationComponent.RandomLoader = new RandomGenerator();
            LoadingSimulationComponent.RandomTruck = new RandomGenerator();

            LoadingSimulationComponent simulation = new LoadingSimulationComponent();
            simulation.Start();

            Console.WriteLine("Имитация завершена в {0}", simulation.SimTime());
            Console.WriteLine();

            for (int i = 0; i < simulation.LoadersStatistics.Length; i++)
            {
                Console.WriteLine(simulation.LoadersStatistics[i]);
                Console.WriteLine();
            }

            Console.WriteLine(simulation.HeapQueue.Statistics());
            Console.WriteLine();
            Console.WriteLine(simulation.TruckQueue.Statistics());
            Console.WriteLine();
            Console.WriteLine(simulation.LoaderQueue.Statistics());
            Console.WriteLine();
            Console.WriteLine(simulation.Calendar.Statistics());
            Console.ReadLine();

            // Завершить имитацию
            simulation.Finish();
        }
    }
}
