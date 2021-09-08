using FlowLineSimulation.App.Simulation;
using Simulation.Core.Actions;
using Simulation.Core.Components;
using Simulation.Core.Processes;
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
    internal class Piece : Process
    {
        /// <summary>
        /// Событие прибытия изделия
        /// </summary>
        protected override IEnumerator<ISimulationAction> Execute()
        {
            FlowLineSimulationComponent flPar = Parent as FlowLineSimulationComponent;
            // Запланировать прибытие следующего изделия
            (new Piece()).ActivateDelay(FlowLineSimulationComponent.RandPiece.Exponential(Params.PieceMeanInterval));
            bool serviceResult;
            yield return DoService(flPar.Worker1, out serviceResult);

            // Попытаться выполнить первое действие
            if (!serviceResult)
            {
                // Если неудачно, зафиксировать статистику по отказам
                flPar.BalksStat.AddData(SimTime());
            }
            else
            {
                // Выполнить второе действие
                yield return DoService(flPar.Worker2, out serviceResult);

                // Собрать статистику по времени пребывания изделия в системе
                flPar.TimeInSystemStat.AddData(SimTime() - StartingTime);
                flPar.TimeHist.AddData(SimTime() - StartingTime);
            }
        }

        protected override void ActionFinishedEvent(IAction act)
        {
            base.ActionFinishedEvent(act);
            Activate();
        }
    }
}
