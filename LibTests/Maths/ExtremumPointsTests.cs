using AleksandrovRTm.Core.Entities;
using AleksandrovRTm.Libs.Functions;
using AleksandrovMaths = AleksandrovRTm.Libs.Maths.Maths;

namespace AleksandrovRTm.LibsTests.Maths
{
    public class ExtremumPointsTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void GetIndexExtremumPointsMax_CombineGauseFunctionArray_CorrectPeakCentresAndAmplitude()
        {
            // Arrange
            double sampleRate = 10;

            double amplitudeOne = 1;
            double amplitudeTwo = 5;

            double peakCentreOne = 1.5;
            double peakCentreTwo = 15.1;

            double deviationOne = 1;
            double deviationTwo = 1;

            // Act
            var gauseOne = new GauseFunction( amplitudeOne, peakCentreOne, deviationOne );
            var signalOne = new DigitalSignal( gauseOne.GetValues( 0, 20, 1 / sampleRate ), sampleRate );

            var gauseTwo = new GauseFunction( amplitudeTwo, peakCentreTwo, deviationTwo );
            var signalTwo = new DigitalSignal( gauseTwo.GetValues( 0, 20, 1 / sampleRate ), sampleRate );

            DigitalSignal combineGause = DigitalSignal.CombineTwoSignals( signalOne, signalTwo );
            List<double> xExtremumsMax = AleksandrovMaths.ExtremumPointsMax( combineGause );

            // Assert
            // Check peak centres
            Assert.AreEqual( peakCentreOne, xExtremumsMax[ 0 ] );
            Assert.AreEqual( peakCentreTwo, xExtremumsMax[ 1 ] );

            // Check amplitudes
            Assert.AreEqual( amplitudeOne, combineGause.Values[ ( int )( xExtremumsMax[ 0 ] * combineGause.SamplingRate ) ] );
            Assert.AreEqual( amplitudeTwo, combineGause.Values[ ( int )( xExtremumsMax[ 1 ] * combineGause.SamplingRate ) ] );
        }
    }
}