﻿using Simulation.Core.Runners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Core.Primitives
{
    /// <summary>
    /// Класс Link - базовый класс внутреннего узла (ячейки) списка
    /// </summary>
    public class LinkedNode : ILinkedNode
    {
        /// <summary>
        /// Конструктор по умолчанию. Создается ячейка, не включенная ни в один список
        /// </summary>
        public LinkedNode()
        {
            FPrev = FNext = HeaderNode = null;
        }

        /// <summary>
        /// Поле связи. Ссылка на предыдущий узел списка
        /// </summary>
        internal ILinkageBase FPrev;

        /// <summary>
        /// Поле связи. Ссылка на следующий узел списка
        /// </summary>
        internal ILinkageBase FNext;

        /// <summary>
        /// Ссылка на заголовочную ячейку списка
        /// </summary>
        public SimulationList HeaderNode
        {
            get;
            internal set;
        }

        /// <summary>
        /// Имитационное время вставки узла в список.
        /// Используется для сбора статистики по времени нахождения узлов в списке.
        /// </summary>
        public double InsertTime
        {
            get;
            internal set;
        }

        /// <summary>
        /// Проверка, является ли ячейка первой в списке
        /// </summary>
        public bool IsFirst
        {
            get
            {
                return (Prev == null);
            }
        }

        /// <summary>
        /// Проверка, является ли ячейка последней в списке
        /// </summary>
        public bool IsLast
        {
            get
            {
                return (Next == null);
            }
        }

        /// <summary>
        /// Только для чтения. Ссылка на предыдущий узел, 
        /// если он является внутренней ячейкой списка.
        /// В противном случае - null.
        /// </summary>
        public ILinkedNode Prev
        {
            get
            {
                if (FPrev is ILinkedNode)
                    return FPrev as ILinkedNode;
                else
                    return null;
            }
        }

        /// <summary>
        /// Только для чтения. Ссылка на следующий узел, 
        /// если он является внутренней ячейкой списка.
        /// В пртивном случае - null.
        /// </summary>
        public ILinkedNode Next
        {
            get
            {
                if (FNext is ILinkedNode)
                    return FNext as ILinkedNode;
                else
                    return null;
            }
        }

        /// <summary>
        /// Завершение работы узла. Узел исключается из списка.
        /// В переопределенном методе производного класса 
        /// ПОСЛЕДНИМ оператором должен быть base.Finish();
        /// </summary>
        public virtual void Finish()
        {
            Remove();
        }

        /// <summary>
        /// Возвращает ссылку на заголовочную ячейку списка, в котором находится узел
        /// </summary>
        /// <returns>Ссылка на заголовочную ячейку</returns>
        public SimulationList GetHeader()
        {
            return HeaderNode;
        }

        /// <summary>
        /// Получение ссылки на следующий узел списка независимо от того, является он внутренней или заголовочной ячейкой
        /// </summary>
        /// <returns>Ссылка на следующий узел</returns>
        public ILinkageBase GetNext()
        {
            return FNext;
        }

        /// <summary>
        /// Получение ссылки на предыдущий узел списка независимо от того, является он внутренней или заголовочной ячейкой
        /// </summary>
        /// <returns>Ссылка на предыдущий узел</returns>
        public ILinkageBase GetPrev()
        {
            return FPrev;
        }

        /// <summary>
        /// Вставка узла в список. 
        /// Если для узла задана собственная функция сравнения, вставка производится с ее использованием.
        /// В противном случае узел вставляется в список последним
        /// </summary>
        /// <param name="lst">Ссылка на заголовочную ячейку списка, в который вставляется текущий узел</param>
        public void Insert(SimulationList lst)
        {
            lst.Insert(this);
        }

        /// <summary>
        /// Вставка узла в список с использованием указанной функции сравнения
        /// </summary>
        /// <param name="lst">Ссылка на заголовочную ячейку списка, в который вставляется узел</param>
        /// <param name="cmp">Функция сравнения, которую следует использоватьпри вставке узла</param>
        public void Insert(SimulationList lst, Func<ILinkedNode, ILinkedNode, bool> cmp)
        {
            lst.Insert(this, cmp);
        }

        /// <summary>
        /// Вставка узла в список после указанного
        /// </summary>
        /// <param name="l">Узел, после которого следует вставлять текущий</param>
        public void InsertAfter(ILinkageBase l)
        {
            Remove();
            InsertTime = GlobalRunner.SimTime();
            FPrev = l;
            FNext = l.GetNext();
            FNext.SetPrev(this);
            l.SetNext(this);
            HeaderNode = l.HeaderNode;
            HeaderNode.Size++;
            HeaderNode.LengthStat.AddData(HeaderNode.Size, InsertTime);
        }

        /// <summary>
        /// Вставка узла в список перед указанным
        /// </summary>
        /// <param name="l">Узел, перед которым следует вставлять текущий</param>
        public void InsertBefore(ILinkageBase l)
        {
            Remove();
            InsertTime = GlobalRunner.SimTime();
            FNext = l;
            FPrev = l.GetPrev();
            FPrev.SetNext(this);
            l.SetPrev(this);
            HeaderNode = l.HeaderNode;
            HeaderNode.Size++;
            HeaderNode.LengthStat.AddData(HeaderNode.Size, InsertTime);
        }

        /// <summary>
        /// Вставка узла в первую позицию списка
        /// </summary>
        /// <param name="lst">Ссылка на заголовочную ячейку списка, в который вставляется узел</param>
        public void InsertFirst(SimulationList lst)
        {
            // Вставка на первое место - это вставка ПОСЛЕ заголовочной ячейки
            lst.InsertFirst(this);
        }

        /// <summary>
        /// Вставка узла в последнюю позицию списка
        /// </summary>
        /// <param name="lst">Ссылка на заголовочную ячейку списка, в который вставляется узел</param>
        public void InsertLast(SimulationList lst)
        {
            // Вставка на последнее место - это вставка ПЕРЕД заголовочной ячейкой
            lst.InsertLast(this);
        }

        /// <summary>
        /// Исключение узла из списка, в котором он находится
        /// </summary>
        public void Remove()
        {
            if (FNext != null)
            {
                HeaderNode.Size--;
                FNext.SetPrev(FPrev);
                FPrev.SetNext(FNext);
                FNext = null;
                FPrev = null;
                HeaderNode.TimeStat.AddData(GlobalRunner.SimTime() - InsertTime);
                HeaderNode.LengthStat.AddData(HeaderNode.Size, GlobalRunner.SimTime());
                SimulationList head = HeaderNode;
                HeaderNode = null;
            }
        }

        /// <summary>
        /// Установка ссылки на следующий узел списка
        /// </summary>
        /// <param name="newNext">Новая ссылка на следующий узел</param>
        public void SetNext(ILinkageBase newNext)
        {
            FNext = newNext;
        }

        /// <summary>
        /// Установка ссылки на предыдущий узел списка
        /// </summary>
        /// <param name="newPrev">Новая ссылка на предыдущий узел</param>
        public void SetPrev(ILinkageBase newPrev)
        {
            FPrev = newPrev;
        }
    }
}
