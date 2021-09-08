using Simulation.Core.Components;
using Simulation.Core.Primitives;
using Simulation.Core.RandomGenerator;
using Simulation.Core.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVControl.App.Services;

namespace TVControl.App.Simulation
{
    public class TvControlSimulationComponent : SimComponent
    {
        /// <summary>
        /// Очередь на настройку
        /// </summary>
        public SimulationList AdjustmentQueue;

        /// <summary>
        /// Очередь на проверку
        /// </summary>
        public SimulationList InspectionQueue;

        /// <summary>
        /// Статистика по времени пребывания в системе
        /// </summary>
        public SimpleStatistics TimeInSystemStat;

        /// <summary>
        /// Статистика по загруженности проверяющих
        /// </summary>
        public ServiceStatistics InspectorsStat;

        /// <summary>
        /// Статистика по загруженности настройщика
        /// </summary>
        public ServiceStatistics AdjustmentStat;

        /// <summary>
        /// Генератор случайных чисел, управляющий прибытием телевизоров на контроль
        /// </summary>
        public static RandomGenerator RandTVSet;

        /// <summary>
        /// Генератор случайных чисел, управляющий продолжительностью проверки
        /// </summary>
        public static RandomGenerator RandInspector;

        /// <summary>
        /// Генератор случайных чисел, управляющий продолжительностью настройки
        /// </summary>
        public static RandomGenerator RandAdjuster;

        /// <summary>
        /// Массив проверяющих
        /// </summary>
        internal Inspector[] Inspect;

        /// <summary>
        /// Настройщик
        /// </summary>
        internal Adjuster Adjust;

        /// <summary>
        /// Генератор телевизоров
        /// </summary>
        internal TvSetGenerator Generator;

        /// <summary>
        /// Завершение имитации
        /// </summary>
        public override void Finish()
        {
            // Завершить настройщика и проверяющих
            Adjust.Finish();
            for (int i = 0; i < Params.InspectorCount; i++)
            {
                Inspect[i].Finish();
            }

            // Удалить очереди
            InspectionQueue.Finish();
            AdjustmentQueue.Finish();
            base.Finish();
        }

        /// <summary>
        /// Создание содержимого имитации
        /// </summary>
        protected override void Init()
        {
            // Создание очередей
            InspectionQueue = new SimulationList("Очередь на проверку");
            AdjustmentQueue = new SimulationList("Очередь на настройку");

            // Содание проверяющих и настройщика
            Inspect = new Inspector[Params.InspectorCount];
            for (int i = 0; i < Params.InspectorCount; i++)
            {
                Inspect[i] = new Inspector();
            }
            Adjust = new Adjuster();
            Generator = new TvSetGenerator();

            // Создание объектов статистики
            TimeInSystemStat = new SimpleStatistics("Время пребывания в системе");
            InspectorsStat = new ServiceStatistics(Params.InspectorCount, "Загруженность проверяющих");
            AdjustmentStat = new ServiceStatistics("Загруженность настройщика");
        }

        /// <summary>
        /// Событие начала имитации
        /// </summary>
        protected override void StartEvent()
        {
            // Запустить генератор
            Generator.Activate();

            // Ожидать окончания имитации
            ReactivateDelay(Params.SimulationTime);
        }

        /// <summary>
        /// Коррекция статистики к текущему времени
        /// </summary>
        public override void StopStat()
        {
            base.StopStat();
            InspectionQueue.StopStat(SimTime());
            AdjustmentQueue.StopStat(SimTime());
            InspectorsStat.StopStat(SimTime());
            AdjustmentStat.StopStat(SimTime());
        }
    }
}
