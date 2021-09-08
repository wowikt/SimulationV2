using Simulation.Core.Runners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Core.Statistics
{
    /// <summary>
    /// Класс ActionStatistics собирает статистику по действиям
    /// </summary>
    public class ActionStatistics
    {
        /// <summary>
        /// Конструктор. Создает объект статистики действия 
        /// в текущий момент имитационного времени.
        /// </summary>
        public ActionStatistics()
        {
            Running = 0;
            LastTime = GlobalRunner.SimTime();
        }

        /// <summary>
        /// Конструктор. Создает объект статистики действия 
        /// в текущий момент имитационного времени.
        /// </summary>
        /// <param name="initX">Начальное значение наблюдаемой величины</param>
        public ActionStatistics(int initX)
        {
            Running = initX;
            LastTime = GlobalRunner.SimTime();
        }

        /// <summary>
        /// Конструктор. Создает объект статистики действия 
        /// в заданный момент имитационного времени.
        /// </summary>
        /// <param name="initX">Начальное значение наблюдаемой величины</param>
        /// <param name="initTime">Момент времени, когда создается объект</param>
        public ActionStatistics(int initX, double initTime)
        {
            Running = initX;
            LastTime = initTime;
        }

        /// <summary>
        /// Конструктор. Создает объект статистики действия 
        /// в заданный момент имитационного времени.
        /// </summary>
        /// <param name="initX">Начальное значение наблюдаемой величины</param>
        /// <param name="initTime">Момент времени, когда создается объект</param>
        /// <param name="header">Заголовок для вывода статистики</param>
        public ActionStatistics(int initX, double initTime, string header)
        {
            Running = initX;
            LastTime = initTime;
            Header = header;
        }

        /// <summary>
        /// Конструктор. Создает объект статистики действия 
        /// в текущий момент имитационного времени.
        /// </summary>
        /// <param name="initX">Начальное значение наблюдаемой величины</param>
        /// <param name="header">Заголовок для вывода статистики</param>
        public ActionStatistics(int initX, string header)
        {
            Running = initX;
            LastTime = GlobalRunner.SimTime();
            Header = header;
        }

        /// <summary>
        /// Конструктор. Создает объект статистики действия 
        /// в текущий момент имитационного времени.
        /// </summary>
        /// <param name="header">Заголовок для вывода статистики</param>
        public ActionStatistics(string header)
        {
            Running = 0;
            LastTime = GlobalRunner.SimTime();
            Header = header;
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
        /// Интеграл наблюдаемой величины по времени
        /// </summary>
        private double SumX;

        /// <summary>
        /// Интеграл квадрата наблюдаемой величины по времени
        /// </summary>
        private double SumX2;

        /// <summary>
        /// Количество завершенный действий
        /// </summary>
        public int Finished
        {
            get;
            private set;
        }

        /// <summary>
        /// Максимальное значение среди накопленных
        /// </summary>
        public int Max
        {
            get;
            private set;
        }

        /// <summary>
        /// Количество исполняемых действий
        /// </summary>
        public int Running
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
        /// Очистка статистики, подготовка к новому сбору данных 
        /// в текущий момент имитационного времени
        /// </summary>
        public void ClearStat()
        {
            ClearStat(GlobalRunner.SimTime());
        }

        /// <summary>
        /// Очистка статистики, подготовка к новому сбору данных 
        /// в заданный момент имитационного времени
        /// </summary>
        /// <param name="newTime"></param>
        public void ClearStat(double newTime)
        {
            SumX = SumX2 = TotalTime = Finished = Max = 0;
            LastTime = newTime;
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
        /// Отметить окончание действия в текущий момент времени
        /// </summary>
        public void Finish()
        {
            Finish(GlobalRunner.CurrSim.SimTime());
        }

        /// <summary>
        /// Отметить окончание действия в заданный момент времени
        /// </summary>
        /// <param name="newTime">Время окончания действия</param>
        public void Finish(double newTime)
        {
            if (newTime > LastTime)
            {
                double dt = newTime - LastTime;
                LastTime = newTime;
                SumX += Running * dt;
                SumX2 += Running * Running * dt;
                TotalTime += dt;
                if (Running > Max)
                {
                    Max = Running;
                }
            }

            Running--;
            Finished++;
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
        /// Отметить приостановку действия в текущий момент времени
        /// </summary>
        public void Preempt()
        {
            Preempt(GlobalRunner.CurrSim.SimTime());
        }

        /// <summary>
        /// Отметить приостановку действия в заданный момент времени
        /// </summary>
        /// <param name="newTime">Время приостановки действия</param>
        public void Preempt(double newTime)
        {
            if (newTime > LastTime)
            {
                double dt = newTime - LastTime;
                LastTime = newTime;
                SumX += Running * dt;
                SumX2 += Running * Running * dt;
                TotalTime += dt;
                if (Running > Max)
                {
                    Max = Running;
                }
            }

            Running--;
        }

        /// <summary>
        /// Отметить возобновление действия в текущий момент времени
        /// </summary>
        public void Resume()
        {
            Resume(GlobalRunner.CurrSim.SimTime());
        }

        /// <summary>
        /// Отметить возобновление действия в заданный момент времени
        /// </summary>
        /// <param name="newTime">Время возобновления действия</param>
        public void Resume(double newTime)
        {
            Start(newTime);
        }

        /// <summary>
        /// Отметить начало действия в текущий момент времени
        /// </summary>
        public void Start()
        {
            Start(GlobalRunner.CurrSim.SimTime());
        }

        /// <summary>
        /// Отметить начало действия в заданный момент времени
        /// </summary>
        /// <param name="newTime">Время начала действия</param>
        public void Start(double newTime)
        {
            if (newTime > LastTime)
            {
                double dt = newTime - LastTime;
                LastTime = newTime;
                SumX += Running * dt;
                SumX2 += Running * Running * dt;
                TotalTime += dt;
                if (Running > Max)
                {
                    Max = Running;
                }
            }

            Running++;
        }

        /// <summary>
        /// Коррекция статистики к текущему имитационному времени.
        /// Учитывается интервал времени, прошедший с момента 
        /// последнего изменения или коррекции.
        /// </summary>
        public void StopStat()
        {
            StopStat(GlobalRunner.SimTime());
        }

        /// <summary>
        /// Коррекция статистики к заданному имитационному времени.
        /// Учитывается интервал времени, прошедший с момента 
        /// последнего изменения или коррекции.
        /// </summary>
        /// <param name="newTime">Имитационное время 
        /// момента коррекции статистики</param>
        public void StopStat(double newTime)
        {
            if (newTime > LastTime)
            {
                // Время прошло, величина не изменилась
                double dt = newTime - LastTime;
                LastTime = newTime;
                SumX += Running * dt;
                SumX2 += Running * Running * dt;
                TotalTime += dt;
                if (Running > Max)
                {
                    Max = Running;
                }
            }
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
            result.AppendLine($"Максимум = {Max,2}\n");
            result.Append($"Сейчас выполняется {Running,2} действий, завершено {Finished,2}");
            return result.ToString();
        }
    }
}
