using Simulation.Core.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Core.Extensions
{
    /// <summary>
    /// Класс Activators содержит методы расширения для активации массивов и списков процессов
    /// </summary>
    public static class Activators
    {
        /// <summary>
        /// Активирует все пассивные процессы в массиве.
        /// Активные и приостановленные процессы игнорируются
        /// </summary>
        /// <param name="actions">Массив ссылок на процессы</param>
        /// <returns>true, если был активирован хотя бы один процесс или компонент</returns>
        public static bool ActivateAll(this IEnumerable<ISchedulable> actions)
        {
            bool result = false;
            foreach (var action in actions)
            {
                if (action.Idle)
                {
                    action.Activate();
                    result = true;
                }
            }

            return result;
        }

        /// <summary>
        /// Активирует все пассивные процессы в списке.
        /// Активные и приостановленные процессы, а также ячейки, не являющиеся процессами, игнорируются
        /// </summary>
        /// <param name="actions">Список, в котором могут находиться процессы</param>
        /// <returns>true, если был активирован хотя бы один процесс или компонент</returns>
        public static bool ActivateAll(this SimulationList actions)
        {
            ILinkedNode node = actions.First;
            bool result = false;
            while (node != null)
            {
                if (node is ISchedulable && (node as ISchedulable).Idle)
                {
                    (node as ISchedulable).Activate();
                    result = true;
                }

                node = node.Next;
            }

            return result;
        }

        /// <summary>
        /// Активирует все пассивные процессы в массиве после указанного события.
        /// Активные и приостановленные процессы игнорируются
        /// </summary>
        /// <param name="actions">Массив ссылок на процессы</param>
        /// <param name="actionBefore">Событие, после которого следует активировать процессы из массива</param>
        /// <returns>true, если был активирован хотя бы один процесс или компонент</returns>
        public static bool ActivateAllAfter(this IEnumerable<ISchedulable> actions, ISchedulable actionBefore)
        {
            bool res = false;
            foreach (var action in actions)
            {
                if (action.Idle)
                {
                    action.ActivateAfter(actionBefore);
                    res = true;
                }
            }

            return res;
        }

        /// <summary>
        /// Активирует все пассивные процессы в списке после указанного события.
        /// Активные и приостановленные процессы, а также ячейки, не являющиеся процессами, игнорируются
        /// </summary>
        /// <param name="actions">Список, в котором могут находиться процессы</param>
        /// <param name="actionBefore">Событие, после которого следует активировать процессы из списка</param>
        /// <returns>true, если был активирован хотя бы один процесс или компонент</returns>
        public static bool ActivateAllAfter(this SimulationList actions, ISchedulable actionBefore)
        {
            ILinkedNode node = actions.First;
            bool result = false;
            while (node != null)
            {
                if (node is ISchedulable && (node as ISchedulable).Idle)
                {
                    (node as ISchedulable).ActivateAfter(actionBefore);
                    result = true;
                }

                node = node.Next;
            }

            return result;
        }

        /// <summary>
        /// Активирует все пассивные процессы в массиве в заданный момент времени.
        /// Активные и приостановленные процессы игнорируются
        /// </summary>
        /// <param name="actions">Массив ссылок на процессы</param>
        /// <param name="t">Время активации всех процессов массива</param>
        /// <returns>true, если был активирован хотя бы один процесс или компонент</returns>
        public static bool ActivateAllAt(this IEnumerable<ISchedulable> actions, double t)
        {
            bool result = false;
            foreach (var action in actions)
            {
                if (action.Idle)
                {
                    action.ActivateAt(t);
                    result = true;
                }
            }

            return result;
        }

        /// <summary>
        /// Активирует все пассивные процессы в списке в заданный момент времени.
        /// Активные и приостановленные процессы, а также ячейки, не являющиеся процессами, игнорируются
        /// </summary>
        /// <param name="actions">Список, в котором могут находиться процессы</param>
        /// <param name="t">Время активации всех процессов из списка</param>
        /// <returns>true, если был активирован хотя бы один процесс или компонент</returns>
        public static bool ActivateAllAt(this SimulationList actions, double t)
        {
            ILinkedNode node = actions.First;
            bool result = false;
            while (node != null)
            {
                if (node is ISchedulable && (node as ISchedulable).Idle)
                {
                    (node as ISchedulable).ActivateAt(t);
                    result = true;
                }

                node = node.Next;
            }

            return result;
        }

        /// <summary>
        /// Активирует все пассивные процессы в массиве перед указанным событием.
        /// Активные и приостановленные процессы игнорируются
        /// </summary>
        /// <param name="actions">Массив ссылок на процессы</param>
        /// <param name="actionAfter">Событие, перед которым следует активировать процессы из массива</param>
        /// <returns>true, если был активирован хотя бы один процесс или компонент</returns>
        public static bool ActivateAllBefore(this IEnumerable<ISchedulable> actions, ISchedulable actionAfter)
        {
            bool res = false;
            foreach (var action in actions)
            {
                if (action.Idle)
                {
                    action.ActivateBefore(actionAfter);
                    res = true;
                }
            }

            return res;
        }

        /// <summary>
        /// Активирует все пассивные процессы в списке перед указанным событием.
        /// Активные и приостановленные процессы, а также ячейки, не являющиеся процессами, игнорируются
        /// </summary>
        /// <param name="actions">Список, в котором могут находиться процессы</param>
        /// <param name="actionAfter">Событие, перед которым следует активировать процессы из списка</param>
        /// <returns>true, если был активирован хотя бы один процесс или компонент</returns>
        public static bool ActivateAllBefore(this SimulationList actions, ISchedulable actionAfter)
        {
            ILinkedNode node = actions.First;
            bool result = false;
            while (node != null)
            {
                if (node is ISchedulable && (node as ISchedulable).Idle)
                {
                    (node as ISchedulable).ActivateBefore(actionAfter);
                    result = true;
                }

                node = node.Next;
            }

            return result;
        }

        /// <summary>
        /// Активирует все пассивные процессы в массиве с заданной задержкой времени.
        /// Активные и приостановленные процессы игнорируются
        /// </summary>
        /// <param name="actions">Массив ссылок на процессы</param>
        /// <param name="dt">Задержка активации всех процессов массива</param>
        /// <returns>true, если был активирован хотя бы один процесс или компонент</returns>
        public static bool ActivateAllDelay(this IEnumerable<ISchedulable> actions, double dt)
        {
            bool result = false;
            foreach (var action in actions)
            {
                if (action.Idle)
                {
                    action.ActivateDelay(dt);
                    result = true;
                }
            }

            return result;
        }

        /// <summary>
        /// Активирует все пассивные процессы в списке с заданной задержкой времени.
        /// Активные и приостановленные процессы, а также ячейки, не являющиеся процессами, игнорируются
        /// </summary>
        /// <param name="actions">Список, в котором могут находиться процессы</param>
        /// <param name="dt">Задержка активации всех процессов из списка</param>
        /// <returns>true, если был активирован хотя бы один процесс или компонент</returns>
        public static bool ActivateAllDelay(this SimulationList actions, double dt)
        {
            ILinkedNode node = actions.First;
            bool result = false;
            while (node != null)
            {
                if (node is ISchedulable && (node as ISchedulable).Idle)
                {
                    (node as ISchedulable).ActivateDelay(dt);
                    result = true;
                }

                node = node.Next;
            }

            return result;
        }

        /// <summary>
        /// Активирует все пассивные процессы в массиве в заданный момент времени с приоритетом.
        /// Активные и приостановленные процессы игнорируются
        /// </summary>
        /// <param name="actions">Массив ссылок на процессы</param>
        /// <param name="t">Время активации всех процессов массива</param>
        /// <returns>true, если был активирован хотя бы один процесс или компонент</returns>
        public static bool ActivateAllPriorAt(this IEnumerable<ISchedulable> actions, double t)
        {
            ISchedulable prev = null;
            bool result = false;
            foreach (var action in actions)
            {
                if (action.Idle)
                {
                    if (prev == null)
                    {
                        action.ActivatePriorAt(t);
                    }
                    else
                    {
                        action.ActivateAfter(prev);
                    }

                    prev = action;
                    result = true;
                }
            }

            return result;
        }

        /// <summary>
        /// Активирует все пассивные процессы в списке в заданный момент времени с приоритетом.
        /// Активные и приостановленные процессы, а также ячейки, не являющиеся процессами, игнорируются
        /// </summary>
        /// <param name="actions">Список, в котором могут находиться процессы</param>
        /// <param name="t">Время активации всех процессов из списка</param>
        /// <returns>true, если был активирован хотя бы один процесс или компонент</returns>
        public static bool ActivateAllPriorAt(this SimulationList actions, double t)
        {
            ISchedulable prev = null;
            ILinkedNode node = actions.First;
            bool res = false;
            while (node != null)
            {
                if (node is ISchedulable && (node as ISchedulable).Idle)
                {
                    if (prev == null)
                    {
                        (node as ISchedulable).ActivatePriorAt(t);
                    }
                    else
                    {
                        (node as ISchedulable).ActivateAfter(prev);
                    }

                    prev = (node as ISchedulable);
                    res = true;
                }

                node = node.Next;
            }

            return res;
        }

        /// <summary>
        /// Активирует все пассивные процессы в массиве с заданной задержкой времени с приоритетом.
        /// Активные и приостановленные процессы игнорируются
        /// </summary>
        /// <param name="actions">Массив ссылок на процессы</param>
        /// <param name="dt">Задержка активации всех процессов массива</param>
        /// <returns>true, если был активирован хотя бы один процесс или компонент</returns>
        public static bool ActivateAllPriorDelay(this IEnumerable<ISchedulable> actions, double dt)
        {
            ISchedulable prev = null;
            bool result = false;
            foreach (var action in actions)
            {
                if (action.Idle)
                {
                    if (prev == null)
                    {
                        action.ActivatePriorDelay(dt);
                    }
                    else
                    {
                        action.ActivateAfter(prev);
                    }

                    prev = action;
                    result = true;
                }
            }

            return result;
        }

        /// <summary>
        /// Активирует все пассивные процессы в списке с заданной задержкой времени с приоритетом.
        /// Активные и приостановленные процессы, а также ячейки, не являющиеся процессами, игнорируются
        /// </summary>
        /// <param name="act">Список, в котором могут находиться процессы</param>
        /// <param name="dt">Задержка активации всех процессов из списка</param>
        /// <returns>true, если был активирован хотя бы один процесс или компонент</returns>
        public static bool ActivateAllPriorDelay(this SimulationList act, double dt)
        {
            ISchedulable prev = null;
            ILinkedNode node = act.First;
            bool result = false;
            while (node != null)
            {
                if (node is ISchedulable && (node as ISchedulable).Idle)
                {
                    if (prev == null)
                    {
                        (node as ISchedulable).ActivatePriorDelay(dt);
                    }
                    else
                    {
                        (node as ISchedulable).ActivateAfter(prev);
                    }

                    prev = (node as ISchedulable);
                    result = true;
                }

                node = node.Next;
            }

            return result;
        }

        /// <summary>
        /// Активирует первый пассивный процесс из массива. Остальные процессы не меняют состояние
        /// </summary>
        /// <param name="actions">Массив процессов</param>
        /// <returns>true, если был активирован процесс или компонент</returns>
        public static bool ActivateFirst(this IEnumerable<ISchedulable> actions)
        {
            ISchedulable idleProc = actions.FirstIdle();
            if (idleProc != null)
            {
                idleProc.Activate();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Активирует первый пассивный процесс из списка. Остальные процессы не меняют состояние
        /// </summary>
        /// <param name="actions">Список, в котором могут быть процессы. 
        /// Элементы списка, не являющиеся процессами, а также пассивные процессы, игнорируются</param>
        /// <returns>true, если был активирован процесс или компонент</returns>
        public static bool ActivateFirst(this SimulationList actions)
        {
            ISchedulable idleProc = actions.FirstIdle();
            if (idleProc != null)
            {
                idleProc.Activate();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Активирует первый пассивный процесс из массива после указанного. Остальные процессы не меняют состояние
        /// </summary>
        /// <param name="actions">Массив процессов</param>
        /// <param name="actionBefore">Процесс, после которого активируется первый подходящий процесс из массива</param>
        /// <returns>true, если был активирован процесс или компонент</returns>
        public static bool ActivateFirstAfter(this IEnumerable<ISchedulable> actions, ISchedulable actionBefore)
        {
            ISchedulable idleProc = actions.FirstIdle();
            if (idleProc != null)
            {
                idleProc.ActivateAfter(actionBefore);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Активирует первый пассивный процесс из списка после указанного. Остальные процессы не меняют состояние
        /// </summary>
        /// <param name="actions">Список, в котором могут быть процессы. 
        /// Элементы списка, не являющиеся процессами, а также пассивные процессы, игнорируются</param>
        /// <param name="actionBefore">Процесс, после которого активируется первый подходящий процесс из списка</param>
        /// <returns>true, если был активирован процесс или компонент</returns>
        public static bool ActivateFirstAfter(this SimulationList actions, ISchedulable actionBefore)
        {
            ISchedulable idleProc = actions.FirstIdle();
            if (idleProc != null)
            {
                idleProc.ActivateAfter(actionBefore);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Активирует первый пассивный процесс из массива в заданный момент времени. Остальные процессы не меняют состояние
        /// </summary>
        /// <param name="actions">Массив процессов</param>
        /// <param name="t">Время активации процесса</param>
        /// <returns>true, если был активирован процесс или компонент</returns>
        public static bool ActivateFirstAt(this IEnumerable<ISchedulable> actions, double t)
        {
            ISchedulable idleProc = actions.FirstIdle();
            if (idleProc != null)
            {
                idleProc.ActivateAt(t);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Активирует первый пассивный процесс из списка в заданный момент времени. Остальные процессы не меняют состояние
        /// </summary>
        /// <param name="actions">Список, в котором могут быть процессы. 
        /// Элементы списка, не являющиеся процессами, а также пассивные процессы, игнорируются</param>
        /// <param name="t">Время активации процесса</param>
        /// <returns>true, если был активирован процесс или компонент</returns>
        public static bool ActivateFirstAt(this SimulationList actions, double t)
        {
            ISchedulable idleProc = actions.FirstIdle();
            if (idleProc != null)
            {
                idleProc.ActivateAt(t);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Активирует первый пассивный процесс из массива перед указанным. Остальные процессы не меняют состояние
        /// </summary>
        /// <param name="actions">Массив процессов</param>
        /// <param name="actionAfter">Процесс, перед которым активируется первый подходящий процесс из массива</param>
        /// <returns>true, если был активирован процесс или компонент</returns>
        public static bool ActivateFirstBefore(this IEnumerable<ISchedulable> actions, ISchedulable actionAfter)
        {
            ISchedulable idleProc = actions.FirstIdle();
            if (idleProc != null)
            {
                idleProc.ActivateBefore(actionAfter);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Активирует первый пассивный процесс из списка перед указанным. Остальные процессы не меняют состояние
        /// </summary>
        /// <param name="actions">Список, в котором могут быть процессы. 
        /// Элементы списка, не являющиеся процессами, а также пассивные процессы, игнорируются</param>
        /// <param name="actionAfter">Процесс, перед которым активируется первый подходящий процесс из списка</param>
        /// <returns>true, если был активирован процесс или компонент</returns>
        public static bool ActivateFirstBefore(this SimulationList actions, ISchedulable actionAfter)
        {
            ISchedulable idleProc = actions.FirstIdle();
            if (idleProc != null)
            {
                idleProc.ActivateBefore(actionAfter);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Активирует первый пассивный процесс из массива с заданным интервалом времени. 
        /// Остальные процессы не меняют состояние
        /// </summary>
        /// <param name="actions">Массив процессов</param>
        /// <param name="dt">Интервал времени для активации процесса</param>
        /// <returns>true, если был активирован процесс или компонент</returns>
        public static bool ActivateFirstDelay(this IEnumerable<ISchedulable> actions, double dt)
        {
            ISchedulable idleProc = actions.FirstIdle();
            if (idleProc != null)
            {
                idleProc.ActivateDelay(dt);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Активирует первый пассивный процесс из списка с заданным интервалом времени. 
        /// Остальные процессы не меняют состояние
        /// </summary>
        /// <param name="actions">Список, в котором могут быть процессы. 
        /// Элементы списка, не являющиеся процессами, а также пассивные процессы, игнорируются</param>
        /// <param name="dt">Интервал времени для активации процесса</param>
        /// <returns>true, если был активирован процесс или компонент</returns>
        public static bool ActivateFirstDelay(this SimulationList actions, double dt)
        {
            ISchedulable idleProc = actions.FirstIdle();
            if (idleProc != null)
            {
                idleProc.ActivateDelay(dt);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Активирует первый пассивный процесс из массива в заданный момент времени с приоритетом. 
        /// Остальные процессы не меняют состояние
        /// </summary>
        /// <param name="actions">Массив процессов</param>
        /// <param name="t">Время активации процесса</param>
        /// <returns>true, если был активирован процесс или компонент</returns>
        public static bool ActivateFirstPriorAt(this IEnumerable<ISchedulable> actions, double t)
        {
            ISchedulable idleProc = actions.FirstIdle();
            if (idleProc != null)
            {
                idleProc.ActivatePriorAt(t);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Активирует первый пассивный процесс из списка в заданный момент времени с приоритетом. 
        /// Остальные процессы не меняют состояние
        /// </summary>
        /// <param name="actions">Список, в котором могут быть процессы. 
        /// Элементы списка, не являющиеся процессами, а также пассивные процессы, игнорируются</param>
        /// <param name="t">Время активации процесса</param>
        /// <returns>true, если был активирован процесс или компонент</returns>
        public static bool ActivateFirstPriorAt(this SimulationList actions, double t)
        {
            ISchedulable idleProc = actions.FirstIdle();
            if (idleProc != null)
            {
                idleProc.ActivatePriorAt(t);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Активирует первый пассивный процесс из массива с заданным интервалом времени с приоритетом. 
        /// Остальные процессы не меняют состояние
        /// </summary>
        /// <param name="actions">Массив процессов</param>
        /// <param name="dt">Интервал времени для активации процесса</param>
        /// <returns>true, если был активирован процесс или компонент</returns>
        public static bool ActivateFirstPriorDelay(this IEnumerable<ISchedulable> actions, double dt)
        {
            ISchedulable idleProc = actions.FirstIdle();
            if (idleProc != null)
            {
                idleProc.ActivatePriorDelay(dt);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Активирует первый пассивный процесс из списка с заданным интервалом времени с приоритетом. 
        /// Остальные процессы не меняют состояние
        /// </summary>
        /// <param name="actions">Список, в котором могут быть процессы. 
        /// Элементы списка, не являющиеся процессами, а также пассивные процессы, игнорируются</param>
        /// <param name="dt">Интервал времени для активации процесса</param>
        /// <returns>true, если был активирован процесс или компонент</returns>
        public static bool ActivateFirstPriorDelay(this SimulationList actions, double dt)
        {
            ISchedulable idleProc = actions.FirstIdle();
            if (idleProc != null)
            {
                idleProc.ActivatePriorDelay(dt);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Находит первый пассивный процесс или компонент в массиве
        /// </summary>
        /// <param name="actions">Массив процессов и/или компонентов</param>
        /// <returns>Первый пассивный процесс или компонент</returns>
        public static ISchedulable FirstIdle(this IEnumerable<ISchedulable> actions)
        {
            foreach (var action in actions)
            {
                if (action.Idle)
                {
                    return action;
                }
            }

            return null;
        }

        /// <summary>
        /// Находит первый пассивный процесс или компонент в списке
        /// </summary>
        /// <param name="act">Список процессов и/или компонентов</param>
        /// <returns>Первый пассивный процесс или компонент</returns>
        public static ISchedulable FirstIdle(this SimulationList act)
        {
            ILinkedNode node = act.First;
            while (node != null)
            {
                if (node is ISchedulable && (node as ISchedulable).Idle)
                {
                    return node as ISchedulable;
                }

                node = node.Next;
            }

            return null;
        }

        /// <summary>
        /// Находит последний пассивный процесс или компонент в массиве
        /// </summary>
        /// <param name="actions">Массив процессов и/или компонентов</param>
        /// <returns>Последний пассивный процесс или компонент</returns>
        public static ISchedulable LastIdle(this IEnumerable<ISchedulable> actions)
        {
            ISchedulable lastIdleAction = null;
            foreach (var action in actions)
            {
                if(action.Idle)
                {
                    lastIdleAction = action;
                }
            }

            return lastIdleAction;
        }

        /// <summary>
        /// Находит последний пассивный процесс или компонент в списке
        /// </summary>
        /// <param name="act">Список процессов и/или компонентов</param>
        /// <returns>Последний пассивный процесс или компонент</returns>
        public static ISchedulable LastIdle(this SimulationList act)
        {
            ILinkedNode node = act.Last;
            while (node != null)
            {
                if (node is ISchedulable && (node as ISchedulable).Idle)
                {
                    return node as ISchedulable;
                }

                node = node.Prev;
            }

            return null;
        }
    }
}
