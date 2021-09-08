using Simulation.Core.Actions;
using Simulation.Core.Components;
using Simulation.Core.Primitives;
using Simulation.Core.Runners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Core.Events
{
    /// <summary>
    /// Уведомление о событии, связанное с объектом-компонентом
    /// </summary>
    internal class ComponentEventNotice : SchedulableEventNotice
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="time">Время события</param>
        /// <param name="comp">Компонент, обрабатывающий событие</param>
        public ComponentEventNotice(double time, SchedulableComponent comp)
            : base(time)
        {
            Comp = comp;
        }

        /// <summary>
        /// Компонент, обрабатывающий событие
        /// </summary>
        internal SchedulableComponent Comp;

        public override void Finish()
        {
            if (Comp != null)
            {
                (Comp as ISchedulable).Event = null;
            }
            base.Finish();
        }

        /// <summary>
        /// Обработка события
        /// </summary>
        /// <returns></returns>
        public override ISimulationAction RunEvent()
        {
            GlobalRunner.CurrSim.CurrentSimTime = EventTime;
            GlobalRunner.GlobalSimTime = EventTime;

            // Исполнить событийный метод компонента
            ISimulationAction res = Comp.Run();

            // Если уведомление не было перемещено (реактивировано), удалить его из календаря
            if (IsFirst)
            {
                Remove();
                // Если в компоненте не назначено другое уведомление о событии, отсоединить уведомление от компонента
                if ((Comp as ISchedulable).Event == this)
                {
                    (Comp as ISchedulable).Event = null;
                }
            }

            // Результат - ссылка на компонент-обработчик
            return res;
        }

        /// <summary>
        /// Отображение содержимого уведомления о событии в текстовом виде
        /// </summary>
        /// <returns>Класс процесса и время запланированного события</returns>
        public override string ToString()
        {
            return "Уведомление о событии компонента " + Comp.ToString() + " в " + EventTime.ToString();
        }
    }
}
