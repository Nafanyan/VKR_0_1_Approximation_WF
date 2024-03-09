using AleksandrovRTm.Core.Entities;

namespace Libs.Maths
{
    internal class MethodFiveChannels
    {
        public double Calculate( DigitalSignal signal, int maxIndex )
        {
            double[] values = signal.Values;
            double x = values[ maxIndex ];

            double numerator = values[ maxIndex + 1 ] * ( values[ maxIndex ] - values[ maxIndex - 2 ] )
                - values[ maxIndex - 1 ] * ( values[ maxIndex ] - values[ maxIndex + 2 ] );

            double denominator = values[ maxIndex + 1 ] * ( values[ maxIndex ] - values[ maxIndex - 2 ] )
                + values[ maxIndex - 1 ] * ( values[ maxIndex ] - values[ maxIndex + 2 ] );

            return x + ( numerator ) / ( denominator );
        }
    }
}