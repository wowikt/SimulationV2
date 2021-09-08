using Simulation.Core.Runners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queens
{
    class Program
    {
        static void Main(string[] args)
        {
            Board.RememberProcedure = WriteStatement;

            Console.Write($"Введите количество ферзей (по умолчанию {Board.QueenCount}): ");
            string input = Console.ReadLine();
            int count;
            if (!string.IsNullOrEmpty(input) && int.TryParse(input, out count))
            {
                Board.QueenCount = count;
            }

            // Создать и запустить основную сопрограмму
            using (var qRun = new QueensRun())
            {
                GlobalRunner.Run(qRun);
            }

            Console.WriteLine($"Готово. Найдено расстановок: {Board.BoardCount}.");
            Console.ReadLine();
        }

        public static void WriteStatement(IList<byte> statement)
        {
            Console.WriteLine(string.Join(" ", statement));
        }
    }
}
