using AleksandrovRTm.Libs.Utils.Functions.Interfaces;

namespace AleksandrovRTm.Libs.Utils.Functions
{
    public abstract class BaseFunction :
        IGetValueOfFunction,
        IGetValuesOfFunction
    {
        public abstract double GetValue( double x );

        virtual public double[] FunctionValues { get; private set; } = new double[0];

        public virtual double[] GetValues( double startX, double endX, double step )
        {
            int numValues = ( int )( ( endX - startX ) / step );
            FunctionValues = new double[numValues];

            for( int i = 0; i < numValues; i++ )
            {
                FunctionValues[i] = GetValue( startX );
                startX += step;
            }

            return FunctionValues;
        }
    }
}
