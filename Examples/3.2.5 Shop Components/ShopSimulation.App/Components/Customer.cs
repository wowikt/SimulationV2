using ShopSimulation.App.Simulation;
using Simulation.Core.Actions;
using Simulation.Core.Components;
using Simulation.Core.Processes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSimulation.App.Components
{
    /// <summary>
    /// Класс, имитирующий покупателя магазина
    /// </summary>
    internal class Customer : SchedulableComponent
    {
        /// <summary>
        /// Количество покупок
        /// </summary>
        internal int BuysCount;

        /// <summary>
        /// Начало работы клиента
        /// </summary>
        protected override void StartEvent()
        {
            ShopSimulationComponent simulation = Parent as ShopSimulationComponent;

            // Вычислить количество покупок
            BuysCount = ShopSimulationComponent.RandCust.NextInt(Param.MinBuysCount, Param.MaxBuysCount);

            // Начать выбор покупок
            simulation.InShopStat.Start(SimTime());

            // Запланировать окончание выбора покупок
            ReactivateDelay(ShopSimulationComponent.RandCust.Uniform(Param.MinShoppingTime, Param.MaxShoppingTime), 
                ActionFinishedEvent);
        }

        /// <summary>
        /// Событие оконачния выбора покупок
        /// </summary>
        public void ActionFinishedEvent()
        {
            ShopSimulationComponent simulation = Parent as ShopSimulationComponent;

            // Закончить выбор покупок
            simulation.InShopStat.Finish(SimTime());

            // Сообщить кассиру о прибытии
            simulation.Cash.Activate();

            // Встать в очередь ожидания
            Wait(simulation.Queue);
        }
    }
}
