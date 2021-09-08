namespace LoadingSimulation.WinForms
{
    partial class LoadingForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LoaderQueueLabel = new System.Windows.Forms.Label();
            this.TruckQueueLabel = new System.Windows.Forms.Label();
            this.HeapQueueLabel = new System.Windows.Forms.Label();
            this.LoaderUsage0ProgessBar = new System.Windows.Forms.ProgressBar();
            this.LoaderUsage1ProgessBar = new System.Windows.Forms.ProgressBar();
            this.Loader0Label = new System.Windows.Forms.Label();
            this.Loader1Label = new System.Windows.Forms.Label();
            this.LoadCount0Label = new System.Windows.Forms.Label();
            this.LoadCount1Label = new System.Windows.Forms.Label();
            this.ForwardLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BackLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ModelingTimeTextBox = new System.Windows.Forms.TextBox();
            this.StatisticsTab = new System.Windows.Forms.TabControl();
            this.StatisticsTabPage = new System.Windows.Forms.TabPage();
            this.ServiceGridView = new System.Windows.Forms.DataGridView();
            this.QueueGridView = new System.Windows.Forms.DataGridView();
            this.StartButton = new System.Windows.Forms.Button();
            this.LoadingTimer = new System.Windows.Forms.Timer(this.components);
            this.UnloadLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.StatisticsTab.SuspendLayout();
            this.StatisticsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ServiceGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QueueGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(83, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Погрузчики";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(13, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 31);
            this.label2.TabIndex = 0;
            this.label2.Text = "Кучи";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(83, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 31);
            this.label3.TabIndex = 0;
            this.label3.Text = "Самосвалы";
            // 
            // LoaderQueueLabel
            // 
            this.LoaderQueueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoaderQueueLabel.Location = new System.Drawing.Point(222, 9);
            this.LoaderQueueLabel.Name = "LoaderQueueLabel";
            this.LoaderQueueLabel.Size = new System.Drawing.Size(63, 31);
            this.LoaderQueueLabel.TabIndex = 0;
            this.LoaderQueueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TruckQueueLabel
            // 
            this.TruckQueueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TruckQueueLabel.Location = new System.Drawing.Point(222, 92);
            this.TruckQueueLabel.Name = "TruckQueueLabel";
            this.TruckQueueLabel.Size = new System.Drawing.Size(63, 31);
            this.TruckQueueLabel.TabIndex = 0;
            this.TruckQueueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // HeapQueueLabel
            // 
            this.HeapQueueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HeapQueueLabel.Location = new System.Drawing.Point(105, 49);
            this.HeapQueueLabel.Name = "HeapQueueLabel";
            this.HeapQueueLabel.Size = new System.Drawing.Size(152, 31);
            this.HeapQueueLabel.TabIndex = 0;
            this.HeapQueueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LoaderUsage0ProgessBar
            // 
            this.LoaderUsage0ProgessBar.Location = new System.Drawing.Point(292, 9);
            this.LoaderUsage0ProgessBar.Name = "LoaderUsage0ProgessBar";
            this.LoaderUsage0ProgessBar.Size = new System.Drawing.Size(129, 23);
            this.LoaderUsage0ProgessBar.TabIndex = 1;
            // 
            // LoaderUsage1ProgessBar
            // 
            this.LoaderUsage1ProgessBar.Location = new System.Drawing.Point(292, 100);
            this.LoaderUsage1ProgessBar.Name = "LoaderUsage1ProgessBar";
            this.LoaderUsage1ProgessBar.Size = new System.Drawing.Size(129, 23);
            this.LoaderUsage1ProgessBar.TabIndex = 1;
            // 
            // Loader0Label
            // 
            this.Loader0Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Loader0Label.Location = new System.Drawing.Point(310, 35);
            this.Loader0Label.Name = "Loader0Label";
            this.Loader0Label.Size = new System.Drawing.Size(97, 31);
            this.Loader0Label.TabIndex = 0;
            this.Loader0Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Loader1Label
            // 
            this.Loader1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Loader1Label.Location = new System.Drawing.Point(310, 66);
            this.Loader1Label.Name = "Loader1Label";
            this.Loader1Label.Size = new System.Drawing.Size(97, 31);
            this.Loader1Label.TabIndex = 0;
            this.Loader1Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoadCount0Label
            // 
            this.LoadCount0Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoadCount0Label.Location = new System.Drawing.Point(427, 9);
            this.LoadCount0Label.Name = "LoadCount0Label";
            this.LoadCount0Label.Size = new System.Drawing.Size(44, 31);
            this.LoadCount0Label.TabIndex = 0;
            this.LoadCount0Label.Text = "0";
            this.LoadCount0Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LoadCount1Label
            // 
            this.LoadCount1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoadCount1Label.Location = new System.Drawing.Point(427, 92);
            this.LoadCount1Label.Name = "LoadCount1Label";
            this.LoadCount1Label.Size = new System.Drawing.Size(44, 31);
            this.LoadCount1Label.TabIndex = 0;
            this.LoadCount1Label.Text = "0";
            this.LoadCount1Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ForwardLabel
            // 
            this.ForwardLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForwardLabel.Location = new System.Drawing.Point(523, 46);
            this.ForwardLabel.Name = "ForwardLabel";
            this.ForwardLabel.Size = new System.Drawing.Size(75, 31);
            this.ForwardLabel.TabIndex = 0;
            this.ForwardLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(705, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 31);
            this.label4.TabIndex = 0;
            this.label4.Text = "Разгрузка";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BackLabel
            // 
            this.BackLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BackLabel.Location = new System.Drawing.Point(523, 135);
            this.BackLabel.Name = "BackLabel";
            this.BackLabel.Size = new System.Drawing.Size(75, 31);
            this.BackLabel.TabIndex = 0;
            this.BackLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(13, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 31);
            this.label5.TabIndex = 0;
            this.label5.Text = "Время";
            // 
            // TimeLabel
            // 
            this.TimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TimeLabel.Location = new System.Drawing.Point(96, 166);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(86, 31);
            this.TimeLabel.TabIndex = 0;
            this.TimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(13, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(240, 31);
            this.label6.TabIndex = 0;
            this.label6.Text = "Время моделирования";
            // 
            // ModelingTimeTextBox
            // 
            this.ModelingTimeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ModelingTimeTextBox.Location = new System.Drawing.Point(259, 197);
            this.ModelingTimeTextBox.Name = "ModelingTimeTextBox";
            this.ModelingTimeTextBox.Size = new System.Drawing.Size(100, 31);
            this.ModelingTimeTextBox.TabIndex = 2;
            this.ModelingTimeTextBox.Text = "480";
            this.ModelingTimeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // StatisticsTab
            // 
            this.StatisticsTab.Controls.Add(this.StatisticsTabPage);
            this.StatisticsTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StatisticsTab.Location = new System.Drawing.Point(13, 235);
            this.StatisticsTab.Name = "StatisticsTab";
            this.StatisticsTab.SelectedIndex = 0;
            this.StatisticsTab.Size = new System.Drawing.Size(959, 318);
            this.StatisticsTab.TabIndex = 3;
            // 
            // StatisticsTabPage
            // 
            this.StatisticsTabPage.Controls.Add(this.QueueGridView);
            this.StatisticsTabPage.Controls.Add(this.ServiceGridView);
            this.StatisticsTabPage.Location = new System.Drawing.Point(4, 29);
            this.StatisticsTabPage.Name = "StatisticsTabPage";
            this.StatisticsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.StatisticsTabPage.Size = new System.Drawing.Size(951, 285);
            this.StatisticsTabPage.TabIndex = 0;
            this.StatisticsTabPage.Text = "Статистика";
            this.StatisticsTabPage.UseVisualStyleBackColor = true;
            // 
            // ServiceGridView
            // 
            this.ServiceGridView.AllowUserToAddRows = false;
            this.ServiceGridView.AllowUserToDeleteRows = false;
            this.ServiceGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.Padding = new System.Windows.Forms.Padding(0, 1, 1, 0);
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ServiceGridView.DefaultCellStyle = dataGridViewCellStyle9;
            this.ServiceGridView.Location = new System.Drawing.Point(7, 7);
            this.ServiceGridView.Name = "ServiceGridView";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.Padding = new System.Windows.Forms.Padding(0, 1, 0, 1);
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ServiceGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.ServiceGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.ServiceGridView.RowTemplate.Height = 24;
            this.ServiceGridView.Size = new System.Drawing.Size(938, 116);
            this.ServiceGridView.TabIndex = 0;
            // 
            // QueueGridView
            // 
            this.QueueGridView.AllowUserToAddRows = false;
            this.QueueGridView.AllowUserToDeleteRows = false;
            this.QueueGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.QueueGridView.Location = new System.Drawing.Point(6, 129);
            this.QueueGridView.Name = "QueueGridView";
            this.QueueGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.QueueGridView.RowTemplate.Height = 24;
            this.QueueGridView.Size = new System.Drawing.Size(938, 150);
            this.QueueGridView.TabIndex = 0;
            // 
            // StartButton
            // 
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartButton.Location = new System.Drawing.Point(366, 197);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(105, 31);
            this.StartButton.TabIndex = 4;
            this.StartButton.Text = "Пуск";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // LoadingTimer
            // 
            this.LoadingTimer.Tick += new System.EventHandler(this.LoadingTimer_Tick);
            // 
            // UnloadLabel
            // 
            this.UnloadLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UnloadLabel.Location = new System.Drawing.Point(834, 46);
            this.UnloadLabel.Name = "UnloadLabel";
            this.UnloadLabel.Size = new System.Drawing.Size(75, 31);
            this.UnloadLabel.TabIndex = 0;
            this.UnloadLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(463, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 31);
            this.label7.TabIndex = 0;
            this.label7.Text = "==>";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(626, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 31);
            this.label8.TabIndex = 0;
            this.label8.Text = "==>";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(626, 135);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 31);
            this.label9.TabIndex = 0;
            this.label9.Text = "<==";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(245, 135);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(176, 31);
            this.label10.TabIndex = 0;
            this.label10.Text = "^============";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(263, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(22, 31);
            this.label11.TabIndex = 0;
            this.label11.Text = "/";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label11.Click += new System.EventHandler(this.label7_Click);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(263, 66);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(22, 31);
            this.label12.TabIndex = 0;
            this.label12.Text = "\\";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label12.Click += new System.EventHandler(this.label7_Click);
            // 
            // LoadingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 565);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.StatisticsTab);
            this.Controls.Add(this.ModelingTimeTextBox);
            this.Controls.Add(this.LoaderUsage1ProgessBar);
            this.Controls.Add(this.LoaderUsage0ProgessBar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.TruckQueueLabel);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.UnloadLabel);
            this.Controls.Add(this.BackLabel);
            this.Controls.Add(this.ForwardLabel);
            this.Controls.Add(this.HeapQueueLabel);
            this.Controls.Add(this.Loader1Label);
            this.Controls.Add(this.Loader0Label);
            this.Controls.Add(this.LoadCount1Label);
            this.Controls.Add(this.LoadCount0Label);
            this.Controls.Add(this.LoaderQueueLabel);
            this.Controls.Add(this.label1);
            this.Name = "LoadingForm";
            this.Text = "Грузоперевозки";
            this.Resize += new System.EventHandler(this.LoadingForm_Resize);
            this.StatisticsTab.ResumeLayout(false);
            this.StatisticsTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ServiceGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QueueGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LoaderQueueLabel;
        private System.Windows.Forms.Label TruckQueueLabel;
        private System.Windows.Forms.Label HeapQueueLabel;
        private System.Windows.Forms.ProgressBar LoaderUsage0ProgessBar;
        private System.Windows.Forms.ProgressBar LoaderUsage1ProgessBar;
        private System.Windows.Forms.Label Loader0Label;
        private System.Windows.Forms.Label Loader1Label;
        private System.Windows.Forms.Label LoadCount0Label;
        private System.Windows.Forms.Label LoadCount1Label;
        private System.Windows.Forms.Label ForwardLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label BackLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ModelingTimeTextBox;
        private System.Windows.Forms.TabControl StatisticsTab;
        private System.Windows.Forms.TabPage StatisticsTabPage;
        private System.Windows.Forms.DataGridView QueueGridView;
        private System.Windows.Forms.DataGridView ServiceGridView;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Timer LoadingTimer;
        private System.Windows.Forms.Label UnloadLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}

