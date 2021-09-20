using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Annotations;

namespace GoldenRatioRoot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Controller control;

        public MainWindow()
        {
            InitializeComponent();
            control = new Controller();
            control.a = InputA;
            control.b = InputB;
            control.eps = InputEpsilon;
        }

        private void CalcButton_Click(object sender, RoutedEventArgs e)
        {
            control.Calculate();
        }
    }

    public class Controller
    {
        public TextBox a;
        public TextBox b;
        public TextBox eps;

        public void Calculate()
        {
            double aNum = Double.Parse(a.Text, CultureInfo.InvariantCulture);
            double bNum = Double.Parse(b.Text, CultureInfo.InvariantCulture);
            double epsNum = Double.Parse(eps.Text, CultureInfo.InvariantCulture);

            var gold = MyMath.GoldenRatioRoot(MyMath.Function1, aNum, bNum, epsNum);
            var point = new PointAnnotation
            {
                X = gold.root,
                Y = gold.value,
                Fill = OxyColors.Red,
                Text = String.Format("X = {0}\nY = {1}", gold.root, gold.value)
            };
            MainViewModel.MyModel.Annotations.Clear();
            MainViewModel.MyModel.Annotations.Add(point);
            MainViewModel.MyModel.InvalidatePlot(true);
        }
    }

    public class MainViewModel
    {
        public MainViewModel()
        {
            MyModel = new PlotModel { Title = "Golder Ratio Root" };

            MyModel.Series.Add(new FunctionSeries(MyMath.Function1, -20, 20, 0.01, "sin(x) + cos(sqrt(3) * x)"));
        }

        public static PlotModel MyModel { get; private set; }
    }

    public class MyMath
    {
        public struct GoldenRatioResult
        {
            public int step;
            public double root;
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
            while (b - a > eps);

            result.root = 0.5 * (b + a);
            result.value = function(result.root);
            return result;
        }
    }
}
