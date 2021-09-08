using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queens
{
    /// <summary>
    /// Глобальные определения, моделирующие шахматную доску
    /// </summary>
    class Board
    {
        private static int _queenCount = 4;
        /// <summary>
        /// Количество ферзей и размер доски
        /// </summary>
        public static int QueenCount
        {
            get
            {
                return _queenCount;
            }
            set
            {
                _queenCount = value;
                Rows = new bool[_queenCount];
                DiagsUp = new bool[2 * _queenCount - 1];
                DiagsDown = new bool[2 * _queenCount - 1];
                Queens = new Queen[_queenCount];
            }
        }

        public static Action<IList<byte>> RememberProcedure;

        /// <summary>
        /// Массив, описывающий занятость горизонталей
        /// </summary>
        static bool[] Rows = new bool[QueenCount];

        /// <summary>
        /// Массив, описывающий занятость диагоналей из левого нижнего угла в правый верхний
        /// </summary>
        static bool[] DiagsUp = new bool[2 * QueenCount - 1];

        /// <summary>
        /// Массив, описывающий занятость диагоналей из левого верхнего угла в правый нижний
        /// </summary>
        static bool[] DiagsDown = new bool[2 * QueenCount - 1];

        /// <summary>
        /// Массив сопрограмм, имитирующих расстановку ферзей
        /// </summary>
        static public Queen[] Queens = new Queen[QueenCount];

        /// <summary>
        /// Количество найденных расстановок
        /// </summary>
        static public int BoardCount = 0;

        /// <summary>
        /// Проверка, свободно ли поле шаматной доски
        /// </summary>
        /// <param name="Col">Номер вертикали</param>
        /// <param name="Row">Номер горизонтали</param>
        /// <returns>true, если поле свободно</returns>
        static public bool IsFree(byte Col, byte Row)
        {
            return !Rows[Row] && !DiagsUp[Col - Row + QueenCount - 1] && !DiagsDown[Col + Row];
        }

        /// <summary>
        /// Занять поле шахматной доски
        /// </summary>
        /// <param name="Col">Номер вертикали</param>
        /// <param name="Row">Номер горизонтали</param>
        static public void MakeOccupied(byte Col, byte Row)
        {
            Rows[Row] = true;
            DiagsUp[Col - Row + QueenCount - 1] = true;
            DiagsDown[Col + Row] = true;
        }

        /// <summary>
        /// Освободить поле шахматной доски
        /// </summary>
        /// <param name="Col">Номер вертикали</param>
        /// <param name="Row">Номер горизонтали</param>
        static public void MakeFree(byte Col, byte Row)
        {
            Rows[Row] = false;
            DiagsUp[Col - Row + QueenCount - 1] = false;
            DiagsDown[Col + Row] = false;
        }

        /// <summary>
        /// Отобразить текущую расстановку
        /// </summary>
        static public void Remember()
        {
            RememberProcedure(Queens.Select(q => q.Row).ToList());
            BoardCount++;
        }
    }
}
