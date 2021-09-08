﻿using Simulation.Core.RandomGenerator;
using Simulation.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TVControl.App;
using TVControl.App.Simulation;

namespace TVControl.WinForms
{
    public partial class TVControlForm : Form
    {
        public TVControlForm()
        {
            InitializeComponent();
            dgvQueue.InitForQueueStat();
            dgvService.InitForServiceStat();
            dgvTime.InitForStat();
            TvControlSimulationComponent.RandAdjuster = new RandomGenerator();
            TvControlSimulationComponent.RandInspector = new RandomGenerator();
            TvControlSimulationComponent.RandTVSet = new RandomGenerator();
        }

        internal TvControlSimulationComponent tvc;

        internal static double VisTimeStep = 0.5;

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (tmrTVControl.Enabled)
            {
                tmrTVControl.Enabled = false;
            }
            else
            {
                tmrTVControl.Enabled = true;
                if (tvc != null)
                {
                    tvc.Finish();
                }
                tvc = new TvControlSimulationComponent();
                tvc.VisualInterval = VisTimeStep;
                tvc.Start();
            }
        }

        private void tmrTVControl_Tick(object sender, EventArgs e)
        {
            lblSimTime.Text = tvc.SimTime().ToString("0.0");
            lblInspectionQueue.Text = new string('*', tvc.InspectionQueue.Size);
            lblAdjustmentQueue.Text = new string('*', tvc.AdjustmentQueue.Size);
            lblInspection.Text = (tvc.InspectorsStat.Running > 0) ? 
                ("(" + new string('*', tvc.InspectorsStat.Running) + ")") : "";
            lblAdjustment.Text = (tvc.AdjustmentStat.Running > 0) ? "(*)" : "";
            InspectionProgressBar.Value = (int)(tvc.InspectorsStat.Mean() / Params.InspectorCount * InspectionProgressBar.Maximum);
            AdjustmentProgressBar.Value = (int)(tvc.AdjustmentStat.Mean() * AdjustmentProgressBar.Maximum);
            dgvTime.ShowStat(tvc.TimeInSystemStat, tvc.AdjustmentCountStatistics);
            dgvService.ShowStat(tvc.InspectorsStat, tvc.AdjustmentStat);
            dgvQueue.ShowStat(tvc.InspectionQueue, tvc.AdjustmentQueue, tvc.Calendar);
            if (tvc.Terminated)
            {
                tmrTVControl.Enabled = false;
            }
            else
            {
                tvc.Start();
            }
        }
    }
}
