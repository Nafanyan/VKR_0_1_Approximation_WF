namespace Libs.Maths
{
    public class Decimator
    {

        public double[] Decimation( double[] array, int coefficientDecimation )
        {
            int sizeDecimatedArray = array.Count() / coefficientDecimation;

            double[] decimatedArray = new double[ sizeDecimatedArray ];

            for ( int i = 0; i < sizeDecimatedArray; i++ )
            {
                decimatedArray[ i ] = array[ i * coefficientDecimation ];
            }

            return decimatedArray;
        }
    }
}

