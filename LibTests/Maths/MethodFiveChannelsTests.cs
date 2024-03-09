using AleksandrovRTm.Core.Entities;
using AleksandrovRTm.Libs.Functions;
using AleksandrovMaths = AleksandrovRTm.Libs.Maths.Maths;

namespace AleksandrovRTm.LibsTests.Maths.MethodFiveChannelsTests
{
    public class MethodFiveChannelsTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Calculate_GauseFunction_CorrectPeakCentre()
        {
            // Arrange
            // Ожидаемые значения, т.е. которые в действительности
            double sampleRate = 100;

            double expectedAmplitude = 1.5;
            double expectedPeakCentre = 5;
            double expectedDeviation = 2;

            // Act
            var gause = new GauseFunction( expectedAmplitude, expectedPeakCentre, expectedDeviation );
            var signal = new DigitalSignal( gause.GetValues( 0, 30, 1 / sampleRate ), sampleRate );
            int maxIndex = signal.Values.ToList().IndexOf( signal.Values.Max() );

            double calculatedAmplitude = AleksandrovMaths.CalculateMethodFiveChannels( signal, maxIndex );

            // Assert
            Assert.AreEqual( expectedAmplitude, Math.Round( calculatedAmplitude, 3 ) );
        }
    }
}

