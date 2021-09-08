using Simulation.Core.Components;
using Simulation.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Core.Services
{
    /// <summary>
    /// Класс ServiceAgent представляет компонент, выполняющий обслуживающее действие
    /// </summary>
    internal class ServiceAgent : SchedulableComponent
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="myService">Ссылка на действие, управляющее агентом</param>
        public ServiceAgent(Service myService)
        {
            MyService = myService;
        }

        /// <summary>
        /// Ссылка на действие, управляющее агентом
        /// </summary>
        internal Service MyService;

        /// <summary>
        /// Обслуживаемый компонент
        /// </summary>
        private IComponent Serviced;

        /// <summary>
        /// Признак занятости обслуживающего действия
        /// </summary>
        public bool Busy
        {
            get;
            internal set;
        }

        /// <summary>
        /// Событие начала работы
        /// </summary>
        protected override void StartEvent()
        {
            // Проверить наличие очередного компонента в очереди
            if (MyService.Queue.Empty())
            {
                return;
            }

            // Извлечь первый компонент
            Serviced = MyService.Queue.First as IComponent;
            Serviced.StartRunning();

            // Агент занят обслуживанием
            Busy = true;

            // Если данному действию предшествовал другое, сообщить
            //   о начале действия для разблокировки возможно заблокированного действия
            if (MyService.PrevService != null)
            {
                MyService.PrevService.Agents.ActivateFirst();
            }

            // Уведомить компонент о начале обслуживания
            Serviced.OnActionStartingEvent(MyService);

            // Зафиксировать начало действия в статистике
            MyService.ServiceStat.Start(SimTime());

            // Запланировать окончание обслуживания
            ReactivateDelay(Serviced.TimeLeft, FinishedEvent);
            Serviced.TimeLeft = 0;
        }

        /// <summary>
        /// Событие окончания обслуживания
        /// </summary>
        protected internal void FinishedEvent()
        {
            // Зафиксировать в статистике окончание обслуживания
            MyService.ServiceStat.Finish(SimTime());

            // Если указано следующее действие, проверить возможность 
            //   помещения компонента в его очередь
            var nextService = MyService.NextService;
            if (nextService != null && 
                (nextService.Queue.MaxSize > 0 && nextService.Queue.Size >= nextService.Queue.MaxSize ||
                nextService.Queue.MaxSize == 0 && nextService.ServiceStat.Running + nextService.ServiceStat.Blocked >= nextService.Capacity))
            {
                // Если поместить нельзя, начать блокировку
                MyService.ServiceStat.StartBlock(SimTime());
                NextScheduledEvent = BlockFinishEvent;
                return;
            }

            // По окончании обслуживания активировать обслуженный компонент
            Serviced.OnActionFinishedEvent(MyService);
            Serviced = null;

            // Агент свободен
            Busy = false;

            // Перейти к извлечению следующего компонента
            Reactivate(StartEvent);

            // Если данному действию предшествовал другое, сообщить
            //   о завершении действия для разблокировки возможно заблокированного действия
            if (MyService.PrevService != null)
            {
                MyService.PrevService.Agents.ActivateFirst();
            }
        }

        /// <summary>
        /// Событие окончания блокировки
        /// </summary>
        public void BlockFinishEvent()
        {
            // Проверить возможность разблокировки
            var nextService = MyService.NextService;
            if ((nextService.Queue.MaxSize > 0 && nextService.Queue.Size >= nextService.Queue.MaxSize ||
                nextService.Queue.MaxSize == 0 && nextService.ServiceStat.Running + nextService.ServiceStat.Blocked >= nextService.Capacity))
            {
                return;
            }

            // Разблокировать действие
            MyService.ServiceStat.FinishBlock(SimTime());

            // По окончании обслуживания активировать обслуженный компонент
            Serviced.OnActionFinishedEvent(MyService);
            Serviced = null;

            // Агент свободен
            Busy = false;

            // Перейти к извлечению следующего компонента
            Reactivate(StartEvent);
        }
    }
}
