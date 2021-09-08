using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FlowLineSimulation.App;
using FlowLineSimulation.App.Simulation;
using Simulation;
using Simulation.Core.RandomGenerator;
using Simulation.WinForms;

namespace FlowLineSimulation.WinForms
{
    public partial class FlowLineForm : Form
    {
        public FlowLineForm()
        {
            InitializeComponent();
            FlowLineSimulationComponent.RandPiece = new RandomGenerator();
            FlowLineSimulationComponent.RandWorker1 = new RandomGenerator();
            FlowLineSimulationComponent.RandWorker2 = new RandomGenerator();
            dgvHist.InitForHist();
            dgvQueue.InitForQueueStat();
            dgvService.InitForServiceStat();
            dgvTime.InitForStat();
        }

        internal FlowLineSimulationComponent flSim;

        internal double VisTimeStep = 0.5;

        private void tmrFlowLine_Tick(object sender, EventArgs e)
        {
            lblSimTime.Text = flSim.SimTime().ToString("0.0");
            lblBalks.Text = (flSim.BalksStat.Count + 1).ToString();
            lblQueue1.Text = new string('*', flSim.Queue1.Size);
            lblQueue2.Text = new string('*', flSim.Queue2.Size);
            lblServiced.Text = flSim.Worker2Stat.Finished.ToString();
            lblWorker1.Text = (flSim.Worker1Stat.Blocked > 0) ? "(*)||" : ((flSim.Worker1Stat.Running > 0) ? "(*)  " : "");
            lblWorker2.Text = (flSim.Worker2Stat.Running > 0) ? "(*)" : "";

            Worker1Chart.Series["Series1"].Points.Clear();
            Worker1Chart.Series["Series1"].Points.AddY(flSim.Worker1Stat.Mean());
            Worker1Chart.Series["Series2"].Points.Clear();
            Worker1Chart.Series["Series2"].Points.AddY(flSim.Worker1Stat.MeanBlockage());
            Worker1Chart.Series["Series3"].Points.Clear();
            Worker1Chart.Series["Series3"].Points.AddY(1 - flSim.Worker1Stat.Mean() - flSim.Worker1Stat.MeanBlockage());

            Worker2ProgressBar.Value = (int)(flSim.Worker2Stat.Mean() * 100);

            dgvTime.ShowStat(flSim.TimeInSystemStat, flSim.BalksStat);
            dgvService.ShowStat(flSim.Worker1Stat, flSim.Worker2Stat);
            dgvQueue.ShowStat(flSim.Queue1, flSim.Queue2, flSim.Calendar);
            dgvHist.ShowHist(flSim.TimeHist);
            if (flSim.Terminated)
            {
                tmrFlowLine.Enabled = false;
            }
            else
            {
                flSim.Start();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (tmrFlowLine.Enabled)
            {
                tmrFlowLine.Enabled = false;
            }
            else
            {
                if (flSim != null)
                {
                    flSim.Finish();
                }

                int queue1size;
                if (int.TryParse(Queue1SizeTextBox.Text, out queue1size))
                {
                    if (queue1size < 0)
                    {
                        queue1size = 0;
                        Queue1SizeTextBox.Text = queue1size.ToString();
                    }
                    else if (queue1size > 6)
                    {
                        queue1size = 6;
                        Queue1SizeTextBox.Text = queue1size.ToString();
                    }

                    Params.Queue1MaxSize = queue1size;
                    Params.Queue2MaxSize = Params.TotalQueuesMaxSize - queue1size;
                }

                tmrFlowLine.Enabled = true;
                flSim = new FlowLineSimulationComponent();
                flSim.VisualInterval = VisTimeStep;
                flSim.Start();
            }
        }

        private void dgvHist_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (flSim != null)
            {
                dgvHist.DrawCell(e, flSim.TimeHist);
            }
        }
    }
}
