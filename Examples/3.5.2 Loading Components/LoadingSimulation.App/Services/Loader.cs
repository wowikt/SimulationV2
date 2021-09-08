using LoadingSimulation.App.Components;
using LoadingSimulation.App.Simulation;
using Simulation.Core.Actions;
using Simulation.Core.Components;
using Simulation.Core.Processes;
using Simulation.Core.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadingSimulation.App.Services
{
    /// <summary>
    /// Компонент, моделирующий работу погрузчика
    /// </summary>
    public class Loader : SchedulableComponent
    {
        /// <summary>
        /// Среднее время погрузки
        /// </summary>
        public double MeanWorkTime { get; set; }

        /// <summary>
        /// Объект сбора статистики
        /// </summary>
        public ServiceStatistics Statistics { get; set; }

        private Truck truck;

        protected override void StartEvent()
        {
            LoadingSimulationComponent simulation = Parent as LoadingSimulationComponent;

            // Ожидать наличия не менее необходимого количества куч и свободного самосвала
            if (simulation.HeapQueue.Size < Parameters.MinHeapQueueSize || simulation.TruckQueue.Empty())
            {
                // Если бульдозер закончил работу, осталось меньше минимального числа куч и все самосвалы свободны
                if (simulation.IsFinished && simulation.HeapQueue.Size < Parameters.MinHeapQueueSize &&
                    simulation.TruckQueue.Size == Parameters.TrucksCount)
                {
                    // Завершить работу посредством активации имитации
                    simulation.Activate();
                }

                // Иначе - ждать
                return;
            }

            // Начало обслуживания
            // Зафиксировать начало работы
            Statistics.Start();

            // Извлечь из очереди первый самосвал
            truck = simulation.TruckQueue.First as Truck;
            truck.StartRunning();
            StartRunning();

            // Убрать кучи из начала очереди
            for (int i = 0; i < Parameters.MinHeapQueueSize; i++)
            {
                simulation.HeapQueue.First.Remove();
            }

            // Выполнить погрузку
            ActivateDelay(LoadingSimulationComponent.RandomLoader.Exponential(MeanWorkTime), LoadingFinishedEvent);
        }

        protected void LoadingFinishedEvent()
        {
            LoadingSimulationComponent simulation = Parent as LoadingSimulationComponent;

            // Закончить работу
            Statistics.Finish();

            // Активировать самосвал
            truck.Activate();

            // Возвращение
            ActivateDelay(Parameters.LoaderReturnTime, ReturnedEvent);
        }

        protected void ReturnedEvent()
        {
            LoadingSimulationComponent simulation = Parent as LoadingSimulationComponent;

            // Встать в очередь ожидания
            Insert(simulation.LoaderQueue);
            NextScheduledEvent = StartEvent;
        }
    }
}
