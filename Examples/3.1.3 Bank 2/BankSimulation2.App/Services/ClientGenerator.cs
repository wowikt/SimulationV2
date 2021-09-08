using BankSimulation2.App.Components;
using BankSimulation2.App.Simulation;
using Simulation.Core.Actions;
using Simulation.Core.Processes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSimulation2.App.Services
{
    /// <summary>
    /// Генератор клиентов банка
    /// </summary>
    internal class ClientGenerator : Process
    {
        /// <summary>
        /// Алгоритм работы генератора
        /// </summary>
        protected override IEnumerator<ISimulationAction> Execute()
        {
            yield return Hold(Param.FirstClientArrival);

            // Количество клиентов задано заранее
            while (true)
            {
                ClearFinished();

                // Создать клиента и запустить его
                (new Client()).Activate();

                // ОЖидать перед созданием следующего
                yield return Hold(BankSimulationProcess.RandClient.Exponential(Param.MeanClientInterval));
            }
        }
    }
}
