using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Core.Statistics
{
    /// <summary>
    /// Класс <c>Statistics</c> собирает точечную статистику по независимым значениям
    /// </summary>
    public class SimpleStatistics
    {
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public SimpleStatistics()
        {
            ClearStat();
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="header">Заголовок для вывода на экран</param>
        public SimpleStatistics(string header)
        {
            ClearStat();
            Header = header;
        }

        /// <summary>
        /// Заголовок для вывода статистики на экран
        /// </summary>
        public string Header;

        /// <summary>
        /// Сумма величин
        /// </summary>
        protected double SumX;

        /// <summary>
        /// Сумма квадратов величин
        /// </summary>
        protected double SumX2;

        /// <summary>
        /// Количество накопленных значений
        /// </summary>
        public int Count
        {
            get;
            protected set;
        }

        /// <summary>
        /// Максимальное значение среди накопленных
        /// </summary>
        public double Max
        {
            get;
            private set;
        }

        /// <summary>
        /// Минимальное значение среди накопленных
        /// </summary>
        public double Min
        {
            get;
            private set;
        }

        /// <summary>
        /// Добавление нового значения к статистике
        /// </summary>
        /// <param name="newX">Добавляемое значение</param>
        public virtual void AddData(double newX)
        {
            // Если это первый элемент данных, взять его в качестве минимального и максимального
            if (Count == 0)
            {
                Min = Max = newX;
            }
            // Иначе учесть, если он является новым максимальным либо минимальным
            else if (newX > Max)
            {
                Max = newX;
            }
            else if (newX < Min)
            {
                Min = newX;
            }

            SumX += newX;
            SumX2 += newX * newX;
            Count++;
        }

        /// <summary>
        /// Очистка статистики, подготовка к новому сбору данных
        /// </summary>
        public virtual void ClearStat()
        {
            SumX = SumX2 = Min = Max = 0;
            Count = 0;
        }

        /// <summary>
        /// Возвращает стандартное отклонение накопленных значений
        /// </summary>
        /// <returns>Стандартное отклонение</returns>
        public double Deviation()
        {
            return Math.Sqrt(Disperse());
        }

        /// <summary>
        /// Возвращает дисперсию накопленных значений
        /// </summary>
        /// <returns>Дисперсия</returns>
        public double Disperse()
        {
            if (Count <= 1)
            {
                return 0;
            }
            else
            {
                double mean = Mean();
                return (SumX2 - Count * mean * mean) / (Count - 1);
            }
        }

        /// <summary>
        /// Возвращает среднее арифметическое по накопленным данным
        /// </summary>
        /// <returns>Среднее арифметическое</returns>
        public double Mean()
        {
            if (Count <= 0)
            {
                return 0;
            }
            else
            {
                return SumX / Count;
            }
        }

        /// <summary>
        /// Преобразует содержимое статистики в текст для отображения на экране
        /// </summary>
        /// <returns>Преобразованное содержимое</returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder(Header + "\n");
            result.AppendLine($"Среднее = {Mean(),6:0.000} +/- {Deviation(),6:0.000}");
            result.AppendLine($"Минимум = {Min,6:0.000}, максимум = {Max,6:0.000}");
            result.Append($"Всего {Count,4} значений");
            return result.ToString();
        }
    }
}
