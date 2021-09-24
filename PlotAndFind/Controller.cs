using OxyPlot;
using OxyPlot.Annotations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GoldenRatioRoot
{
    public class Controller
    {
        public TextBox TextBoxA;
        public TextBox TextBoxB;
        public TextBox TextBoxEps;
        public RadioButton RButtonGoldenSectionMin;
        public RadioButton RButtonHalvingMin;

        public void Calculate()
        {
            double numA = Double.Parse(TextBoxA.Text, CultureInfo.InvariantCulture);
            double numB = Double.Parse(TextBoxB.Text, CultureInfo.InvariantCulture);
            double numEps = Double.Parse(TextBoxEps.Text, CultureInfo.InvariantCulture);

            Calculation.CalculationResult result;
            if (RButtonGoldenSectionMin.IsChecked == true) result = Calculation.GoldenSectionOpt(MyMath.Function1, numA, numB, numEps);
            else result = Calculation.HalvingOpt(MyMath.Function1, numA, numB, numEps);

            var point = new PointAnnotation
            {
                X = result.point,
                Y = result.value,
                Fill = OxyColors.Red,
                Text = String.Format("X = {0}\nY = {1}\nSteps = {2}", result.point, result.value, result.step)
            };
            var left = new PointAnnotation
            {
                X = numA,
                Y = MyMath.Function1(numA),
                Fill = OxyColors.Blue
            };
            var right = new PointAnnotation
            {
                X = numB,
                Y = MyMath.Function1(numB),
                Fill = OxyColors.Blue
            };
            MainViewModel.MyModel.Annotations.Clear();
            MainViewModel.MyModel.Annotations.Add(point);
            MainViewModel.MyModel.Annotations.Add(left);
            MainViewModel.MyModel.Annotations.Add(right);
            MainViewModel.MyModel.InvalidatePlot(true);
        }
    }
}
