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
    /// Класс WorkPlace1 имитирует обслуживание на первом рабочем месте
    /// </summary>
    internal class WorkPlace1 : SchedulableComponent
    {
        /// <summary>
        /// Текущее обслуживаемое изделие
        /// </summary>
        private Piece piece;

        /// <summary>
        /// Событие начала работы
        /// </summary>
        protected override void StartEvent()
        {
            FlowLineSimulationComponent simulation = Parent as FlowLineSimulationComponent;

            // ОЖидать появления изделий в очереди
            if (simulation.Queue1.Empty())
            {
                return;
            }

            // Зафиксировать начало обслуживания
            simulation.Worker1Stat.Start(SimTime());

            // Извлечь первое изделие из очереди
            piece = simulation.Queue1.First as Piece;
            piece.StartRunning();

            // Выполнить обслуживание
            ReactivateDelay(FlowLineSimulationComponent.RandWorker1.Exponential(Params.Worker1MeanTime), 
                ServiceFinishedEvent);
        }

        /// <summary>
        /// Событие окончания обслуживания
        /// </summary>
        public void ServiceFinishedEvent()
        {
            FlowLineSimulationComponent simulation = Parent as FlowLineSimulationComponent;

            // Зафиксировать окончание обслуживания
            simulation.Worker1Stat.Finish(SimTime());

            // Если очередь к второму рабочему месту заполнена
            if (Params.Queue2MaxSize == 0 && simulation.Worker2Stat.Running > 0 ||
                Params.Queue2MaxSize > 0 && simulation.Queue2.Size >= Params.Queue2MaxSize)
            {
                // Зафиксировать начало блокировки
                simulation.Worker1Stat.StartBlock(SimTime());
                NextScheduledEvent = BlockFinishEvent;
                return;
            }

            // Поместить изделие в очередь ко второму рабочему месту
            piece.Insert(simulation.Queue2);

            // Запустить обслуживание на втором рабочем месте
            simulation.Worker2.Activate();

            // Перейти к извлечению следующего изделия
            Reactivate(StartEvent);
        }

        /// <summary>
        /// Событие окончания блокировки
        /// </summary>
        public void BlockFinishEvent()
        {
            FlowLineSimulationComponent simulation = Parent as FlowLineSimulationComponent;

            // Ожидать появления места в очереди
            if (Params.Queue2MaxSize == 0 && simulation.Worker2Stat.Running > 0 ||
                Params.Queue2MaxSize > 0 && simulation.Queue2.Size >= Params.Queue2MaxSize)
            {
                return;
            }

            // Зафиксировать окончание блокировки
            simulation.Worker1Stat.FinishBlock(SimTime());

            // Поместить изделие в очередь ко второму рабочему месту
            piece.Insert(simulation.Queue2);

            // Запустить обслуживание на втором рабочем месте
            simulation.Worker2.Activate();
            Reactivate(StartEvent);
        }
    }
}
