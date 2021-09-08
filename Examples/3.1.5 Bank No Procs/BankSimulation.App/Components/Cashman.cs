using Simulation.Core.Actions;
using Simulation.Core.Processes;
using BankSimulation.App.Simulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSimulation.App.Components
{
    /// <summary>
    /// Процесс, имитирущий работу кассира в банке
    /// </summary>
    public class Cashman : Process
    {
        /// <summary>
        /// Алгоритм работы
        /// </summary>
        protected override IEnumerator<ISimulationAction> Execute()
        {
            BankSimulationProcess bsPar = Parent as BankSimulationProcess;
            while (true)
            {
                // Ожидать появления клиента в очереди
                while (bsPar.Queue.Empty())
                {
                    yield return Passivate();
                }

                // Извлечь первого клиента из очереди
                Client clt = bsPar.Queue.First as Client;
                clt.Insert(bsPar.Running);

                // Если он не ожидал, учесть его
                if (clt.StartingTime == SimTime())
                {
                    bsPar.NotWaited++;
                }

                // Выполнить обслуживание
                bsPar.CashStat.Start(SimTime());
                yield return Hold(BankSimulationProcess.RandCashman.Uniform(Param.MinCashTime, Param.MaxCashTime));
                bsPar.CashStat.Finish(SimTime());

                // Вычислить время пребывания в системе и учесть его в статистике и гистограмме
                double inBankTime = SimTime() - clt.StartingTime;
                bsPar.InBankHist.AddData(inBankTime);
                bsPar.InBankStat.AddData(inBankTime);
                clt.Insert(bsPar.Finished);

                // Если обслужены все клиенты, завершить имитацию
                if (bsPar.CashStat.Finished == Param.MaxClientCount)
                {
                    bsPar.Activate();
                }
            }
        }
    }
}
