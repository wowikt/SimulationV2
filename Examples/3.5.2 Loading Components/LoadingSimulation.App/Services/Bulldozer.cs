using LoadingSimulation.App.Components;
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

namespace LoadingSimulation.App.Services
{
    public class Bulldozer : SchedulableComponent
    {
        protected override void StartEvent()
        {
            LoadingSimulationComponent simulation = Parent as LoadingSimulationComponent;

            if (SimTime() > Parameters.ModelingTime)
            {
                // Работа завершена
                simulation.IsFinished = true;
                return;
            }

            // Создать кучу земли и поставить ее в очередь
            new Heap().Insert(simulation.HeapQueue);

            // Если куч хотя бы минимальное количество
            if (simulation.HeapQueue.Size >= Parameters.MinHeapQueueSize)
            {
                // Активировать первого погрузчика (если есть)
                simulation.LoaderQueue.ActivateFirst();
            }

            ReactivateDelay(LoadingSimulationComponent.RandomBulldozer.Erlang(Parameters.HeapParamInterval, Parameters.HeapParamCount));
        }
    }
}
