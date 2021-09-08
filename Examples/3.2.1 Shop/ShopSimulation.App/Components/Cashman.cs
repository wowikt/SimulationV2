using ShopSimulation.App.Simulation;
using Simulation.Core.Actions;
using Simulation.Core.Processes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSimulation.App.Components
{
    /// <summary>
    /// Процесс, имитирущий работу кассира в банке
    /// </summary>
    class Cashman : Process
    {
        /// <summary>
        /// Алгоритм работы
        /// </summary>
        protected override IEnumerator<ISimulationAction> Execute()
        {
            ShopSimulationProcess simulation = Parent as ShopSimulationProcess;

            while (true)
            {
                // Ожидать появления покупателя в очереди
                while (simulation.Queue.Empty())
                {
                    yield return Passivate();
                }

                // Извлечь первого покупателя из очереди
                Customer customer = simulation.Queue.First as Customer;
                customer.StartRunning();

                // Выполнить обслуживание
                simulation.CashStat.Start(SimTime());
                yield return Hold(ShopSimulationProcess.RandService.Erlang(Param.MeanTimePerBuy, customer.BuysCount));
                simulation.CashStat.Finish(SimTime());
                
                // Вычислить время пребывания в системе и учесть его в статистике и гистограмме
                double inBankTime = SimTime() - customer.StartingTime;
                simulation.TimeHist.AddData(inBankTime);
                simulation.TimeStat.AddData(inBankTime);
                
                // Активировать покупателя для завершения им работы
                customer.Activate();
            }
        }
    }
}
