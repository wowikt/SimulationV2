using PertNetworkSimulation.App.Components;
using Simulation.Core.Components;
using Simulation.Core.Extensions;
using Simulation.Core.Histograms;
using Simulation.Core.RandomGenerator;
using Simulation.Core.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PertNetworkSimulation.App.Simulation
{
    public class PertNetworkSimulationComponent : SimComponent
    {
        public PertNode[] Nodes { get; set; }

        public static RandomGenerator ArcRandom;

        public static SimpleStatistics[] NodeStatistics;

        public static Histogram[] NodeHistograms;

        static PertNetworkSimulationComponent()
        {
            NodeStatistics = new SimpleStatistics[Parameters.NodeCount];
            NodeHistograms = new Histogram[Parameters.NodeCount];

            for (int i = 1; i < Parameters.NodeCount; i++)
            {
                NodeStatistics[i] = new SimpleStatistics($"Статистика по узлу {i + 1}");
                NodeHistograms[i] = new Histogram(Parameters.HistogramData[i - 1].Min, Parameters.HistogramData[i - 1].Step, 
                    Parameters.HistogramData[i - 1].StepCount, $"Гистограмма по узлу {i + 1}");
            }
        }

        protected override void Init()
        {
            base.Init();

            Nodes = new PertNode[Parameters.NodeCount];
            for (int i = 0; i < Parameters.NodeCount; i++)
            {
                Nodes[i] = new PertNode { Statistics = NodeStatistics[i], Histogram = NodeHistograms[i] };
            }

            Nodes[0].IsFirstNode = true;
            Nodes[Nodes.Length - 1].IsLastNode = true;

            foreach (var arcData in Parameters.ArcData)
            {
                new PertArc
                {
                    EndNode = Nodes[arcData.EndNodeIndex],
                    ActionTime = ArcRandom.Triangular(arcData.MinTime, arcData.ModaTime, arcData.MaxTime),
                }.Insert(Nodes[arcData.StartNodeIndex].OutgoingArcs);

                Nodes[arcData.EndNodeIndex].MinIncomeArcCount++;
            }
        }

        protected override void StartEvent()
        {
            Nodes.ActivateAll();
        }

        public override void Finish()
        {
            foreach (var node in Nodes)
            {
                node.Finish();
            }

            base.Finish();
        }
    }
}
