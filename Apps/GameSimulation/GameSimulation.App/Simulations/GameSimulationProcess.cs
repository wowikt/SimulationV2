using GameSimulation.App.Components;
using Simulation.Core.Actions;
using Simulation.Core.Processes;
using Simulation.Core.RandomGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.App.Simulations
{
    public class GameSimulationProcess : SimProc
    {
        public Player Player { get; set; }

        public RandomGenerator Random { get; set; } = new RandomGenerator();

        protected override IEnumerator<ISimulationAction> Execute()
        {
            Player = new Player();
            Player.Value = 100;
            Player.Activate();
            yield return Passivate();
        }
    }
}
