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
    /// Класс, имитирующий клиента в банке
    /// </summary>
    class Customer : Process
    {
        public int BuysCount;

        /// <summary>
        /// Алгоритм работы клиента
        /// </summary>
        protected override IEnumerator<ISimulationAction> Execute()
        {
            ShopSimulationProcess simulation = Parent as ShopSimulationProcess;

            BuysCount = ShopSimulationProcess.RandCust.NextInt(Param.MinBuysCount, Param.MaxBuysCount);
            simulation.InShopStat.Start(SimTime());
            yield return Hold(ShopSimulationProcess.RandCust.Uniform(Param.MinShoppingTime, Param.MaxShoppingTime));
            simulation.InShopStat.Finish(SimTime());

            // Сообщить кассиру о прибытии
            simulation.Cash.Activate();
            
            // Встать в очередь ожидания
            yield return Wait(simulation.Queue);
            
            // После окончания обслуживания завершить работу
            GoFinished();
        }
    }
}
