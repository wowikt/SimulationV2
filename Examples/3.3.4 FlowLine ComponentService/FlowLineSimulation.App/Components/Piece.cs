using FlowLineSimulation.App.Simulation;
using Simulation.Core.Actions;
using Simulation.Core.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowLineSimulation.App.Components
{
    /// <summary>
    /// Класс Piece моделирует цикл существования изделия
    /// </summary>
    internal class Piece : SchedulableComponent
    {
        /// <summary>
        /// Событие прибытия изделия
        /// </summary>
        protected override void StartEvent()
        {
            FlowLineSimulationComponent flPar = Parent as FlowLineSimulationComponent;
            // Запланировать прибытие следующего изделия
            (new Piece()).ActivateDelay(FlowLineSimulationComponent.RandPiece.Exponential(Params.PieceMeanInterval));
            // Попытаться выполнить первое действие
            if (!DoService(flPar.Worker1, FinishEvent))
            {
                // Если попытка неудачна, зафиксировать статистику по отказам
                flPar.BalksStat.AddData(SimTime());
            }
        }

        protected override void ActionFinishedEvent(IAction act)
        {
            FlowLineSimulationComponent flPar = Parent as FlowLineSimulationComponent;
            if (act == flPar.Worker1)
            {
                // Выполнить второе действие
                DoService(flPar.Worker2);
            }
            else if (act == flPar.Worker2)
            {
                // Собрать статистику по времени пребывания изделия в системе
                flPar.TimeInSystemStat.AddData(SimTime() - StartingTime);
                flPar.TimeHist.AddData(SimTime() - StartingTime);
            }
        }
    }
}
