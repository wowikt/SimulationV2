using Simulation.Core.Actions;
using Simulation.Core.Components;
using Simulation.Core.Events;
using Simulation.Core.Primitives;
using Simulation.Core.Runners;
using Simulation.Core.Simulation;
using Simulation.Core.Visualizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Core.Processes
{
    /// <summary>
    /// Класс SimProc - главный процесс имитации
    /// </summary>
    public class SimProc : Process, IMainSimulation
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        public SimProc()
        {
            PrevSim = GlobalRunner.CurrSim;
            GlobalRunner.CurrSim = this;
            (this as IMainSimulation).CurrentSimTime = 0;
            GlobalRunner.GlobalSimTime = 0;
            Parent = this;
            Calendar = new SimulationList(GlobalRunner.CalendarOrder, 0, "Календарь");
            Finished = new SimulationList();
            Running = new SimulationList();
            Event = new ProcessEventNotice(0, this);
            Event.InsertFirst(Calendar);
            GlobalRunner.CurrSim = PrevSim;
        }

        /// <summary>
        /// Календарь событий
        /// </summary>
        public SimulationList Calendar
        {
            get;
            set;
        }

        /// <summary>
        /// Сборщик завершенных процессов
        /// </summary>
        public Collector Collect
        {
            get;
            internal set;
        }

        private IMainSimulation PrevSim;

        /// <summary>
        /// Текущее имитационное время
        /// </summary>
        double IMainSimulation.CurrentSimTime
        {
            get;
            set;
        }

        /// <summary>
        /// Список завершенных процессов для периодического удаления
        /// </summary>
        public SimulationList Finished
        {
            get;
            internal set;
        }

        /// <summary>
        /// Список свободных процессов
        /// </summary>
        public SimulationList Running
        {
            get;
            internal set;
        }

        internal static StopSim Stopped = new StopSim();

        /// <summary>
        /// Процесс-визуализатор
        /// </summary>
        internal Visualizer VisProc;

        /// <summary>
        /// Шаг визуализации
        /// </summary>
        public double VisualInterval
        {
            get
            {
                if (VisProc == null)
                {
                    return 0;
                }
                else
                {
                    return VisProc.Interval;
                }
            }
            set
            {
                if (VisProc == null)
                {
                    VisProc = new Visualizer(value);
                    VisProc.Parent = this;
                    VisProc.Activate();
                }
                else
                {
                    VisProc.Interval = value;
                }
            }
        }

        /// <summary>
        /// Очистка статистики
        /// </summary>
        public virtual void ClearStat()
        {
            Calendar.ClearStat();
        }

        /// <summary>
        /// Вывод на консоль календаря событий. Используется с целью диагностики при отладке программ
        /// </summary>
        public void DumpEventQueue()
        {
            SchedulableEventNotice en = Calendar.First as SchedulableEventNotice;
            while (en != null)
            {
                Console.WriteLine(en);
                en = en.Next as SchedulableEventNotice;
            }
        }

        /// <summary>
        /// Завершение имитации
        /// </summary>
        public override void Finish()
        {
            Finished.Finish();
            Running.Finish();
            Calendar.Finish();
            base.Finish();
        }

        /// <summary>
        /// Исполняемый метод процесса имитации. Никогда не должен вызываться прямо или переопределяться
        /// </summary>
        protected override IEnumerator<ISimulationAction> Run()
        {
            Collect = new Collector();
            Init();
            StartingTime = SimTime();
            if (VisProc != null)
            {
                VisProc.Activate();
            }

            var exec = Execute();
            while (exec.MoveNext())
            {
                yield return exec.Current;
            }

            TerminatedState = true;
            StopStat();
            yield return Finalize();
        }

        /// <summary>
        /// Возвращает текущее имитационное время данной имитации
        /// </summary>
        /// <returns>Имитационное время</returns>
        public override double SimTime()
        {
            return (this as IMainSimulation).CurrentSimTime;
        }

        /// <summary>
        /// Запуск процесса имитации. Фактически, запускается диспетчер, управляющий имитацией
        /// </summary>
        public void Start()
        {
            ISimulationAction res;
            int i = 0;
            PrevSim = GlobalRunner.CurrSim;
            GlobalRunner.CurrSim = this;
            do
            {
                // Получить очередную запись календаря событий
                SchedulableEventNotice en = Calendar.First as SchedulableEventNotice;
                // Исполнить событие
                res = en.RunEvent();
                i++;
            }
            while (!(res is FinishAction));
            // Если результат исполнения - пустой указатель, приостановить исполнение
            GlobalRunner.CurrSim = PrevSim;
        }

        /// <summary>
        /// Коррекция статистики к текущему моменту
        /// </summary>
        public virtual void StopStat()
        {
            Calendar.StopStat();
        }
    }
}
