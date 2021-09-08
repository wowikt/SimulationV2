using Simulation.Core.Actions;
using Simulation.Core.Extensions;
using Simulation.Core.Processes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVControl.App.Components;
using TVControl.App.Simulation;

namespace TVControl.App.Services
{
    /// <summary>
    /// Класс Adjuster представляет работу настройщика в имитации контроля телевизоров
    /// </summary>
    internal class Adjuster : Process
    {
        /// <summary>
        /// Алгоритм работы настройщика
        /// </summary>
        protected override IEnumerator<ISimulationAction> Execute()
        {
            TvControlSimulationComponent simulation = Parent as TvControlSimulationComponent;
            while (true)
            {
                // Ожидать появления телевизоров в очереди
                while (simulation.AdjustmentQueue.Empty())
                {
                    yield return Passivate();
                }

                // Извлечь первый телевизор из очереди
                TvSet tv = simulation.AdjustmentQueue.First as TvSet;
                tv.Insert(simulation.Running);

                // Выполнить настройку
                simulation.AdjustmentStat.Start(SimTime());
                yield return Hold(TvControlSimulationComponent.RandTVSet.Uniform(Params.MinAdjustmentTime,
                    Params.MaxAdjustmentTime));
                simulation.AdjustmentStat.Finish(SimTime());
                tv.AdjustmentCount++;

                // Поместить настроенный телевизор в очередь на проверку
                tv.Insert(simulation.InspectionQueue);

                // Активировать свободного проверяющего
                simulation.Inspect.ActivateFirst();
            }
        }
    }
}
