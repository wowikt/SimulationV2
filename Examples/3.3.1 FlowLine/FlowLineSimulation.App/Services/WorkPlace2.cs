using FlowLineSimulation.App.Components;
using FlowLineSimulation.App.Simulation;
using Simulation.Core.Actions;
using Simulation.Core.Processes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowLineSimulation.App.Services
{
    /// <summary>
    /// Класс WorkPlace2 имитирует обслуживание изделия на втором рабочем месте
    /// </summary>
    internal class WorkPlace2 : Process
    {
        /// <summary>
        /// Алгоритм обслуживания
        /// </summary>
        protected override IEnumerator<ISimulationAction> Execute()
        {
            FlowLineSimulationComponent flPar = Parent as FlowLineSimulationComponent;
            while (true)
            {
                // ОЖидать появления изделий в очереди
                while (flPar.Queue2.Empty())
                {
                    yield return Passivate();
                }

                // Зафиксировать начало обслуживания
                flPar.Worker2Stat.Start(SimTime());

                // Извлечь изделие из очереди
                Piece pc = flPar.Queue2.First as Piece;
                pc.StartRunning();

                // Уведомить первого рабочего об освобождении места в очереди
                flPar.Worker1.Activate();

                // Выполнить обслуживание
                yield return Hold(FlowLineSimulationComponent.RandWorker2.Exponential(Params.Worker2MeanTime));

                // Собрать статистику по времени пребвания изделия в системе
                flPar.TimeInSystemStat.AddData(SimTime() - pc.StartingTime);
                flPar.TimeHist.AddData(SimTime() - pc.StartingTime);

                // Зафиксировать окончание обслуживания
                flPar.Worker2Stat.Finish(SimTime());

                // Уведомить первого рабочего об окончании операции
                flPar.Worker1.Activate();
            }
        }
    }
}
