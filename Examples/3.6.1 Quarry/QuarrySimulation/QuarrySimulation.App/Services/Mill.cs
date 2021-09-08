using QuarrySimulation.App.Components;
using QuarrySimulation.App.Simulation;
using Simulation.Core.Actions;
using Simulation.Core.Processes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuarrySimulation.App.Services
{
    public class Mill : Process
    {
        /// <summary>
        /// Процесс работы измельчителя
        /// </summary>
        /// <returns></returns>
        protected override IEnumerator<ISimulationAction> Execute()
        {
            QuarrySimulationComponent simulation = Parent as QuarrySimulationComponent;

            while (true)
            {
                // Ожидать поступления самосвалов на разгрузку
                while (simulation.MillQueue.Empty())
                {
                    yield return Passivate();
                }

                // Извлечь первый самосвал из очереди
                var truck = simulation.MillQueue.First as Truck;
                truck.StartRunning();

                // Разгрузка с записью статистики
                simulation.MillStatistics.Start();
                yield return Hold(QuarrySimulationComponent.RandomMill.Exponential(truck.Settings.UnloadingTime));
                if (truck.Settings.IsHeavy)
                {
                    simulation.HeavyCount++;
                }
                else
                {
                    simulation.LightCount++;
                }

                simulation.Delivered += truck.Settings.Tonnage;
                simulation.MillStatistics.Finish();

                // Отправить самосвал в обратный путь
                truck.Activate();
            }
        }
    }
}
