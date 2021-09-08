using QuarrySimulation.App.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuarrySimulation.App
{
    public class Parameters
    {
        /// <summary>
        /// Количество экскаваторов
        /// </summary>
        public static int ExcavatorCount = 3;

        /// <summary>
        /// Настройки тяжелых самосвалов
        /// </summary>
        public static TruckSettings HeavyTruckSettings = new TruckSettings
        {
            IsHeavy = true,
            Tonnage = 50,
            LoadingTime = 10,
            TripTime = 2,
            UnloadingTime = 4,
        };

        /// <summary>
        /// Настройки легких самосвалов
        /// </summary>
        public static TruckSettings LightTruckSettings = new TruckSettings
        {
            IsHeavy = false,
            Tonnage = 20,
            LoadingTime = 5,
            TripTime = 1.5,
            UnloadingTime = 2,
        };

        /// <summary>
        /// Добавочное время в пути для груженого самосвала
        /// </summary>
        public static double ExtraTripTime = 1;

        /// <summary>
        /// Время имитации
        /// </summary>
        public static double SimulationTime = 480;

        /// <summary>
        /// Количество лекгих самосвалов на экскаватор
        /// </summary>
        public static int InitLightTrucks = 2;

        /// <summary>
        /// Количество тяжелых самосвалов на экскаватор
        /// </summary>
        public static int InitHeavyTrucks = 1;

        /// <summary>
        /// Шаг времени визуализации
        /// </summary>
        public static double VisTimeStep = 0.2;
    }
}
