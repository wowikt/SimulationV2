using LoadingSimulation.App.Components;
using LoadingSimulation.App.Services;
using Simulation.Core.Components;
using Simulation.Core.Primitives;
using Simulation.Core.RandomGenerator;
using Simulation.Core.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadingSimulation.App.Simulation
{
    public class LoadingSimulationComponent : SimComponent
    {
        public static RandomGenerator RandomBulldozer { get; set; }

        public static RandomGenerator RandomLoader { get; set; }

        public static RandomGenerator RandomTruck { get; set; }

        /// <summary>
        /// Очередь куч, готовых к перевозке
        /// </summary>
        public SimulationList HeapQueue { get; set; }

        /// <summary>
        /// Очередь самосвалов, ожидающих работы
        /// </summary>
        public SimulationList TruckQueue { get; set; }

        /// <summary>
        /// Очередь погрузчиков, ожидающих работы
        /// </summary>
        public SimulationList LoaderQueue { get; set; }

        /// <summary>
        /// Статистика по погрузчикам
        /// </summary>
        public ServiceStatistics[] LoadersStatistics { get; set; }

        /// <summary>
        /// Признак завершения работы
        /// </summary>
        public bool IsFinished { get; set; }

        /// <summary>
        /// Бульдозер
        /// </summary>
        public Bulldozer Bulldozer { get; set; }

        public int ForwardCount { get; set; }

        public int UnloadCount { get; set; }

        public int BackwardCount { get; set; }

        protected override void Init()
        {
            base.Init();

            // Создать списки самосвалов, погрузчиков и куч
            TruckQueue = new SimulationList("Очередь грузовиков");
            LoaderQueue = new SimulationList("Очередь погрузчиков");
            HeapQueue = new SimulationList("Очередь куч");

            // Массив статистик погрузчиков
            LoadersStatistics = new ServiceStatistics[Parameters.LoadersCount];

            for (int i = 0; i < Parameters.LoadersCount; i++)
            {
                LoadersStatistics[i] = new ServiceStatistics($"Загруженность погрузчика {i + 1}");

                // Создать погрузчики и поместить их в очередь
                new Loader
                {
                    Statistics = LoadersStatistics[i],
                    MeanWorkTime = Parameters.LoaderTimeMean[i]
                }.Insert(LoaderQueue);
            }

            // Создать самосвалы и поместить их в очередь
            for (int i = 0; i < Parameters.TrucksCount; i++)
            {
                new Truck().Insert(TruckQueue);
            }

            // Создать бульдозер
            Bulldozer = new Bulldozer();

            // Процесс работы не окончен
            IsFinished = false;
        }

        protected override void StartEvent()
        {
            // Запустить бульдозер
            Bulldozer.Activate();

            // Ожидать окончания
            Passivate();

            // Скорректировать статистики
            StopStat();
        }

        public override void StopStat()
        {
            base.StopStat();
            foreach (var stat in LoadersStatistics)
            {
                stat.StopStat();
            }

            TruckQueue.StopStat();
            LoaderQueue.StopStat();
            HeapQueue.StopStat();
        }

        public override void Finish()
        {
            Bulldozer.Finish();
            TruckQueue.Finish();
            LoaderQueue.Finish();
            HeapQueue.Finish();
            base.Finish();
        }
    }
}
