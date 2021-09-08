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
    public class Client : SchedulableComponent
    {
        public static int ArrivedCount;

        private int CashIndex;

        protected override void StartEvent()
        {
            BankSimulationProcess simulation = Parent as BankSimulationProcess;
            StartingTime = SimTime();
            ArrivedCount++;

            if (simulation.Queue.Size < Param.MaxQueueLength)
            {
                Insert(simulation.Queue);
                CashIndex = -1;

                for (int i = 0; i < Param.CashCount; i++)
                {
                    if (simulation.CurrentClient[i] == null)
                    {
                        CashIndex = i;
                        break;
                    }
                }

                if (CashIndex >= 0)
                {
                    Remove();
                    simulation.CurrentClient[CashIndex] = this;
                    simulation.CashStat.Start(SimTime());
                    if (SimTime() == StartingTime)
                    {
                        simulation.NotWaited++;
                    }

                    ReactivateDelay(BankSimulationProcess.RandCashman.Uniform(Param.MinCashTime, Param.MaxCashTime), 
                        ServiceFinished);
                }
            }
            else
            {
                simulation.NotServiced++;
            }

            if (ArrivedCount > Param.CashCount + Param.StartClientNum)
            {
                (new Client()).ActivateDelay(BankSimulationProcess.RandClient.Exponential(Param.MeanClientInterval));
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
                nextClient.CashIndex = CashIndex;
                simulation.CurrentClient[CashIndex] = nextClient;
                simulation.CashStat.Start(SimTime());
                if (SimTime() == nextClient.StartingTime)
                {
                    simulation.NotWaited++;
                }

                nextClient.ActivateDelay(BankSimulationProcess.RandCashman.Uniform(Param.MinCashTime, Param.MaxCashTime), 
                    nextClient.ServiceFinished);
            }
            else
            {
                simulation.CurrentClient[CashIndex] = null;
            }

            if (simulation.CashStat.Finished == Param.MaxClientCount)
            {
                simulation.Activate();
            }
        }
    }
}
