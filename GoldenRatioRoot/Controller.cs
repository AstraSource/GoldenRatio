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
        public RadioButton RButtonRoot;
        public RadioButton RButtonMin;
        public RadioButton RButtonMax;

        public void Calculate()
        {
            double numA = Double.Parse(TextBoxA.Text, CultureInfo.InvariantCulture);
            double numB = Double.Parse(TextBoxB.Text, CultureInfo.InvariantCulture);
            double numEps = Double.Parse(TextBoxEps.Text, CultureInfo.InvariantCulture);

            Calculation.CalculationResult gold;
            if (RButtonRoot.IsChecked == true) gold = Calculation.GoldenRatioRoot(MyMath.Function1, numA, numB, numEps);
            else gold = Calculation.GoldenRatioOpt(MyMath.Function1, numA, numB, numEps);

            var point = new PointAnnotation
            {
                X = gold.point,
                Y = gold.value,
                Fill = OxyColors.Red,
                Text = String.Format("X = {0}\nY = {1}", gold.point, gold.value)
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
