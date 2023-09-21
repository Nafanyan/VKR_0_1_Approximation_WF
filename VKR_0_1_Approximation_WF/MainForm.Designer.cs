namespace VKR_0_1_Approximation_WF
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            AmplitudeTextBox1 = new TextBox();
            PeakCenterTextBox1 = new TextBox();
            DeviationTextBox1 = new TextBox();
            AmplitudeTextBox2 = new TextBox();
            PeakCenterTextBox2 = new TextBox();
            DeviationTextBox2 = new TextBox();
            AmplitudeLabel = new Label();
            PeakCenterLabel = new Label();
            DeviationLabel = new Label();
            CreateChart = new Button();
            CreateCharts = new Button();
            SuspendLayout();
            // 
            // AmplitudeTextBox1
            // 
            AmplitudeTextBox1.Location = new Point( 53, 62 );
            AmplitudeTextBox1.Name = "AmplitudeTextBox1";
            AmplitudeTextBox1.Size = new Size( 125, 27 );
            AmplitudeTextBox1.TabIndex = 0;
            // 
            // PeakCenterTextBox1
            // 
            PeakCenterTextBox1.Location = new Point( 203, 62 );
            PeakCenterTextBox1.Name = "PeakCenterTextBox1";
            PeakCenterTextBox1.Size = new Size( 125, 27 );
            PeakCenterTextBox1.TabIndex = 1;
            // 
            // DeviationTextBox1
            // 
            DeviationTextBox1.Location = new Point( 365, 62 );
            DeviationTextBox1.Name = "DeviationTextBox1";
            DeviationTextBox1.Size = new Size( 125, 27 );
            DeviationTextBox1.TabIndex = 2;
            // 
            // AmplitudeTextBox2
            // 
            AmplitudeTextBox2.Location = new Point( 53, 141 );
            AmplitudeTextBox2.Name = "AmplitudeTextBox2";
            AmplitudeTextBox2.Size = new Size( 125, 27 );
            AmplitudeTextBox2.TabIndex = 3;
            // 
            // PeakCenterTextBox2
            // 
            PeakCenterTextBox2.Location = new Point( 203, 141 );
            PeakCenterTextBox2.Name = "PeakCenterTextBox2";
            PeakCenterTextBox2.Size = new Size( 125, 27 );
            PeakCenterTextBox2.TabIndex = 4;
            // 
            // DeviationTextBox2
            // 
            DeviationTextBox2.Location = new Point( 365, 141 );
            DeviationTextBox2.Name = "DeviationTextBox2";
            DeviationTextBox2.Size = new Size( 125, 27 );
            DeviationTextBox2.TabIndex = 5;
            // 
            // AmplitudeLabel
            // 
            AmplitudeLabel.AutoSize = true;
            AmplitudeLabel.Location = new Point( 53, 23 );
            AmplitudeLabel.Name = "AmplitudeLabel";
            AmplitudeLabel.Size = new Size( 88, 20 );
            AmplitudeLabel.TabIndex = 6;
            AmplitudeLabel.Text = "Амплитуды";
            // 
            // PeakCenterLabel
            // 
            PeakCenterLabel.AutoSize = true;
            PeakCenterLabel.Location = new Point( 203, 23 );
            PeakCenterLabel.Name = "PeakCenterLabel";
            PeakCenterLabel.Size = new Size( 146, 20 );
            PeakCenterLabel.TabIndex = 7;
            PeakCenterLabel.Text = "Отклонение центра";
            // 
            // DeviationLabel
            // 
            DeviationLabel.AutoSize = true;
            DeviationLabel.Location = new Point( 365, 23 );
            DeviationLabel.Name = "DeviationLabel";
            DeviationLabel.Size = new Size( 67, 20 );
            DeviationLabel.TabIndex = 8;
            DeviationLabel.Text = "Ширина";
            // 
            // CreateChart
            // 
            CreateChart.Location = new Point( 53, 195 );
            CreateChart.Name = "CreateChart";
            CreateChart.Size = new Size( 94, 49 );
            CreateChart.TabIndex = 9;
            CreateChart.Text = "Построить график";
            CreateChart.UseVisualStyleBackColor = true;
            CreateChart.Click += CreateChart_Click;
            // 
            // CreateCharts
            // 
            CreateCharts.Location = new Point( 203, 195 );
            CreateCharts.Name = "CreateCharts";
            CreateCharts.Size = new Size( 94, 49 );
            CreateCharts.TabIndex = 10;
            CreateCharts.Text = "Построить графики";
            CreateCharts.UseVisualStyleBackColor = true;
            CreateCharts.Click += CreateCharts_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF( 8F, 20F );
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size( 800, 450 );
            Controls.Add( CreateCharts );
            Controls.Add( CreateChart );
            Controls.Add( DeviationLabel );
            Controls.Add( PeakCenterLabel );
            Controls.Add( AmplitudeLabel );
            Controls.Add( DeviationTextBox2 );
            Controls.Add( PeakCenterTextBox2 );
            Controls.Add( AmplitudeTextBox2 );
            Controls.Add( DeviationTextBox1 );
            Controls.Add( PeakCenterTextBox1 );
            Controls.Add( AmplitudeTextBox1 );
            Name = "MainForm";
            Text = "Form1";
            ResumeLayout( false );
            PerformLayout();
        }

        #endregion

        private TextBox AmplitudeTextBox1;
        private TextBox PeakCenterTextBox1;
        private TextBox DeviationTextBox1;
        private TextBox AmplitudeTextBox2;
        private TextBox PeakCenterTextBox2;
        private TextBox DeviationTextBox2;
        private Label AmplitudeLabel;
        private Label PeakCenterLabel;
        private Label DeviationLabel;
        private Button CreateChart;
        private Button CreateCharts;
    }
}