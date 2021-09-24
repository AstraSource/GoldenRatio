using System.Windows;
using OxyPlot;
using OxyPlot.Series;

namespace GoldenRatioRoot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Controller control;

        public MainWindow()
        {
            InitializeComponent();
            control = new Controller
            {
                TextBoxA = InputA,
                TextBoxB = InputB,
                TextBoxEps = InputEpsilon,
                RButtonGoldenSectionMin = RBRoot,
                RButtonHalvingMin = RBOpt
            };
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
            MyModel = new PlotModel { Title = "Minimum Value. Function plot"};

            MyModel.Series.Add(new FunctionSeries(MyMath.Function1, -20, 20, 0.01, "sin(x) + cos(sqrt(3) * x)"));
        }

        public static PlotModel MyModel { get; private set; }
    }
}
