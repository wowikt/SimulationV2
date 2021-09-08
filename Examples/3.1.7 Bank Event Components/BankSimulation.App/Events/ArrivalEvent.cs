using BankSimulation.App.Components;
using BankSimulation.App.Simulation;
using Simulation.Core.Actions;
using Simulation.Core.Components;
using Simulation.Core.Processes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSimulation.App.Events
{
    internal class ArrivalEvent : SchedulableComponent
    {
        internal static int ArrivedCount;

        protected override ISimulationAction Run()
        {
            BankSimulationProcess simulation = Parent as BankSimulationProcess;
            ClearFinished();

            if (ArrivedCount == Param.MaxClientCount)
            {
                return new ContinueAction(null);
            }

            Client newClient = new Client(SimTime());
            ArrivedCount++;

            if (simulation.CurrentClient != null)
            {
                newClient.Insert(simulation.Queue);
            }
            else
            {
                simulation.CurrentClient = newClient;

                if (newClient.StartingTime == SimTime())
                {
                    simulation.NotWaited++;
                }

                simulation.CashStat.Start(SimTime());
                (new FinishedEvent())
                    .ActivateDelay(BankSimulationProcess.RandCashman.Uniform(Param.MinCashTime, Param.MaxCashTime));
            }

            return ReactivateDelay(BankSimulationProcess.RandClient.Exponential(Param.MeanClientInterval));
        }
    }
}
