namespace AleksandrovRTm.Libs.Maths
{
    public class FindPoint
    {
        private int _bitDeph = 3;
        private double[] _graphics;
        private double _sampleRate;

        public FindPoint( double[] graphics, double sampleRate, int bitDeph = 3 )
        {
            _graphics = graphics;
            _sampleRate = sampleRate;
            _bitDeph = bitDeph;
        }
        
        public Dictionary<string, double> FindPointOfTheY( double y, double heightRelativeToY )
        {
            Dictionary<string, double> result = new Dictionary<string, double>();
            int xFromY = _graphics.ToList().IndexOf( y );

            for ( int i = 0; i <= xFromY; i++ )
            {
                if ( _graphics[ i ] <= y * heightRelativeToY && _graphics[ i + 1 ] >= y * heightRelativeToY )
                {
                    result[ "x" ] = Math.Round( ( i + 1 ) / _sampleRate, _bitDeph );
                    result[ "y" ] = _graphics[ i + 1 ];
                    return result;
                }
            }

            return result;
        }

        public Dictionary<string, double> FindPointRightOfTheY( double y, double heightRelativeToY )
        {
            Dictionary<string, double> result = new Dictionary<string, double>();
            int xFromY = _graphics.ToList().IndexOf( y );

            for ( int i = _graphics.Count() - 2; i >= xFromY; i-- )
            {
                if ( _graphics[ i ] >= y * heightRelativeToY && _graphics[ i + 1 ] <= y * heightRelativeToY )
                {
                    result[ "x" ] = Math.Round( ( i - 1 ) / _sampleRate, _bitDeph );
                    result[ "y" ] = _graphics[ i + -1 ];
                }
            }

            return result;
        }
    }
}
