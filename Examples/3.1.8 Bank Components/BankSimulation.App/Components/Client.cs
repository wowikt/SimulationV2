using BankSimulation.App.Simulation;
using Simulation.Core.Actions;
using Simulation.Core.Components;
using Simulation.Core.Primitives;
using Simulation.Core.Processes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSimulation.App.Components
{
    /// <summary>
    /// Класс, имитирующий клиента в банке
    /// </summary>
    class Client : SchedulableComponent
    {
        public static int ArrivedCount;

        protected override void StartEvent()
        {
            BankSimulationProcess simulation = Parent as BankSimulationProcess;
            StartingTime = SimTime();
            ArrivedCount++;
            if (simulation.CurrentClient != null)
            {
                Insert(simulation.Queue);
            }
            else
            {
                simulation.CurrentClient = this;
                simulation.CashStat.Start(SimTime());
                if (SimTime() == StartingTime)
                {
                    simulation.NotWaited++;
                }

                ReactivateDelay(BankSimulationProcess.RandCashman.Uniform(Param.MinCashTime, Param.MaxCashTime), 
                    ServiceFinished);
            }

            if (ArrivedCount < Param.MaxClientCount)
            {
                (new Client())
                    .ActivateDelay(BankSimulationProcess.RandClient.Exponential(Param.MeanClientInterval));
            }
        }

        public void ServiceFinished()
        {
            BankSimulationProcess simulation = Parent as BankSimulationProcess;
            simulation.InBankHist.AddData(SimTime() - StartingTime);
            simulation.InBankStat.AddData(SimTime() - StartingTime);
            simulation.CashStat.Finish(SimTime());

            if (simulation.Queue.Size > 0)
            {
                Client nextClient = simulation.Queue.First as Client;
                nextClient.Remove();
                simulation.CurrentClient = nextClient;
                simulation.CashStat.Start(SimTime());

                if (SimTime() == nextClient.StartingTime)
                {
                    simulation.NotWaited++;
                }

                nextClient
                    .ActivateDelay(BankSimulationProcess.RandCashman.Uniform(Param.MinCashTime, Param.MaxCashTime), 
                        nextClient.ServiceFinished);
            }
            else
            {
                simulation.CurrentClient = null;
            }

            if (simulation.CashStat.Finished == Param.MaxClientCount)
            {
                simulation.Activate();
            }
        }
    }
}
