namespace AleksandrovRTm.Libs.Utils.Functions
{
    public class GauseFunction : BaseFunction
    {
        public double Amplitude
        {
            get => _amplitude;
            set => _amplitude = value;
        }
        public double PeakCenter
        {
            get => _peakCenter;
            set => _peakCenter = value;
        }
        public double Deviation
        {
            get => _deviation;
            set => _deviation = value;
        }

        private double _amplitude;
        private double _peakCenter;
        private double _deviation;

        public GauseFunction( double amplitude, double peakCenter, double deviation )
        {
            _amplitude = amplitude;
            _peakCenter = peakCenter;
            _deviation = deviation;
        }

        public override double GetValue( double x )
        {
            double expFunc = Math.Exp( -1 * Math.Pow( x - _peakCenter, 2 ) / Math.Pow( _deviation, 2 ) );
            return _amplitude * expFunc;
        }

        public static double CalculateDeviation( double y, double x, double amplitude, double peakCenter )
        {
            var deviation = Math.Sqrt( -1 * Math.Pow( x - peakCenter, 2 ) / Math.Log( y / amplitude ) );
            return Math.Round( deviation, 3 );
        }
    }
}
