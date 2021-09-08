using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuarrySimulation.App.Settings
{
    /// <summary>
    /// Характеристики самосвала
    /// </summary>
    public class TruckSettings
    {
        /// <summary>
        /// Является ли тяжелым
        /// </summary>
        public bool IsHeavy { get; set; }

        /// <summary>
        /// Грузоподъемность
        /// </summary>
        public double Tonnage { get; set; }

        /// <summary>
        /// Время погрузки
        /// </summary>
        public double LoadingTime { get; set; }

        /// <summary>
        /// Время в пути
        /// </summary>
        public double TripTime { get; set; }

        /// <summary>
        /// Время разгрузки
        /// </summary>
        public double UnloadingTime { get; set; }
    }
}
