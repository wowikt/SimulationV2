using Simulation.Core.Runners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Core.Statistics
{
    /// <summary>
    /// Класс <c>IntervalStatistics</c> собирает интервальную статистику по значениям, дискретно меняющимся во времени
    /// </summary>
    public class IntervalStatistics
    {
        /// <summary>
        /// Конструктор. Создает объект интервальной статистики в текущий момент имитационного времени.
        /// </summary>
        /// <param name="initX">Начальное значение наблюдаемой величины</param>
        public IntervalStatistics(double initX)
        {
            LastX = initX;
            LastTime = GlobalRunner.SimTime();
        }

        /// <summary>
        /// Конструктор. Создает объект интервальной статистики в заданный момент имитационного времени.
        /// </summary>
        /// <param name="initX">Начальное значение наблюдаемой величины</param>
        /// <param name="initTime">Момент времени, когда создается объект</param>
        public IntervalStatistics(double initX, double initTime)
        {
            LastX = initX;
            LastTime = initTime;
        }

        /// <summary>
        /// Заголовок для вывода статистики на экран
        /// </summary>
        public string Header;

        /// <summary>
        /// Момент последнего изменения величины
        /// </summary>
        private double LastTime;

        /// <summary>
        /// Значение величины с момента последнего изменения
        /// </summary>
        public double LastX;

        /// <summary>
        /// Интеграл наблюдаемой величины по времени
        /// </summary>
        private double SumX;

        /// <summary>
        /// Интеграл квадрата наблюдаемой величины по времени
        /// </summary>
        private double SumX2;

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
        /// Общее время наблюдения со сбором статистики
        /// </summary>
        public double TotalTime
        {
            get;
            private set;
        }

        /// <summary>
        /// Добавление нового значения наблюдаемой величины к статистике в текущий момент имитационного времени.
        /// Фактически учитывается статистика за промежуток времени с последнего изменения до текущего.
        /// Указанное значение запоминается для учета в будущем.
        /// </summary>
        /// <param name="newX">Новое значение наблюдаемой величины</param>
        public void AddData(double newX)
        {
            AddData(newX, GlobalRunner.SimTime());
        }

        /// <summary>
        /// Добавление нового значения наблюдаемой величины к статистике с указанием момента времени, когда оно изменяется.
        /// Фактически учитывается статистика за промежуток времени с последнего изменения до текущего.
        /// Указанное значение запоминается для учета в будущем.
        /// </summary>
        /// <param name="newX">Новое значение наблюдаемой величины</param>
        /// <param name="newTime">Имитационное время в момент изменения</param>
        public void AddData(double newX, double newTime)
        {
            // Промежуток времени с момента последнего обновления
            double dt = newTime - LastTime;
            if (dt < 0)
            {
                // Ошибочное значение
                //   *** (может быть, генерировать исключение?)
                dt = 0;
            }

            // Если с момента последнего изменения прошло ненулевое время
            if (dt > 0)
            {
                // Если это первое изменение величины, инициализировать статистику
                if (TotalTime == 0)
                {
                    Min = Max = LastX;
                }
                // Иначе - скорректировать крайние значения
                else if (LastX < Min)
                {
                    Min = LastX;
                }
                else if (LastX > Max)
                {
                    Max = LastX;
                }

                // Учесть нахождение величины на уровне LastX в течение времени dt
                SumX += dt * LastX;
                SumX2 += dt * LastX * LastX;
                TotalTime += dt;
            }

            // Запомнить новое состояние
            LastTime = newTime;
            LastX = newX;
        }

        /// <summary>
        /// Очистка статистики, подготовка к новому сбору данных в текущий момент имитационного времени
        /// </summary>
        public void ClearStat()
        {
            ClearStat(GlobalRunner.SimTime());
        }

        /// <summary>
        /// Очистка статистики, подготовка к новому сбору данных в заданный момент имитационного времени
        /// </summary>
        /// <param name="newTime"></param>
        public void ClearStat(double newTime)
        {
            SumX = SumX2 = Min = Max = TotalTime = 0;
            LastTime = newTime;
            // Величина LastX не изменяется
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
            if (TotalTime == 0)
            {
                return 0;
            }
            else
            {
                double mean = Mean();
                return SumX2 / TotalTime - mean * mean;
            }
        }

        /// <summary>
        /// Возвращает среднее арифметическое по накопленным данным
        /// </summary>
        /// <returns>Среднее арифметическое</returns>
        public double Mean()
        {
            if (TotalTime == 0)
            {
                return 0;
            }
            else
            {
                return SumX / TotalTime;
            }
        }

        /// <summary>
        /// Коррекция статистики к текущему имитационному времени.
        /// Учитывается интервал времени, прошедший с момента последнего изменения или коррекции.
        /// </summary>
        public void StopStat()
        {
            StopStat(GlobalRunner.SimTime());
        }

        /// <summary>
        /// Коррекция статистики к заданному имитационному времени.
        /// Учитывается интервал времени, прошедший с момента последнего изменения или коррекции.
        /// </summary>
        /// <param name="newTime">Имитационное время момента коррекции статистики</param>
        public void StopStat(double newTime)
        {
            // Время прошло, величина не изменилась
            AddData(LastX, newTime);
        }

        /// <summary>
        /// Преобразует содержимое статистики в текст для отображения на экране
        /// </summary>
        /// <returns>Преобразованное содержимое</returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(Header);
            result.AppendLine($"Среднее = {Mean(),6:0.000} +/- {Deviation(),6:0.000}");
            result.AppendLine($"Минимум = {Min,6:0.000}, максимум = {Max,6:0.000}");
            result.Append($"Всего {TotalTime,6:0.000} единиц времени, текущее значение = {LastX,6:0.000}");
            return result.ToString();
        }
    }
}
