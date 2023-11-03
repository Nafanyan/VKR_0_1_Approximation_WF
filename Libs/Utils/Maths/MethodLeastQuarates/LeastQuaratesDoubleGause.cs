using AleksandrovRTm.Libs.Utils.Core;
using AleksandrovRTm.Libs.Utils.Functions;

namespace AleksandrovRTm.Libs.Utils.Maths.MethodLeastQuarates
{
    public class LeastQuaratesDoubleGause
    {
        public DigitalSignal Signal;
        public double AmplitudeFirst { get; private set; }
        public double MatExpectationFirst { get; private set; }
        public double DeviationFirst { get; private set; }
        public double AmplitudeSecond { get; private set; }
        public double MatExpectationSecond { get; private set; }
        public double DeviationSecond { get; private set; }

        private double _h = 10;
        private readonly double MinH = 0.0001;

        public LeastQuaratesDoubleGause(
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

        public LeastQuaratesDoubleGause(
           DigitalSignal signal,
           List<double> amplitudes,
           List<double> matExpectations,
           List<double> deviations )
        {

            Signal = signal;
            if ( ( amplitudes.Count != matExpectations.Count )
                || ( amplitudes.Count != deviations.Count ) )
            {
                throw new Exception( "Размерность коллекций отличается. Каждому значению амплитуды должно соответствовать своё значение " +
                    "мат. ожидания и среднего отклонения." );
            }

            Dictionary<string, double> correctParams = GetCorrectParams( amplitudes, matExpectations, deviations );
            AmplitudeFirst = correctParams[ "AmplitudeFirst" ];
            MatExpectationFirst = correctParams[ "MatExpectationFirst" ];
            DeviationFirst = correctParams[ "DeviationFirst" ];
            AmplitudeSecond = correctParams[ "AmplitudeSecond" ];
            MatExpectationSecond = correctParams[ "MatExpectationSecond" ];
            DeviationSecond = correctParams[ "DeviationSecond" ];
        }

        private LeastQuaratesDoubleGause()
        {

        }


        public void CalculateParameters()
        {
            double minValue = double.MaxValue;
            var calculatedResult = new Dictionary<List<double>, double>();
            var minValueParams = new Dictionary<List<double>, double>();
            int count = 0;

            while ( minValue >= 0.00001 && count != 1000 )
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
                if ( minValue == newMinValueParams.Value )
                {
                    _h = _h <= MinH ? MinH : _h / 10;
                    count = _h == MinH ? count + 1 : count;
                    continue;
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
            var sig1 = new DigitalSignal( gauseOne.GetValues( 0, Signal.Values.Length, 1 / Signal.SamplingRate ), Signal.SamplingRate ); ;
            var sig2 = new DigitalSignal( gauseTwo.GetValues( 0, Signal.Values.Length, 1 / Signal.SamplingRate ), Signal.SamplingRate );

            for ( int x = 0; x < Signal.Values.Length; x++ )
            {
                double y = Signal.Values[ x ];
                sum += Math.Pow( y - ( sig1.Values[ x ] + sig2.Values[ x ] ), 2 );
            }
            return sum;
        }

        private Dictionary<string, double> GetCorrectParams( List<double> amplitudes, List<double> matExpectations, List<double> deviations )
        {
            var correctParams = new Dictionary<string, double>();
            var calculatedValueOfLeastQuarates = new List<double>();
            for ( int i = 0; i < amplitudes.Count; i++ )
            {
                for ( int j = 0; j < amplitudes.Count; j++ )
                {
                    if ( deviations[ i ] is Double.NaN || deviations[ j ] is Double.NaN || i == j)
                    {
                        calculatedValueOfLeastQuarates.Add( Double.MaxValue );
                        continue;
                    }

                    calculatedValueOfLeastQuarates.Add( GetValueOfLeastQuarates(
                        amplitudes[ i ],
                        matExpectations[ i ],
                        deviations[ i ],
                        amplitudes[ j ],
                        matExpectations[ j ],
                        deviations[ j ] ) );
                }
            }

            int indexMin = calculatedValueOfLeastQuarates.IndexOf( calculatedValueOfLeastQuarates.Min() );
            int indexFirstParams = Convert.ToInt32( Math.Floor( ( Decimal )indexMin / amplitudes.Count ) );
            int indexSecondParams = indexMin % amplitudes.Count;

            correctParams[ "AmplitudeFirst" ] = amplitudes[ indexFirstParams ];
            correctParams[ "MatExpectationFirst" ] = matExpectations[ indexFirstParams ];
            correctParams[ "DeviationFirst" ] = deviations[ indexFirstParams ];
            correctParams[ "AmplitudeSecond" ] = amplitudes[ indexSecondParams ];
            correctParams[ "MatExpectationSecond" ] = matExpectations[ indexSecondParams ];
            correctParams[ "DeviationSecond" ] = deviations[ indexSecondParams ];

            return correctParams;
        }
    }
}
