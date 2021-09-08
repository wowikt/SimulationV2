using LoadingSimulation.App.Simulation;
using Simulation.Core.Actions;
using Simulation.Core.Extensions;
using Simulation.Core.Processes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadingSimulation.App.Components
{
    public class Truck : Process
    {
        protected override IEnumerator<ISimulationAction> Execute()
        {
            // Процесс, моделирующий работу грузовика
            LoadingSimulationComponent simulation = Parent as LoadingSimulationComponent;

            while (true)
            {
                // Грузовик загружен после ожидания
                // Перевозка
                simulation.ForwardCount++;
                yield return Hold(LoadingSimulationComponent.RandomTruck.Normal(Parameters.TruckForwardMean, Parameters.TruckForwardDeviation));
                simulation.ForwardCount--;

                // Разгрузка
                simulation.UnloadCount++;
                yield return Hold(LoadingSimulationComponent.RandomTruck.Uniform(Parameters.TruckUnloadMin, Parameters.TruckUnloadMax));
                simulation.UnloadCount--;

                // Возвращение
                simulation.BackwardCount++;
                yield return Hold(LoadingSimulationComponent.RandomTruck.Normal(Parameters.TruckBackMean, Parameters.TruckBackDeviation));
                simulation.BackwardCount--;

                // Активировать свободный погрузчик
                simulation.LoaderQueue.ActivateFirst();

                // Встать в очередь ожидания
                yield return Wait(simulation.TruckQueue);
            }
        }
    }
}
