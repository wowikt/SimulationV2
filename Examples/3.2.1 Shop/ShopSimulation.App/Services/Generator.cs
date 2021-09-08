using ShopSimulation.App.Components;
using ShopSimulation.App.Simulation;
using Simulation.Core.Actions;
using Simulation.Core.Processes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSimulation.App.Services
{
    /// <summary>
    /// Генератор клиентов банка
    /// </summary>
    class Generator : Process
    {
        /// <summary>
        /// Алгоритм работы генератора
        /// </summary>
        protected override IEnumerator<ISimulationAction> Execute()
        {
            // Количество клиентов заранее неизвестно
            while (true)
            {
                ClearFinished();

                // Создать клиента и запустить его
                (new Customer()).Activate();

                // Ожидать перед созданием следующего
                yield return Hold(ShopSimulationProcess.RandCust.Exponential(Param.MeanCustInterval));
            }
        }
    }
}
