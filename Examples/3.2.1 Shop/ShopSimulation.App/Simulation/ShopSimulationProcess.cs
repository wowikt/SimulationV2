using ShopSimulation.App.Components;
using ShopSimulation.App.Services;
using Simulation.Core.Actions;
using Simulation.Core.Histograms;
using Simulation.Core.Primitives;
using Simulation.Core.Processes;
using Simulation.Core.RandomGenerator;
using Simulation.Core.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSimulation.App.Simulation
{
    /// <summary>
    /// Имитация обслуживания покупателей в магазине
    /// </summary>
    public class ShopSimulationProcess : SimProc
    {
        /// <summary>
        /// Кассир
        /// </summary>
        internal Cashman Cash;

        /// <summary>
        /// Статистика по занятости кассира
        /// </summary>
        public ServiceStatistics CashStat;

        /// <summary>
        /// Генератор покупателей
        /// </summary>
        internal Generator CustGen;

        /// <summary>
        /// Статистика по числу покупателей в торговом зале
        /// </summary>
        public ActionStatistics InShopStat;

        /// <summary>
        /// Точечная гистограмма по времени пребывания в магазине
        /// </summary>
        public Histogram TimeHist;

        /// <summary>
        /// Точечная статистика по времени пребывания в магазине
        /// </summary>
        public SimpleStatistics TimeStat;

        /// <summary>
        /// Очередь ожидания
        /// </summary>
        public SimulationList Queue;

        /// <summary>
        /// Генератор случайных чисел, управляющий созданием клиентов
        /// </summary>
        public static RandomGenerator RandCust;

        /// <summary>
        /// Генератор случайных чисел, управляющий работой кассира
        /// </summary>
        public static RandomGenerator RandService;

        /// <summary>
        /// Алгоритм имитации
        /// </summary>
        protected override IEnumerator<ISimulationAction> Execute()
        {
            // Запустить генератор клиентов
            CustGen.Activate();
            // Ждать окончания обслуживания
            yield return Hold(Param.SimulationTime);
        }

        /// <summary>
        /// Создание объектов имитации
        /// </summary>
        protected override void Init()
        {
            base.Init();
            Cash = new Cashman();
            CustGen = new Generator();
            Queue = new SimulationList("Очередь ожидания");
            TimeStat = new SimpleStatistics("Время нахождения клиентов в системе");
            TimeHist = new Histogram(Param.HistMin, Param.HistStep, Param.HistStepCount, "Время нахождения клиентов в системе");
            CashStat = new ServiceStatistics("Занятость кассира");
            InShopStat = new ActionStatistics("Количество покупателей в торговом зале");
        }

        /// <summary>
        /// Удаление имитации
        /// </summary>
        public override void Finish()
        {
            // Требуется удалить все процессы
            Queue.Finish();
            Cash.Finish();
            CustGen.Finish();
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
            InShopStat.StopStat();
        }
    }
}
