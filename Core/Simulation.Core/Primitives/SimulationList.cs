using Simulation.Core.Runners;
using Simulation.Core.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Core.Primitives
{
    /// <summary>
    /// Класс SimulationList - список узлов. Непосредственно сам объект является заголовочной ячейкой списка.
    /// </summary>
    public class SimulationList : ILinkageBase
    {
        /// <summary>
        /// Конструктор по умолчанию. 
        /// Список создается с привязкой к моменту имитационного времени, 
        /// соответствующему текущему процессу имитации.
        /// Функция сравнения не задается.
        /// Максимальная длина не установлена.
        /// </summary>
        public SimulationList()
        {
            FNext = FPrev = this;
            CompFunc = null;
            LengthStat = new IntervalStatistics(0);
            TimeStat = new SimpleStatistics();
            HeaderNode = this;
        }

        /// <summary>
        /// Конструктор. 
        /// Список создается с привязкой к моменту имитационного времени, 
        /// соответствующему текущему процессу имитации.
        /// Функция сравнения задается параметром.
        /// Максимальная длина не установлена.
        /// </summary>
        /// <param name="order">Делегат функции сравнения</param>
        public SimulationList(Func<ILinkedNode, ILinkedNode, bool> order)
        {
            FNext = FPrev = this;
            CompFunc = order;
            LengthStat = new IntervalStatistics(0);
            TimeStat = new SimpleStatistics();
            HeaderNode = this;
        }

        /// <summary>
        /// Конструктор. 
        /// Список создается с привязкой к моменту имитационного времени, 
        /// соответствующему текущему процессу имитации, и заданной максимальной длиной.
        /// Функция сравнения задается параметром.
        /// </summary>
        /// <param name="order">Делегат функции сравнения</param>
        /// <param name="max">Максимальный размер очереди</param>
        public SimulationList(Func<ILinkedNode, ILinkedNode, bool> order, int max)
        {
            FNext = FPrev = this;
            CompFunc = order;
            LengthStat = new IntervalStatistics(0);
            TimeStat = new SimpleStatistics();
            HeaderNode = this;
            MaxSize = max;
        }

        /// <summary>
        /// Конструктор. 
        /// Список создается с привязкой к заданному моменту 
        /// имитационного времени и заданной максимальной длиной.
        /// Функция сравнения задается параметром.
        /// </summary>
        /// <param name="order">Делегат функции сравнения</param>
        /// <param name="max">Максимальный размер очереди</param>
        /// <param name="simTime">Имитационное время, соответствующее созданию списка</param>
        public SimulationList(Func<ILinkedNode, ILinkedNode, bool> order, int max, double simTime)
        {
            FNext = FPrev = this;
            CompFunc = order;
            LengthStat = new IntervalStatistics(0, simTime);
            TimeStat = new SimpleStatistics();
            HeaderNode = this;
            MaxSize = max;
        }

        /// <summary>
        /// Конструктор. 
        /// Список создается с привязкой к заданному моменту имитационного времени 
        /// и заданной максимальной длиной.
        /// Функция сравнения задается параметром.
        /// </summary>
        /// <param name="order">Делегат функции сравнения</param>
        /// <param name="max">Максимальный размер очереди</param>
        /// <param name="simTime">Имитационное время, соответствующее созданию списка</param>
        /// <param name="aHeader">Заголовок списка при выводе статистики</param>
        public SimulationList(Func<ILinkedNode, ILinkedNode, bool> order, int max, double simTime, string aHeader)
        {
            FNext = FPrev = this;
            CompFunc = order;
            LengthStat = new IntervalStatistics(0, simTime);
            TimeStat = new SimpleStatistics();
            StatHeader = aHeader;
            HeaderNode = this;
            MaxSize = max;
        }

        /// <summary>
        /// Конструктор. 
        /// Список создается с привязкой к моменту имитационного времени, 
        /// соответствующему текущему процессу имитации, и заданной максимальной длиной.
        /// Функция сравнения задается параметром.
        /// </summary>
        /// <param name="order">Делегат функции сравнения</param>
        /// <param name="max">Максимальный размер очереди</param>
        /// <param name="aHeader">Заголовок списка при выводе статистики</param>
        public SimulationList(Func<ILinkedNode, ILinkedNode, bool> order, int max, string aHeader)
        {
            FNext = FPrev = this;
            CompFunc = order;
            LengthStat = new IntervalStatistics(0);
            TimeStat = new SimpleStatistics();
            StatHeader = aHeader;
            HeaderNode = this;
            MaxSize = max;
        }

        /// <summary>
        /// Конструктор. 
        /// Список создается с привязкой к моменту имитационного времени, 
        /// соответствующему текущему процессу имитации.
        /// Функция сравнения задается параметром.
        /// Максимальная длина не установлена.
        /// </summary>
        /// <param name="order">Делегат функции сравнения</param>
        /// <param name="aHeader">Заголовок списка при выводе статистики</param>
        public SimulationList(Func<ILinkedNode, ILinkedNode, bool> order, string aHeader)
        {
            FNext = FPrev = this;
            CompFunc = order;
            LengthStat = new IntervalStatistics(0);
            TimeStat = new SimpleStatistics();
            StatHeader = aHeader;
            HeaderNode = this;
        }

        /// <summary>
        /// Конструктор. 
        /// Список создается с привязкой к заданному моменту имитационного времени 
        /// и заданной максимальной длиной.
        /// Функция сравнения не задается.
        /// </summary>
        /// <param name="max">Максимальный размер очереди</param>
        /// <param name="simTime">Имитационное время, соответствующее созданию списка</param>
        /// <param name="aHeader">Заголовок списка при выводе статистики</param>
        public SimulationList(int max, double simTime, string aHeader)
        {
            FNext = FPrev = this;
            CompFunc = null;
            LengthStat = new IntervalStatistics(0, simTime);
            TimeStat = new SimpleStatistics();
            StatHeader = aHeader;
            HeaderNode = this;
            MaxSize = max;
        }

        /// <summary>
        /// Конструктор по умолчанию. 
        /// Список создается с привязкой к моменту имитационного времени, 
        /// соответствующему текущему процессу имитации, и заданной максимальной длиной.
        /// Функция сравнения не задается.
        /// </summary>
        /// <param name="max">Максимальный размер очереди</param>
        public SimulationList(int max)
        {
            FNext = FPrev = this;
            CompFunc = null;
            LengthStat = new IntervalStatistics(0);
            TimeStat = new SimpleStatistics();
            HeaderNode = this;
            MaxSize = max;
        }

        /// <summary>
        /// Конструктор с указанием заголовка. 
        /// Список создается с привязкой к моменту имитационного времени, 
        /// соответствующему текущему процессу имитации, и заданной максимальной длиной.
        /// Функция сравнения не задается.
        /// </summary>
        /// <param name="max">Максимальный размер очереди</param>
        /// <param name="aHeader">Заголовок списка при выводе статистики</param>
        public SimulationList(int max, string aHeader)
        {
            FNext = FPrev = this;
            CompFunc = null;
            LengthStat = new IntervalStatistics(0);
            TimeStat = new SimpleStatistics();
            StatHeader = aHeader;
            HeaderNode = this;
            MaxSize = max;
        }

        /// <summary>
        /// Конструктор с указанием заголовка. 
        /// Список создается с привязкой к моменту имитационного времени, 
        /// соответствующему текущему процессу имитации.
        /// Функция сравнения не задается.
        /// Максимальная длина не установлена.
        /// </summary>
        /// <param name="aHeader">Заголовок списка при выводе статистики</param>
        public SimulationList(string aHeader)
        {
            FNext = FPrev = this;
            CompFunc = null;
            LengthStat = new IntervalStatistics(0);
            TimeStat = new SimpleStatistics();
            StatHeader = aHeader;
            HeaderNode = this;
        }

        /// <summary>
        /// Делегат функции сравнения, определяющий упорядоченность списка
        /// </summary>
        protected internal Func<ILinkedNode, ILinkedNode, bool> CompFunc = null;

        /// <summary>
        /// Поле связи. Ссылка на предыдущий узел списка
        /// </summary>
        internal ILinkageBase FPrev;

        /// <summary>
        /// Поле связи. Ссылка на следующий узел списка
        /// </summary>
        internal ILinkageBase FNext;

        /// <summary>
        /// Статистика по длине списка
        /// </summary>
        public IntervalStatistics LengthStat;

        /// <summary>
        /// Максимально возможный размер очереди. Методы классов List и Link 
        /// не учитывают его, однако это значение может учитываться методами классов
        /// и компонентов при работе с очередями. 
        /// Значение, равное 0, означает отсутствие ограничения на длину.
        /// </summary>
        public int MaxSize;

        /// <summary>
        /// Заголовок при выводе статистики списка
        /// </summary>
        public string StatHeader;

        /// <summary>
        /// Статистика по времени нахождения узлов в очереди
        /// </summary>
        public SimpleStatistics TimeStat;

        /// <summary>
        /// Ссылка на первый узел списка.
        /// </summary>
        public ILinkedNode First
        {
            get
            {
                return Next;
            }
        }

        /// <summary>
        /// Ссылка на заголовочную ячейку списка
        /// </summary>
        public SimulationList HeaderNode
        {
            get;
            internal set;
        }

        /// <summary>
        /// Ссылка на последний узел списка.
        /// </summary>
        public ILinkedNode Last
        {
            get
            {
                return Prev;
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
        /// Установка делегата функции сравнения. 
        /// Возможна только для пустого списка, для которого эта функция еще не была задана.
        /// Если любое из этих условий нарушается, не выполняется никаких действий.
        /// </summary>
        public Func<ILinkedNode, ILinkedNode, bool> OrderFunc
        {
            set
            {
                if (CompFunc == null && Empty())
                {
                    CompFunc = value;
                }
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
        /// Количество узлов списка
        /// </summary>
        public int Size
        {
            get;
            internal set;
        }

        /// <summary>
        /// Очистка списка с завершением всех входящих в него узлов
        /// </summary>
        public void Clear()
        {
            while (!Empty())
                First.Finish();
        }

        /// <summary>
        /// Очистка статистик списка с привязкой к текущему имитационному времени
        /// </summary>
        public void ClearStat()
        {
            ClearStat(GlobalRunner.SimTime());
        }

        /// <summary>
        /// Очистка статистик списка с привязкой к заданному имитационному времени
        /// </summary>
        /// <param name="simTime">Имитационное время, когда выполняется очистка статистик</param>
        public void ClearStat(double simTime)
        {
            TimeStat.ClearStat();
            LengthStat.ClearStat(simTime);
        }

        /// <summary>
        /// Проверка списка на пустоту
        /// </summary>
        /// <returns>true, если список пуст. false, если в нем есть хотя бы один узел.</returns>
        public bool Empty()
        {
            return FNext == this;
        }

        /// <summary>
        /// Удаление списка
        /// </summary>
        public virtual void Finish()
        {
            // Очистить список
            Clear();
            FNext = null;
            FPrev = null;
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
        /// Вставка в список нового узла
        /// </summary>
        /// <param name="inserted">Вставляемый узел</param>
        /// <returns>true, если узел был вставлен. 
        /// false, если попытка вставки оказалась неудачной по причине переполнения списка</returns>
        public void Insert(ILinkedNode inserted)
        {
            // Если функция сравнения в списке не указана, поместить на последнее место
            if (CompFunc == null)
                InsertLast(inserted);
            else
            {
                // Найти место вставки
                ILinkedNode lnk = First;
                while (lnk != null)
                {
                    if (CompFunc(inserted, lnk))
                        break;
                    lnk = lnk.Next;
                }
                // Если список закончен, вставить в конец
                if (lnk == null)
                    InsertLast(inserted);
                // Иначе вставить перед найденной ячейкой
                else
                    inserted.InsertBefore(lnk);
            }
        }

        /// <summary>
        /// Вставка в список нового узла с указанной функцией сравнения
        /// </summary>
        /// <param name="inserted">Вставляемый узел</param>
        /// <param name="cmp">Функция сравнения, используемая при вставке</param>
        /// <returns>true, если узел был вставлен. 
        /// false, если попытка вставки оказалась неудачной по причине переполнения списка</returns>
        public void Insert(ILinkedNode inserted, Func<ILinkedNode, ILinkedNode, bool> cmp)
        {
            // Найти место вставки
            ILinkedNode lnk = First;
            while (lnk != null)
            {
                if (cmp(inserted, lnk))
                    break;
                lnk = lnk.Next;
            }
            // Если список закончен, вставить в конец
            if (lnk == null)
                InsertLast(inserted);
            // Иначе вставить перед найденной ячейкой
            else
                inserted.InsertBefore(lnk);
        }

        /// <summary>
        /// Вставка нового узла в начало списка
        /// </summary>
        /// <param name="inserted">Вставляемый узел</param>
        /// <returns>true, если узел был вставлен. 
        /// false, если попытка вставки оказалась неудачной по причине переполнения списка</returns>
        public void InsertFirst(ILinkedNode inserted)
        {
            // Вставка на первое место - это вставка ПОСЛЕ заголовочной ячейки
            inserted.InsertAfter(this);
        }

        /// <summary>
        /// Вставка нового узла в конец списка
        /// </summary>
        /// <param name="inserted">Вставляемый узел</param>
        /// <returns>true, если узел был вставлен. 
        /// false, если попытка вставки оказалась неудачной по причине переполнения списка</returns>
        public void InsertLast(ILinkedNode inserted)
        {
            // Вставка на первое место - это вставка ПОСЛЕ заголовочной ячейки
            inserted.InsertBefore(this);
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

        /// <summary>
        /// Отображение статистики по использованию списка
        /// </summary>
        /// <returns>Статистика в виде текста</returns>
        public string Statistics()
        {
            StringBuilder Result = new StringBuilder(StatHeader + "\n");
            Result.AppendFormat("Средняя длина = {0,6:0.000} +/- {1,6:0.000}\n", LengthStat.Mean(), LengthStat.Deviation());
            Result.AppendFormat("Максимальная длина = {0,2}, сейчас = {1,2}\n", LengthStat.Max, Size);
            Result.AppendFormat("Среднее время ожидания = {0,6:0.000}", TimeStat.Mean());
            return Result.ToString();
        }

        /// <summary>
        /// Коррекция статистик списка к текущему имитационному времени
        /// </summary>
        public void StopStat()
        {
            StopStat(GlobalRunner.SimTime());
        }

        /// <summary>
        /// Коррекция статистик списка к заданному имитационному времени
        /// </summary>
        /// <param name="simTime">Имитационное время, к которому корректируется статистика</param>
        public void StopStat(double simTime)
        {
            LengthStat.StopStat(simTime);
        }
    }
}
