using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Core.Primitives
{
    /// <summary>
    /// Интерфейс ILinkedNode содержит определения, обязательные для любых объектов, которые могут быть вставлены в список
    /// </summary>
    public interface ILinkedNode : ILinkageBase
    {
        /// <summary>
        /// Имитационное время вставки узла в список.
        /// Используется для сбора статистики по времени нахождения узлов в списке.
        /// </summary>
        double InsertTime { get; }

        /// <summary>
        /// Проверка, является ли ячейка первой в списке
        /// </summary>
        bool IsFirst { get; }

        /// <summary>
        /// Проверка, является ли ячейка последней в списке
        /// </summary>
        bool IsLast { get; }

        /// <summary>
        /// Возвращает ссылку на заголовочную ячейку списка, в котором находится узел
        /// </summary>
        /// <returns>Ссылка на заголовочную ячейку</returns>
        SimulationList GetHeader();

        /// <summary>
        /// Вставка узла в список. 
        /// Если для узла задана собственная функция сравнения, вставка производится с ее использованием.
        /// В противном случае узел вставляется в список последним
        /// </summary>
        /// <param name="l">Ссылка на заголовочную ячейку списка, в который вставляется текущий узел</param>
        void Insert(SimulationList l);

        /// <summary>
        /// Вставка узла в список с использованием указанной функции сравнения
        /// </summary>
        /// <param name="l">Ссылка на заголовочную ячейку списка, в который вставляется узел</param>
        /// <param name="cmp">Функция сравнения, которую следует использоватьпри вставке узла</param>
        void Insert(SimulationList l, Func<ILinkedNode, ILinkedNode, bool> cmp);

        /// <summary>
        /// Вставка узла в список после указанного
        /// </summary>
        /// <param name="l">Узел, после которого следует вставлять текущий</param>
        void InsertAfter(ILinkageBase l);

        /// <summary>
        /// Вставка узла в список перед указанным
        /// </summary>
        /// <param name="l">Узел, перед которым следует вставлять текущий</param>
        void InsertBefore(ILinkageBase l);

        /// <summary>
        /// Вставка узла в первую позицию списка
        /// </summary>
        /// <param name="l">Ссылка на заголовочную ячейку списка, в который вставляется узел</param>
        void InsertFirst(SimulationList l);

        /// <summary>
        /// Вставка узла в последнюю позицию списка
        /// </summary>
        /// <param name="l">Ссылка на заголовочную ячейку списка, в который вставляется узел</param>
        void InsertLast(SimulationList l);

        /// <summary>
        /// Исключение узла из списка, в котором он находится
        /// </summary>
        void Remove();
    }
}
