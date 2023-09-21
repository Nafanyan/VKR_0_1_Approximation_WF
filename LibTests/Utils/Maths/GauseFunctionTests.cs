using AleksandrovRTm.Libs.Utils.Core;
using AleksandrovRTm.Libs.Utils.Functions;
using AleksandrovRTm.Libs.Utils.Maths;

namespace AleksandrovRTm.LibsTests.Utils
{
    public class GauseFunctionTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void CalculateDeviation_YXAmplitudePeakCenter_CorrectDevuation()
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
            var gauseOne = new GauseFunction(amplitudeOne, peakCentreOne, deviationOne);
            var signalOne = new DigitalSignal(gauseOne.GetValues(0, 30, 1 / sampleRate), sampleRate);

            var gauseTwo = new GauseFunction(amplitudeTwo, peakCentreTwo, deviationTwo);
            var signalTwo = new DigitalSignal(gauseTwo.GetValues(0, 30, 1 / sampleRate), sampleRate);

            DigitalSignal combineGause = DigitalSignal.CombineTwoSignals(signalOne, signalTwo);
            List<double> xExtremumsMax = Maths.ExtremumPointsMax(combineGause);
            double maxOneGause = combineGause.Values[(int)(xExtremumsMax[0] * combineGause.SamplingRate)];
            double maxTwoGause = combineGause.Values[(int)(xExtremumsMax[1] * combineGause.SamplingRate)];

            var pointFromGauseOne = Maths.FindPointLeftOfTheY(combineGause, maxOneGause, 0.3);
            var pointFromGauseTwo = Maths.FindPointRightOfTheY(combineGause, maxTwoGause, 0.3);

            // Assert
            Assert.AreEqual(deviationOne, GauseFunction.CalculateDeviation(pointFromGauseOne["y"], pointFromGauseOne["x"], amplitudeOne, xExtremumsMax[ 0 ] ) );
            Assert.AreEqual(deviationTwo, GauseFunction.CalculateDeviation(pointFromGauseTwo["y"], pointFromGauseTwo["x"], amplitudeTwo, xExtremumsMax[ 1 ] ) );
        }
    }
}
