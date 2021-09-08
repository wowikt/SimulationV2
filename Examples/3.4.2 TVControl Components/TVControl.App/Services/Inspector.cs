using Simulation.Core.Actions;
using Simulation.Core.Components;
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
    /// Класс Inspector моделирует работу проверяющего в модели контроля телевизоров
    /// </summary>
    internal class Inspector : SchedulableComponent
    {
        /// <summary>
        /// Текущий проверяемый телевизор
        /// </summary>
        private TvSet tv;

        /// <summary>
        /// Событие начала проверки
        /// </summary>
        protected override void StartEvent()
        {
            TvControlSimulationComponent simulation = Parent as TvControlSimulationComponent;

            // ОЖидать появления телевизоров
            if (simulation.InspectionQueue.Empty())
            {
                return;
            }

            // Извлечь первый телевизор из очереди
            tv = simulation.InspectionQueue.First as TvSet;
            tv.Insert(simulation.Running);

            // Начать проверку
            simulation.InspectorsStat.Start(SimTime());
            ReactivateDelay(TvControlSimulationComponent.RandInspector.Uniform(Params.MinInspectionTime,
                Params.MaxInspectionTime), ServiceFinishedEvent);
        }

        /// <summary>
        /// Событие окончания проверки
        /// </summary>
        public void ServiceFinishedEvent()
        {
            TvControlSimulationComponent simulation = Parent as TvControlSimulationComponent;

            // Закончить проверку
            simulation.InspectorsStat.Finish(SimTime());

            // Если телевизор исправен
            if (TvControlSimulationComponent.RandInspector.Draw(Params.NoAdjustmentProb))
            {
                // Зафиксировать статистику по времени пребывания в системе
                simulation.TimeInSystemStat.AddData(SimTime() - tv.StartingTime);
            }
            else
            {
                // Поместить телевизор в очередь к настройщику
                tv.Insert(simulation.AdjustmentQueue);
                // Активировать настройщика
                simulation.Adjust.Activate();
            }

            // Перейти к следующему телевизору
            tv = null;
            Reactivate(StartEvent);
        }
    }
}
