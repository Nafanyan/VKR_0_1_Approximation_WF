namespace AleksandrovRTm.Libs.Maths
{
    internal class ExtremumPoints
    {
        public int Aperture { get; set; } = 3;

        private const int BitDeph = 3;
        private double[] _graphics;
        private double _sampleRate;

        public ExtremumPoints( double[] graphics, double sampleRate )
        {
            _graphics = graphics;
            _sampleRate = sampleRate;
        }

        public List<double> GetXsExtremumPointsMax()
        {
            var extremumPointsMax = new List<double>();
            var areaOfAperture = new List<double>();
            int localIndexMax = 0;

            for ( int i = 0; i < _graphics.Length - Aperture; i++ )
            {
                areaOfAperture = new List<double>();
                for ( int j = i; j < Aperture + i; j++ )
                {
                    areaOfAperture.Add( _graphics[ j ] );
                }

                localIndexMax = areaOfAperture.IndexOf( areaOfAperture.Max() );
                if ( localIndexMax == Aperture / 2 )
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
                if ( localIndexMin == Aperture / 2 )
                {
                    double xExtremum = ( i + localIndexMin ) / _sampleRate;
                    extremumPointsMin.Add( Math.Round( xExtremum, BitDeph ) );
                }
            }

            return extremumPointsMin;
        }
    }
}
