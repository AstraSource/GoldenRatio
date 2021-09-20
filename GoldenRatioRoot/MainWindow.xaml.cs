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
            control.root = RBRoot;
            control.min = RBOpt;
        }

        private void CalcButton_Click(object sender, RoutedEventArgs e)
        {
            control.Calculate();
        }
    }

    public class MainViewModel
    {
        public MainViewModel()
        {
            MyModel = new PlotModel { Title = "Golder Ratio" };

            MyModel.Series.Add(new FunctionSeries(MyMath.Function1, -20, 20, 0.01, "sin(x) + cos(sqrt(3) * x)"));
        }

        public static PlotModel MyModel { get; private set; }
    }
}
