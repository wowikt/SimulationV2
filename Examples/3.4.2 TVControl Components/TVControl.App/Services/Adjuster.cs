using Simulation.Core.Actions;
using Simulation.Core.Components;
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
    internal class Adjuster : SchedulableComponent
    {
        /// <summary>
        /// Текущий настраиваемый телевизор
        /// </summary>
        private TvSet tv;

        /// <summary>
        /// Событие начала настройки
        /// </summary>
        protected override void StartEvent()
        {
            TvControlSimulationComponent simulation = Parent as TvControlSimulationComponent;

            // Ожидать появления телевизоров в очереди
            if (simulation.AdjustmentQueue.Empty())
            {
                return;
            }

            // Извлечь первый телевизор из очереди
            tv = simulation.AdjustmentQueue.First as TvSet;
            tv.Insert(simulation.Running);

            // Начать настройку
            simulation.AdjustmentStat.Start(SimTime());
            ReactivateDelay(TvControlSimulationComponent.RandTVSet.Uniform(Params.MinAdjustmentTime,
                Params.MaxAdjustmentTime), ServiceFinishedEvent);
        }

        /// <summary>
        /// Событие окончания настройки
        /// </summary>
        public void ServiceFinishedEvent()
        {
            TvControlSimulationComponent simulation = Parent as TvControlSimulationComponent;

            // Завершить настройку
            simulation.AdjustmentStat.Finish(SimTime());

            // Поместить настроенный телевизор в очередь на проверку
            tv.Insert(simulation.InspectionQueue);

            // Активировать свободного проверяющего
            simulation.Inspect.ActivateFirst();

            // Перейти к настройке следующего телевизора
            tv = null;
            Reactivate(StartEvent);
        }
    }
}
