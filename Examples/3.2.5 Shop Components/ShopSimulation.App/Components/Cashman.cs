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
    /// Компонент, имитирущий работу кассира в банке
    /// </summary>
    internal class Cashman : SchedulableComponent
    {
        /// <summary>
        /// Текущий обслуживаемый покупатель
        /// </summary>
        internal Customer Customer;

        /// <summary>
        /// Начало работы с клиентом
        /// </summary>
        protected override void StartEvent()
        {
            ShopSimulationComponent simulation = Parent as ShopSimulationComponent;

            // Если очередь пуста, ничего не делать
            if (simulation.Queue.Empty())
            {
                return;
            }

            // Извлечь первого покупателя из очереди
            Customer = simulation.Queue.First as Customer;
            Customer.StartRunning();

            // Начать обслуживание
            simulation.CashStat.Start(SimTime());

            // Запланировать событие окончания обслуживания
            ReactivateDelay(ShopSimulationComponent.RandService.Erlang(Param.MeanTimePerBuy, Customer.BuysCount), 
                ServiceFinishedEvent);
        }

        /// <summary>
        /// Событие окончания обслуживания
        /// </summary>
        public void ServiceFinishedEvent()
        {
            ShopSimulationComponent simulation = Parent as ShopSimulationComponent;

            // Закончить обслуживание
            simulation.CashStat.Finish(SimTime());

            // Вычислить время пребывания в системе и учесть его в статистике и гистограмме
            double inShopTime = SimTime() - Customer.StartingTime;
            simulation.TimeHist.AddData(inShopTime);
            simulation.TimeStat.AddData(inShopTime);

            // Перейти к обслуживанию следующего клиента
            Reactivate(OnStartEvent);
        }
    }
}
