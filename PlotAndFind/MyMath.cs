using System;

namespace PlotAndFind
{
    public class MyMath
    {
        public static double Function1(double x) => Math.Sin(x) + Math.Cos(Math.Sqrt(3) * x);
    }

    public class Calculation
    {
        public struct CalculationResult
        {
            public int step;
            public double point;
            public double value;
        }

        /*public static CalculationResult GoldenSectionRoot(Func<double, double> function, double a, double b, double eps)
        {
            var result = new CalculationResult();
            result.step = 0;

            do
            {
                result.step++;
                double c = a + 0.618 * (b - a);
                //if (function(c) < eps) break;
                if (Math.Sign(function(a)) * Math.Sign(function(c)) < 0) b = c;
                else a = c;
            }
            while (Math.Abs(b - a) > eps);

            result.point = 0.5 * (b + a);
            result.value = function(result.point);
            return result;
        }*/

        /// <summary>
        /// Находит минимальное или максимальное значение методом золотого сечения.
        /// </summary>
        /// <param name="function">Функция для поиска</param>
        /// <param name="a">Левая граница локализации</param>
        /// <param name="b">Правая граница локализации</param>
        /// <param name="eps">Точность поиска</param>
        /// <returns>Минимальное или максимальное значение в указанном диапазоне.</returns>
        public static CalculationResult GoldenSectionOpt(Func<double, double> function, double a, double b, double eps)
        {
            var result = new CalculationResult();
            result.step = 0;

            do
            {
                result.step++;
                double x1 = a + (b - a) * 0.382;
                double x2 = a + (b - a) * 0.618;
                if (function(x1) >= function(x2)) a = x1;
                else b = x2;
            }
            while (Math.Abs(b - a) > eps);

            result.point = 0.5 * (b + a);
            result.value = function(result.point);
            return result;
        }

        /// <summary>
        /// Находит минимальное или максимальное значение методом дихотомии.
        /// </summary>
        /// <param name="function">Функция для поиска</param>
        /// <param name="a">Левая граница локализации</param>
        /// <param name="b">Правая граница локализации</param>
        /// <param name="eps">Точность поиска</param>
        /// <returns>Минимальное или максимальное значение в указанном диапазоне.</returns>
        public static CalculationResult HalvingOpt(Func<double, double> function, double a, double b, double eps)
        {
            var result = new CalculationResult();
            result.step = 0;

            do
            {
                double x = (a + b) / 2;
                if (function(x - eps) < function(x + eps)) b = x;
                else a = x;
                result.step++;
            }
            while (Math.Abs(b - a) >= eps);

            result.point = (a + b) / 2;
            result.value = function(result.point);

            return result;
        }
    }
}
