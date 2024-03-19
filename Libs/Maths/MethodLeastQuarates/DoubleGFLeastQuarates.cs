using AleksandrovRTm.Core.Entities;
using AleksandrovRTm.Libs.Functions;

namespace AleksandrovRTm.Libs.Maths.MethodLeastQuarates
{
    public class DoubleGFLeastQuarates
    {
        public DigitalSignal Signal;
        public double AmplitudeFirst { get; private set; }
        public double MatExpectationFirst { get; private set; }
        public double DeviationFirst { get; private set; }
        public double AmplitudeSecond { get; private set; }
        public double MatExpectationSecond { get; private set; }
        public double DeviationSecond { get; private set; }

        private double _h = 0.1;

        public DoubleGFLeastQuarates(
            DigitalSignal signal,
            double amplitudeFirst,
            double matExpectationFirst,
            double deviationFirst,
            double amplitudeSecond,
            double matExpectationSecond,
            double deviationSecond )
        {
            Signal = signal;
            AmplitudeFirst = amplitudeFirst;
            MatExpectationFirst = matExpectationFirst;
            DeviationFirst = deviationFirst;
            AmplitudeSecond = amplitudeSecond;
            MatExpectationSecond = matExpectationSecond;
            DeviationSecond = deviationSecond;
        }

        public void CalculateParameters()
        {
            double minValue = double.MaxValue;
            var calculatedResult = new Dictionary<List<double>, double>();
            var minValueParams = new Dictionary<List<double>, double>();

            while ( minValue >= 0.001 && _h != 0 )
            {
                List<Dictionary<string, double>> variantParams = GetAllVariantsForParams();

                calculatedResult = new Dictionary<List<double>, double>();
                foreach ( var variantParam in variantParams )
                {
                    calculatedResult[ variantParam.Values.ToList() ] = GetValueOfLeastQuarates(
                        variantParam[ "AmplitudeFirst" ],
                        variantParam[ "MatExpectationFirst" ],
                        variantParam[ "DeviationFirst" ],
                        variantParam[ "AmplitudeSecond" ],
                        variantParam[ "MatExpectationSecond" ],
                        variantParam[ "DeviationSecond" ] );
                }

                var newMinValueParams = calculatedResult.LastOrDefault( r => r.Value == calculatedResult.Values.Min() );
                if ( Math.Round( minValue, 3 ) == Math.Round( newMinValueParams.Value, 3 ) )
                {
                    _h /= 2;
                }

                minValue = newMinValueParams.Value;
                AmplitudeFirst = newMinValueParams.Key[ 0 ];
                MatExpectationFirst = newMinValueParams.Key[ 1 ];
                DeviationFirst = newMinValueParams.Key[ 2 ];
                AmplitudeSecond = newMinValueParams.Key[ 3 ];
                MatExpectationSecond = newMinValueParams.Key[ 4 ];
                DeviationSecond = newMinValueParams.Key[ 5 ];
            }
        }

        private List<Dictionary<string, double>> GetAllVariantsForParams()
        {
            var variants = new List<int> { -1, 0, 1 };
            var variantParams = new List<Dictionary<string, double>>();
            for ( int i = 0; i < Math.Pow( variants.Count(), 6 ); i++ )
            {
                var newVariantsParams = new Dictionary<string, double>();
                newVariantsParams[ "AmplitudeFirst" ] = AmplitudeFirst + _h * variants[ i % 3 ];
                newVariantsParams[ "MatExpectationFirst" ] = MatExpectationFirst + _h * variants[ i / 3 % 3 ];
                newVariantsParams[ "DeviationFirst" ] = DeviationFirst + _h * variants[ i / 9 % 3 ];
                newVariantsParams[ "AmplitudeSecond" ] = AmplitudeSecond + _h * variants[ i / 27 % 3 ];
                newVariantsParams[ "MatExpectationSecond" ] = MatExpectationSecond + _h * variants[ i / 81 % 3 ];
                newVariantsParams[ "DeviationSecond" ] = DeviationSecond + _h * variants[ i / 243 % 3 ];
                variantParams.Add( newVariantsParams );
            }

            return variantParams;
        }

        private double GetValueOfLeastQuarates(
            double amplitudeFirst,
            double matExpectationFirst,
            double deviationFirst,
            double amplitudeSecond,
            double matExpectationSecond,
            double deviationSecond )
        {
            double sum = 0;
            var gauseOne = new GauseFunction( amplitudeFirst, matExpectationFirst, deviationFirst );
            var gauseTwo = new GauseFunction( amplitudeSecond, matExpectationSecond, deviationSecond );
            var sig1 = new DigitalSignal( gauseOne.GetValues( 0, 30, 1 / Signal.SamplingRate ), Signal.SamplingRate ); ;
            var sig2 = new DigitalSignal( gauseTwo.GetValues( 0, 30, 1 / Signal.SamplingRate ), Signal.SamplingRate );

            double y = 0;
            double yFirstTheorSignal = 0;
            double ySecondTheorSignal = 0;
            double yTheorSignal = 0;

            for ( int x = 0; x < Signal.Values.Length; x++ )
            {
                y = Signal.Values[ x ];

                yFirstTheorSignal = sig1.Values[ x ];
                ySecondTheorSignal = sig2.Values[ x ];

                yTheorSignal = yFirstTheorSignal > ySecondTheorSignal ?
                    yFirstTheorSignal
                    : ySecondTheorSignal;

                sum += Math.Pow( y - ( yTheorSignal ), 2 );
            }
            return sum;
        }
    }
}
