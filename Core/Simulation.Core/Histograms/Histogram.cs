using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Core.Histograms
{
    /// <summary>
    /// Класс <c>Histogram</c> собирает данные по количеству значений, попадающих в заданные интервалы
    /// </summary>
    public class Histogram : HistogramBase
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="low">Нижняя граница первого конечного интервала</param>
        /// <param name="step">Шаг каждого конечного интервала</param>
        /// <param name="intervalCount">Количество конечных интервалов</param>
        public Histogram(double low, double step, int intervalCount)
            : base(low, step, intervalCount)
        {
            Data = new int[IntervalCount + 2];
            TotalCount = 0;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="low">Нижняя граница первого конечного интервала</param>
        /// <param name="step">Шаг каждого конечного интервала</param>
        /// <param name="intervalCount">Количество конечных интервалов</param>
        /// <param name="header">Заголовок при выводе на экран</param>
        public Histogram(double low, double step, int intervalCount, string header)
            : base(low, step, intervalCount, header)
        {
            Data = new int[IntervalCount + 2];
            TotalCount = 0;
        }

        /// <summary>
        /// Массив, в котором содержится количество значений, попадающее в каждый интервал
        /// </summary>
        private int[] Data;

        /// <summary>
        /// Общее количество записанных значений
        /// </summary>
        public int TotalCount
        {
            get;
            private set;
        }

        /// <summary>
        /// Добавляет к гистограмме новое значение. Увеличивает на 1 элемент массива, соответствующий добавляемой величине, 
        /// и общее количество значений
        /// </summary>
        /// <param name="newData">Добавляемое значение</param>
        public void AddData(double newData)
        {
            Data[IntervalIndex(newData)]++;
            TotalCount++;
        }

        /// <summary>
        /// Очищает гистограмму, записывая нулевые значения во все элементы массива и обнуляя счетчик значений
        /// </summary>
        public override void Clear()
        {
            for (int i = 0; i <= IntervalCount + 1; i++)
            {
                Data[i] = 0;
            }

            TotalCount = 0;
        }

        /// <summary>
        /// Возвращает количество значений, попавших в указанный интервал
        /// </summary>
        /// <param name="index">Индекс интервала</param>
        /// <returns>Количество значений</returns>
        public int Count(int index)
        {
            if (index <= 0)
            {
                return Data[0];
            }
            else if (index >= IntervalCount + 1)
            {
                return Data[IntervalCount + 1];
            }
            else
            {
                return Data[index];
            }
        }

        /// <summary>
        /// Общее количество значений, попавших в интервалы от крайнего левого до указанного
        /// </summary>
        /// <param name="index">Индекс интервала</param>
        /// <returns>Общее количество значений</returns>
        public int CumulativeCount(int index)
        {
            int Sum = 0;
            for (int i = 0; i <= index && i <= IntervalCount + 1; i++)
            {
                Sum += Data[i];
            }

            return Sum;
        }

        /// <summary>
        /// Возвращает долю от общего количества значений, попавших в интервалы от левого до указанного
        /// </summary>
        /// <param name="index">Индекс интервала</param>
        /// <returns>Доля количества значений</returns>
        public override double CumulativePercent(int index)
        {
            if (TotalCount == 0)
            {
                return 0;
            }
            else
            {
                return (double)CumulativeCount(index) / TotalCount;
            }
        }

        /// <summary>
        /// Возвращает долю от общего количества значений, попавших в указанный интервал
        /// </summary>
        /// <param name="index">Индекс интервала</param>
        /// <returns>Доля количества значений</returns>
        public override double Percent(int index)
        {
            if (TotalCount == 0)
            {
                return 0;
            }
            else
            {
                return (double)Count(index) / TotalCount;
            }
        }

        /// <summary>
        /// Отображает содержимое гистограммы в текстовом виде для отображения на экране
        /// </summary>
        /// <returns>Текстовый вид гистограммы</returns>
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(Header);

            // Нулевой полубесконечный интервал
            int cumulativeCount = (int)Math.Round(CumulativePercent(0) * 40) - 1;
            int percentCount = (int)Math.Round(Percent(0) * 40);

            StringBuilder graphLine = new StringBuilder();
            if (cumulativeCount > 0)
            {
                graphLine.Append(' ', cumulativeCount);
            }

            if (cumulativeCount >= 0)
            {
                graphLine.Append('o');
            }

            for (int j = 0; j < percentCount; j++)
            {
                graphLine[j] = '*';
            }

            output.AppendLine($" -INF - {UpperBound(0),5:0.00} : {Count(0),4} ({Percent(0) * 100,5:0.00}%), " +
                $"{CumulativePercent(0) * 100,6:0.00}% {graphLine}");

            // Конечные интервалы
            for (int i = 1; i <= IntervalCount; i++)
            {
                cumulativeCount = (int)Math.Round(CumulativePercent(i) * 40) - 1;
                percentCount = (int)Math.Round(Percent(i) * 40);
                graphLine.Clear();

                if (cumulativeCount > 0)
                {
                    graphLine.Append(' ', cumulativeCount);
                }

                if (cumulativeCount >= 0)
                {
                    graphLine.Append('o');
                }

                for (int j = 0; j < percentCount; j++)
                {
                    graphLine[j] = '*';
                }

                output.AppendLine($"{LowerBound(i),5:0.00} - {UpperBound(i),5:0.00} : {Count(i),4} " +
                    $"({Percent(i) * 100,5:0.00}%), {CumulativePercent(i) * 100,6:0.00}% {graphLine}");
            }

            // Последний полубесконечный интервал
            cumulativeCount = (int)Math.Round(CumulativePercent(IntervalCount + 1) * 40) - 1;
            percentCount = (int)Math.Round(Percent(IntervalCount + 1) * 40);
            graphLine.Clear();

            if (cumulativeCount > 0)
            {
                graphLine.Append(' ', cumulativeCount);
            }

            if (cumulativeCount >= 0)
            {
                graphLine.Append('o');
            }

            for (int j = 0; j < percentCount; j++)
            {
                graphLine[j] = '*';
            }

            output.Append($"{LowerBound(IntervalCount + 1),5:0.00} -  +INF : {Count(IntervalCount + 1),4} " +
                $"({Percent(IntervalCount + 1) * 100,5:0.00}%), {CumulativePercent(IntervalCount + 1) * 100,6:0.00}% {graphLine}");

            return output.ToString();
        }
    }
}
