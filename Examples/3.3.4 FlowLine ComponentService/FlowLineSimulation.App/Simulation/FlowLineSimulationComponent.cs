using FlowLineSimulation.App.Components;
using Simulation.Core.Components;
using Simulation.Core.Histograms;
using Simulation.Core.Primitives;
using Simulation.Core.RandomGenerator;
using Simulation.Core.Services;
using Simulation.Core.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowLineSimulation.App.Simulation
{
    public class FlowLineSimulationComponent : SimComponent
    {
        /// <summary>
        /// Статистика по промежуткам времени между отказами в обслуживании
        /// </summary>
        public TimeBetStatistics BalksStat;

        /// <summary>
        /// Статистика по времени пребывания обслуженных изделий в системе
        /// </summary>
        public SimpleStatistics TimeInSystemStat;

        /// <summary>
        /// Гистограмма по времени пребывания обслуженных изделий в системе
        /// </summary>
        public Histogram TimeHist;

        /// <summary>
        /// Генератор случайных чисел, управляющий поступлением изделий на обработку
        /// </summary>
        public static RandomGenerator RandPiece;

        /// <summary>
        /// Генератор случайных чисел, управляющий продолжительностью операции 
        /// на первом рабочем месте
        /// </summary>
        public static RandomGenerator RandWorker1;

        /// <summary>
        /// Генератор случайных чисел, управляющий продолжительностью операции 
        /// на втором рабочем месте
        /// </summary>
        public static RandomGenerator RandWorker2;

        /// <summary>
        /// Процесс, имитирующий выполнение первой операции
        /// </summary>
        public Service Worker1;

        /// <summary>
        /// Процесс, имитирующий выполнение второй операции
        /// </summary>
        public Service Worker2;

        /// <summary>
        /// Завершение работы имитации
        /// </summary>
        public override void Finish()
        {
            Worker1.Finish();
            Worker2.Finish();
            base.Finish();
        }

        /// <summary>
        /// Создание объектов имитации
        /// </summary>
        protected override void Init()
        {
            base.Init();
            BalksStat = new TimeBetStatistics("Интервалы времени между отказами в обслуживании");
            TimeInSystemStat = new SimpleStatistics("Время в системе");
            TimeHist = new Histogram(Params.HistMin, Params.HistStep, Params.HistStepCount, "Время в системе");
            Worker1 = new Service(1, Params.Queue1MaxSize,
                () => RandWorker1.Exponential(Params.Worker1MeanTime), "Первое рабочее место");
            Worker2 = new Service(1, Params.Queue2MaxSize,
                () => RandWorker2.Exponential(Params.Worker2MeanTime), "Второе рабочее место");
            Worker1.NextService = Worker2;
        }

        /// <summary>
        /// Начало работы
        /// </summary>
        protected override void StartEvent()
        {
            // Создать первое изделие
            (new Piece()).Activate();

            // ОЖидать окончания имитации
            ReactivateDelay(Params.SimulationTime);
        }

        /// <summary>
        /// Коррекция статистики
        /// </summary>
        public override void StopStat()
        {
            base.StopStat();
            Worker1.StopStat();
            Worker2.StopStat();
        }
    }
}
