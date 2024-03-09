using AleksandrovRTm.Core.Entities;
using AleksandrovRTm.Libs.Maths.MethodLeastQuarates;
using Libs.Maths;
using Libs.Maths.MethodFirstMoments;

namespace AleksandrovRTm.Libs.Maths
{
    public static class Maths
    {
        /// <summary>
        /// Рассчитывает экстремумы максимумов у входного сигнала
        /// </summary>
        /// <param name="digitalSignal"></param>
        /// <returns>X значения экстремумов максимумов</returns>
        public static List<double> ExtremumPointsMax( DigitalSignal digitalSignal )
        {
            var extremumPoints = new ExtremumPoints( digitalSignal.Values, digitalSignal.SamplingRate );

            return extremumPoints.GetXsExtremumPointsMax();
        }

        /// <summary>
        /// Рассчитывает экстремумы минимумов у входного сигнала
        /// </summary>
        /// <param name="digitalSignal"></param>
        /// <returns>X значения экстремумов минимумов</returns>
        public static List<double> ExtremumPointsMin( DigitalSignal digitalSignal )
        {
            var extremumPoints = new ExtremumPoints( digitalSignal.Values, digitalSignal.SamplingRate );

            return extremumPoints.GetXsExtremumPointsMin();
        }

        public static double[] ReflectFunctionsLeftToRight( int index, double[] graphics )
        {
            var reflectFunctions = new ReflectFunctions( graphics );

            return reflectFunctions.GetReflectFunctionsLeftToRight( index );
        }

        public static double[] ReflectFunctionsRightToLeft( int index, double[] graphics )
        {
            var reflectFunctions = new ReflectFunctions( graphics );

            return reflectFunctions.GetReflectFunctionsRightToLeft( index );
        }

        /// <summary>
        /// Метод находит приближенное значение x при котором f(x) примерно равно y * heightRelativeToY 
        /// слева от опорной точки.
        /// </summary>
        /// <param name="digitalSignal"></param>
        /// <param name="y"></param>
        /// <param name="heightRelativeToY"></param>
        /// <returns>Возвращает словарь с x и f(x), при котором f(x) ~= y * heightRelativeToY. При условии, когда значение не найдено вернется y</returns>
        public static Dictionary<string, double> FindPointLeftOfTheY( DigitalSignal digitalSignal, double y, double heightRelativeToY )
        {
            var findPoint = new FindPoint( digitalSignal.Values, digitalSignal.SamplingRate );

            return findPoint.FindPointOfTheY( y, heightRelativeToY );
        }

        /// <summary>
        /// Метод находит приближенное значение x при котором f(x) примерно равно y * heightRelativeToY 
        /// слева от опорной точки.
        /// </summary>
        /// <param name="digitalSignal"></param>
        /// <param name="y"></param>
        /// <param name="heightRelativeToY"></param>
        /// <returns>Возвращает словарь с x и f(x), при котором f(x) ~= y * heightRelativeToY. При условии, когда значение не найдено вернется y</returns>
        public static Dictionary<string, double> FindPointRightOfTheY( DigitalSignal digitalSignal, double y, double heightRelativeToY )
        {
            var findPoint = new FindPoint( digitalSignal.Values, digitalSignal.SamplingRate );

            return findPoint.FindPointRightOfTheY( y, heightRelativeToY );
        }

        /// <summary>
        /// Возвращает объект наименьших квадратов для двойной функции Гаусса
        /// </summary>
        /// <param name="signal"></param>
        /// <param name="amplitudeFirst"></param>
        /// <param name="matExpectationFirst"></param>
        /// <param name="deviationFirst"></param>
        /// <param name="amplitudeSecond"></param>
        /// <param name="matExpectationSecond"></param>
        /// <param name="deviationSecond"></param>
        /// <returns></returns>
        public static DoubleGFLeastQuarates GetLeastQuaratesDoubleGause(
            DigitalSignal signal,
            double amplitudeFirst,
            double matExpectationFirst,
            double deviationFirst,
            double amplitudeSecond,
            double matExpectationSecond,
            double deviationSecond )
        {
            var leastQuarates = new DoubleGFLeastQuarates(
                signal,
                amplitudeFirst,
                matExpectationFirst,
                deviationFirst,
                amplitudeSecond,
                matExpectationSecond,
                deviationSecond );

            leastQuarates.CalculateParameters();
            return leastQuarates;
        }

        /// <summary>
        /// Рассчитывает величину первого момента для предоставляемой функции на указанном
        /// диапазоне
        /// </summary>
        /// <param name="signal"></param>
        /// <param name="startRange"></param>
        /// <param name="endRange"></param>
        /// <returns></returns>
        public static double CalculateMethodFirstMoments(
            DigitalSignal signal,
            int startRange,
            int endRange )
        {
            var methodFirstMoments = new MethodFirstMoments();

            return methodFirstMoments.Calculate( signal, startRange, endRange );
        }

        /// <summary>
        /// Оценивает центроиду пика с помощью метода пяти каналов
        /// </summary>
        /// <param name="signal"></param>
        /// <param name="maxIndex"></param>
        /// <returns></returns>
        public static double CalculateMethodFiveChannels( DigitalSignal signal, int maxIndex )
        {
            var methodFiveChannels = new MethodFiveChannels();

            return methodFiveChannels.Calculate( signal, maxIndex );
        }
    }
}
