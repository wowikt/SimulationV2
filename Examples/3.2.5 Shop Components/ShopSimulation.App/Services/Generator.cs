using ShopSimulation.App.Components;
using ShopSimulation.App.Simulation;
using Simulation.Core.Actions;
using Simulation.Core.Components;
using Simulation.Core.Processes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSimulation.App.Services
{
    /// <summary>
    /// Генератор покупателей магазина
    /// </summary>
    internal class Generator : SchedulableComponent
    {
        /// <summary>
        /// Алгоритм работы генератора
        /// </summary>
        protected override void StartEvent()
        {
            // Создать покупателя и запустить его
            (new Customer()).Activate();

            // Ожидать перед созданием следующего
            ReactivateDelay(ShopSimulationComponent.RandCust.Exponential(Param.MeanCustInterval));
        }
    }
}
