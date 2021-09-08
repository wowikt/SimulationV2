using FlowLineSimulation.App.Components;
using FlowLineSimulation.App.Services;
using Simulation.Core.Components;
using Simulation.Core.Histograms;
using Simulation.Core.Primitives;
using Simulation.Core.RandomGenerator;
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
        /// Очередь изделий к первому рабочему месту
        /// </summary>
        public SimulationList Queue1;

        /// <summary>
        /// Очередь изделий к второму рабочему месту
        /// </summary>
        public SimulationList Queue2;

        /// <summary>
        /// Статистика по промежуткам времени между отказами в обслуживании
        /// </summary>
        public TimeBetStatistics BalksStat;

        /// <summary>
        /// Статистика по времени пребывания обслуженных изделий в системе
        /// </summary>
        public SimpleStatistics TimeInSystemStat;

        /// <summary>
        /// Статистика по загруженности первого рабочего
        /// </summary>
        public ServiceStatistics Worker1Stat;

        /// <summary>
        /// Статистика по загруженности второго рабочего
        /// </summary>
        public ServiceStatistics Worker2Stat;

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
        internal WorkPlace1 Worker1;

        /// <summary>
        /// Процесс, имитирующий выполнение второй операции
        /// </summary>
        internal WorkPlace2 Worker2;

        /// <summary>
        /// Завершение работы имитации
        /// </summary>
        public override void Finish()
        {
            Worker1.Finish();
            Worker2.Finish();
            Queue1.Finish();
            Queue2.Finish();
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
            Queue1 = new SimulationList(Params.Queue1MaxSize, "Очередь к первому рабочему месту");
            Queue2 = new SimulationList(Params.Queue2MaxSize, "Очередь к второму рабочему месту");
            Worker1 = new WorkPlace1();
            Worker2 = new WorkPlace2();
            Worker1Stat = new ServiceStatistics("Занятость первого рабочего места");
            Worker2Stat = new ServiceStatistics("Занятость второго рабочего места");
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
            Queue1.StopStat();
            Queue2.StopStat();
            Worker1Stat.StopStat();
            Worker2Stat.StopStat();
        }
    }
}
