using QuarrySimulation.App.Simulation;
using Simulation.Core.RandomGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuarrySimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            QuarrySimulationComponent.RandomTruck = new RandomGenerator();
            QuarrySimulationComponent.RandomMill = new RandomGenerator();

            QuarrySimulationComponent simulation = new QuarrySimulationComponent();
            simulation.Start();

            Console.WriteLine($"Имитация завершена в {simulation.SimTime()}");
            Console.WriteLine();

            foreach (var excavator in simulation.Excavators)
            {
                Console.WriteLine(excavator.ServiceStat);
                Console.WriteLine();
            }

            Console.WriteLine(simulation.Mill.ServiceStat);
            Console.WriteLine();
            Console.WriteLine(simulation.ReturnStatistics);
            Console.WriteLine();

            foreach (var excavator in simulation.Excavators)
            {
                Console.WriteLine(excavator.Queue.Statistics());
                Console.WriteLine();
            }

            Console.WriteLine(simulation.Mill.Queue.Statistics());
            Console.WriteLine();
            Console.WriteLine(simulation.Calendar.Statistics());
            Console.ReadLine();
            // Завершить имитацию
            simulation.Finish();

        }
    }
}
