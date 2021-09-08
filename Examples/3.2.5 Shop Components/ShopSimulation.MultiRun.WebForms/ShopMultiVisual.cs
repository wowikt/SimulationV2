using ShopSimulation.App.Simulation;
using Simulation.Core.Histograms;
using Simulation.Core.RandomGenerator;
using Simulation.Core.Statistics;
using Simulation.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShopSimulation.MultiRun.WebForms
{
    public partial class ShopMultiVisual : Form
    {
        public ShopMultiVisual()
        {
            InitializeComponent();
            ShopSimulationComponent.RandCust = new RandomGenerator();
            ShopSimulationComponent.RandService = new RandomGenerator();
            Program.CashUsageStat = new SimpleStatistics("Занятость кассира");
            Program.TimeStat = new SimpleStatistics("Среднее время пребывания в системе");
            Program.InShopStat = new SimpleStatistics("Среднее количество покупателей в торговом зале");
            Program.InShopMaxStat = new SimpleStatistics("Максимальное количество покупателей в торговом зале");
            Program.MaxQueueLenStat = new SimpleStatistics("Максимальная длина очереди");
            Program.WaitStat = new SimpleStatistics("Среднее время ожидания в очереди");
            Program.TimeHist = new Histogram(Program.HistMin, Program.HistStep, 
                Program.HistStepCount, "Среднее время пребывания в системе");
            dgvHist.InitForHist();
            dgvStat.InitForStat();
        }

        internal int StepNum;

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (tmrShop.Enabled)
            {
                tmrShop.Enabled = false;
            }
            else
            {
                tmrShop.Enabled = true;
                StepNum = 0;
                Program.CashUsageStat.ClearStat();
                Program.TimeStat.ClearStat();
                Program.InShopStat.ClearStat();
                Program.InShopMaxStat.ClearStat();
                Program.MaxQueueLenStat.ClearStat();
                Program.WaitStat.ClearStat();
                Program.TimeHist.Clear();
            }
        }

        private void tmrShop_Tick(object sender, EventArgs e)
        {
            // Создать имитацию
            ShopSimulationComponent ShopSim = new ShopSimulationComponent();
            // Запустить ее
            ShopSim.Start();
            // Собрать статистику
            Program.CashUsageStat.AddData(ShopSim.CashStat.Mean());
            Program.TimeStat.AddData(ShopSim.TimeStat.Mean());
            Program.TimeHist.AddData(ShopSim.TimeStat.Mean());
            Program.InShopStat.AddData(ShopSim.InShopStat.Mean());
            Program.InShopMaxStat.AddData(ShopSim.InShopStat.Max);
            Program.MaxQueueLenStat.AddData(ShopSim.Queue.LengthStat.Max);
            Program.WaitStat.AddData(ShopSim.Queue.TimeStat.Mean());
            // Удалить имитацию
            ShopSim.Finish();
            dgvStat.ShowStat(Program.CashUsageStat, Program.TimeStat, Program.InShopStat, 
                Program.InShopMaxStat, Program.MaxQueueLenStat, Program.WaitStat);
            dgvHist.ShowHist(Program.TimeHist);
            if (++StepNum == Program.RunCount)
            {
                tmrShop.Enabled = false;
            }
            lblRunCount.Text = StepNum.ToString();
        }

        private void dgvHist_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            dgvHist.DrawCell(e, Program.TimeHist);
        }

        private void dgvHist_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                dgvHist.Refresh();
            }
        }
    }
}
