using BankSimulation.App.Components;
using BankSimulation.App.Simulation;
using Simulation.Core.Actions;
using Simulation.Core.Processes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSimulation.App.Events
{
    internal class ArrivalEvent : Process
    {
        internal static int ArrivedCount;

        protected override IEnumerator<ISimulationAction> Execute()
        {
            BankSimulationProcess simulation = Parent as BankSimulationProcess;
            ClearFinished();

            if (ArrivedCount < Param.MaxClientCount)
            {
                Client newClient = new Client(SimTime());
                ArrivedCount++;
                newClient.Insert(simulation.Queue);
                if (simulation.CurrentClient == null)
                {
                    newClient.Remove();
                    simulation.CurrentClient = newClient;
                    if (newClient.StartingTime == SimTime())
                    {
                        simulation.NotWaited++;
                    }

                    simulation.CashStat.Start(SimTime());
                    (new FinishedEvent())
                        .ActivateDelay(BankSimulationProcess.RandCashman.Uniform(Param.MinCashTime, Param.MaxCashTime));
                }

                (new ArrivalEvent())
                    .ActivateDelay(BankSimulationProcess.RandClient.Exponential(Param.MeanClientInterval));
            }

            GoFinished();
            yield return new ContinueAction(this);
        }
    }
}
