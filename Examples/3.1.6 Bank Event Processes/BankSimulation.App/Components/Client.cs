using BankSimulation.App.Simulation;
using Simulation.Core.Actions;
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
    internal class Client : LinkedNode
    {
        public Client(double startTime)
        {
            StartingTime = startTime;
        }

        public double StartingTime;
    }
}
