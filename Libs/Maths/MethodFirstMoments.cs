using AleksandrovRTm.Core.Entities;
using Libs.Extensions;

namespace Libs.Maths.MethodFirstMoments
{
    internal class GFMethodFirstMoments
    {
        public double Calculate( DigitalSignal signal, int startRange, int endRange )
        {
            return CalculateSumOfMultiplicationXY( signal, startRange, endRange )
                / signal.Values.SumInRange( startRange, endRange );
        }

        private double CalculateSumOfMultiplicationXY( DigitalSignal signal, int startRange, int endRange )
        {
            double sumOfMultiplicationXY = 0;

            for ( int x = startRange; x <= endRange; x++ )
            {
                sumOfMultiplicationXY = signal.Values[ x ] * x;
            }

            return sumOfMultiplicationXY;
        }
    }
}

