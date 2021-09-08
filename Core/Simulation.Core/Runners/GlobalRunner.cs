using Simulation.Core.Coroutines;
using Simulation.Core.Events;
using Simulation.Core.Primitives;
using Simulation.Core.Simulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Core.Runners
{
    public static class GlobalRunner
    {
        /// <summary>
        /// Периодичность срабатывания очистки завершенных объектов
        /// </summary>
        static public double CleanTimeStep = 1;

        /// <summary>
        /// Ссылка на текущую исполняемую сопрограмму
        /// </summary>
        internal static Coroutine CurrentProc;

        /// <summary>
        /// Глобальный диспетчер, управляющий работой сопрограмм
        /// </summary>
        static internal Dispatcher Dispatch;

        /// <summary>
        /// Возобновляет приостановленное исполнение сопрограмм под управлением глобального диспетчера.
        /// <para>Если глобального диспетчера нет, порождается исключение</para>
        /// </summary>
        static public void ResumeDispatcher()
        {
            if (Dispatch != null)
            {
                Dispatch.Resume();
            }
            else
                throw new ESimulationException("ResumeDispatcher(): попытка возобновления несуществующего диспетчера сопрограмм");
        }

        /// <summary>
        /// Создает глобальный диспетчер, если его нет, и запускает исполнение сопрограмм под его управлением
        /// <para>Если глобальный диспетчер существует, запускает исполнение сопрограмм под его управлением</para>
        /// </summary>
        /// <param name="first">Сопрограмма, с которой начинается исполнение</param>
        static public void RunDispatcher(Coroutine first)
        {
            if (Dispatch == null)
            {
                Dispatch = new Dispatcher(first);
            }
            else
            {
                Dispatch.NextProc = first;
            }
            Dispatch.Resume();
        }

        static internal double GlobalSimTime;

        /// <summary>
        /// Текущая исполняемая имитация
        /// </summary>
        static internal IMainSimulation CurrSim = null;

        public static void SwitchTo(Coroutine coroutine)
        {
            CurrentProc = coroutine;
        }

        public static void Run()
        {
            while (CurrentProc.RunProc.MoveNext())
            {
                var action = CurrentProc.RunProc.Current;
                action.ProcessAction();
            }
        }

        public static void Run(Coroutine coroutine)
        {
            SwitchTo(coroutine);
            Run();
        }

        /// <summary>
        /// Возвращает текущее имитационное время, соответствующее активной исполняемой имитации
        /// </summary>
        /// <returns>Текущее имитационное время</returns>
        static public double SimTime()
        {
            if (CurrSim == null)
                return GlobalSimTime;
            else
                return CurrSim.SimTime();
        }

        /// <summary>
        /// Стандартная функция сравнения для календаря событий. 
        /// Используется при вставке уведомлений о событиях в календарь без приоритета
        /// </summary>
        /// <param name="a">Ссылка на вставляемое уведомление</param>
        /// <param name="b">Ссылка на очередное уведомление списка</param>
        /// <returns>Результат сравнения</returns>
        internal static bool CalendarOrder(ILinkedNode a, ILinkedNode b)
        {
            return (a as SchedulableEventNotice).EventTime < (b as SchedulableEventNotice).EventTime;
        }
    }
}
