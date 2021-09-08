using Simulation.Core.Actions;
using Simulation.Core.Coroutines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queens
{
    /// <summary>
    /// Сопрограмма, организующая работу по расстановке ферзей
    /// </summary>
    public class QueensRun : Coroutine
    {
        /// <summary>
        /// Основной метод
        /// </summary>
        protected override IEnumerator<ISimulationAction> Execute()
        {
            // Создать ферзей
            for (byte i = 0; i < Board.QueenCount; i++)
            {
                Board.Queens[i] = new Queen(i);
            }

            // Запустить первого
            yield return SwitchTo(Board.Queens[0]);
            
            // Отобразить количество полученных расстановок
            Console.WriteLine("Найдено расстановок: {0}", Board.BoardCount);

            // Удалить ферзей
            for (int i = 0; i < Board.QueenCount; i++)
            {
                Board.Queens[i].Dispose();
            }
        }
    }
}
