using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadingSimulation.App
{
    public static class Parameters
    {
        public static double ModelingTime = 480;

        public static int MinHeapQueueSize = 2;
        public static double HeapParamInterval = 4;
        public static int HeapParamCount = 2;
        public static double LoaderReturnTime = 5;
        public static double TruckForwardMean = 22;
        public static double TruckForwardDeviation = 3;
        public static double TruckUnloadMin = 2;
        public static double TruckUnloadMax = 8;
        public static double TruckBackMean = 18;
        public static double TruckBackDeviation = 3;
        public static int TrucksCount = 4;
        public static int LoadersCount = 2;
        public static double[] LoaderTimeMean = { 12, 14 };
        public static double VisTimeStep = 0.5;
    }
}
