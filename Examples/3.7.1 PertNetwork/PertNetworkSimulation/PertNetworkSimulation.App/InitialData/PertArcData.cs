using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PertNetworkSimulation.App.InitialData
{
    public class PertArcData
    {
        public int StartNodeIndex { get; set; }

        public int EndNodeIndex { get; set; }

        public double MinTime { get; set; }

        public double ModaTime { get; set; }

        public double MaxTime { get; set; }
    }
}
