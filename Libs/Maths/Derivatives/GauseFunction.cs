namespace AleksandrovRTm.Libs.Maths.Derivatives
{
    internal static class GauseFunction
    {
        public static double DerivativeOfAmplitude( double matExpectation, double deviation, double x )
        {
            return Math.Exp( GetExpParam( matExpectation, deviation, x ) );
        }

        public static double DerivativeOfMatExpectation(
            double amplitude,
            double matExpectation,
            double deviation,
            double x )
        {
            double derivativeOfExpParam = 2 * ( x - matExpectation ) / Math.Pow( deviation, 2 );
            return amplitude * derivativeOfExpParam * GetExpParam( matExpectation, deviation, x );
        }

        public static double DerivativeOfDeviation(
            double amplitude,
            double matExpectation,
            double deviation,
            double x )
        {
            double derivativeOfExpParam = 2 * Math.Pow( ( x - matExpectation ), 2 ) / Math.Pow( deviation, 3 );
            return amplitude * derivativeOfExpParam * GetExpParam( matExpectation, deviation, x );
        }

        public static double DerivativeOfX(
            double amplitude,
            double matExpectation,
            double deviation,
            double x )
        {
            double derivativeOfExpParam = -2 * ( x - matExpectation ) / Math.Pow( deviation, 2 );
            return amplitude * derivativeOfExpParam * GetExpParam( matExpectation, deviation, x );
        }

        private static double GetExpParam( double matExpectation, double deviation, double x )
        {
            return -1 * Math.Pow( ( x - matExpectation ), 2 ) / Math.Pow( deviation, 2 );
        }
    }
}
