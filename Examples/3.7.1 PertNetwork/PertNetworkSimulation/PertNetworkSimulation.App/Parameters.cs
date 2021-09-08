using PertNetworkSimulation.App.InitialData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PertNetworkSimulation.App
{
    public static class Parameters
    {
        public static int NodeCount = 6;

        public static PertArcData[] ArcData = new PertArcData[]
        {
            new PertArcData
            {
                StartNodeIndex = 0,
                EndNodeIndex = 1,
                MinTime = 1,
                ModaTime = 3,
                MaxTime = 5,
            },
            new PertArcData
            {
                StartNodeIndex = 0,
                EndNodeIndex = 2,
                MinTime = 3,
                ModaTime = 6,
                MaxTime = 9,
            },
            new PertArcData
            {
                StartNodeIndex = 0,
                EndNodeIndex = 3,
                MinTime = 10,
                ModaTime = 13,
                MaxTime = 19,
            },
            new PertArcData
            {
                StartNodeIndex = 1,
                EndNodeIndex = 4,
                MinTime = 3,
                ModaTime = 9,
                MaxTime = 12,
            },
            new PertArcData
            {
                StartNodeIndex = 1,
                EndNodeIndex = 2,
                MinTime = 1,
                ModaTime = 3,
                MaxTime = 8,
            },
            new PertArcData
            {
                StartNodeIndex = 2,
                EndNodeIndex = 5,
                MinTime = 8,
                ModaTime = 9,
                MaxTime = 16,
            },
            new PertArcData
            {
                StartNodeIndex = 2,
                EndNodeIndex = 3,
                MinTime = 4,
                ModaTime = 7,
                MaxTime = 13,
            },
            new PertArcData
            {
                StartNodeIndex = 4,
                EndNodeIndex = 5,
                MinTime = 3,
                ModaTime = 6,
                MaxTime = 9,
            },
            new PertArcData
            {
                StartNodeIndex = 3,
                EndNodeIndex = 5,
                MinTime = 1,
                ModaTime = 3,
                MaxTime = 8,
            },
        };

        public static HistogramData[] HistogramData = new HistogramData[]
        {
            new HistogramData
            {
                Min = 1,
                Step = 0.2,
                StepCount = 20,
            },
            new HistogramData
            {
                Min = 3,
                Step = 0.5,
                StepCount = 20,
            },
            new HistogramData
            {
                Min = 10,
                Step = 1,
                StepCount = 16,
            },
            new HistogramData
            {
                Min = 4,
                Step = 0.5,
                StepCount = 26,
            },
            new HistogramData
            {
                Min = 11,
                Step = 1,
                StepCount = 23,
            },
        };

        public static int RunCount = 400;
    }
}
