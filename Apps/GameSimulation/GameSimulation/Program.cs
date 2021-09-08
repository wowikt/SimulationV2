using GameSimulation.App.Simulations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            var sim = new MultiGameSimulationProcess();
            sim.Start();
            Console.WriteLine(sim.Statistics.ToString());
            Console.WriteLine();
            Console.WriteLine(sim.ValueHistogram.ToString());
            Console.WriteLine("Готово");
            Console.ReadLine();
        }
    }
}
