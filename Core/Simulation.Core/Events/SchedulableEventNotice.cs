using Simulation.Core.Actions;
using Simulation.Core.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Core.Events
{
    /// <summary>
    /// Класс EventNotice - ячейка календаря событий
    /// </summary>
    public abstract class SchedulableEventNotice : LinkedNode
    {
        /// <summary>
        /// Конструктор. Записывает значения параметров в поля объекта
        /// </summary>
        /// <param name="time">Время наступления события</param>
        protected SchedulableEventNotice(double time)
        {
            EventTime = time;
        }

        /// <summary>
        /// Имитационное время наступления события
        /// </summary>
        internal double EventTime;

        /// <summary>
        /// Вставка в календарь событий до всех уведомлений с тем же значением времени
        /// </summary>
        /// <param name="l">Календарь событий</param>
        internal void InsertPrior(SimulationList l)
        {
            Insert(l, PriorCompFunc);
        }

        /// <summary>
        /// Функция сравнения для вставки с приоритетом уведомления о событиях в календарь
        /// </summary>
        /// <param name="a">Ссылка на вставляемое уведомление</param>
        /// <param name="b">Ссылка на очередное уведомление в списке</param>
        /// <returns>true, если ячейка a может быть вставлена перед ячейкой b</returns>
        private static bool PriorCompFunc(ILinkedNode a, ILinkedNode b)
        {
            return (a as SchedulableEventNotice).EventTime <= (b as SchedulableEventNotice).EventTime;
        }

        /// <summary>
        /// Обработка очередного события
        /// </summary>
        public abstract ISimulationAction RunEvent();

        /// <summary>
        /// Изменение времени наступления события и перестановка уведомления в календаре
        /// после всех уведомлений с равным временем наступления события
        /// </summary>
        /// <param name="newTime">Новое время наступления события</param>
        internal void SetTime(double newTime)
        {
            SimulationList lst = GetHeader();
            EventTime = newTime;
            Insert(lst);
        }

        /// <summary>
        /// Изменение времени наступления события и перестановка уведомления в календаре
        /// до всех уведомлений с равным временем наступления события
        /// </summary>
        /// <param name="newTime">Новое время наступления события</param>
        internal void SetTimePrior(double newTime)
        {
            SimulationList lst = GetHeader();
            EventTime = newTime;
            InsertPrior(lst);
        }
    }
}
