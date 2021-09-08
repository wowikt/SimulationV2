using ShopSimulation.App.Simulation;
using Simulation.Core.Histograms;
using Simulation.Core.RandomGenerator;
using Simulation.Core.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSimulation.MultiRun
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создать генераторы случайных чисел
            ShopSimulationProcess.RandCust = new RandomGenerator();
            ShopSimulationProcess.RandService = new RandomGenerator();
            CashUsageStat = new SimpleStatistics("Занятость кассира");
            TimeStat = new SimpleStatistics("Среднее время пребывания в системе");
            InShopStat = new SimpleStatistics("Среднее количество покупателей в торговом зале");
            InShopMaxStat = new SimpleStatistics("Максимальное количество покупателей в торговом зале");
            MaxQueueLenStat = new SimpleStatistics("Максимальная длина очереди");
            WaitStat = new SimpleStatistics("Среднее время ожидания в очереди");
            TimeHist = new Histogram(HistMin, HistStep, HistStepCount, "Среднее время пребывания в системе");

            for (int i = 0; i < RunCount; i++)
            {
                // Создать имитацию
                ShopSim = new ShopSimulationProcess();

                // Запустить ее
                if (i % 5 == 0)
                {
                    Console.Write("*");
                }

                ShopSim.Start();

                // Собрать статистику
                CashUsageStat.AddData(ShopSim.CashStat.Mean());
                TimeStat.AddData(ShopSim.TimeStat.Mean());
                TimeHist.AddData(ShopSim.TimeStat.Mean());
                InShopStat.AddData(ShopSim.InShopStat.Mean());
                InShopMaxStat.AddData(ShopSim.InShopStat.Max);
                MaxQueueLenStat.AddData(ShopSim.Queue.LengthStat.Max);
                WaitStat.AddData(ShopSim.Queue.TimeStat.Mean());

                // Удалить имитацию
                ShopSim.Finish();

                //ShopSim.Dispose();
                ShopSim = null;
            }

            // Вывод статистики
            Console.WriteLine();
            Console.WriteLine(CashUsageStat);
            Console.WriteLine();
            Console.WriteLine(TimeStat);
            Console.WriteLine();
            Console.WriteLine(InShopStat);
            Console.WriteLine();
            Console.WriteLine(InShopMaxStat);
            Console.WriteLine();
            Console.WriteLine(MaxQueueLenStat);
            Console.WriteLine();
            Console.WriteLine(WaitStat);
            Console.WriteLine();
            Console.WriteLine(TimeHist);
            Console.WriteLine("Готово");
            Console.ReadLine();
        }

        /// <summary>
        /// Статистика по занятости касира
        /// </summary>
        internal static SimpleStatistics CashUsageStat;

        /// <summary>
        /// Нижняя граница гистограммы
        /// </summary>
        internal static double HistMin = 8;

        /// <summary>
        /// Шаг гистограммы
        /// </summary>
        internal static double HistStep = 1;

        /// <summary>
        /// Количество шагов гистограммы
        /// </summary>
        internal static int HistStepCount = 20;

        /// <summary>
        /// Статистика по максимальному количеству покупателей в торговом зале
        /// </summary>
        internal static SimpleStatistics InShopMaxStat;

        /// <summary>
        /// Статистика по среднему количеству покупателей в торговом зале
        /// </summary>
        internal static SimpleStatistics InShopStat;

        /// <summary>
        /// Статистика по максимальной длине очереди
        /// </summary>
        internal static SimpleStatistics MaxQueueLenStat;

        /// <summary>
        /// Количество прогонов
        /// </summary>
        internal static int RunCount = 400;

        /// <summary>
        /// Ссылка на объект-имитацию
        /// </summary>
        internal static ShopSimulationProcess ShopSim;

        /// <summary>
        /// Гистограмма по времени пребывания в магазине
        /// </summary>
        internal static Histogram TimeHist;

        /// <summary>
        /// Статистика по времени пребывания в магазине
        /// </summary>
        internal static SimpleStatistics TimeStat;

        /// <summary>
        /// Статистика по среднему времени ожидания в очереди
        /// </summary>
        internal static SimpleStatistics WaitStat;
    }
}
