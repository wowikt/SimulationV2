using QuarrySimulation.App.Components;
using Simulation.Core.Components;
using Simulation.Core.Extensions;
using Simulation.Core.Primitives;
using Simulation.Core.RandomGenerator;
using Simulation.Core.Services;
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
        /// Экскаваторы
        /// </summary>
        public Service[] Excavators { get; set; }

        /// <summary>
        /// Количетсов самосвалов, движущихся на разгрузку
        /// </summary>
        public int[] ForwardTrips { get; set; }

        /// <summary>
        /// Измельчитель
        /// </summary>
        public Service Mill { get; set; }

        /// <summary>
        /// Статистика по возврату самосвалов
        /// </summary>
        public ActionStatistics ReturnStatistics { get; set; }

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

        /// <summary>
        /// Список всех грузовиков. Используется только при построении модели,
        ///   чтобы при запуске имитации все активировать и тем самым начать имитацию
        /// </summary>
        private SimulationList AllTrucks;

        protected override void Init()
        {
            base.Init();
            Excavators = new Service[Parameters.ExcavatorCount];
            ForwardTrips = new int[Parameters.ExcavatorCount];
            AllTrucks = new SimulationList();
            for (int i = 0; i < Excavators.Length; i++)
            {
                Excavators[i] = new Service($"Экскаватор {i + 1}");

                for (int j = 0; j < Parameters.InitLightTrucks; j++)
                {
                    new Truck
                    {
                        Index = i,
                        Excavator = Excavators[i],
                        Settings = Parameters.LightTruckSettings,
                    }.Insert(AllTrucks);
                }

                for (int j = 0; j < Parameters.InitHeavyTrucks; j++)
                {
                    new Truck
                    {
                        Index = i,
                        Excavator = Excavators[i],
                        Settings = Parameters.HeavyTruckSettings,
                    }.Insert(AllTrucks);
                }
            }

            // Тяжелые самосвалы имеют преимущество в очереди к измельчителю
            Mill = new Service("Измельчитель");
            Mill.Queue.OrderFunc = (a, b) => ((Truck)a).Settings.IsHeavy && !((Truck)b).Settings.IsHeavy;
            ReturnStatistics = new ActionStatistics("Возврат самосвалов");
        }

        protected override void StartEvent()
        {
            AllTrucks.ActivateAll();
            ReactivateDelay(Parameters.SimulationTime);
            StopStat();
        }

        public override void StopStat()
        {
            base.StopStat();
            foreach (var excavator in Excavators)
            {
                excavator.ServiceStat.StopStat();
            }

            Mill.ServiceStat.StopStat();
            ReturnStatistics.StopStat();
        }

        public override void Finish()
        {
            foreach (var excavator in Excavators)
            {
                excavator.Finish();
            }

            Mill.Finish();
            base.Finish();
        }
    }
}
