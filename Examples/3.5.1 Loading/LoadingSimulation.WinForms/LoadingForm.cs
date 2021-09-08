using LoadingSimulation.App;
using LoadingSimulation.App.Simulation;
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

namespace LoadingSimulation.WinForms
{
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
            LoadingSimulationComponent.RandomBulldozer = new RandomGenerator();
            LoadingSimulationComponent.RandomLoader = new RandomGenerator();
            LoadingSimulationComponent.RandomTruck = new RandomGenerator();
            ServiceGridView.InitForServiceStat();
            QueueGridView.InitForQueueStat();
        }

        private LoadingSimulationComponent simulation;

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (LoadingTimer.Enabled)
            {
                LoadingTimer.Enabled = false;
            }
            else
            {
                LoadingTimer.Enabled = true;
                simulation = new LoadingSimulationComponent();
                simulation.VisualInterval = Parameters.VisTimeStep;
                simulation.Start();
            }
        }

        private void LoadingTimer_Tick(object sender, EventArgs e)
        {
            simulation.StopStat();
            TimeLabel.Text = simulation.SimTime().ToString("0.0");
            HeapQueueLabel.Text = new string('o', simulation.HeapQueue.Size);
            LoaderQueueLabel.Text = new string('>', simulation.LoaderQueue.Size);
            TruckQueueLabel.Text = new string('*', simulation.TruckQueue.Size);

            Loader0Label.Text = (simulation.LoadersStatistics[0].Running == 0) ? 
                string.Empty : 
                $"({new string('*', simulation.LoadersStatistics[0].Running)})";
            Loader1Label.Text = (simulation.LoadersStatistics[1].Running == 0) ? 
                string.Empty : 
                $"({new string('*', simulation.LoadersStatistics[1].Running)})";

            ForwardLabel.Text = new string('*', simulation.ForwardCount);
            UnloadLabel.Text = new string('*', simulation.UnloadCount);
            BackLabel.Text = new string('*', simulation.BackwardCount);

            LoadCount0Label.Text = simulation.LoadersStatistics[0].Finished.ToString();
            LoadCount1Label.Text = simulation.LoadersStatistics[1].Finished.ToString();

            LoaderUsage0ProgessBar.Value = (int)(simulation.LoadersStatistics[0].Mean() * 100);
            LoaderUsage1ProgessBar.Value = (int)(simulation.LoadersStatistics[1].Mean() * 100);

            ServiceGridView.ShowStat(simulation.LoadersStatistics[0], simulation.LoadersStatistics[1]);
            QueueGridView.ShowStat(simulation.HeapQueue, simulation.LoaderQueue, simulation.TruckQueue, simulation.Calendar);

            if (simulation.Terminated)
            {
                LoadingTimer.Enabled = false;
            }
            else
            {
                simulation.Start();
            }
        }

        private void LoadingForm_Resize(object sender, EventArgs e)
        {
            int NewWidth = ClientSize.Width;
            int NewHeight = ClientSize.Height;
            StatisticsTab.Width = NewWidth - StatisticsTab.Location.X * 2;
            StatisticsTab.Height = NewHeight - StatisticsTab.Location.Y - StatisticsTab.Location.X;
            StatisticsTabPage.Width = StatisticsTab.ClientRectangle.Width;
            StatisticsTabPage.Height = StatisticsTab.ClientRectangle.Height;
            ServiceGridView.Width = StatisticsTabPage.ClientSize.Width - ServiceGridView.Location.X * 2;
            QueueGridView.Width = StatisticsTabPage.ClientSize.Width - QueueGridView.Location.X * 2;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
