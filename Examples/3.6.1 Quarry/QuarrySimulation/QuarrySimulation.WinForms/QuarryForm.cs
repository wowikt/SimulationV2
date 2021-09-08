using QuarrySimulation.App;
using QuarrySimulation.App.Components;
using QuarrySimulation.App.Simulation;
using Simulation.Core.Primitives;
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

namespace QuarrySimulation.WinForms
{
    public partial class QuarryForm : Form
    {
        public QuarryForm()
        {
            InitializeComponent();
            QuarrySimulationComponent.RandomMill = new RandomGenerator();
            QuarrySimulationComponent.RandomTruck = new RandomGenerator();
            ServicesDataGridView.InitForServiceStat();
            ActionsDataGridView.InitForActionStat();
            QueuesDataGridView.InitForQueueStat();
        }

        private QuarrySimulationComponent simulation;

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (SimulatonTimer.Enabled)
            {
                SimulatonTimer.Enabled = false;
            }
            else
            {
                SimulatonTimer.Enabled = true;
                simulation = new QuarrySimulationComponent();
                simulation.VisualInterval = Parameters.VisTimeStep;
                simulation.Start();
            }
        }

        private void SimulatonTimer_Tick(object sender, EventArgs e)
        {
            const string busyString = "(*)";
            simulation.StopStat();
            TimeLabel.Text = simulation.SimTime().ToString("0.0");

            ExcavatorQueue0Label.Text = TruckChars(simulation.ExcavatorQueues[0], 'O', 'o');
            ExcavatorQueue1Label.Text = TruckChars(simulation.ExcavatorQueues[1], 'O', 'o');
            ExcavatorQueue2Label.Text = TruckChars(simulation.ExcavatorQueues[2], 'O', 'o');

            Excavator0Label.Text = simulation.ExcavatorStatistics[0].Running == 0 ? string.Empty : busyString;
            Excavator1Label.Text = simulation.ExcavatorStatistics[1].Running == 0 ? string.Empty : busyString;
            Excavator2Label.Text = simulation.ExcavatorStatistics[2].Running == 0 ? string.Empty : busyString;

            Excavator0CompletedLabel.Text = simulation.ExcavatorStatistics[0].Finished.ToString();
            Excavator1CompletedLabel.Text = simulation.ExcavatorStatistics[1].Finished.ToString();
            Excavator2CompletedLabel.Text = simulation.ExcavatorStatistics[2].Finished.ToString();

            Excavator0ProgressBar.Value = (int)(simulation.ExcavatorStatistics[0].Mean() * 100);
            Excavator1ProgressBar.Value = (int)(simulation.ExcavatorStatistics[1].Mean() * 100);
            Excavator2ProgressBar.Value = (int)(simulation.ExcavatorStatistics[2].Mean() * 100);

            MillQueueLabel.Text = TruckChars(simulation.MillQueue, 'O', 'o');
            MillLabel.Text = simulation.MillStatistics.Running == 0 ? string.Empty : busyString;
            MillCompletedLabel.Text = simulation.MillStatistics.Finished.ToString();
            MillProgressBar.Value = (int)(simulation.MillStatistics.Mean() * 100);

            ForwardTrip0Label.Text = new string('*', simulation.ForwardTrips[0]);
            ForwardTrip1Label.Text = new string('*', simulation.ForwardTrips[1]);
            ForwardTrip2Label.Text = new string('*', simulation.ForwardTrips[2]);
            BackTripLabel.Text = new string('*', simulation.ReturnStatistics.Running);

            HeavyCountLabel.Text = simulation.HeavyCount.ToString();
            LightCountLabel.Text = simulation.LightCount.ToString();
            DeliveredLabel.Text = simulation.Delivered.ToString();

            ServicesDataGridView.ShowStat(simulation.ExcavatorStatistics[0], simulation.ExcavatorStatistics[1], 
                simulation.ExcavatorStatistics[2], simulation.MillStatistics);
            ActionsDataGridView.ShowStat(simulation.ReturnStatistics);
            QueuesDataGridView.ShowStat(simulation.ExcavatorQueues[0], simulation.ExcavatorQueues[1], 
                simulation.ExcavatorQueues[2], simulation.MillQueue, simulation.Calendar);

            if (simulation.Terminated)
            {
                SimulatonTimer.Enabled = false;
            }
            else
            {
                simulation.Start();
            }
        }

        private string TruckChars(SimulationList queue, char heavyChar, char lightChar)
        {
            StringBuilder result = new StringBuilder();
            Truck prevTruck = queue.Last as Truck;
            if (prevTruck != null)
            {
                Truck truck;
                do
                {
                    truck = prevTruck;
                    prevTruck = truck.Prev as Truck;
                    result.Append(truck.Settings.IsHeavy ? heavyChar : lightChar);
                } while (truck != queue.First);
            }

            return result.ToString();
        }

        private void QuarryForm_Resize(object sender, EventArgs e)
        {
            int NewWidth = ClientSize.Width;
            int NewHeight = ClientSize.Height;
            StatistcsTabControl.Width = NewWidth - StatistcsTabControl.Location.X * 2;
            StatistcsTabControl.Height = NewHeight - StatistcsTabControl.Location.Y - StatistcsTabControl.Location.X;
            ActionsTabPage.Width = StatistcsTabControl.ClientRectangle.Width;
            ActionsTabPage.Height = StatistcsTabControl.ClientRectangle.Height;
            QueuesTabPage.Width = StatistcsTabControl.ClientRectangle.Width;
            QueuesTabPage.Height = StatistcsTabControl.ClientRectangle.Height;
            ServicesDataGridView.Width = ActionsTabPage.ClientSize.Width - ServicesDataGridView.Location.X * 2;
            ActionsDataGridView.Width = ActionsTabPage.ClientSize.Width - ActionsDataGridView.Location.X * 2;
            QueuesDataGridView.Width = QueuesTabPage.ClientSize.Width - QueuesDataGridView.Location.X * 2;
        }
    }
}
