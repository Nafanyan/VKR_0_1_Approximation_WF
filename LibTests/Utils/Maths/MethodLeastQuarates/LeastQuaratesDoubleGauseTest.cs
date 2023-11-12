using AleksandrovRTm.Libs.Utils.Core;
using AleksandrovRTm.Libs.Utils.Functions;
using AleksandrovRTm.Libs.Utils.Maths;
using System.Text;

namespace AleksandrovRTm.LibsTests.Utils
{
    internal class LeastQuaratesDoubleGauseTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void CalculateParameters_TheoreticalParamsGauseFunction_CorrectParams()
        {
            // Arrange
            // Ожидаемые значения, т.е. которые в действительности
            double sampleRate = 10;

            double expectedAmplitudeOne = 1;
            double expectedAmplitudeTwo = 4;

            double expectedPeakCentreOne = 5;
            double expectedPeakCentreTwo = 15;

            double expectedDeviationOne = 1;
            double expectedDeviationTwo = 2;

            // Реальные значения, т.е. которые в теории были рассчитаны
            double realAmplitudeOne = 1.3;
            double realAmplitudeTwo = 4.3;

            double realPeakCentreOne = 5.3;
            double realPeakCentreTwo = 15.3;

            double realDeviationOne = 1.3;
            double realDeviationTwo = 2.3;

            // Act
            var gauseOne = new GauseFunction( expectedAmplitudeOne, expectedPeakCentreOne, expectedDeviationOne );
            var signalOne = new DigitalSignal( gauseOne.GetValues( 0, 30, 1 / sampleRate ), sampleRate );

            var gauseTwo = new GauseFunction( expectedAmplitudeTwo, expectedPeakCentreTwo, expectedDeviationTwo );
            var signalTwo = new DigitalSignal( gauseTwo.GetValues( 0, 30, 1 / sampleRate ), sampleRate );

            DigitalSignal combineGause = DigitalSignal.CombineTwoSignals( signalOne, signalTwo );

            var leastQuarates = Maths.GetLeastQuaratesDoubleGause(
                combineGause,
                realAmplitudeOne,
                realPeakCentreOne,
                realDeviationOne,
                realAmplitudeTwo,
                realPeakCentreTwo,
                realDeviationTwo );

            // Assert
            Assert.AreEqual( expectedAmplitudeOne, Math.Round( leastQuarates.AmplitudeFirst, 2 ) );
            Assert.AreEqual( expectedPeakCentreOne, Math.Round( leastQuarates.MatExpectationFirst, 2 ) );
            Assert.AreEqual( expectedDeviationOne, Math.Round( leastQuarates.DeviationFirst, 2 ) );

            Assert.AreEqual( expectedAmplitudeTwo, Math.Round( leastQuarates.AmplitudeSecond, 2 ) );
            Assert.AreEqual( expectedPeakCentreTwo, Math.Round( leastQuarates.MatExpectationSecond, 2 ) );
            Assert.AreEqual( expectedDeviationTwo, Math.Round( leastQuarates.DeviationSecond, 2 ) );
        }

        [Test]
        public void CalculateParameters_TheoreticalListParamsGauseFunction_CorrectParams()
        {
            // Arrange
            // Ожидаемые значения, т.е. которые в действительности
            double sampleRate = 10;

            double expectedAmplitudeOne = 1;
            double expectedAmplitudeTwo = 4;

            double expectedPeakCentreOne = 5;
            double expectedPeakCentreTwo = 15;

            double expectedDeviationOne = 1;
            double expectedDeviationTwo = 2;

            // Реальные значения, т.е. которые в теории были рассчитаны
            List<double> realAmplitudeOne = new List<double> { 1.7, 1, 2, 4.3, 4.5, 3, 1.8, 9, 5.2, -2.1 };

            List<double> realPeakCentreOne = new List<double> { 5, 4, 3, 14, 12, 13, 17, 28, 25, 19 };

            List<double> realDeviationOne = new List<double> { 1.3, 0.8, 2.2, 2.3, 2, 1.3, 1.8, 2.4, 4.5, 1 };

            // Act
            var gauseOne = new GauseFunction( expectedAmplitudeOne, expectedPeakCentreOne, expectedDeviationOne );
            var signalOne = new DigitalSignal( gauseOne.GetValues( 0, 30, 1 / sampleRate ), sampleRate );

            var gauseTwo = new GauseFunction( expectedAmplitudeTwo, expectedPeakCentreTwo, expectedDeviationTwo );
            var signalTwo = new DigitalSignal( gauseTwo.GetValues( 0, 30, 1 / sampleRate ), sampleRate );

            DigitalSignal combineGause = DigitalSignal.CombineTwoSignals( signalOne, signalTwo );
            
            // Создаю объект метода наименьших квадратов для двойной функции Гаусса
            var leastQuarates = Maths.GetLeastQuaratesDoubleGauses(
                combineGause,
                realAmplitudeOne,
                realPeakCentreOne,
                realDeviationOne );

            // Assert
            Assert.AreEqual( expectedAmplitudeOne, Math.Round( leastQuarates.AmplitudeFirst, 2 ) );
            Assert.AreEqual( expectedPeakCentreOne, Math.Round( leastQuarates.MatExpectationFirst, 2 ) );
            Assert.AreEqual( expectedDeviationOne, Math.Round( leastQuarates.DeviationFirst, 2 ) );

            Assert.AreEqual( expectedAmplitudeTwo, Math.Round( leastQuarates.AmplitudeSecond, 2 ) );
            Assert.AreEqual( expectedPeakCentreTwo, Math.Round( leastQuarates.MatExpectationSecond, 2 ) );
            Assert.AreEqual( expectedDeviationTwo, Math.Round( leastQuarates.DeviationSecond, 2 ) );
        }

        [Test]
        public void CalculateParameters_CalculatedParamsGauseFunction_CorrectParams()
        {
            // Arrange
            double sampleRate = 10;

            double amplitudeOne = 1;
            double amplitudeTwo = 5;

            double peakCentreOne = 5;
            double peakCentreTwo = 15;

            double deviationOne = 1;
            double deviationTwo = 2;

            // Act
            // Создаю две функции Гаусса и объеденяю их
            var gauseOne = new GauseFunction( amplitudeOne, peakCentreOne, deviationOne );
            var signalOne = new DigitalSignal( gauseOne.GetValues( 0, 30, 1 / sampleRate ), sampleRate );

            var gauseTwo = new GauseFunction( amplitudeTwo, peakCentreTwo, deviationTwo );
            var signalTwo = new DigitalSignal( gauseTwo.GetValues( 0, 30, 1 / sampleRate ), sampleRate );

            DigitalSignal combineGause = DigitalSignal.CombineTwoSignals( signalOne, signalTwo );

            List<double> xExtremumsMax = Maths.ExtremumPointsMax( combineGause, 5 );
            List<double> maxsGause = xExtremumsMax.Select( t => combineGause.Values[ ( int )( t * combineGause.SamplingRate ) ] )
                .ToList();
            List<double> deviations = GetDeviations( combineGause, maxsGause, xExtremumsMax );

            // Создаю объект метода наименьших квадратов для двойной функции Гаусса
            var leastQuarates = Maths.GetLeastQuaratesDoubleGauses(
                combineGause,
                maxsGause,
                xExtremumsMax,
                deviations );

            // Assert
            Assert.AreEqual( amplitudeOne, leastQuarates.AmplitudeFirst );
            Assert.AreEqual( peakCentreOne, leastQuarates.MatExpectationFirst );
            Assert.AreEqual( deviationOne, leastQuarates.DeviationFirst );

            Assert.AreEqual( amplitudeTwo, leastQuarates.AmplitudeSecond );
            Assert.AreEqual( peakCentreTwo, leastQuarates.MatExpectationSecond );
            Assert.AreEqual( deviationTwo, leastQuarates.DeviationSecond );
        }

        [Test]
        public void CalculateParameters_RealData_CorrectParams()
        {
            // Arrange
            List<double> data = new List<double>();
            using ( FileStream fstream = File.OpenRead( "../../../../Realnye_dannye.txt" ) )
            {
                byte[] buffer = new byte[ fstream.Length ];
                fstream.ReadAsync( buffer, 0, buffer.Length );
                string textFromFile = Encoding.Default.GetString( buffer );
                fstream.Close();
                data = textFromFile.Split( "\r\n" )
                    .Select( t => t.Replace( '.', ',' ) )
                    .Where( t => t != "" )
                    .Select( t => Convert.ToDouble( t ) ).ToList();
            }

            // Act
            var signal = new DigitalSignal( data.ToArray() );
            List<double> xExtremumsMax = Maths.ExtremumPointsMax( signal, 5 );
            List<double> maxsGause = xExtremumsMax.Select( t => signal.Values[ ( int )( t * signal.SamplingRate ) ] )
                .ToList();
            List<double> deviations = GetDeviations( signal, maxsGause, xExtremumsMax );

            // Создаю объект метода наименьших квадратов для двойной функции Гаусса
            var leastQuarates = Maths.GetLeastQuaratesDoubleGauses(
                signal,
                maxsGause,
                xExtremumsMax,
                deviations );

            // Assert
        }

        [Test]
        public void CalculateParameters_ModuleData_CorrectParams()
        {
            // Arrange
            List<double> data = new List<double>();
            using ( FileStream fstream = File.OpenRead( "../../../../Smodelirovannye_dannye_1.txt" ) )
            {
                byte[] buffer = new byte[ fstream.Length ];
                fstream.ReadAsync( buffer, 0, buffer.Length );
                string textFromFile = Encoding.Default.GetString( buffer );
                fstream.Close();
                data = textFromFile.Split( "\r\n" )
                    .Select( t => t.Replace( '.', ',' ) )
                    .Where( t => t != "" )
                    .Select( t => Convert.ToDouble( t ) ).ToList();
            }

            // Act
            var signal = new DigitalSignal( data.ToArray() );
            List<double> xExtremumsMax = Maths.ExtremumPointsMax( signal, 5 );
            List<double> maxsGause = xExtremumsMax.Select( t => signal.Values[ ( int )( t * signal.SamplingRate ) ] )
                .ToList();
            List<double> deviations = GetDeviations( signal, maxsGause, xExtremumsMax );

            // Создаю объект метода наименьших квадратов для двойной функции Гаусса
            var leastQuarates = Maths.GetLeastQuaratesDoubleGauses(
                signal,
                maxsGause,
                xExtremumsMax,
                deviations );

            // Assert
        }

        private List<double> GetDeviations( DigitalSignal signal, List<double> amplitudes, List<double> peakCenters )
        {
            var result = new List<double>();
            for ( int i = 0; i < amplitudes.Count; i++ )
            {
                var pointFromGause = Maths.FindPointLeftOfTheY( signal, amplitudes[ i ], 0.4 );
                result.Add( GauseFunction.CalculateDeviation( pointFromGause[ "y" ], pointFromGause[ "x" ], amplitudes[ i ], peakCenters[ i ] ) );
            }
            return result;
        }
    }
}
