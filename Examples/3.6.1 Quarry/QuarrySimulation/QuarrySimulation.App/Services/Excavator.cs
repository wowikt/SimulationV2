using QuarrySimulation.App.Components;
using QuarrySimulation.App.Simulation;
using Simulation.Core.Actions;
using Simulation.Core.Primitives;
using Simulation.Core.Processes;
using Simulation.Core.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuarrySimulation.App.Services
{
    public class Excavator : Process
    {
        /// <summary>
        /// Очередь самосвалов
        /// </summary>
        public SimulationList Queue { get; set; }

        /// <summary>
        /// Статистика
        /// </summary>
        public ServiceStatistics Statistics { get; set; }

        /// <summary>
        /// Работа экскаватора
        /// </summary>
        /// <returns></returns>
        protected override IEnumerator<ISimulationAction> Execute()
        {
            while (true)
            {
                // Ожилать появления самосвалов в очереди
                while (Queue.Empty())
                {
                    yield return Passivate();
                }

                // Взять первый самосвал
                var truck = Queue.First as Truck;
                truck.StartRunning();

                // Погрузка с записью статистики
                Statistics.Start();
                yield return Hold(QuarrySimulationComponent.RandomTruck.Exponential(truck.Settings.LoadingTime));
                Statistics.Finish();

                // Отправить самосвал
                truck.Activate();
            }
        }
    }
}
