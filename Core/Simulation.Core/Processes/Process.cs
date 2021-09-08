using Simulation.Core.Actions;
using Simulation.Core.Components;
using Simulation.Core.Coroutines;
using Simulation.Core.Events;
using Simulation.Core.Extensions;
using Simulation.Core.Primitives;
using Simulation.Core.Runners;
using Simulation.Core.Services;
using Simulation.Core.Simulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Core.Processes
{
    /// <summary>
    /// Класс Process - базовый класс процесса, выполняемого при исполнении имитации
    /// </summary>
    public class Process : Coroutine, ISchedulable, IComponent
    {
        /// <summary>
        /// Конструктор. Устанавливает ссылку на родительскую имитацию.
        /// </summary>
        public Process()
        {
            // Получить ссылку на родительский процесс имитации
            Parent = GlobalRunner.CurrSim;
            // Если родительский процесс существует и данный процесс - не процесс имитации,
            //   встать в список свободных процессов
            if (Parent != null && !(this is SimProc))
            {
                StartRunning();
            }
            OnActionStartingEvent = ActionStartingEvent;
            OnActionFinishedEvent = ActionFinishedEvent;
            //OnEnteredNode = EnteredEvent;
            //OnNodeEnterFailed = NodeEnterFailedEvent;
            //OnReleased = ReleasedEvent;
            // Уведомления о событии нет
            Event = null;
            //Global.CurrProc = this;
        }

        /// <summary>
        /// Уведомление о событии, связанное с процессом
        /// </summary>
        public SchedulableEventNotice Event
        {
            get;
            set;
        }

        /// <summary>
        /// Ссылка на метод обработки события начала обслуживающего действия
        /// </summary>
        public Action<IAction> OnActionStartingEvent
        {
            get;
            internal set;
        }

        /// <summary>
        /// Ссылка на метод обработки события начала обслуживающего действия
        /// </summary>
        public Action<IAction> OnActionFinishedEvent
        {
            get;
            internal set;
        }

        ///// <summary>
        ///// Событийный метод, вызываемый после успешной вставки ячейки в список
        ///// </summary>
        //public NodeEventProc OnEnteredNode
        //{
        //    get;
        //    protected internal set;
        //}

        ///// <summary>
        ///// Событийный метод, вызываемый после неудачной попытки вставки ячейки
        ///// в список по причине переполнения списка
        ///// </summary>
        //public NodeEventProc OnNodeEnterFailed
        //{
        //    get;
        //    protected internal set;
        //}

        ///// <summary>
        ///// Событийный метод, вызываемый после исключения ячейки из списка
        ///// </summary>
        //public NodeEventProc OnReleased
        //{
        //    get;
        //    protected internal set;
        //}

        /// <summary>
        /// Процесс имитации, в рамках которой выполняется данный процесс
        /// </summary>
        public IMainSimulation Parent
        {
            get;
            set;
        }

        /// <summary>
        /// Индекс списка, в который помещается компонент в случае если объект-очередь
        /// имеет несколько списков. Он должен принимать значение от 0 до 
        /// максимального индекса списка, в противном случае порождается исключение.
        /// Если очередь имеет один список, это свойство не принимается во внимание.
        /// </summary>
        public int QueueIndex
        {
            get;
            set;
        }

        /// <summary>
        /// Имитационное время начала работы процесса
        /// </summary>
        public double StartingTime
        {
            get;
            set;
        }

        /// <summary>
        /// Имитационное время, оставшееся до выполнения незавершенного действия.
        /// Используется, если текущее действие было перехвачено другим процессом.
        /// </summary>
        public double TimeLeft
        {
            get;
            set;
        }

        /// <summary>
        /// Время наступления события данного процесса. 
        /// Если события нет, большая отрицательная величина (-1e300).
        /// </summary>
        public double EventTime
        {
            get
            {
                if (Idle)
                    return -1e300;
                else
                    return (Event as SchedulableEventNotice).EventTime;
            }
        }

        /// <summary>
        /// Указывает, находится ли процесс в пассивном или завершенном состоянии
        /// </summary>
        public bool Idle
        {
            get
            {
                return Event == null;
            }
        }

        /// <summary>
        /// Помещает запись уведомления об активации процесса непосредственно после текущего.
        /// <para>Если процесс находится в активном или приостановленном состоянии, 
        /// ничего не делает</para>
        /// </summary>
        public void Activate()
        {
            ActivateDelay(0);
        }

        /// <summary>
        /// Создает запись уведомления об активации процесса 
        /// непосредственно после указанной записи
        /// </summary>
        /// <param name="en">Запись уведомления о событии, после которой 
        /// следует поместить запись нового события</param>
        internal void ActivateAfter(SchedulableEventNotice en)
        {
            if (!Idle)
            {
                return;
            }
            Event = new ProcessEventNotice(en.EventTime, this);
            Event.InsertAfter(en);
        }

        /// <summary>
        /// Создает запись уведомления об активации процесса 
        /// непосредственно после записи указанного процесса
        /// <para>Если процесс находится в активном или приостановленном состоянии, 
        /// ничего не делает</para>
        /// <para>Если процесс-параметр находится в пассивном или завершенном состоянии, 
        /// порождается исключение</para>
        /// </summary>
        /// <param name="p">Процесс, после которого следует активировать данный</param>
        public void ActivateAfter(ISchedulable p)
        {
            if (!Idle)
            {
                return;
            }
            if (p.Idle)
            {
                throw new ESimulationException(
                    "Нельзя выполнить ActivateAfter(p) после пассивного процесса");
            }
            ActivateAfter(p.Event);
        }

        /// <summary>
        /// Создает запись уведомления об активации процесса в указанное время
        /// <para>Если процесс находится в активном или приостановленном состоянии, 
        /// ничего не делает</para>
        /// </summary>
        /// <param name="t">Имитационное время активации процесса</param>
        public void ActivateAt(double t)
        {
            if (!Idle)
            {
                return;
            }
            if (t < SimTime())
            {
                t = SimTime();
            }
            Event = new ProcessEventNotice(t, this);
            Event.Insert(Parent.Calendar);
        }

        /// <summary>
        /// Создает запись уведомления об активации процесса 
        /// непосредственно перед указанной записью
        /// <para>Если процесс находится в активном или приостановленном состоянии, 
        /// ничего не делает</para>
        /// <para>Если процесс-параметр находится в пассивном или завершенном состоянии, 
        /// порождается исключение</para>
        /// </summary>
        /// <param name="en">Запись уведомления о событии, перед которой 
        /// следует поместить запись нового события</param>
        internal void ActivateBefore(SchedulableEventNotice en)
        {
            if (!Idle)
            {
                return;
            }
            Event = new ProcessEventNotice(en.EventTime, this);
            Event.InsertBefore(en);
        }

        /// <summary>
        /// Создает запись уведомления об активации процесса 
        /// непосредственно перед записью указанного процесса
        /// <para>Если процесс находится в активном или приостановленном состоянии, 
        /// ничего не делает</para>
        /// <para>Если процесс-параметр находится в пассивном или завершенном состоянии, 
        /// порождается исключение</para>
        /// </summary>
        /// <param name="p">Процесс, перед которым следует активировать данный</param>
        public void ActivateBefore(ISchedulable p)
        {
            if (!Idle)
            {
                return;
            }
            if (p.Idle)
            {
                throw new ESimulationException(
                    "Нельзя выполнить ActivateAfter(p) после пассивного процесса");
            }
            ActivateBefore(p.Event);
        }

        /// <summary>
        /// Создает запись уведомления об активации процесса с указанной задержкой времени
        /// <para>Если процесс находится в активном или приостановленном состоянии, 
        /// ничего не делает</para>
        /// </summary>
        /// <param name="dt">Задержка относительно текущего имитационного времени</param>
        public void ActivateDelay(double dt)
        {
            ActivateAt(SimTime() + dt);
        }

        /// <summary>
        /// Создает запись уведомления об активации процесса в указанное время 
        /// с приоритетом по отношению к процессам, запланированным ранее на то же время
        /// <para>Если процесс находится в активном или приостановленном состоянии, 
        /// ничего не делает</para>
        /// </summary>
        /// <param name="t">Имитационное время активации процесса</param>
        public void ActivatePriorAt(double t)
        {
            if (!Idle)
            {
                return;
            }
            if (t < SimTime())
            {
                t = SimTime();
            }
            Event = new ProcessEventNotice(t, this);
            Event.InsertPrior(Parent.Calendar);
        }

        /// <summary>
        /// Создает запись уведомления об активации процесса с указанной задержкой времени 
        /// с приоритетом по отношению к процессам, запланированным ранее на то же время
        /// <para>Если процесс находится в активном или приостановленном состоянии, 
        /// ничего не делает</para>
        /// </summary>
        /// <param name="dt">Задержка относительно текущего имитационного времени</param>
        public void ActivatePriorDelay(double dt)
        {
            ActivatePriorAt(SimTime() + dt);
        }

        /// <summary>
        /// Удаление завершенных процессов. 
        /// Используется для оптимизации количества потоков в программе
        /// </summary>
        public void ClearFinished()
        {
            Parent.Collect.Activate();
        }

        /// <summary>
        /// Основной алгоритм работы процесса. Должен быть переопределен в производном классе.
        /// В данном классе ничего не делает.
        /// </summary>
        protected override IEnumerator<ISimulationAction> Execute()
        {
            yield break;
        }

        /// <summary>
        /// Завершение работы процесса. Удаляет уведомление о событии из календаря.
        /// В переопределенном методе производного класса 
        /// ОБЯЗАТЕЛЬНО должен вызываться ПОСЛЕДНИМ.
        /// </summary>
        public override void Finish()
        {
            SchedulableEventNotice en = Event;
            if (Event != null)
            {
                (Event as ProcessEventNotice).Proc = null;
                Event = null;
                en.Finish();
            }
            base.Finish();
        }

        /// <summary>
        /// Включение процесса в список завершенных для последующего автоматического удаления.
        /// <para>Любой процесс, не завершаемый явно извне методом Finish(), 
        /// должен завершать свою работу посредством этого метода</para>
        /// </summary>
        public void GoFinished()
        {
            Insert(Parent.Finished);
        }

        /// <summary>
        /// Обрабатывает все события, запланированные на текущее время, и возобновляет процесс
        /// <para>Эквивалентно вызову Hold(0)</para>
        /// </summary>
        public ISimulationAction Hold()
        {
            return Hold(0);
        }

        /// <summary>
        /// Приостанавливает процесс на заданный промежуток времени
        /// </summary>
        /// <param name="dt">Время приостановки процесса</param>
        public ISimulationAction Hold(double dt)
        {
            return ReactivateDelay(dt);
        }

        /// <summary>
        /// Инициализация процесса
        /// <para>Может использоваться для создания внутренних объектов процесса, 
        /// которые должны создаваться в контексте процесса</para>
        /// <para>В отличие от конструктора, исполняется 
        /// в контексте потока данного процесса</para>
        /// </summary>
        protected virtual void Init()
        {
        }

        /// <summary>
        /// Переводит процесс в пассивное состояние, удаляя его 
        /// запись уведомления о событии из календаря
        /// <para>Если процесс является текущим, управление передается 
        /// следующему по порядку процессу</para>
        /// </summary>
        public ISimulationAction Passivate()
        {
            if (Idle)
            {
                return new ContinueAction(this);
            }

            SchedulableEventNotice pen = Event;
            (Event as ProcessEventNotice).Proc = null;
            Event = null;
            pen.Finish();
            return new ContinueAction(this);
        }

        /// <summary>
        /// Перемещает запись уведомления об активации процесса, 
        /// в том числе приостановленного, непосредственно после текущего.
        /// <para>Если процесс находится в активном состоянии 
        /// (то есть, является текущим), ничего не делает</para>
        /// </summary>
        public ISimulationAction Reactivate()
        {
            return ReactivateDelay(0);
        }

        /// <summary>
        /// Перемещает запись уведомления об активации процесса 
        /// непосредственно после указанной записи
        /// <para>Если процесс находится в пассивном состоянии, 
        /// создает новую запись уведомления</para>
        /// <para>Если процесс является активным, он приостанавливается</para>
        /// <para>Если процесс-параметр находится в пассивном состоянии, 
        /// порождается исключение</para>
        /// </summary>
        /// <param name="en">Запись, после которой следует активировать текущую</param>
        internal ISimulationAction ReactivateAfter(SchedulableEventNotice en)
        {
            if (Idle)
            {
                ActivateAfter(en);
                return new ContinueAction(this);
            }

            if (Event.IsFirst)
            {
                (Event as SchedulableEventNotice).EventTime = en.EventTime;
                Event.InsertAfter(en);
            }
            else
            {
                Event.EventTime = en.EventTime;
                Event.InsertAfter(en);
            }

            return new ContinueAction(this);
        }

        /// <summary>
        /// Перемещает запись уведомления об активации процесса 
        /// непосредственно после записи указанного процесса
        /// <para>Если процесс находится в пассивном состоянии, 
        /// создает новую запись уведомления</para>
        /// <para>Если процесс является активным, он приостанавливается</para>
        /// <para>Если процесс-параметр находится в пассивном состоянии, 
        /// порождается исключение</para>
        /// </summary>
        /// <param name="p">Процесс, перед которым следует активировать данный</param>
        public ISimulationAction ReactivateAfter(ISchedulable p)
        {
            if (Idle)
            {
                ActivateAfter(p);
                return new ContinueAction(this);
            }

            if (p.Idle)
            {
                throw new ESimulationException(
                    "Нельзя выполнить ReactivateAfter(p) после пассивного процесса");
            }

            return ReactivateAfter(p.Event);
        }

        /// <summary>
        /// Перемещает запись уведомления об активации процесса на указанное время
        /// <para>Если процесс находится в пассивном состоянии, 
        /// создает новую запись уведомления</para>
        /// <para>Если процесс является активным, он приостанавливается</para>
        /// </summary>
        /// <param name="t">Имитационное время активации процесса</param>
        public ISimulationAction ReactivateAt(double t)
        {
            if (Idle)
            {
                ActivateAt(t);
                return new ContinueAction(this);
            }

            if (t < SimTime())
            {
                t = SimTime();
            }

            Event.SetTime(t);
            return new ContinueAction(this);
        }

        /// <summary>
        /// Перемещает запись уведомления об активации процесса 
        /// непосредственно перед указанной записью
        /// <para>Если процесс находится в пассивном состоянии, 
        /// создает новую запись уведомления</para>
        /// <para>Если процесс является активным, он приостанавливается</para>
        /// <para>Если процесс-параметр находится в пассивном состоянии, 
        /// порождается исключение</para>
        /// </summary>
        /// <param name="en">Запись, перед которой следует активировать текущую</param>
        internal ISimulationAction ReactivateBefore(SchedulableEventNotice en)
        {
            if (Idle)
            {
                ActivateBefore(en);
                return new ContinueAction(this);
            }

            Event.EventTime = en.EventTime;
            Event.InsertBefore(en);
            return new ContinueAction(this);
        }

        /// <summary>
        /// Перемещает запись уведомления об активации процесса 
        /// непосредственно перед записью указанного процесса
        /// <para>Если процесс находится в пассивном состоянии, 
        /// создает новую запись уведомления</para>
        /// <para>Если процесс является активным, он приостанавливается</para>
        /// <para>Если процесс-параметр находится в пассивном состоянии, 
        /// порождается исключение</para>
        /// </summary>
        /// <param name="p">Процесс, перед которым следует активировать данный</param>
        public ISimulationAction ReactivateBefore(ISchedulable p)
        {
            if (Idle)
            {
                ActivateBefore(p);
                return new ContinueAction(this);
            }

            if (p.Idle)
            {
                throw new ESimulationException(
                    "Нельзя выполнить ReactivateBefore(p) перед пассивным процессом");
            }

            return ReactivateBefore(p.Event);
        }

        /// <summary>
        /// Перемещает запись уведомления об активации процесса 
        /// с указанной задержкой времени относительно текущего процесса.
        /// <para>Если процесс находится в пассивном состоянии, 
        /// создает новую запись уведомления</para>
        /// <para>Если процесс является активным, он приостанавливается</para>
        /// </summary>
        /// <param name="dt">Имитационное время активации процесса</param>
        public ISimulationAction ReactivateDelay(double dt)
        {
            return ReactivateAt(SimTime() + dt);
        }

        /// <summary>
        /// Перемещает запись уведомления об активации процесса 
        /// на указанное время с приоритетом.
        /// <para>Если процесс находится в пассивном состоянии, 
        /// создает новую запись уведомления</para>
        /// <para>Если процесс является активным, он приостанавливается</para>
        /// </summary>
        /// <param name="t">Имитационное время активации процесса</param>
        public ISimulationAction ReactivatePriorAt(double t)
        {
            if (Idle)
            {
                ActivatePriorAt(t);
                return new ContinueAction(this);
            }

            if (t < SimTime())
            {
                t = SimTime();
            }

            Event.SetTimePrior(t);
            return new ContinueAction(this);
        }

        /// <summary>
        /// Перемещает запись уведомления об активации процесса 
        /// с указанной задержкой времени относительно текущего процесса с приоритетом.
        /// <para>Если процесс находится в пассивном состоянии, 
        /// создает новую запись уведомления</para>
        /// <para>Если процесс является активным, он приостанавливается</para>
        /// </summary>
        /// <param name="dt">Имитационное время активации процесса</param>
        public ISimulationAction ReactivatePriorDelay(double dt)
        {
            return ReactivatePriorAt(SimTime() + dt);
        }

        /// <summary>
        /// Организует исполнение метода Execute() в контексте процесса
        /// </summary>
        protected override IEnumerator<ISimulationAction> Run()
        {
            GlobalRunner.CurrentProc = this;
            Init();
            StartingTime = SimTime();
            using (var execute = Execute())
            {
                while(execute.MoveNext())
                {
                    yield return execute.Current;
                }
            }

            TerminatedState = true;
            SchedulableEventNotice en = Event;
            (Event as ProcessEventNotice).Proc = null;
            Event = null;
            en.Finish();
        }

        /// <summary>
        /// Возвращает текущее имитационное время. 
        /// Обращается к родительскому процесу имитации.
        /// </summary>
        /// <returns>Текущее имитационное время</returns>
        public virtual double SimTime()
        {
            return Parent.SimTime();
        }

        /// <summary>
        /// Включение процесса в список свободных. Используется также 
        /// для извлечения процесса из очереди ожидания 
        /// (при этом он все равно попадает в список свободных процессов)
        /// </summary>
        public void StartRunning()
        {
            Insert(Parent.Running);
        }

        /// <summary>
        /// Стандартный метод обработки обслуживающего действия.
        /// В данном классе ничего не делает.
        /// </summary>
        protected internal virtual void ActionStartingEvent(IAction act)
        {
        }

        /// <summary>
        /// Стандартный метод обработки обслуживающего действия.
        /// В данном классе ничего не делает.
        /// </summary>
        protected internal virtual void ActionFinishedEvent(IAction act)
        {
        }

        /// <summary>
        /// Постановка процесса в очередь и перевод его в режим ожидания
        /// <para>Если очередь имеет максимальный размер, процесс 
        /// не ставится в очередь</para>
        /// </summary>
        /// <param name="q">Очередь ожидания</param>
        /// <returns><para>false, если процесс не поставлен в очередь.</para> 
        /// <para>true, если процесс успешно поставлен 
        /// и возобновлен после ожидания</para></returns>
        public ISimulationAction Wait(SimulationList q)
        {
            if (q.MaxSize == 0 || q.Size < q.MaxSize)
            {
                Insert(q);
                return Passivate();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Выполняет обслуживающее действие
        /// </summary>
        /// <param name="serv">Обслуживающее действие</param>
        /// <param name="dt">Планируемая продолжительность действия</param>
        /// <returns>true, если действие было успешно выполнено. 
        /// false, если компонент не удалось поставить в очередь 
        /// по причине ее заполненности.</returns>
        public bool DoService(Service serv, double dt)
        {
            if (serv.Queue.MaxSize > 0 && serv.Queue.Size >= serv.Queue.MaxSize)
            {
                return false;
            }
            TimeLeft = dt;
            serv.Agents.ActivateFirst();
            Wait(serv.Queue);
            return true;
        }

        /// <summary>
        /// Выполняет обслуживающее действие.
        /// Продолжительность действия определяется делегатом, находящимся 
        /// в объекте действия. Если делегат отсутствует, порождается исключение.
        /// </summary>
        /// <param name="serv">Обслуживающее действие</param>
        /// <returns>true, если действие было успешно выполнено. 
        /// false, если компонент не удалось поставить в очередь 
        /// по причине ее заполненности.</returns>
        protected ISimulationAction DoService(Service serv, out bool result)
        {
            if (serv.Queue.MaxSize > 0 && serv.Queue.Size >= serv.Queue.MaxSize ||
                serv.Queue.MaxSize == 0 && serv.ServiceStat.Running + serv.ServiceStat.Blocked >= serv.Capacity)
            {
                result = false;
                return new ContinueAction(this);
            }

            if (serv.Duration == null)
            {
                throw new ESimulationException(
                    "DoService(serv): у объекта действия не задан делегат, " +
                    "вычисляющий длительность обслуживания");
            }

            TimeLeft = serv.Duration();
            serv.Agents.ActivateFirst();
            result = true;
            return Wait(serv.Queue);
        }

        /// <summary>
        /// Стандартный событийный метод для события вставки в очередь.
        /// В данном классе ничего не делает
        /// </summary>
        /// <param name="node">Узел, в который был помещен объект</param>
        protected internal virtual void EnteredEvent(LinkedNode node)
        {
        }

        /// <summary>
        /// Стандартный событийный метод для события неудачи вставки в очередь.
        /// В данном классе ничего не делает
        /// </summary>
        /// <param name="node">Очередь, в которую предпринималась попытка 
        /// вставки объекта</param>
        protected internal virtual void NodeEnterFailedEvent(LinkedNode node)
        {
        }

        /// <summary>
        /// Стандартный событийный метод для события исключения из очереди.
        /// В данном классе ничего не делает
        /// </summary>
        /// <param name="node">Очередь, из которой был исключен объект</param>
        protected internal virtual void ReleasedEvent(LinkedNode node)
        {
        }
    }
}
