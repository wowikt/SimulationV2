using FlowLineSimulation.App;
using FlowLineSimulation.App.Simulation;
using Simulation.Core.RandomGenerator;
using Simulation.Core.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowLineSimulation.MultiRun
{
    class Program
    {
        const int RunCount = 1000;

        static SimpleStatistics ServicedStatistics;

        static SimpleStatistics BalkedStatistics;

        static SimpleStatistics Worker1BusyStatistics;

        static SimpleStatistics Worker1BlockedStatistics;

        static SimpleStatistics Worker2BusyStatistics;

        static void Main(string[] args)
        {
            // Создать генераторы случайных чисел
            FlowLineSimulationComponent.RandPiece = new RandomGenerator();
            FlowLineSimulationComponent.RandWorker1 = new RandomGenerator();
            FlowLineSimulationComponent.RandWorker2 = new RandomGenerator();

            ServicedStatistics = new SimpleStatistics("Количество обслуженных изделий");
            BalkedStatistics = new SimpleStatistics("Количество отклоненных изделий");
            Worker1BusyStatistics = new SimpleStatistics("Занятость первого рабочего");
            Worker1BlockedStatistics = new SimpleStatistics("Блокировка первого рабочего");
            Worker2BusyStatistics = new SimpleStatistics("Занятость второго рабочего");

            for (int queue1length = 0; queue1length <= Params.TotalQueuesMaxSize; queue1length++)
            {
                ServicedStatistics.ClearStat();
                BalkedStatistics.ClearStat();
                Worker1BusyStatistics.ClearStat();
                Worker1BlockedStatistics.ClearStat();
                Worker2BusyStatistics.ClearStat();

                Params.Queue1MaxSize = queue1length;
                Params.Queue2MaxSize = Params.TotalQueuesMaxSize - queue1length;

                Console.WriteLine($"Прогоны с Queue1MaxSize = {Params.Queue1MaxSize}, Queue2MaxSize = {Params.Queue2MaxSize}:");
                for (int i = 0; i < RunCount; i++)
                {
                    FlowLineSimulationComponent simulation = new FlowLineSimulationComponent();
                    if (i % 10 == 0)
                    {
                        Console.Write(".");
                    }

                    simulation.Start();

                    ServicedStatistics.AddData(simulation.Worker2Stat.Finished);
                    BalkedStatistics.AddData(simulation.BalksStat.Count + 1);
                    Worker1BusyStatistics.AddData(simulation.Worker1Stat.Mean());
                    Worker1BlockedStatistics.AddData(simulation.Worker1Stat.MeanBlockage());
                    Worker2BusyStatistics.AddData(simulation.Worker2Stat.Mean());
                }

                Console.WriteLine();
                Console.WriteLine(ServicedStatistics);
                Console.WriteLine();
                Console.WriteLine(BalkedStatistics);
                Console.WriteLine();
                Console.WriteLine(Worker1BusyStatistics);
                Console.WriteLine();
                Console.WriteLine(Worker1BlockedStatistics);
                Console.WriteLine();
                Console.WriteLine(Worker2BusyStatistics);
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
