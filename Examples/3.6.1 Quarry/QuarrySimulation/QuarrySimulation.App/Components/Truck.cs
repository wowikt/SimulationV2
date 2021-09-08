using QuarrySimulation.App.Services;
using QuarrySimulation.App.Settings;
using QuarrySimulation.App.Simulation;
using Simulation.Core.Actions;
using Simulation.Core.Primitives;
using Simulation.Core.Processes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuarrySimulation.App.Components
{
    public class Truck : Process
    {
        /// <summary>
        /// Индекс экскаватора
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Очередь к экскаватору
        /// </summary>
        public SimulationList Queue { get; set; }

        /// <summary>
        /// Экскаватор
        /// </summary>
        public Excavator Excavator { get; set; }

        /// <summary>
        /// Характеристики
        /// </summary>
        public TruckSettings Settings { get; set; }

        protected override IEnumerator<ISimulationAction> Execute()
        {
            QuarrySimulationComponent simulation = Parent as QuarrySimulationComponent;

            while (true)
            {
                // Самосвал загружен и отправляется к измельчителю
                simulation.ForwardTrips[Index]++;
                yield return Hold(Settings.TripTime + Parameters.ExtraTripTime);
                simulation.ForwardTrips[Index]--;

                // Актичировать разгрузку
                simulation.Mill.Activate();

                // Встать в очередь к измельчителю
                yield return Wait(simulation.MillQueue);

                // Обратный путь с записью статистики
                simulation.ReturnStatistics.Start();
                yield return Hold(Settings.TripTime);
                simulation.ReturnStatistics.Finish();

                // Активировать свой экскаватор
                Excavator.Activate();

                // Встать в очередь к своему экскаватору
                yield return Wait(Queue);
            }
        }
    }
}
