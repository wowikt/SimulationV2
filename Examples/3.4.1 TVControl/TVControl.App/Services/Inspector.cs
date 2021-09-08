using Simulation.Core.Actions;
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
    internal class Inspector : Process
    {
        /// <summary>
        /// Алгоритм проверки
        /// </summary>
        protected override IEnumerator<ISimulationAction> Execute()
        {
            TvControlSimulationComponent simulation = Parent as TvControlSimulationComponent;
            while (true)
            {
                // ОЖидать появления телевизоров
                while (simulation.InspectionQueue.Empty())
                {
                    yield return Passivate();
                }

                // Извлечь первый телевизор из очереди
                TvSet tv = simulation.InspectionQueue.First as TvSet;
                tv.Insert(simulation.Running);
                simulation.InspectorsStat.Start(SimTime());

                // Выполнить проверку
                yield return Hold(TvControlSimulationComponent.RandInspector.Uniform(Params.MinInspectionTime,
                    Params.MaxInspectionTime));
                simulation.InspectorsStat.Finish(SimTime());

                // Если телевизор исправен
                if (TvControlSimulationComponent.RandInspector.Draw(Params.NoAdjustmentProb))
                {
                    // Зафиксировать статистику по времени пребывания в системе
                    simulation.TimeInSystemStat.AddData(SimTime() - tv.StartingTime);

                    if (tv.AdjustmentCount > 0)
                    {
                        simulation.AdjustmentCountStatistics.AddData(tv.AdjustmentCount);
                    }
                }
                else
                {
                    // Поместить телевизор в очередь к настройщику
                    tv.Insert(simulation.AdjustmentQueue);

                    // Активировать настройщика
                    simulation.Adjust.Activate();
                }
            }
        }
    }
}
