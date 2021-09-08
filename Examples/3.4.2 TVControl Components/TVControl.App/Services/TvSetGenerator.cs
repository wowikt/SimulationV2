using Simulation.Core.Components;
using Simulation.Core.Extensions;
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
    /// Класс TVSetGenerator обеспечивает поступление проверяемых телевизоров в систему
    /// </summary>
    class TvSetGenerator : SchedulableComponent
    {
        /// <summary>
        /// Основное событие генератора
        /// </summary>
        protected override void StartEvent()
        {
            TvControlSimulationComponent simulation = Parent as TvControlSimulationComponent;

            // Создать новый телевизор
            TvSet tv = new TvSet();
            tv.StartingTime = SimTime();

            // Поместить его в очередь на проверку
            tv.Insert(simulation.InspectionQueue);

            // Активизировать первого свободного проверяющего
            simulation.Inspect.ActivateFirst();

            // Ожидать перед поступлением следующего телевизора
            ReactivateDelay(TvControlSimulationComponent.RandTVSet.Uniform(Params.MinTVSetInterval,
                Params.MaxTVSetInterval));
        }
    }
}
