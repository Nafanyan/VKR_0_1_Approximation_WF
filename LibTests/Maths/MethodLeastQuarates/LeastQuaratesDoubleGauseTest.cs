using AleksandrovRTm.Core.Entities;
using AleksandrovRTm.Libs.Functions;
using AleksandrovMaths = AleksandrovRTm.Libs.Maths.Maths;

namespace AleksandrovRTm.LibsTests.Maths.MethodLeastQuarates
{
    internal class LeastQuaratesDoubleGauseTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [TestCase( 0.1, 0.1, 0.1, 0.1, 0.1, 0.1 )]
        [TestCase( 0.2, 0.2, 0.2, 0.2, 0.2, 0.2 )]
        [TestCase( 0.3, 0.3, 0.3, 0.3, 0.3, 0.3 )]
        [TestCase( 0.4, 0.4, 0.4, 0.4, 0.4, 0.4 )]
        [TestCase( 0.5, 0.5, 0.5, 0.5, 0.5, 0.5 )]
        [TestCase( 0.7, 0.7, 0.7, 0.7, 0.7, 0.7 )]
        [TestCase( 0.8, 0.8, 0.8, 0.8, 0.8, 0.8 )]
        [TestCase( 0.9, 0.9, 0.9, 0.9, 0.9, 0.9 )]

        [TestCase( 1, 1, 1, 1, 1, 1 )]
        [TestCase( -0.1, -0.1, -0.1, -0.1, -0.1, -0.1 )]
        [TestCase( -0.1, -0.1, -0.1, -0.1, -0.1, -0.1 )]
        [TestCase( -0.2, -0.2, -0.2, -0.2, -0.2, -0.2 )]
        [TestCase( -0.3, -0.3, -0.3, -0.3, -0.3, -0.3 )]
        [TestCase( -0.4, -0.4, -0.4, -0.4, -0.4, -0.4 )]
        [TestCase( -0.5, -0.5, -0.5, -0.5, -0.5, -0.5 )]
        [TestCase( -0.7, -0.7, -0.7, -0.7, -0.7, -0.7 )]
        [TestCase( -0.8, -0.8, -0.8, -0.8, -0.8, -0.8 )]
        [TestCase( -0.9, -0.9, -0.9, -0.9, -0.9, -0.9 )]
        [TestCase( -1, -1, -1, -1, -1, -1 )]

        public void Calculate_parametes_signal_theor(
            double amplitudeOneErrorRate,
            double amplitudeTwoErrorRate,
            double peakCentreOneErrorRate,
            double peakCentreTwoErrorRate,
            double deviationTwoErrorRate,
            double deviationOneErrorRate )
        {
            // Arrange
            // Ожидаемые значения, т.е. которые в действительности
            double sampleRate = 10000;

            double expectedAmplitudeOne = 4.3;
            double expectedAmplitudeTwo = 3.2;

            double expectedPeakCentreOne = 4.1;
            double expectedPeakCentreTwo = 6.4;

            double expectedDeviationOne = 1.1;
            double expectedDeviationTwo = 2.4;

            // Реальные значения, т.е. которые в теории были рассчитаны
            double realAmplitudeOne = expectedAmplitudeOne + amplitudeOneErrorRate;
            double realAmplitudeTwo = expectedAmplitudeTwo + amplitudeTwoErrorRate;

            double realPeakCentreOne = expectedPeakCentreOne + peakCentreOneErrorRate;
            double realPeakCentreTwo = expectedPeakCentreTwo + peakCentreTwoErrorRate;

            double realDeviationOne = expectedDeviationOne + deviationOneErrorRate;
            double realDeviationTwo = expectedDeviationTwo + deviationTwoErrorRate;

            // Act
            var gauseOne = new GauseFunction( expectedAmplitudeOne, expectedPeakCentreOne, expectedDeviationOne );
            var signalOne = new DigitalSignal( gauseOne.GetValues( 0, 30, 1 / sampleRate ), sampleRate );

            var gauseTwo = new GauseFunction( expectedAmplitudeTwo, expectedPeakCentreTwo, expectedDeviationTwo );
            var signalTwo = new DigitalSignal( gauseTwo.GetValues( 0, 30, 1 / sampleRate ), sampleRate );

            DigitalSignal combineGause = DigitalSignal.CombineTwoSignals( signalOne, signalTwo );

            var leastQuarates = AleksandrovMaths.GetLeastQuaratesDoubleGause(
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

        [TestCase( 0.1, 0.1, 0.1, 0.1, 0.1, 0.1 )]
        [TestCase( 0.2, 0.2, 0.2, 0.2, 0.2, 0.2 )]
        [TestCase( 0.3, 0.3, 0.3, 0.3, 0.3, 0.3 )]
        [TestCase( 0.4, 0.4, 0.4, 0.4, 0.4, 0.4 )]
        [TestCase( 0.5, 0.5, 0.5, 0.5, 0.5, 0.5 )]
        [TestCase( 0.7, 0.7, 0.7, 0.7, 0.7, 0.7 )]
        [TestCase( 0.8, 0.8, 0.8, 0.8, 0.8, 0.8 )]
        [TestCase( 0.9, 0.9, 0.9, 0.9, 0.9, 0.9 )]

        [TestCase( 1, 1, 1, 1, 1, 1 )]
        [TestCase( -0.1, -0.1, -0.1, -0.1, -0.1, -0.1 )]
        [TestCase( -0.1, -0.1, -0.1, -0.1, -0.1, -0.1 )]
        [TestCase( -0.2, -0.2, -0.2, -0.2, -0.2, -0.2 )]
        [TestCase( -0.3, -0.3, -0.3, -0.3, -0.3, -0.3 )]
        [TestCase( -0.4, -0.4, -0.4, -0.4, -0.4, -0.4 )]
        [TestCase( -0.5, -0.5, -0.5, -0.5, -0.5, -0.5 )]
        [TestCase( -0.7, -0.7, -0.7, -0.7, -0.7, -0.7 )]
        [TestCase( -0.8, -0.8, -0.8, -0.8, -0.8, -0.8 )]
        [TestCase( -0.9, -0.9, -0.9, -0.9, -0.9, -0.9 )]
        [TestCase( -1, -1, -1, -1, -1, -1 )]

        public void Calculate_parametes_resize_signal_theor(
            double amplitudeOneErrorRate,
            double amplitudeTwoErrorRate,
            double peakCentreOneErrorRate,
            double peakCentreTwoErrorRate,
            double deviationTwoErrorRate,
            double deviationOneErrorRate )
        {
            // Arrange
            // Ожидаемые значения, т.е. которые в действительности
            double sampleRate = 1000000;

            double expectedAmplitudeOne = 4.3;
            double expectedAmplitudeTwo = 3.2;

            double expectedPeakCentreOne = 4.1;
            double expectedPeakCentreTwo = 6.4;

            double expectedDeviationOne = 1.1;
            double expectedDeviationTwo = 2.4;

            // Реальные значения, т.е. которые в теории были рассчитаны
            double realAmplitudeOne = expectedAmplitudeOne + amplitudeOneErrorRate;
            double realAmplitudeTwo = expectedAmplitudeTwo + amplitudeTwoErrorRate;

            double realPeakCentreOne = expectedPeakCentreOne + peakCentreOneErrorRate;
            double realPeakCentreTwo = expectedPeakCentreTwo + peakCentreTwoErrorRate;

            double realDeviationOne = expectedDeviationOne + deviationOneErrorRate;
            double realDeviationTwo = expectedDeviationTwo + deviationTwoErrorRate;

            // Act
            var gauseOne = new GauseFunction( expectedAmplitudeOne, expectedPeakCentreOne, expectedDeviationOne );
            var signalOne = new DigitalSignal( gauseOne.GetValues( 0, 30, 1 / sampleRate ), sampleRate );

            var gauseTwo = new GauseFunction( expectedAmplitudeTwo, expectedPeakCentreTwo, expectedDeviationTwo );
            var signalTwo = new DigitalSignal( gauseTwo.GetValues( 0, 30, 1 / sampleRate ), sampleRate );

            DigitalSignal combineGause = DigitalSignal.CombineTwoSignals( signalOne, signalTwo );

            var decimator = AleksandrovMaths.GetDecimator();
            int coefficientDecimation = 10000;

            var decimatedSignal = new DigitalSignal( decimator.Decimation( combineGause.Values, coefficientDecimation ), sampleRate / coefficientDecimation );

            var leastQuarates = AleksandrovMaths.GetLeastQuaratesDoubleGause(
                decimatedSignal,
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
        public void Calculate_parametes_signal_real()
        {
            // Arrange
            double sampleRate = 100;

            double amplitudeOne = 4.3;
            double amplitudeTwo = 3.2;

            double peakCentreOne = 4.1;
            double peakCentreTwo = 6.4;

            double deviationOne = 1.1;
            double deviationTwo = 2.4;

            // Act
            // Создаю две функции Гаусса и объеденяю их
            var gauseOne = new GauseFunction( amplitudeOne, peakCentreOne, deviationOne );
            var signalOne = new DigitalSignal( gauseOne.GetValues( 0, 30, 1 / sampleRate ), sampleRate );

            var gauseTwo = new GauseFunction( amplitudeTwo, peakCentreTwo, deviationTwo );
            var signalTwo = new DigitalSignal( gauseTwo.GetValues( 0, 30, 1 / sampleRate ), sampleRate );

            DigitalSignal combineGause = DigitalSignal.CombineTwoSignals( signalOne, signalTwo );

            var filter = AleksandrovMaths.GetDecimator();
            int coefficientDecimation = ( int )( combineGause.Values.Count() / 100 );

            DigitalSignal combineFilteredSignal = new DigitalSignal(
                filter.Decimation( combineGause.Values, coefficientDecimation ),
                100 );

            // Нахожу экстремумы, а из них амплитуды и значения максимумов относительно x
            List<double> xExtremumsMax = AleksandrovMaths.ExtremumPointsMax( combineGause );
            double maxOneGause = combineGause.Values[ ( int )( xExtremumsMax[ 0 ] * combineGause.SamplingRate ) ];
            double maxTwoGause = combineGause.Values[ ( int )( xExtremumsMax[ 1 ] * combineGause.SamplingRate ) ];

            // Беру любую точку на каждой из функций Гаусса и расчитываю среднее отклонение их уравнения с одной неизвестной
            var pointFromGauseOne = AleksandrovMaths.FindPointLeftOfTheY( combineGause, maxOneGause, 0.3 );
            var pointFromGauseTwo = AleksandrovMaths.FindPointRightOfTheY( combineGause, maxTwoGause, 0.3 );
            double deviationFirstGause = GauseFunction.CalculateDeviation( pointFromGauseOne[ "y" ], pointFromGauseOne[ "x" ], amplitudeOne, peakCentreOne );
            double deviationSecondGause = GauseFunction.CalculateDeviation( pointFromGauseTwo[ "y" ], pointFromGauseTwo[ "x" ], amplitudeTwo, peakCentreTwo );

            // Создаю объект метода наименьших квадратов для двойной функции Гаусса
            var leastQuarates = AleksandrovMaths.GetLeastQuaratesDoubleGause(
                combineFilteredSignal,
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
