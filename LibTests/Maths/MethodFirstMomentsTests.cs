
using AleksandrovRTm.Core.Entities;
using AleksandrovRTm.Libs.Functions;
using AleksandrovMaths = AleksandrovRTm.Libs.Maths.Maths;

namespace AleksandrovRTm.LibsTests.Maths.MethodFirstMoments
{
    internal class MethodFirstMomentsTests
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

            double expectedAmplitude = 1;
            double expectedPeakCentre = 5;
            double expectedDeviation = 1;

            // Act
            var gause = new GauseFunction( expectedAmplitude, expectedPeakCentre, expectedDeviation );
            var signal = new DigitalSignal( gause.GetValues( 0, 30, 1 / sampleRate ), sampleRate );

            double calculatedPeakCentre = AleksandrovMaths.CalculateMethodFirstMoments(
                signal, 400, 600 );
            // Assert
            Assert.AreEqual( expectedPeakCentre, calculatedPeakCentre );
        }
    }
}

