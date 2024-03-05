using Libs.Exceptions;

namespace Libs.Extensions
{
    public static class DoubleArrayExtensions
    {
        public static double SumInRange( this Array array, int startRange, int endRange )
        {
            if ( !( array is double[] || array is float[] || array is int[] ) )
            {
                throw new NotValidTypeException( "Type of array is not: double, float, int" );
            }

            double sumY = 0;

            for ( int x = startRange; x <= endRange; x++ )
            {
                sumY += ( double )array.GetValue( x );
            }

            return sumY;
        }
    }
}