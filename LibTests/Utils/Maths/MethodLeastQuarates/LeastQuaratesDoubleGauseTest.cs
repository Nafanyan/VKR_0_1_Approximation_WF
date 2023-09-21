using AleksandrovRTm.Libs.Utils.Core;
using AleksandrovRTm.Libs.Utils.Functions;
using AleksandrovRTm.Libs.Utils.Maths;

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
            double sampleRate = 100;

            double expectedAmplitudeOne = 1;
            double expectedAmplitudeTwo = 4;

            double expectedPeakCentreOne = 5;
            double expectedPeakCentreTwo = 15;

            double expectedDeviationOne = 1;
            double expectedDeviationTwo = 2;

            // Реальные значения, т.е. которые в теории были рассчитаны
            double realAmplitudeOne = 1.1;
            double realAmplitudeTwo = 4.9;

            double realPeakCentreOne = 5.4;
            double realPeakCentreTwo = 15;

            double realDeviationOne = 1.23;
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

            // Нахожу экстремумы, а из них амплитуды и значения максимумов относительно x
            List<double> xExtremumsMax = Maths.ExtremumPointsMax( combineGause );
            double maxOneGause = combineGause.Values[ ( int )( xExtremumsMax[ 0 ] * combineGause.SamplingRate ) ];
            double maxTwoGause = combineGause.Values[ ( int )( xExtremumsMax[ 1 ] * combineGause.SamplingRate ) ];

            // Беру любую точку на каждой из функций Гаусса и расчитываю среднее отклонение их уравнения с одной неизвестной
            var pointFromGauseOne = Maths.FindPointLeftOfTheY( combineGause, maxOneGause, 0.3 );
            var pointFromGauseTwo = Maths.FindPointRightOfTheY( combineGause, maxTwoGause, 0.3 );
            double deviationFirstGause = GauseFunction.CalculateDeviation( pointFromGauseOne[ "y" ], pointFromGauseOne[ "x" ], amplitudeOne, peakCentreOne );
            double deviationSecondGause = GauseFunction.CalculateDeviation( pointFromGauseTwo[ "y" ], pointFromGauseTwo[ "x" ], amplitudeTwo, peakCentreTwo );

            // Создаю объект метода наименьших квадратов для двойной функции Гаусса
            var leastQuarates = Maths.GetLeastQuaratesDoubleGause(
                combineGause,
                maxOneGause,
                xExtremumsMax[ 0 ],
                deviationFirstGause,
                maxTwoGause,
                xExtremumsMax[ 1 ],
                deviationSecondGause );

            // Assert
            Assert.AreEqual( amplitudeOne, leastQuarates.AmplitudeFirst );
            Assert.AreEqual( peakCentreOne, leastQuarates.MatExpectationFirst );
            Assert.AreEqual( deviationOne, leastQuarates.DeviationFirst );

            Assert.AreEqual( amplitudeTwo, leastQuarates.AmplitudeSecond );
            Assert.AreEqual( peakCentreTwo, leastQuarates.MatExpectationSecond );
            Assert.AreEqual( deviationTwo, leastQuarates.DeviationSecond );
        }
    }
}
