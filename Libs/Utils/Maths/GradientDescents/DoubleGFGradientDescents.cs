using AleksandrovRTm.Libs.Utils.Maths.Derivatives;

namespace AleksandrovRTm.Libs.Utils.Maths.GradientDescents
{
    internal class DoubleGFGradientDescents
    {
        public double AmplitudeFirst { get; private set; }
        public double MatExpectationFirst { get; private set; }
        public double DeviationFirst { get; private set; }
        public double AmplitudeSecond { get; private set; }
        public double MatExpectationSecond { get; private set; }
        public double DeviationSecond { get; private set; }
        public double X { get; private set; }

        private readonly double _stepGradientDescent = 0.01;
        private readonly List<string> _nameParams = new List<string>()
        {
            "AmplitudeFirst",
            "MatExpectationFirst",
            "DeviationFirst",
            "AmplitudeSecond",
            "MatExpectationSecond",
            "DeviationSecond",
        };

        public DoubleGFGradientDescents( 
            double amplitudeFirst, 
            double matExpectationFirst, 
            double deviationFirst,
            double amplitudeSecond,
            double matExpectationSecond,
            double deviationSecond,
            double x )
        {
            AmplitudeFirst = amplitudeFirst;
            MatExpectationFirst = matExpectationFirst;
            DeviationFirst = deviationFirst;
            AmplitudeSecond = amplitudeSecond;
            MatExpectationSecond = matExpectationSecond;
            DeviationSecond = deviationSecond;
            X = x;
        }

        public Dictionary<string, double> Start()
        {
            var calculatedParameters = new Dictionary<string, double>();
            int count = 0;
            while( true && count <= 1000 )
            {
                calculatedParameters = CalculationStepOfGradientDescent();
                if( GradientIsMax( calculatedParameters ) )
                {
                    return calculatedParameters;
                }
                count++;
            }
            return calculatedParameters;
        }

        private Dictionary<string, double> CalculationStepOfGradientDescent()
        {
            var previousParams = new List<double>
            {
                AmplitudeSecond,
                MatExpectationSecond,
                DeviationSecond,
                X
            };

            var newParams = new List<double>()
            {
                GauseFunction.DerivativeOfAmplitude( MatExpectationSecond, DeviationSecond, X ),
                GauseFunction.DerivativeOfMatExpectation( AmplitudeSecond, MatExpectationSecond, DeviationSecond, X ),
                GauseFunction.DerivativeOfDeviation( AmplitudeSecond, MatExpectationSecond, DeviationSecond, X ),
                GauseFunction.DerivativeOfX(AmplitudeSecond, MatExpectationSecond, DeviationSecond, X),
            };

            var calculationParams = new Dictionary<string, double>();
            for( int i = 0; i < previousParams.Count; i++ )
            {
                calculationParams[_nameParams[i]] = ( previousParams[i] + _stepGradientDescent * newParams[i] );
            }

            return calculationParams;
        }

        private bool GradientIsMax( Dictionary< string, double> calculatedParameters )
        {
            return calculatedParameters["Amplitude"] <= AmplitudeSecond
                && calculatedParameters["MatExpectation"] <= MatExpectationSecond
                && calculatedParameters["Deviation"] <= DeviationSecond
                && calculatedParameters["X"] <= X;
        }
    }
}
