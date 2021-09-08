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
    /// Класс WorkPlace1 имитирует обслуживание на первом рабочем месте
    /// </summary>
    internal class WorkPlace1 : Process
    {
        // Алгоритм процесса
        protected override IEnumerator<ISimulationAction> Execute()
        {
            FlowLineSimulationComponent flPar = Parent as FlowLineSimulationComponent;
            while (true)
            {
                // ОЖидать появления изделий в очереди
                while (flPar.Queue1.Empty())
                {
                    yield return Passivate();
                }

                // Зафиксировать начало обслуживания
                flPar.Worker1Stat.Start(SimTime());

                // Извлечь первое изделие из очереди
                Piece pc = flPar.Queue1.First as Piece;
                pc.StartRunning();

                // Выполнить обслуживание
                yield return Hold(FlowLineSimulationComponent.RandWorker1.Exponential(Params.Worker1MeanTime));

                // Зафиксировать окончание обслуживания
                flPar.Worker1Stat.Finish(SimTime());

                // Если очередь к второму рабочему месту заполнена
                if (Params.Queue2MaxSize == 0 && flPar.Worker2Stat.Running > 0 ||
                    Params.Queue2MaxSize > 0 && flPar.Queue2.Size >= Params.Queue2MaxSize)
                {
                    // Зафиксировать начало блокировки
                    flPar.Worker1Stat.StartBlock(SimTime());

                    // Ожидать появления места в очереди
                    while (Params.Queue2MaxSize == 0 && flPar.Worker2Stat.Running > 0 ||
                        Params.Queue2MaxSize > 0 && flPar.Queue2.Size >= Params.Queue2MaxSize)
                    {
                        yield return Passivate();
                    }

                    // Зафиксировать окончание блокировки
                    flPar.Worker1Stat.FinishBlock(SimTime());
                }

                // Поместить изделие в очередь ко второму рабочему месту
                pc.Insert(flPar.Queue2);

                // Запустить обслуживание на втором рабочем месте
                flPar.Worker2.Activate();
            }
        }
    }
}
