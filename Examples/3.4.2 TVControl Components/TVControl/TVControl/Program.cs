using Simulation.Core.RandomGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVControl.App.Simulation;

namespace TVControl
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создать генераторы случайных чисел
            TvControlSimulationComponent.RandAdjuster = new RandomGenerator();
            TvControlSimulationComponent.RandInspector = new RandomGenerator();
            TvControlSimulationComponent.RandTVSet = new RandomGenerator();
            // Создать имитацию и запустить ее
            TvControlSimulationComponent tvc = new TvControlSimulationComponent();
            tvc.Start();
            // Вывести результаты
            Console.WriteLine("Имитация завершена в {0}", tvc.SimTime());
            Console.WriteLine();
            Console.WriteLine(tvc.TimeInSystemStat);
            Console.WriteLine();
            Console.WriteLine(tvc.InspectorsStat);
            Console.WriteLine();
            Console.WriteLine(tvc.AdjustmentStat);
            Console.WriteLine();
            Console.WriteLine(tvc.InspectionQueue.Statistics());
            Console.WriteLine();
            Console.WriteLine(tvc.AdjustmentQueue.Statistics());
            Console.WriteLine();
            Console.WriteLine(tvc.Calendar.Statistics());
            Console.ReadLine();
            // Завершить имитацию
            tvc.Finish();
        }
    }
}
