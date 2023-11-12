namespace AleksandrovRTm.Libs.Utils.Signals
{
    internal class ExtremumPoints
    {
        public int Aperture { get; private set; } = 3;

        private const int BitDeph = 3;
        private double[] _graphics;
        private double _sampleRate;

        public ExtremumPoints( double[] graphics, double sampleRate, int aperture = 3 )
        {
            _graphics = graphics;
            _sampleRate = sampleRate;
            Aperture = aperture;
        }

        public List<double> GetXsExtremumPointsMax()
        {
            var extremumPointsMax = new List<double>();
            var areaOfAperture = new List<double>();
            int localIndexMax = 0;
            int localIndexMin = 0;

            for ( int i = 0; i < _graphics.Length - Aperture; i++ )
            {
                areaOfAperture = new List<double>();
                for ( int j = i; j < Aperture + i; j++ )
                {
                    areaOfAperture.Add( _graphics[ j ] );
                }

                localIndexMax = areaOfAperture.IndexOf( areaOfAperture.Max() );
                var localAreaLeft = areaOfAperture.GetRange( 0, Convert.ToInt32( Aperture / 2 ) )
                    .ToList();
                var localAreaRight = areaOfAperture.GetRange( Convert.ToInt32( Aperture / 2 ) + 1, Convert.ToInt32( Aperture / 2 ) )
                    .ToList();

                if ( localIndexMax == Aperture / 2
                    && IncreasingTrend( localAreaLeft )
                    && DecreasingTrend( localAreaRight ) )
                {
                    double xExtremum = ( i + localIndexMax ) / _sampleRate;
                    extremumPointsMax.Add( Math.Round( xExtremum, BitDeph ) );
                }
            }

            return extremumPointsMax;
        }

        public List<double> GetXsExtremumPointsMin()
        {
            var extremumPointsMin = new List<double>();
            var areaOfAperture = new List<double>();
            int localIndexMin = 0;

            for ( int i = 0; i < _graphics.Length - Aperture; i++ )
            {
                areaOfAperture = new List<double>();
                for ( int j = i; j < Aperture + i; j++ )
                {
                    areaOfAperture.Add( _graphics[ j ] );
                }

                localIndexMin = areaOfAperture.IndexOf( areaOfAperture.Min() );
                var localAreaLeft = areaOfAperture.GetRange( 0, Convert.ToInt32( Aperture / 2 ) )
                    .ToList();
                var localAreaRight = areaOfAperture.GetRange( Convert.ToInt32( Aperture / 2 ) + 1, Convert.ToInt32( Aperture / 2 ) )
                    .ToList();

                if ( localIndexMin == Aperture / 2
                    && IncreasingTrend( localAreaRight )
                    && DecreasingTrend( localAreaLeft ) )
                {
                    double xExtremum = ( i + localIndexMin ) / _sampleRate;
                    extremumPointsMin.Add( Math.Round( xExtremum, BitDeph ) );
                }
            }

            return extremumPointsMin;
        }

        private bool IncreasingTrend( List<double> data )
        {
            double value = data[ 0 ];
            foreach ( double nextValue in data )
            {
                if ( value > nextValue )
                {
                    return false;
                }
                value = nextValue;
            }
            return true;
        }

        private bool DecreasingTrend( List<double> data )
        {
            double value = data[ 0 ];
            foreach ( double nextValue in data )
            {
                if ( value < nextValue )
                {
                    return false;
                }
                value = nextValue;
            }
            return true;
        }
    }
}
