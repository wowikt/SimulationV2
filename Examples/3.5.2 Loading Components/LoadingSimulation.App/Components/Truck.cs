using LoadingSimulation.App.Simulation;
using Simulation.Core.Actions;
using Simulation.Core.Components;
using Simulation.Core.Extensions;
using Simulation.Core.Processes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadingSimulation.App.Components
{
    /// <summary>
    /// Компонент, моделирующий работу грузовика
    /// </summary>
    public class Truck : SchedulableComponent
    {
        protected override void StartEvent()
        {
            LoadingSimulationComponent simulation = Parent as LoadingSimulationComponent;

            // Грузовик загружен после ожидания
            // Перевозка
            simulation.ForwardCount++;
            ActivateDelay(LoadingSimulationComponent.RandomTruck.Normal(Parameters.TruckForwardMean, Parameters.TruckForwardDeviation), 
                ArrivedToUnloadEvent);
        }

        protected void ArrivedToUnloadEvent()
        {
            LoadingSimulationComponent simulation = Parent as LoadingSimulationComponent;
            simulation.ForwardCount--;

            // Разгрузка
            simulation.UnloadCount++;
            ActivateDelay(LoadingSimulationComponent.RandomTruck.Uniform(Parameters.TruckUnloadMin, Parameters.TruckUnloadMax), 
                UnloadedEvent);
        }

        protected void UnloadedEvent()
        {
            LoadingSimulationComponent simulation = Parent as LoadingSimulationComponent;
            simulation.UnloadCount--;

            // Возвращение
            simulation.BackwardCount++;
            ActivateDelay(LoadingSimulationComponent.RandomTruck.Normal(Parameters.TruckBackMean, Parameters.TruckBackDeviation), 
                ReturnedEvent);
        }

        protected void ReturnedEvent()
        {
            LoadingSimulationComponent simulation = Parent as LoadingSimulationComponent;
            simulation.BackwardCount--;

            // Активировать свободный погрузчик
            simulation.LoaderQueue.ActivateFirst();

            // Встать в очередь ожидания
            Insert(simulation.TruckQueue);
            NextScheduledEvent = StartEvent;
        }
    }
}
