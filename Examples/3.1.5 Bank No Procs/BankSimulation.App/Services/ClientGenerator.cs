using BankSimulation.App.Components;
using BankSimulation.App.Simulation;
using Simulation.Core.Actions;
using Simulation.Core.Processes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSimulation.App.Services
{
    /// <summary>
    /// Генератор клиентов банка
    /// </summary>
    class ClientGenerator : Process
    {
        /// <summary>
        /// Алгоритм работы генератора
        /// </summary>
        protected override IEnumerator<ISimulationAction> Execute()
        {
            BankSimulationProcess bsPar = Parent as BankSimulationProcess;

            // Количество клиентов задано заранее
            for (int i = 0; i < Param.MaxClientCount; i++)
            {
                ClearFinished();

                // Создать клиента и запустить его
                (new Client(SimTime())).Insert(bsPar.Queue);
                bsPar.Cash.Activate();

                // ОЖидать перед созданием следующего
                yield return Hold(BankSimulationProcess.RandClient.Exponential(Param.MeanClientInterval));
            }
        }
    }
}
