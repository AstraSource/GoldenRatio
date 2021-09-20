using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenRatioRoot
{
    public class MyMath
    {
        public struct GoldenRatioResult
        {
            public int step;
            public double point;
            public double value;
        }

        public static double Function1(double x)
        {
            return Math.Sin(x) + Math.Cos(Math.Sqrt(3) * x);
        }

        public static GoldenRatioResult GoldenRatioRoot(Func<double, double> function, double a, double b, double eps)
        {
            var result = new GoldenRatioResult();
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
        }

        public static GoldenRatioResult GoldenRatioOpt(Func<double, double> function, double a, double b, double eps)
        {
            var result = new GoldenRatioResult();
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
    }
}
