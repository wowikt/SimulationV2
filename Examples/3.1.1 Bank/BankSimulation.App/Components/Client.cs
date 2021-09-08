using BankSimulation.App.Simulation;
using Simulation.Core.Actions;
using Simulation.Core.Processes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSimulation.App.Components
{
    /// <summary>
    /// Класс, имитирующий клиента в банке
    /// </summary>
    class Client : Process
    {
        /// <summary>
        /// Алгоритм работы клиента
        /// </summary>
        protected override IEnumerator<ISimulationAction> Execute()
        {
            BankSimulationProcess bsPar = Parent as BankSimulationProcess;
            // Сообщить кассиру о прибытии
            bsPar.Cash.Activate();
            // Встать в очередь ожидания
            yield return Wait(bsPar.Queue);
            // После окончания обслуживания завершить работу
            GoFinished();
        }
    }
}
