using BankSimulation2.App.Simulation;
using Simulation.Core.Actions;
using Simulation.Core.Processes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSimulation2.App.Components
{
    /// <summary>
    /// Процесс, имитирущий работу кассира в банке
    /// </summary>
    internal class Cashman : Process
    {
        public Cashman(Client clt)
        {
            CurrClient = clt;
        }

        Client CurrClient;
        /// <summary>
        /// Алгоритм работы
        /// </summary>
        protected override IEnumerator<ISimulationAction> Execute()
        {
            BankSimulationProcess bsPar = Parent as BankSimulationProcess;
            // Передать управление клиенту, чтобы он запомнил время запуска
            CurrClient.StartRunning();
            CurrClient.Activate();
            yield return Hold(0);

            // Приступить к работе
            while (true)
            {
                // Если он не ожидал, учесть его
                if (CurrClient.StartingTime == SimTime())
                {
                    bsPar.NotWaited++;
                }

                // Выполнить обслуживание
                bsPar.CashStat.Start(SimTime());
                yield return Hold(BankSimulationProcess.RandCashman.Uniform(Param.MinCashTime, Param.MaxCashTime));
                bsPar.CashStat.Finish(SimTime());

                // Вычислить время пребывания в системе и учесть его в статистике и гистограмме
                double inBankTime = SimTime() - CurrClient.StartingTime;
                bsPar.InBankHist.AddData(inBankTime);
                bsPar.InBankStat.AddData(inBankTime);
                
                // Активировать клиента для завершения им работы
                CurrClient.Activate();

                // Если обслужены все клиенты, завершить имитацию
                if (bsPar.CashStat.Finished == Param.MaxClientCount)
                {
                    bsPar.Activate();
                    yield return Passivate();
                }

                // Ожидать появления клиента в очереди
                while (bsPar.Queue.Empty())
                {
                    yield return Passivate();
                }

                // Извлечь первого клиента из очереди
                CurrClient = bsPar.Queue.First as Client;
                CurrClient.StartRunning();
            }
        }
    }
}
