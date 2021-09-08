using ShopSimulation.App.Simulation;
using Simulation.Core.RandomGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создать генераторы случайных чисел
            ShopSimulationComponent.RandCust = new RandomGenerator();
            ShopSimulationComponent.RandService = new RandomGenerator();

            // Создать имитацию
            ShopSimulationComponent simulation = new ShopSimulationComponent();

            // Запустить ее
            simulation.Start();

            Console.WriteLine($"Имитация завершена в момент [{simulation.SimTime(),10:0.000}]");
            Console.WriteLine();
            Console.WriteLine(simulation.CashStat);
            Console.WriteLine();
            Console.WriteLine(simulation.TimeStat);
            Console.WriteLine();
            Console.WriteLine(simulation.InShopStat);
            Console.WriteLine();
            Console.WriteLine(simulation.Queue.Statistics());
            Console.WriteLine();
            Console.WriteLine(simulation.Calendar.Statistics());
            Console.WriteLine();
            Console.WriteLine(simulation.TimeHist);

            // Удалить имитацию
            simulation.Finish();
            Console.WriteLine("Готово");
            Console.ReadLine();
        }
    }
}
