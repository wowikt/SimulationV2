using LoadingSimulation.App.Components;
using LoadingSimulation.App.Simulation;
using Simulation.Core.Actions;
using Simulation.Core.Processes;
using Simulation.Core.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadingSimulation.App.Services
{
    public class Loader : Process
    {
        /// <summary>
        /// Среднее время погрузки
        /// </summary>
        public double MeanWorkTime { get; set; }

        /// <summary>
        /// Объект сбора статистики
        /// </summary>
        public ServiceStatistics Statistics { get; set; }

        protected override IEnumerator<ISimulationAction> Execute()
        {
            // Процесс, моделирующий работу погрузчика
            LoadingSimulationComponent simulation = Parent as LoadingSimulationComponent;

            while (true)
            {
                // Ожидать наличия не менее необходимого количества куч и свободного самосвала
                while (simulation.HeapQueue.Size < Parameters.MinHeapQueueSize || simulation.TruckQueue.Empty())
                {
                    // Если бульдозер закончил работу, осталось меньше минимального числа куч и все самосвалы свободны
                    if (simulation.IsFinished && simulation.HeapQueue.Size < Parameters.MinHeapQueueSize && 
                        simulation.TruckQueue.Size == Parameters.TrucksCount)
                    {
                        // Завершить работу посредством активации имитации
                        simulation.Activate();
                    }

                    // Иначе - ждать
                    yield return Passivate();
                }

                // Начало обслуживания
                // Зафиксировать начало работы
                Statistics.Start();

                // Извлечь из очереди первый самосвал
                var truck = simulation.TruckQueue.First as Truck;
                truck.StartRunning();
                StartRunning();

                // Убрать кучи из начала очереди
                for (int i = 0; i < Parameters.MinHeapQueueSize; i++)
                {
                    simulation.HeapQueue.First.Remove();
                }

                // Выполнить погрузку
                yield return Hold(LoadingSimulationComponent.RandomLoader.Exponential(MeanWorkTime));

                // Закончить работу
                Statistics.Finish();

                // Активировать самосвал
                truck.Activate();

                // Возвращение
                yield return Hold(Parameters.LoaderReturnTime);

                // Встать в очередь ожидания
                Insert(simulation.LoaderQueue);
            }
        }
    }
}
