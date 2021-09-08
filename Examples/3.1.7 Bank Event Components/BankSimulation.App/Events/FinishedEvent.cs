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
    internal class FinishedEvent : SchedulableComponent
    {
        protected override ISimulationAction Run()
        {
            BankSimulationProcess simulation = Parent as BankSimulationProcess;
            Client currentClient = simulation.CurrentClient;
            simulation.CashStat.Finish(SimTime());
            simulation.InBankStat.AddData(SimTime() - currentClient.StartingTime);
            simulation.InBankHist.AddData(SimTime() - currentClient.StartingTime);

            if (simulation.CashStat.Finished == Param.MaxClientCount)
            {
                simulation.Activate();
                return new ContinueAction(null);
            }

            if (simulation.Queue.Size > 0)
            {
                currentClient = simulation.Queue.First as Client;
                currentClient.Remove();
                simulation.CurrentClient = currentClient;
                if (currentClient.StartingTime == SimTime())
                {
                    simulation.NotWaited++;
                }

                simulation.CashStat.Start(SimTime());
                return ReactivateDelay(BankSimulationProcess.RandCashman.Uniform(Param.MinCashTime, Param.MaxCashTime));
            }

            simulation.CurrentClient = null;
            return new ContinueAction(null);
        }
    }
}
