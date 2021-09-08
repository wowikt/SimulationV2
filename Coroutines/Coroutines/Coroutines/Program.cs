using Simulation.Core.Coroutines;
using Simulation.Core.Runners;
using System;

namespace Coroutines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MyProc procA = new MyProc { Name = "A" })
            using (MyProc procB = new MyProc { Name = "B" })
            using (MyProc procC = new MyProc { Name = "C" })
            {
                procA.NextProc = procB;
                procB.NextProc = procC;
                procC.NextProc = procA;

                GlobalRunner.Run(procA);
            }

            Console.WriteLine("Finished!");
            Console.ReadLine();
        }
    }
}
