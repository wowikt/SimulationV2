using FlowLineSimulation.App.Components;
using FlowLineSimulation.App.Simulation;
using Simulation.Core.Actions;
using Simulation.Core.Components;
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
    internal class WorkPlace2 : SchedulableComponent
    {
        /// <summary>
        /// Текущее обрабатываемое изделие
        /// </summary>
        Piece piece;

        /// <summary>
        /// Событие начала работы
        /// </summary>
        protected override void StartEvent()
        {
            FlowLineSimulationComponent simulation = Parent as FlowLineSimulationComponent;

            // ОЖидать появления изделий в очереди
            if (simulation.Queue2.Empty())
            {
                return;
            }

            // Зафиксировать начало обслуживания
            simulation.Worker2Stat.Start(SimTime());

            // Извлечь изделие из очереди
            piece = simulation.Queue2.First as Piece;
            piece.StartRunning();

            // Уведомить первого рабочего об освобождении места в очереди
            simulation.Worker1.Activate();

            // Выполнить обслуживание
            ReactivateDelay(FlowLineSimulationComponent.RandWorker2.Exponential(Params.Worker2MeanTime), 
                ServiceFinishedEvent);
        }

        /// <summary>
        /// Событие окончания обслуживания
        /// </summary>
        protected void ServiceFinishedEvent()
        {
            FlowLineSimulationComponent simulation = Parent as FlowLineSimulationComponent;

            // Собрать статистику по времени пребвания изделия в системе
            simulation.TimeInSystemStat.AddData(SimTime() - piece.StartingTime);
            simulation.TimeHist.AddData(SimTime() - piece.StartingTime);

            // Зафиксировать окончание обслуживания
            simulation.Worker2Stat.Finish(SimTime());

            // Уведомить первого рабочего об окончании операции
            simulation.Worker1.Activate();

            // Перейти к извлечению следующего изделия
            Reactivate(StartEvent);
        }
    }
}
