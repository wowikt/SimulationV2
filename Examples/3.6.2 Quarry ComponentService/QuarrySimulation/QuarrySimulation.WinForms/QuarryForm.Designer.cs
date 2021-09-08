namespace QuarrySimulation.WinForms
{
    partial class QuarryForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ExcavatorQueue0Label = new System.Windows.Forms.Label();
            this.Excavator0Label = new System.Windows.Forms.Label();
            this.Excavator0CompletedLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.Excavator0ProgressBar = new System.Windows.Forms.ProgressBar();
            this.ForwardTrip0Label = new System.Windows.Forms.Label();
            this.ExcavatorQueue1Label = new System.Windows.Forms.Label();
            this.Excavator1Label = new System.Windows.Forms.Label();
            this.ForwardTrip1Label = new System.Windows.Forms.Label();
            this.Excavator1CompletedLabel = new System.Windows.Forms.Label();
            this.Excavator1ProgressBar = new System.Windows.Forms.ProgressBar();
            this.ExcavatorQueue2Label = new System.Windows.Forms.Label();
            this.Excavator2Label = new System.Windows.Forms.Label();
            this.ForwardTrip2Label = new System.Windows.Forms.Label();
            this.Excavator2CompletedLabel = new System.Windows.Forms.Label();
            this.Excavator2ProgressBar = new System.Windows.Forms.ProgressBar();
            this.MillQueueLabel = new System.Windows.Forms.Label();
            this.MillLabel = new System.Windows.Forms.Label();
            this.MillProgressBar = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.MillCompletedLabel = new System.Windows.Forms.Label();
            this.BackTripLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.HeavyCountLabel = new System.Windows.Forms.Label();
            this.LightCountLabel = new System.Windows.Forms.Label();
            this.DeliveredLabel = new System.Windows.Forms.Label();
            this.SimulationTimeTextBox = new System.Windows.Forms.TextBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.StatistcsTabControl = new System.Windows.Forms.TabControl();
            this.ActionsTabPage = new System.Windows.Forms.TabPage();
            this.QueuesTabPage = new System.Windows.Forms.TabPage();
            this.ServicesDataGridView = new System.Windows.Forms.DataGridView();
            this.ActionsDataGridView = new System.Windows.Forms.DataGridView();
            this.QueuesDataGridView = new System.Windows.Forms.DataGridView();
            this.SimulatonTimer = new System.Windows.Forms.Timer(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.StatistcsTabControl.SuspendLayout();
            this.ActionsTabPage.SuspendLayout();
            this.QueuesTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ServicesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ActionsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QueuesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Самосвалы";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(154, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 33);
            this.label2.TabIndex = 0;
            this.label2.Text = "Экскаваторы";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ExcavatorQueue0Label
            // 
            this.ExcavatorQueue0Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExcavatorQueue0Label.Location = new System.Drawing.Point(12, 42);
            this.ExcavatorQueue0Label.Name = "ExcavatorQueue0Label";
            this.ExcavatorQueue0Label.Size = new System.Drawing.Size(136, 33);
            this.ExcavatorQueue0Label.TabIndex = 0;
            this.ExcavatorQueue0Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Excavator0Label
            // 
            this.Excavator0Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Excavator0Label.Location = new System.Drawing.Point(154, 42);
            this.Excavator0Label.Name = "Excavator0Label";
            this.Excavator0Label.Size = new System.Drawing.Size(90, 33);
            this.Excavator0Label.TabIndex = 0;
            this.Excavator0Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Excavator0CompletedLabel
            // 
            this.Excavator0CompletedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Excavator0CompletedLabel.Location = new System.Drawing.Point(250, 42);
            this.Excavator0CompletedLabel.Name = "Excavator0CompletedLabel";
            this.Excavator0CompletedLabel.Size = new System.Drawing.Size(58, 33);
            this.Excavator0CompletedLabel.TabIndex = 0;
            this.Excavator0CompletedLabel.Text = "0";
            this.Excavator0CompletedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(314, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 33);
            this.label3.TabIndex = 0;
            this.label3.Text = "Время";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TimeLabel
            // 
            this.TimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TimeLabel.Location = new System.Drawing.Point(399, 9);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(85, 33);
            this.TimeLabel.TabIndex = 0;
            this.TimeLabel.Text = "0";
            this.TimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Excavator0ProgressBar
            // 
            this.Excavator0ProgressBar.Location = new System.Drawing.Point(319, 46);
            this.Excavator0ProgressBar.Name = "Excavator0ProgressBar";
            this.Excavator0ProgressBar.Size = new System.Drawing.Size(100, 23);
            this.Excavator0ProgressBar.TabIndex = 1;
            // 
            // ForwardTrip0Label
            // 
            this.ForwardTrip0Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForwardTrip0Label.Location = new System.Drawing.Point(425, 42);
            this.ForwardTrip0Label.Name = "ForwardTrip0Label";
            this.ForwardTrip0Label.Size = new System.Drawing.Size(90, 33);
            this.ForwardTrip0Label.TabIndex = 0;
            this.ForwardTrip0Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ExcavatorQueue1Label
            // 
            this.ExcavatorQueue1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExcavatorQueue1Label.Location = new System.Drawing.Point(12, 86);
            this.ExcavatorQueue1Label.Name = "ExcavatorQueue1Label";
            this.ExcavatorQueue1Label.Size = new System.Drawing.Size(136, 33);
            this.ExcavatorQueue1Label.TabIndex = 0;
            this.ExcavatorQueue1Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Excavator1Label
            // 
            this.Excavator1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Excavator1Label.Location = new System.Drawing.Point(154, 86);
            this.Excavator1Label.Name = "Excavator1Label";
            this.Excavator1Label.Size = new System.Drawing.Size(90, 33);
            this.Excavator1Label.TabIndex = 0;
            this.Excavator1Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ForwardTrip1Label
            // 
            this.ForwardTrip1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForwardTrip1Label.Location = new System.Drawing.Point(425, 86);
            this.ForwardTrip1Label.Name = "ForwardTrip1Label";
            this.ForwardTrip1Label.Size = new System.Drawing.Size(90, 33);
            this.ForwardTrip1Label.TabIndex = 0;
            this.ForwardTrip1Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Excavator1CompletedLabel
            // 
            this.Excavator1CompletedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Excavator1CompletedLabel.Location = new System.Drawing.Point(250, 86);
            this.Excavator1CompletedLabel.Name = "Excavator1CompletedLabel";
            this.Excavator1CompletedLabel.Size = new System.Drawing.Size(58, 33);
            this.Excavator1CompletedLabel.TabIndex = 0;
            this.Excavator1CompletedLabel.Text = "0";
            this.Excavator1CompletedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Excavator1ProgressBar
            // 
            this.Excavator1ProgressBar.Location = new System.Drawing.Point(319, 90);
            this.Excavator1ProgressBar.Name = "Excavator1ProgressBar";
            this.Excavator1ProgressBar.Size = new System.Drawing.Size(100, 23);
            this.Excavator1ProgressBar.TabIndex = 1;
            // 
            // ExcavatorQueue2Label
            // 
            this.ExcavatorQueue2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExcavatorQueue2Label.Location = new System.Drawing.Point(12, 129);
            this.ExcavatorQueue2Label.Name = "ExcavatorQueue2Label";
            this.ExcavatorQueue2Label.Size = new System.Drawing.Size(136, 33);
            this.ExcavatorQueue2Label.TabIndex = 0;
            this.ExcavatorQueue2Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Excavator2Label
            // 
            this.Excavator2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Excavator2Label.Location = new System.Drawing.Point(154, 129);
            this.Excavator2Label.Name = "Excavator2Label";
            this.Excavator2Label.Size = new System.Drawing.Size(90, 33);
            this.Excavator2Label.TabIndex = 0;
            this.Excavator2Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ForwardTrip2Label
            // 
            this.ForwardTrip2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForwardTrip2Label.Location = new System.Drawing.Point(425, 129);
            this.ForwardTrip2Label.Name = "ForwardTrip2Label";
            this.ForwardTrip2Label.Size = new System.Drawing.Size(90, 33);
            this.ForwardTrip2Label.TabIndex = 0;
            this.ForwardTrip2Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Excavator2CompletedLabel
            // 
            this.Excavator2CompletedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Excavator2CompletedLabel.Location = new System.Drawing.Point(250, 129);
            this.Excavator2CompletedLabel.Name = "Excavator2CompletedLabel";
            this.Excavator2CompletedLabel.Size = new System.Drawing.Size(58, 33);
            this.Excavator2CompletedLabel.TabIndex = 0;
            this.Excavator2CompletedLabel.Text = "0";
            this.Excavator2CompletedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Excavator2ProgressBar
            // 
            this.Excavator2ProgressBar.Location = new System.Drawing.Point(319, 133);
            this.Excavator2ProgressBar.Name = "Excavator2ProgressBar";
            this.Excavator2ProgressBar.Size = new System.Drawing.Size(100, 23);
            this.Excavator2ProgressBar.TabIndex = 1;
            // 
            // MillQueueLabel
            // 
            this.MillQueueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MillQueueLabel.Location = new System.Drawing.Point(521, 86);
            this.MillQueueLabel.Name = "MillQueueLabel";
            this.MillQueueLabel.Size = new System.Drawing.Size(136, 33);
            this.MillQueueLabel.TabIndex = 0;
            this.MillQueueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MillLabel
            // 
            this.MillLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MillLabel.Location = new System.Drawing.Point(663, 86);
            this.MillLabel.Name = "MillLabel";
            this.MillLabel.Size = new System.Drawing.Size(90, 33);
            this.MillLabel.TabIndex = 0;
            this.MillLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MillProgressBar
            // 
            this.MillProgressBar.Location = new System.Drawing.Point(668, 46);
            this.MillProgressBar.Name = "MillProgressBar";
            this.MillProgressBar.Size = new System.Drawing.Size(100, 23);
            this.MillProgressBar.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(653, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 33);
            this.label4.TabIndex = 0;
            this.label4.Text = "Измельчитель";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MillCompletedLabel
            // 
            this.MillCompletedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MillCompletedLabel.Location = new System.Drawing.Point(759, 86);
            this.MillCompletedLabel.Name = "MillCompletedLabel";
            this.MillCompletedLabel.Size = new System.Drawing.Size(58, 33);
            this.MillCompletedLabel.TabIndex = 0;
            this.MillCompletedLabel.Text = "0";
            this.MillCompletedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BackTripLabel
            // 
            this.BackTripLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BackTripLabel.Location = new System.Drawing.Point(250, 171);
            this.BackTripLabel.Name = "BackTripLabel";
            this.BackTripLabel.Size = new System.Drawing.Size(153, 33);
            this.BackTripLabel.TabIndex = 0;
            this.BackTripLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(653, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 33);
            this.label5.TabIndex = 0;
            this.label5.Text = "Тяжелых";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(653, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 33);
            this.label6.TabIndex = 0;
            this.label6.Text = "Легких";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(12, 218);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(249, 33);
            this.label7.TabIndex = 0;
            this.label7.Text = "Время моделирования";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // HeavyCountLabel
            // 
            this.HeavyCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HeavyCountLabel.Location = new System.Drawing.Point(798, 119);
            this.HeavyCountLabel.Name = "HeavyCountLabel";
            this.HeavyCountLabel.Size = new System.Drawing.Size(58, 33);
            this.HeavyCountLabel.TabIndex = 0;
            this.HeavyCountLabel.Text = "0";
            this.HeavyCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LightCountLabel
            // 
            this.LightCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LightCountLabel.Location = new System.Drawing.Point(798, 152);
            this.LightCountLabel.Name = "LightCountLabel";
            this.LightCountLabel.Size = new System.Drawing.Size(58, 33);
            this.LightCountLabel.TabIndex = 0;
            this.LightCountLabel.Text = "0";
            this.LightCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DeliveredLabel
            // 
            this.DeliveredLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeliveredLabel.Location = new System.Drawing.Point(798, 185);
            this.DeliveredLabel.Name = "DeliveredLabel";
            this.DeliveredLabel.Size = new System.Drawing.Size(58, 33);
            this.DeliveredLabel.TabIndex = 0;
            this.DeliveredLabel.Text = "0";
            this.DeliveredLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SimulationTimeTextBox
            // 
            this.SimulationTimeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SimulationTimeTextBox.Location = new System.Drawing.Point(267, 220);
            this.SimulationTimeTextBox.Name = "SimulationTimeTextBox";
            this.SimulationTimeTextBox.Size = new System.Drawing.Size(100, 31);
            this.SimulationTimeTextBox.TabIndex = 2;
            this.SimulationTimeTextBox.Text = "480";
            this.SimulationTimeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // StartButton
            // 
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartButton.Location = new System.Drawing.Point(391, 218);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(93, 33);
            this.StartButton.TabIndex = 3;
            this.StartButton.Text = "Пуск";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // StatistcsTabControl
            // 
            this.StatistcsTabControl.Controls.Add(this.ActionsTabPage);
            this.StatistcsTabControl.Controls.Add(this.QueuesTabPage);
            this.StatistcsTabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StatistcsTabControl.Location = new System.Drawing.Point(17, 255);
            this.StatistcsTabControl.Name = "StatistcsTabControl";
            this.StatistcsTabControl.SelectedIndex = 0;
            this.StatistcsTabControl.Size = new System.Drawing.Size(899, 346);
            this.StatistcsTabControl.TabIndex = 4;
            // 
            // ActionsTabPage
            // 
            this.ActionsTabPage.Controls.Add(this.ActionsDataGridView);
            this.ActionsTabPage.Controls.Add(this.ServicesDataGridView);
            this.ActionsTabPage.Location = new System.Drawing.Point(4, 29);
            this.ActionsTabPage.Name = "ActionsTabPage";
            this.ActionsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ActionsTabPage.Size = new System.Drawing.Size(891, 313);
            this.ActionsTabPage.TabIndex = 0;
            this.ActionsTabPage.Text = "Действия";
            this.ActionsTabPage.UseVisualStyleBackColor = true;
            // 
            // QueuesTabPage
            // 
            this.QueuesTabPage.Controls.Add(this.QueuesDataGridView);
            this.QueuesTabPage.Location = new System.Drawing.Point(4, 29);
            this.QueuesTabPage.Name = "QueuesTabPage";
            this.QueuesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.QueuesTabPage.Size = new System.Drawing.Size(891, 313);
            this.QueuesTabPage.TabIndex = 1;
            this.QueuesTabPage.Text = "Очереди";
            this.QueuesTabPage.UseVisualStyleBackColor = true;
            // 
            // ServicesDataGridView
            // 
            this.ServicesDataGridView.AllowUserToAddRows = false;
            this.ServicesDataGridView.AllowUserToDeleteRows = false;
            this.ServicesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ServicesDataGridView.Location = new System.Drawing.Point(7, 7);
            this.ServicesDataGridView.Name = "ServicesDataGridView";
            this.ServicesDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.ServicesDataGridView.RowTemplate.Height = 24;
            this.ServicesDataGridView.Size = new System.Drawing.Size(878, 171);
            this.ServicesDataGridView.TabIndex = 0;
            // 
            // ActionsDataGridView
            // 
            this.ActionsDataGridView.AllowUserToAddRows = false;
            this.ActionsDataGridView.AllowUserToDeleteRows = false;
            this.ActionsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ActionsDataGridView.Location = new System.Drawing.Point(7, 185);
            this.ActionsDataGridView.Name = "ActionsDataGridView";
            this.ActionsDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.ActionsDataGridView.RowTemplate.Height = 24;
            this.ActionsDataGridView.Size = new System.Drawing.Size(878, 72);
            this.ActionsDataGridView.TabIndex = 1;
            // 
            // QueuesDataGridView
            // 
            this.QueuesDataGridView.AllowUserToAddRows = false;
            this.QueuesDataGridView.AllowUserToDeleteRows = false;
            this.QueuesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.QueuesDataGridView.Location = new System.Drawing.Point(7, 7);
            this.QueuesDataGridView.Name = "QueuesDataGridView";
            this.QueuesDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.QueuesDataGridView.RowTemplate.Height = 24;
            this.QueuesDataGridView.Size = new System.Drawing.Size(878, 166);
            this.QueuesDataGridView.TabIndex = 0;
            // 
            // SimulatonTimer
            // 
            this.SimulatonTimer.Tick += new System.EventHandler(this.SimulatonTimer_Tick);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(653, 185);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(139, 33);
            this.label8.TabIndex = 0;
            this.label8.Text = "Доставлено";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // QuarryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 613);
            this.Controls.Add(this.StatistcsTabControl);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.SimulationTimeTextBox);
            this.Controls.Add(this.Excavator2ProgressBar);
            this.Controls.Add(this.Excavator1ProgressBar);
            this.Controls.Add(this.MillProgressBar);
            this.Controls.Add(this.Excavator0ProgressBar);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.Excavator2CompletedLabel);
            this.Controls.Add(this.DeliveredLabel);
            this.Controls.Add(this.LightCountLabel);
            this.Controls.Add(this.HeavyCountLabel);
            this.Controls.Add(this.MillCompletedLabel);
            this.Controls.Add(this.Excavator1CompletedLabel);
            this.Controls.Add(this.Excavator0CompletedLabel);
            this.Controls.Add(this.ForwardTrip2Label);
            this.Controls.Add(this.ForwardTrip1Label);
            this.Controls.Add(this.BackTripLabel);
            this.Controls.Add(this.ForwardTrip0Label);
            this.Controls.Add(this.Excavator2Label);
            this.Controls.Add(this.MillLabel);
            this.Controls.Add(this.MillQueueLabel);
            this.Controls.Add(this.Excavator1Label);
            this.Controls.Add(this.Excavator0Label);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ExcavatorQueue2Label);
            this.Controls.Add(this.ExcavatorQueue1Label);
            this.Controls.Add(this.ExcavatorQueue0Label);
            this.Controls.Add(this.label1);
            this.Name = "QuarryForm";
            this.Text = "Карьер";
            this.Resize += new System.EventHandler(this.QuarryForm_Resize);
            this.StatistcsTabControl.ResumeLayout(false);
            this.ActionsTabPage.ResumeLayout(false);
            this.QueuesTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ServicesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ActionsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QueuesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ExcavatorQueue0Label;
        private System.Windows.Forms.Label Excavator0Label;
        private System.Windows.Forms.Label Excavator0CompletedLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.ProgressBar Excavator0ProgressBar;
        private System.Windows.Forms.Label ForwardTrip0Label;
        private System.Windows.Forms.Label ExcavatorQueue1Label;
        private System.Windows.Forms.Label Excavator1Label;
        private System.Windows.Forms.Label ForwardTrip1Label;
        private System.Windows.Forms.Label Excavator1CompletedLabel;
        private System.Windows.Forms.ProgressBar Excavator1ProgressBar;
        private System.Windows.Forms.Label ExcavatorQueue2Label;
        private System.Windows.Forms.Label Excavator2Label;
        private System.Windows.Forms.Label ForwardTrip2Label;
        private System.Windows.Forms.Label Excavator2CompletedLabel;
        private System.Windows.Forms.ProgressBar Excavator2ProgressBar;
        private System.Windows.Forms.Label MillQueueLabel;
        private System.Windows.Forms.Label MillLabel;
        private System.Windows.Forms.ProgressBar MillProgressBar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label MillCompletedLabel;
        private System.Windows.Forms.Label BackTripLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label HeavyCountLabel;
        private System.Windows.Forms.Label LightCountLabel;
        private System.Windows.Forms.Label DeliveredLabel;
        private System.Windows.Forms.TextBox SimulationTimeTextBox;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.TabControl StatistcsTabControl;
        private System.Windows.Forms.TabPage ActionsTabPage;
        private System.Windows.Forms.DataGridView ActionsDataGridView;
        private System.Windows.Forms.DataGridView ServicesDataGridView;
        private System.Windows.Forms.TabPage QueuesTabPage;
        private System.Windows.Forms.DataGridView QueuesDataGridView;
        private System.Windows.Forms.Timer SimulatonTimer;
        private System.Windows.Forms.Label label8;
    }
}

