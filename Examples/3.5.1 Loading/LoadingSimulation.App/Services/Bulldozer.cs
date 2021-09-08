using LoadingSimulation.App.Components;
using LoadingSimulation.App.Simulation;
using Simulation.Core.Actions;
using Simulation.Core.Extensions;
using Simulation.Core.Processes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadingSimulation.App.Services
{
    public class Bulldozer : Process
    {
        protected override IEnumerator<ISimulationAction> Execute()
        {
            LoadingSimulationComponent simulation = Parent as LoadingSimulationComponent;

            while (SimTime() <= Parameters.ModelingTime)
            {
                // Создать кучу земли и поставить ее в очередь
                new Heap().Insert(simulation.HeapQueue);

                // Если куч хотя бы минимальное количество
                if (simulation.HeapQueue.Size >= Parameters.MinHeapQueueSize)
                {
                    // Активировать первого погрузчика (если есть)
                    simulation.LoaderQueue.ActivateFirst();
                }

                yield return Hold(LoadingSimulationComponent.RandomBulldozer.Erlang(Parameters.HeapParamInterval, Parameters.HeapParamCount));
            }

            // Работа завершена
            simulation.IsFinished = true;
        }
    }
}
