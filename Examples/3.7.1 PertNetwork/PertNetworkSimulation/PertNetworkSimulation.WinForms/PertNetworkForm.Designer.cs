namespace PertNetworkSimulation.WinForms
{
    partial class PertNetworkForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.RunCountTextBox = new System.Windows.Forms.TextBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.StatisticsTabControl = new System.Windows.Forms.TabControl();
            this.StatisticsTabPage = new System.Windows.Forms.TabPage();
            this.Node1TabPage = new System.Windows.Forms.TabPage();
            this.Node2TabPage = new System.Windows.Forms.TabPage();
            this.Node3TabPage = new System.Windows.Forms.TabPage();
            this.Node4TabPage = new System.Windows.Forms.TabPage();
            this.Node5TabPage = new System.Windows.Forms.TabPage();
            this.StatisticsGridView = new System.Windows.Forms.DataGridView();
            this.Node1HistogramGridView = new System.Windows.Forms.DataGridView();
            this.Node2HistogramGridView = new System.Windows.Forms.DataGridView();
            this.Node3HistogramGridView = new System.Windows.Forms.DataGridView();
            this.Node4HistogramGridView = new System.Windows.Forms.DataGridView();
            this.Node5HistogramGridView = new System.Windows.Forms.DataGridView();
            this.StatisticsTabControl.SuspendLayout();
            this.StatisticsTabPage.SuspendLayout();
            this.Node1TabPage.SuspendLayout();
            this.Node2TabPage.SuspendLayout();
            this.Node3TabPage.SuspendLayout();
            this.Node4TabPage.SuspendLayout();
            this.Node5TabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StatisticsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Node1HistogramGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Node2HistogramGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Node3HistogramGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Node4HistogramGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Node5HistogramGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Количество прогонов:";
            // 
            // RunCountTextBox
            // 
            this.RunCountTextBox.Location = new System.Drawing.Point(252, 13);
            this.RunCountTextBox.Name = "RunCountTextBox";
            this.RunCountTextBox.Size = new System.Drawing.Size(100, 31);
            this.RunCountTextBox.TabIndex = 1;
            this.RunCountTextBox.Text = "400";
            this.RunCountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(359, 13);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(110, 31);
            this.StartButton.TabIndex = 2;
            this.StartButton.Text = "Пуск";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // StatisticsTabControl
            // 
            this.StatisticsTabControl.Controls.Add(this.StatisticsTabPage);
            this.StatisticsTabControl.Controls.Add(this.Node1TabPage);
            this.StatisticsTabControl.Controls.Add(this.Node2TabPage);
            this.StatisticsTabControl.Controls.Add(this.Node3TabPage);
            this.StatisticsTabControl.Controls.Add(this.Node4TabPage);
            this.StatisticsTabControl.Controls.Add(this.Node5TabPage);
            this.StatisticsTabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StatisticsTabControl.Location = new System.Drawing.Point(19, 45);
            this.StatisticsTabControl.Name = "StatisticsTabControl";
            this.StatisticsTabControl.SelectedIndex = 0;
            this.StatisticsTabControl.Size = new System.Drawing.Size(1003, 445);
            this.StatisticsTabControl.TabIndex = 3;
            // 
            // StatisticsTabPage
            // 
            this.StatisticsTabPage.Controls.Add(this.StatisticsGridView);
            this.StatisticsTabPage.Location = new System.Drawing.Point(4, 29);
            this.StatisticsTabPage.Name = "StatisticsTabPage";
            this.StatisticsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.StatisticsTabPage.Size = new System.Drawing.Size(995, 412);
            this.StatisticsTabPage.TabIndex = 0;
            this.StatisticsTabPage.Text = "Статистика";
            this.StatisticsTabPage.UseVisualStyleBackColor = true;
            // 
            // Node1TabPage
            // 
            this.Node1TabPage.Controls.Add(this.Node1HistogramGridView);
            this.Node1TabPage.Location = new System.Drawing.Point(4, 29);
            this.Node1TabPage.Name = "Node1TabPage";
            this.Node1TabPage.Padding = new System.Windows.Forms.Padding(3);
            this.Node1TabPage.Size = new System.Drawing.Size(995, 412);
            this.Node1TabPage.TabIndex = 1;
            this.Node1TabPage.Text = "Узел 1";
            this.Node1TabPage.UseVisualStyleBackColor = true;
            // 
            // Node2TabPage
            // 
            this.Node2TabPage.Controls.Add(this.Node2HistogramGridView);
            this.Node2TabPage.Location = new System.Drawing.Point(4, 29);
            this.Node2TabPage.Name = "Node2TabPage";
            this.Node2TabPage.Padding = new System.Windows.Forms.Padding(3);
            this.Node2TabPage.Size = new System.Drawing.Size(995, 412);
            this.Node2TabPage.TabIndex = 2;
            this.Node2TabPage.Text = "Узел 2";
            this.Node2TabPage.UseVisualStyleBackColor = true;
            // 
            // Node3TabPage
            // 
            this.Node3TabPage.Controls.Add(this.Node3HistogramGridView);
            this.Node3TabPage.Location = new System.Drawing.Point(4, 29);
            this.Node3TabPage.Name = "Node3TabPage";
            this.Node3TabPage.Size = new System.Drawing.Size(995, 412);
            this.Node3TabPage.TabIndex = 3;
            this.Node3TabPage.Text = "Узел 3";
            this.Node3TabPage.UseVisualStyleBackColor = true;
            // 
            // Node4TabPage
            // 
            this.Node4TabPage.Controls.Add(this.Node4HistogramGridView);
            this.Node4TabPage.Location = new System.Drawing.Point(4, 29);
            this.Node4TabPage.Name = "Node4TabPage";
            this.Node4TabPage.Size = new System.Drawing.Size(995, 412);
            this.Node4TabPage.TabIndex = 4;
            this.Node4TabPage.Text = "Узел 4";
            this.Node4TabPage.UseVisualStyleBackColor = true;
            // 
            // Node5TabPage
            // 
            this.Node5TabPage.Controls.Add(this.Node5HistogramGridView);
            this.Node5TabPage.Location = new System.Drawing.Point(4, 29);
            this.Node5TabPage.Name = "Node5TabPage";
            this.Node5TabPage.Size = new System.Drawing.Size(995, 412);
            this.Node5TabPage.TabIndex = 5;
            this.Node5TabPage.Text = "Завершение работы";
            this.Node5TabPage.UseVisualStyleBackColor = true;
            // 
            // StatisticsGridView
            // 
            this.StatisticsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StatisticsGridView.Location = new System.Drawing.Point(7, 6);
            this.StatisticsGridView.Name = "StatisticsGridView";
            this.StatisticsGridView.Size = new System.Drawing.Size(982, 201);
            this.StatisticsGridView.TabIndex = 0;
            // 
            // Node1HistogramGridView
            // 
            this.Node1HistogramGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Node1HistogramGridView.Location = new System.Drawing.Point(7, 6);
            this.Node1HistogramGridView.Name = "Node1HistogramGridView";
            this.Node1HistogramGridView.Size = new System.Drawing.Size(982, 399);
            this.Node1HistogramGridView.TabIndex = 0;
            this.Node1HistogramGridView.Tag = "1";
            this.Node1HistogramGridView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.NodeHistogramGridView_CellPainting);
            this.Node1HistogramGridView.Scroll += new System.Windows.Forms.ScrollEventHandler(this.NodeHistogramGridView_Scroll);
            // 
            // Node2HistogramGridView
            // 
            this.Node2HistogramGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Node2HistogramGridView.Location = new System.Drawing.Point(7, 6);
            this.Node2HistogramGridView.Name = "Node2HistogramGridView";
            this.Node2HistogramGridView.Size = new System.Drawing.Size(982, 400);
            this.Node2HistogramGridView.TabIndex = 0;
            this.Node2HistogramGridView.Tag = "2";
            this.Node2HistogramGridView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.NodeHistogramGridView_CellPainting);
            this.Node2HistogramGridView.Scroll += new System.Windows.Forms.ScrollEventHandler(this.NodeHistogramGridView_Scroll);
            // 
            // Node3HistogramGridView
            // 
            this.Node3HistogramGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Node3HistogramGridView.Location = new System.Drawing.Point(7, 6);
            this.Node3HistogramGridView.Name = "Node3HistogramGridView";
            this.Node3HistogramGridView.Size = new System.Drawing.Size(982, 400);
            this.Node3HistogramGridView.TabIndex = 0;
            this.Node3HistogramGridView.Tag = "3";
            this.Node3HistogramGridView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.NodeHistogramGridView_CellPainting);
            this.Node3HistogramGridView.Scroll += new System.Windows.Forms.ScrollEventHandler(this.NodeHistogramGridView_Scroll);
            // 
            // Node4HistogramGridView
            // 
            this.Node4HistogramGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Node4HistogramGridView.Location = new System.Drawing.Point(7, 6);
            this.Node4HistogramGridView.Name = "Node4HistogramGridView";
            this.Node4HistogramGridView.Size = new System.Drawing.Size(982, 400);
            this.Node4HistogramGridView.TabIndex = 0;
            this.Node4HistogramGridView.Tag = "4";
            this.Node4HistogramGridView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.NodeHistogramGridView_CellPainting);
            this.Node4HistogramGridView.Scroll += new System.Windows.Forms.ScrollEventHandler(this.NodeHistogramGridView_Scroll);
            // 
            // Node5HistogramGridView
            // 
            this.Node5HistogramGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Node5HistogramGridView.Location = new System.Drawing.Point(7, 6);
            this.Node5HistogramGridView.Name = "Node5HistogramGridView";
            this.Node5HistogramGridView.Size = new System.Drawing.Size(982, 400);
            this.Node5HistogramGridView.TabIndex = 0;
            this.Node5HistogramGridView.Tag = "5";
            this.Node5HistogramGridView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.NodeHistogramGridView_CellPainting);
            this.Node5HistogramGridView.Scroll += new System.Windows.Forms.ScrollEventHandler(this.NodeHistogramGridView_Scroll);
            // 
            // PertNetworkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 502);
            this.Controls.Add(this.StatisticsTabControl);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.RunCountTextBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "PertNetworkForm";
            this.Text = "Сеть PERT";
            this.Load += new System.EventHandler(this.PertNetworkForm_Load);
            this.Resize += new System.EventHandler(this.PertNetworkForm_Resize);
            this.StatisticsTabControl.ResumeLayout(false);
            this.StatisticsTabPage.ResumeLayout(false);
            this.Node1TabPage.ResumeLayout(false);
            this.Node2TabPage.ResumeLayout(false);
            this.Node3TabPage.ResumeLayout(false);
            this.Node4TabPage.ResumeLayout(false);
            this.Node5TabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StatisticsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Node1HistogramGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Node2HistogramGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Node3HistogramGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Node4HistogramGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Node5HistogramGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox RunCountTextBox;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.TabControl StatisticsTabControl;
        private System.Windows.Forms.TabPage StatisticsTabPage;
        private System.Windows.Forms.DataGridView StatisticsGridView;
        private System.Windows.Forms.TabPage Node1TabPage;
        private System.Windows.Forms.DataGridView Node1HistogramGridView;
        private System.Windows.Forms.TabPage Node2TabPage;
        private System.Windows.Forms.TabPage Node3TabPage;
        private System.Windows.Forms.TabPage Node4TabPage;
        private System.Windows.Forms.TabPage Node5TabPage;
        private System.Windows.Forms.DataGridView Node2HistogramGridView;
        private System.Windows.Forms.DataGridView Node3HistogramGridView;
        private System.Windows.Forms.DataGridView Node4HistogramGridView;
        private System.Windows.Forms.DataGridView Node5HistogramGridView;
    }
}

