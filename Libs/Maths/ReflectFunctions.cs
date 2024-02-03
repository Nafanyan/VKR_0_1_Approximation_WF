namespace AleksandrovRTm.Libs.Maths
{
    internal class ReflectFunctions
    {

        private double[] _graphics;

        public ReflectFunctions( double[] graphics )
        {
            _graphics = graphics;
        }

        public double[] GetReflectFunctionsLeftToRight( int index )
        {
            double[] result = new double[ index * 2 ];

            for ( int i = 0; i < index; i++ )
            {
                result[ i ] = _graphics[ i ];
            }

            for ( int i = index; i > 0; i-- )
            {
                result[ i ] = _graphics[ i ];
            }
            return result;
        }

        public double[] GetReflectFunctionsRightToLeft( int index )
        {
            double[] result = new double[ index * 2 ];

            for ( int i = _graphics.Length - 1; i > index; i-- )
            {
                result[ _graphics.Length - i ] = _graphics[ i ];
            }

            for ( int i = index; i < _graphics.Length - 1; i++ )
            {
                result[ i ] = _graphics[ i ];
            }

            return result;
        }
    }
}
