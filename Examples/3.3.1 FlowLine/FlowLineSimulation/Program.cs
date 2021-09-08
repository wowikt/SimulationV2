using Simulation.Core.RandomGenerator;
using FlowLineSimulation.App.Simulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowLineSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создать генераторы случайных чисел
            FlowLineSimulationComponent.RandPiece = new RandomGenerator();
            FlowLineSimulationComponent.RandWorker1 = new RandomGenerator();
            FlowLineSimulationComponent.RandWorker2 = new RandomGenerator();

            // СОздать имитацию и запустить ее
            FlowLineSimulationComponent flSim = new FlowLineSimulationComponent();
            flSim.Start();

            // Вывести статистику
            Console.WriteLine(flSim.TimeInSystemStat);
            Console.WriteLine();
            Console.WriteLine(flSim.BalksStat);
            Console.WriteLine();
            Console.WriteLine(flSim.Worker1Stat);
            Console.WriteLine();
            Console.WriteLine(flSim.Worker2Stat);
            Console.WriteLine();
            Console.WriteLine(flSim.Queue1.Statistics());
            Console.WriteLine();
            Console.WriteLine(flSim.Queue2.Statistics());
            Console.WriteLine();
            Console.WriteLine(flSim.Calendar.Statistics());
            Console.WriteLine();
            Console.WriteLine(flSim.TimeHist);
            Console.ReadLine();
            // Удалить имитацию
            flSim.Finish();
        }
    }
}
