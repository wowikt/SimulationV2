using Simulation.Core.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVControl.App.Components
{
    /// <summary>
    /// Класс TVSet представляет проверяемый телевизор
    /// </summary>
    internal class TvSet : LinkedNode
    {
        /// <summary>
        /// Время появления телевизора в системе
        /// </summary>
        internal double StartingTime;

        /// <summary>
        /// Количество пройденных телевизором настроек
        /// </summary>
        internal int AdjustmentCount;
    }
}
