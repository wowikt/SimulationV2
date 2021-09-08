using Simulation.Core.Histograms;
using Simulation.Core.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopSimulation.MultiRun.WebForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ShopMultiVisual());
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
