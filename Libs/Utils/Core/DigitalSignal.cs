namespace AleksandrovRTm.Libs.Utils.Core
{
    public struct DigitalSignal
    {
        public double[] Values { get; private set; }
        public double SamplingRate { get; private set; }

        public DigitalSignal(double[] values, double samplingRate = 1)
        {
            Values = values;
            SamplingRate = samplingRate;
        }

        public static DigitalSignal CombineTwoSignals( DigitalSignal firstFunction, DigitalSignal secondFunction )
        {
            if( firstFunction.SamplingRate != secondFunction.SamplingRate )
            {
                return new DigitalSignal();
            }

            int numValues = firstFunction.Values.Length >= secondFunction.Values.Length
                ? firstFunction.Values.Length
                : secondFunction.Values.Length;
            double[] values = new double[numValues];

            for( int i = 0; i < numValues; i++ )
            {
                values[i] = firstFunction.Values[i] >= secondFunction.Values[i]
                    ? firstFunction.Values[i]
                    : secondFunction.Values[i];
            }

            return new DigitalSignal( values, firstFunction.SamplingRate );
        }

        public double[] GetPayLoadSignal()
        {
            return Values
                .Where(x => x >= 0.01)
                .ToArray();
        }
    }
}
