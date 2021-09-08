using QuarrySimulation.App.Settings;
using QuarrySimulation.App.Simulation;
using Simulation.Core.Actions;
using Simulation.Core.Components;
using Simulation.Core.Primitives;
using Simulation.Core.Processes;
using Simulation.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuarrySimulation.App.Components
{
    public class Truck : SchedulableComponent
    {
        public int Index { get; set; }

        /// <summary>
        /// Экскаватор
        /// </summary>
        public Service Excavator { get; set; }

        /// <summary>
        /// Характеристики
        /// </summary>
        public TruckSettings Settings { get; set; }

        /// <summary>
        /// Событие начала работы самосвала
        /// </summary>
        protected override void StartEvent()
        {
            // Запустить сервис экскаватора
            DoService(Excavator, QuarrySimulationComponent.RandomTruck.Exponential(Settings.LoadingTime), LoadedEvent);
        }

        /// <summary>
        /// Самосвал загружен - следовать к измельчителю
        /// </summary>
        protected void LoadedEvent()
        {
            QuarrySimulationComponent simulation = Parent as QuarrySimulationComponent;

            // Самосвал загружен и отправляется к измельчителю
            simulation.ForwardTrips[Index]++;
            ReactivateDelay(Settings.TripTime + Parameters.ExtraTripTime, ArrivedToMillEvent);
        }

        /// <summary>
        /// Прибытие к измельчителю
        /// </summary>
        protected void ArrivedToMillEvent()
        {
            QuarrySimulationComponent simulation = Parent as QuarrySimulationComponent;
            simulation.ForwardTrips[Index]--;

            // Активировать разгрузку
            DoService(simulation.Mill, QuarrySimulationComponent.RandomMill.Exponential(Settings.UnloadingTime), MillFinishedEvent);
        }

        /// <summary>
        /// Разгрузка окончена - следовать к экскаватору
        /// </summary>
        protected void MillFinishedEvent()
        {
            QuarrySimulationComponent simulation = Parent as QuarrySimulationComponent;

            // Собрать данные по разгруженному самосвалу
            if (Settings.IsHeavy)
            {
                simulation.HeavyCount++;
            }
            else
            {
                simulation.LightCount++;
            }

            simulation.Delivered += Settings.Tonnage;

            // Обратный путь с записью статистики
            simulation.ReturnStatistics.Start();
            ReactivateDelay(Settings.TripTime, GotBackEvent);
        }

        /// <summary>
        /// Прибытие к экскаватору
        /// </summary>
        protected void GotBackEvent()
        {
            QuarrySimulationComponent simulation = Parent as QuarrySimulationComponent;

            // Завершить сбор статистики и начать заново
            simulation.ReturnStatistics.Finish();
            Reactivate(StartEvent);
        }

        /// <summary>
        /// Событие окончания сервиса
        /// </summary>
        /// <param name="act"></param>
        protected override void ActionFinishedEvent(IAction act)
        {
            base.ActionFinishedEvent(act);

            // Перейти к следующему запланированному событию
            OnNextScheduledEvent();
        }
    }
}
