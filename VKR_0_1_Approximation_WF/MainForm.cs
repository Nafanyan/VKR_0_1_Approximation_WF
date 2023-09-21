using AleksandrovRTm.Libs.Utils.Functions;
using AleksandrovRTm.Libs.Utils.Signals;

namespace VKR_0_1_Approximation_WF
{
    public partial class MainForm : Form
    {
        private BaseFunction BaseFunctionOne { get; set; }
        private BaseFunction BaseFunctionTwo { get; set; }

        public MainForm()
        {
            InitializeComponent();

        }

        // Код кнопок, пока лучше смотреть в код конструктора класса 
        private void CreateChart_Click( object sender, EventArgs e )
        {
            try
            {
                double amplitude = Convert.ToDouble( AmplitudeTextBox1.Text );
                double peakCentre = Convert.ToDouble( PeakCenterTextBox1.Text );
                double deviation = Convert.ToDouble( DeviationTextBox1.Text );
                BaseFunctionOne = new GauseFunction(amplitude, peakCentre, deviation);
            }
            catch( Exception exc )
            {
                Console.WriteLine( exc.Message );
            }
        }

        private void CreateCharts_Click( object sender, EventArgs e )
        {
            CreateCharts_Temp();
            //try
            //{
            //    double amplitudeOne = Convert.ToDouble( AmplitudeTextBox1.Text );
            //    double peakCentreOne = Convert.ToDouble( PeakCenterTextBox1.Text );
            //    double deviationOne = Convert.ToDouble( DeviationTextBox1.Text );
            //    BaseFunctionOne = new GauseFunction( amplitudeOne, peakCentreOne, deviationOne );

            //    double amplitudeTwo = Convert.ToDouble( AmplitudeTextBox2.Text );
            //    double peakCentreTwo = Convert.ToDouble( PeakCenterTextBox2.Text );
            //    double deviationTwo = Convert.ToDouble( DeviationTextBox2.Text );
            //    BaseFunctionTwo = new GauseFunction( amplitudeTwo, peakCentreTwo, deviationTwo );
            //}
            //catch( Exception exc )
            //{
            //    Console.WriteLine( exc.Message );
            //}
        }

        private void CreateCharts_Temp()
        {
            try
            {
                double amplitudeOne = 1;
                double peakCentreOne = 1;
                double deviationOne = 1;
                BaseFunctionOne = new GauseFunction( amplitudeOne, peakCentreOne, deviationOne );

                double amplitudeTwo = 1;
                double peakCentreTwo = 1;
                double deviationTwo = 1;
                BaseFunctionTwo = new GauseFunction( amplitudeTwo, peakCentreTwo, deviationTwo );
            }
            catch( Exception exc )
            {
                Console.WriteLine( exc.Message );
            }
        }
    }
}