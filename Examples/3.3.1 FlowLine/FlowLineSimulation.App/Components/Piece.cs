using FlowLineSimulation.App.Simulation;
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

            // Если в очереди к первому рабочему месту есть место
            if (Params.Queue1MaxSize == 0 && flPar.Worker1Stat.Running == 0 && flPar.Worker1Stat.Blocked == 0 || 
                Params.Queue1MaxSize > 0 && flPar.Queue1.Size < Params.Queue1MaxSize)
            {
                // Запустить обслуживание
                flPar.Worker1.Activate();

                // Встать в очередь
                Wait(flPar.Queue1);
            }
            else
            {
                // Иначе - зафиксировать статистику по отказам
                flPar.BalksStat.AddData(SimTime());
            }
        }
    }
}
