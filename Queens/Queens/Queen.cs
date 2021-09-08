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
    /// Сопрограмма, управляющая расстановкой одного ферзя
    /// </summary>
    public class Queen : Coroutine
    {
        /// <summary>
        /// Номер вертикали
        /// </summary>
        public byte Col;

        /// <summary>
        /// Номер горизонтали
        /// </summary>
        public byte Row;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="aCol">Номер вертикали для ферзя</param>
        public Queen(byte aCol)
        {
            Col = aCol;
            Row = 0;
        }

        /// <summary>
        /// Алгоритм поиска места для ферзя
        /// </summary>
        protected override IEnumerator<ISimulationAction> Execute()
        {
            while (true)
            {
                // Если очередное поле свободно
                if (Board.IsFree(Col, Row))
                {
                    // Занять его
                    Board.MakeOccupied(Col, Row);

                    // Если ферзь не последний
                    if (Col < Board.QueenCount - 1)
                    {
                        // Активировать следующего для поиска места
                        yield return SwitchTo(Board.Queens[Col + 1]);
                    }
                    else
                    {
                        // В противном случае отобразить расстановку
                        Board.Remember();
                    }

                    // Освободить поле
                    Board.MakeFree(Col, Row);
                }

                // Попробовать следующее поле
                Row++;

                // Если оно последнее на вертикали
                if (Row == Board.QueenCount)
                {
                    // Начать заново
                    Row = 0;

                    // Если это первый ферзь
                    if (Col == 0)
                    {
                        // Завершить работу
                        yield return Finish();
                    }
                    else
                    {
                        // Иначе активировать предыдущего для поиска другого варианта
                        yield return SwitchTo(Board.Queens[Col - 1]);
                    }
                }
            }
        }
    }
}
