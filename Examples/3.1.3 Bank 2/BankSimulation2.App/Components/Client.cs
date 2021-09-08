using BankSimulation2.App.Simulation;
using Simulation.Core.Actions;
using Simulation.Core.Processes;
using Simulation.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSimulation2.App.Components
{
    /// <summary>
    /// Класс, имитирующий клиента в банке
    /// </summary>
    internal class Client : Process
    {
        public Client()
        {
            Inserted = false;
        }

        public Client(bool inserted)
        {
            Inserted = inserted;
        }

        internal bool Inserted;

        /// <summary>
        /// Алгоритм работы клиента
        /// </summary>
        protected override IEnumerator<ISimulationAction> Execute()
        {
            BankSimulationProcess simulation = Parent as BankSimulationProcess;

            // Если клиент был внедрен в систему принудительно
            if (Inserted)
            {
                // Сразу ожидать обслуживания
                yield return Passivate();
            }
            else if (simulation.Queue.Size < Param.MaxQueueLength)
            {
                // Активировать кассиров
                simulation.Cash.ActivateFirst();
                // Ждать обслуживания
                yield return Wait(simulation.Queue);
            }
            else
            {
                // Очередь заполнена - увеличить счетчик отказов
                simulation.NotServiced++;
            }

            // Встать в очередь завершенных процессов
            GoFinished();
        }
    }
}
