using QuarrySimulation.App.Components;
using QuarrySimulation.App.Services;
using Simulation.Core.Components;
using Simulation.Core.Extensions;
using Simulation.Core.Primitives;
using Simulation.Core.RandomGenerator;
using Simulation.Core.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuarrySimulation.App.Simulation
{
    public class QuarrySimulationComponent : SimComponent
    {
        public static RandomGenerator RandomTruck { get; set; }

        public static RandomGenerator RandomMill { get; set; }

        /// <summary>
        /// Очереди к экскаваторам
        /// </summary>
        public SimulationList[] ExcavatorQueues { get; set; }

        /// <summary>
        /// Очередь к измельчителю
        /// </summary>
        public SimulationList MillQueue { get; set; }

        /// <summary>
        /// Экскаваторы
        /// </summary>
        public Excavator[] Excavators { get; set; }

        /// <summary>
        /// Количетсов самосвалов, движущихся на разгрузку
        /// </summary>
        public int[] ForwardTrips { get; set; }

        /// <summary>
        /// Измельчитель
        /// </summary>
        public Mill Mill { get; set; }

        /// <summary>
        /// Статистика по возврату самосвалов
        /// </summary>
        public ActionStatistics ReturnStatistics { get; set; }

        /// <summary>
        /// Статистики по экскаваторам
        /// </summary>
        public ServiceStatistics[] ExcavatorStatistics;

        /// <summary>
        /// Статистика по измельчителю
        /// </summary>
        public ServiceStatistics MillStatistics { get; set; }

        /// <summary>
        /// Количество разгруженных тяжелых самосвалов
        /// </summary>
        public int HeavyCount { get; set; }

        /// <summary>
        /// Количество разгруженных легких самосвалов
        /// </summary>
        public int LightCount { get; set; }

        /// <summary>
        /// Масса доставленного груза
        /// </summary>
        public double Delivered { get; set; }

        protected override void Init()
        {
            base.Init();
            ExcavatorQueues = new SimulationList[Parameters.ExcavatorCount];
            ExcavatorStatistics = new ServiceStatistics[Parameters.ExcavatorCount];
            Excavators = new Excavator[Parameters.ExcavatorCount];
            ForwardTrips = new int[Parameters.ExcavatorCount];
            for (int i = 0; i < ExcavatorQueues.Length; i++)
            {
                ExcavatorQueues[i] = new SimulationList($"Очередь к экскаватору {i + 1}");
                ExcavatorStatistics[i] = new ServiceStatistics($"Загруженность экскаватора {i + 1}");
                Excavators[i] = new Excavator
                {
                    Queue = ExcavatorQueues[i],
                    Statistics = ExcavatorStatistics[i]
                };

                for (int j = 0; j < Parameters.InitLightTrucks; j++)
                {
                    new Truck
                    {
                        Index = i,
                        Queue = ExcavatorQueues[i],
                        Excavator = Excavators[i],
                        Settings = Parameters.LightTruckSettings,
                    }.Insert(ExcavatorQueues[i]);
                }

                for (int j = 0; j < Parameters.InitHeavyTrucks; j++)
                {
                    new Truck
                    {
                        Index = i,
                        Queue = ExcavatorQueues[i],
                        Excavator = Excavators[i],
                        Settings = Parameters.HeavyTruckSettings,
                    }.Insert(ExcavatorQueues[i]);
                }
            }

            // Тяжедые самосвалы имеют преимущество в очереди к измельчителю
            MillQueue = new SimulationList((a, b) => ((Truck)a).Settings.IsHeavy && !((Truck)b).Settings.IsHeavy, 
                "Очередь к измельчителю");
            MillStatistics = new ServiceStatistics("Загруженность измельчителя");
            Mill = new Mill();
            ReturnStatistics = new ActionStatistics("Возврат самосвалов");
        }

        protected override void StartEvent()
        {
            Excavators.ActivateAll();
            ReactivateDelay(Parameters.SimulationTime);
            StopStat();
        }

        public override void StopStat()
        {
            base.StopStat();
            foreach (var stat in ExcavatorStatistics)
            {
                stat.StopStat();
            }

            MillStatistics.StopStat();
            ReturnStatistics.StopStat();
        }

        public override void Finish()
        {
            foreach (var excavator in Excavators)
            {
                excavator.Finish();
            }

            Mill.Finish();
            foreach (var queue in ExcavatorQueues)
            {
                queue.Finish();
            }

            MillQueue.Finish();
            base.Finish();
        }
    }
}
