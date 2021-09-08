using PertNetworkSimulation.App;
using PertNetworkSimulation.App.Simulation;
using Simulation.Core.RandomGenerator;
using Simulation.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PertNetworkSimulation.WinForms
{
    public partial class PertNetworkForm : Form
    {
        public PertNetworkForm()
        {
            InitializeComponent();
            StatisticsGridView.InitForStat();
            Node1HistogramGridView.InitForHist();
            Node2HistogramGridView.InitForHist();
            Node3HistogramGridView.InitForHist();
            Node4HistogramGridView.InitForHist();
            Node5HistogramGridView.InitForHist();
            PertNetworkSimulationComponent.ArcRandom = new RandomGenerator();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            int runCount;
            if (int.TryParse(RunCountTextBox.Text, out runCount))
            {
                Parameters.RunCount = runCount;
            }

            for (int i = 1; i < Parameters.NodeCount; i++)
            {
                PertNetworkSimulationComponent.NodeStatistics[i].ClearStat();
                PertNetworkSimulationComponent.NodeHistograms[i].Clear();
            }

            for (int i = 0; i < Parameters.RunCount; i++)
            {
                new PertNetworkSimulationComponent().Start();
            }

            StatisticsGridView.ShowStat(PertNetworkSimulationComponent.NodeStatistics.Skip(1).ToArray());
            Node1HistogramGridView.ShowHist(PertNetworkSimulationComponent.NodeHistograms[1]);
            Node2HistogramGridView.ShowHist(PertNetworkSimulationComponent.NodeHistograms[2]);
            Node3HistogramGridView.ShowHist(PertNetworkSimulationComponent.NodeHistograms[3]);
            Node4HistogramGridView.ShowHist(PertNetworkSimulationComponent.NodeHistograms[4]);
            Node5HistogramGridView.ShowHist(PertNetworkSimulationComponent.NodeHistograms[5]);
        }

        private void PertNetworkForm_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < Parameters.NodeCount; i++)
            {
                PertNetworkSimulationComponent.NodeStatistics[i].ClearStat();
                PertNetworkSimulationComponent.NodeHistograms[i].Clear();
            }
        }

        private void PertNetworkForm_Resize(object sender, EventArgs e)
        {
            int NewWidth = ClientSize.Width;
            int NewHeight = ClientSize.Height;
            StatisticsTabControl.Width = NewWidth - StatisticsTabControl.Location.X * 2;
            StatisticsTabControl.Height = NewHeight - StatisticsTabControl.Location.Y - StatisticsTabControl.Location.X;
            StatisticsTabPage.Width = StatisticsTabControl.ClientRectangle.Width;
            StatisticsTabPage.Height = StatisticsTabControl.ClientRectangle.Height;
            Node1TabPage.Width = StatisticsTabControl.ClientRectangle.Width;
            Node1TabPage.Height = StatisticsTabControl.ClientRectangle.Height;
            Node2TabPage.Width = StatisticsTabControl.ClientRectangle.Width;
            Node2TabPage.Height = StatisticsTabControl.ClientRectangle.Height;
            Node3TabPage.Width = StatisticsTabControl.ClientRectangle.Width;
            Node3TabPage.Height = StatisticsTabControl.ClientRectangle.Height;
            Node4TabPage.Width = StatisticsTabControl.ClientRectangle.Width;
            Node4TabPage.Height = StatisticsTabControl.ClientRectangle.Height;
            Node5TabPage.Width = StatisticsTabControl.ClientRectangle.Width;
            Node5TabPage.Height = StatisticsTabControl.ClientRectangle.Height;
            StatisticsGridView.Width = StatisticsTabPage.ClientSize.Width - StatisticsGridView.Location.X * 2;
            Node1HistogramGridView.Width = Node1TabPage.ClientSize.Width - Node1HistogramGridView.Location.X * 2;
            Node1HistogramGridView.Height = Node1TabPage.ClientSize.Height - Node1HistogramGridView.Location.Y * 2;
            Node2HistogramGridView.Width = Node2TabPage.ClientSize.Width - Node2HistogramGridView.Location.X * 2;
            Node2HistogramGridView.Height = Node2TabPage.ClientSize.Height - Node2HistogramGridView.Location.Y * 2;
            Node3HistogramGridView.Width = Node3TabPage.ClientSize.Width - Node3HistogramGridView.Location.X * 2;
            Node3HistogramGridView.Height = Node3TabPage.ClientSize.Height - Node3HistogramGridView.Location.Y * 2;
            Node4HistogramGridView.Width = Node4TabPage.ClientSize.Width - Node4HistogramGridView.Location.X * 2;
            Node4HistogramGridView.Height = Node4TabPage.ClientSize.Height - Node4HistogramGridView.Location.Y * 2;
            Node5HistogramGridView.Width = Node5TabPage.ClientSize.Width - Node5HistogramGridView.Location.X * 2;
            Node5HistogramGridView.Height = Node5TabPage.ClientSize.Height - Node5HistogramGridView.Location.Y * 2;
        }

        private void NodeHistogramGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            int i = Convert.ToInt32(dgv.Tag);
            dgv.DrawCell(e, PertNetworkSimulationComponent.NodeHistograms[i]);
        }

        private void NodeHistogramGridView_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll && e.NewValue < e.OldValue)
            {
                (sender as DataGridView).Refresh();
            }
        }
    }
}
