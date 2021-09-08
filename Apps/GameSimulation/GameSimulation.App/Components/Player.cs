using GameSimulation.App.Simulations;
using Simulation.Core.Actions;
using Simulation.Core.Processes;
using Simulation.Core.RandomGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSimulation.App.Components
{
    public class Player : Process
    {
        public static double WinPercent = 1.5;

        public static double LosePercent = 0.6;

        public static int StepCount = 100;

        public static double StepTime = 1;

        private static int RunningPlayerCount = 0;

        private MultiGameSimulationProcess _parent;

        public double Value { get; set; }

        protected override IEnumerator<ISimulationAction> Execute()
        {
            RunningPlayerCount++;
            _parent = Parent as MultiGameSimulationProcess;

            for (int i = 0; i < StepCount; i++)
            {
                MakeMove();
                yield return Hold(StepTime);
            }

            RunningPlayerCount--;
            if (RunningPlayerCount == 0)
            {
                _parent.Activate();
            }
        }

        private void MakeMove()
        {
            if (_parent.Random.Draw(0.5))
            {
                Value *= WinPercent;
            }
            else
            {
                Value *= LosePercent;
            }
        }
    }
}
