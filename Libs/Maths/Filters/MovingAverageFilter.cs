namespace Libs.Maths.Filters
{
    public class MovingAverageFilter
    {
        public double[] Filtering( double[] array, int size )
        {
            int sizeFilteredArray = array.Count() / size;
            double[] filteredArray = new double[ sizeFilteredArray ];

            double filteredValue;
            int count = 0;
            for ( int i = 0; i < array.Count(); i += size )
            {
                filteredValue = 0;
                for ( int j = i; j < i + size; j++ )
                {
                    filteredValue += array[ j ];
                }
                filteredArray[ count ] = filteredValue / size;
                count++;
            }

            return filteredArray;
        }
    }
}

