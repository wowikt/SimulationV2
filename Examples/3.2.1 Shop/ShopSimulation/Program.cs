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
            ShopSimulationProcess.RandCust = new RandomGenerator();
            ShopSimulationProcess.RandService = new RandomGenerator();
            // Создать имитацию
            ShopSimulationProcess bs = new ShopSimulationProcess();
            // Запустить ее
            bs.Start();
            Console.WriteLine($"Имитация завершена в момент [{bs.SimTime(),10:0.000}]");
            Console.WriteLine();
            Console.WriteLine(bs.CashStat);
            Console.WriteLine();
            Console.WriteLine(bs.TimeStat);
            Console.WriteLine();
            Console.WriteLine(bs.InShopStat);
            Console.WriteLine();
            Console.WriteLine(bs.Queue.Statistics());
            Console.WriteLine();
            Console.WriteLine(bs.Calendar.Statistics());
            Console.WriteLine();
            Console.WriteLine(bs.TimeHist);
            // Удалить имитацию
            bs.Finish();
            Console.WriteLine("Готово");
            Console.ReadLine();
        }
    }
}
