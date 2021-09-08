using Simulation.Core.Actions;
using Simulation.Core.Coroutines;
using System;
using System.Collections.Generic;

namespace Coroutines
{
    public class MyProc : Coroutine
    {
        protected override IEnumerator<ISimulationAction> Run()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Сопрограмма {0}: {1}", Name, i);
                yield return SwitchTo(NextProc);
            }
        }

        /// <summary>
        /// Отображемое имя
        /// </summary>
        public string Name;

        /// <summary>
        /// Ссылка на следующую по очереди сопрограмму
        /// </summary>
        public Coroutine NextProc;
    }
}
