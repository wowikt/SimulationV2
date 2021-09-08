using BankSimulation.App.Components;
using Simulation.Core.Components;
using Simulation.Core.Histograms;
using Simulation.Core.Primitives;
using Simulation.Core.RandomGenerator;
using Simulation.Core.Statistics;

namespace BankSimulation.App.Simulation
{
    /// <summary>
    /// Имитация обслуживания клиентов в банке
    /// </summary>
    public class BankSimulationProcess : SimComponent
    {
        /// <summary>
        /// Точечная гистограмма по времени пребывания в банке
        /// </summary>
        public Histogram InBankHist;

        /// <summary>
        /// Количество клиентов, обслуженных без ожидания в очереди
        /// </summary>
        public int NotWaited;

        /// <summary>
        /// Очередь ожидания
        /// </summary>
        public SimulationList Queue;

        /// <summary>
        /// Статистика по занятости кассира
        /// </summary>
        public ServiceStatistics CashStat;

        /// <summary>
        /// Генератор случайных чисел, управляющий созданием клиентов
        /// </summary>
        public static RandomGenerator RandClient;

        /// <summary>
        /// Генератор случайных чисел, управляющий работой кассира
        /// </summary>
        public static RandomGenerator RandCashman;

        /// <summary>
        /// Точечная статистика по времени пребывания в банке
        /// </summary>
        public SimpleStatistics InBankStat;

        /// <summary>
        /// Клиент, обслуживаемый в данный момент
        /// </summary>
        internal Client CurrentClient;

        /// <summary>
        /// Алгоритм имитации
        /// </summary>
        protected override void StartEvent()
        {
            (new Client()).Activate();
        }

        /// <summary>
        /// Создание объектов имитации
        /// </summary>
        protected override void Init()
        {
            base.Init();
            Queue = new SimulationList("Очередь ожидания");
            InBankStat = new SimpleStatistics("Время нахождения клиентов в системе");
            InBankHist = new Histogram(Param.HistMin, Param.HistStep, Param.HistStepCount, "Время нахождения клиентов в системе");
            CashStat = new ServiceStatistics("Занятость кассира");
            NotWaited = 0;
            VisualInterval = Param.VisTimeStep;
            Client.ArrivedCount = 0;
        }

        /// <summary>
        /// Удаление имитации
        /// </summary>
        public override void Finish()
        {
            // Требуется удалить все процессы
            Queue.Finish();

            // Остальные объекты имитации удалять не требуется
            base.Finish();
        }

        /// <summary>
        /// Коррекция статистики
        /// </summary>
        public override void StopStat()
        {
            base.StopStat();
            CashStat.StopStat();
            Queue.StopStat();
        }
    }
}
