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
        public TextBox a;
        public TextBox b;
        public TextBox eps;
        public RadioButton root;
        public RadioButton min;

        public void Calculate()
        {
            double aNum = Double.Parse(a.Text, CultureInfo.InvariantCulture);
            double bNum = Double.Parse(b.Text, CultureInfo.InvariantCulture);
            double epsNum = Double.Parse(eps.Text, CultureInfo.InvariantCulture);

            MyMath.GoldenRatioResult gold;
            if (root.IsChecked == true) gold = MyMath.GoldenRatioRoot(MyMath.Function1, aNum, bNum, epsNum);
            else gold = MyMath.GoldenRatioOpt(MyMath.Function1, aNum, bNum, epsNum);

            var point = new PointAnnotation
            {
                X = gold.point,
                Y = gold.value,
                Fill = OxyColors.Red,
                Text = String.Format("X = {0}\nY = {1}", gold.point, gold.value)
            };
            var left = new PointAnnotation
            {
                X = aNum,
                Y = MyMath.Function1(aNum),
                Fill = OxyColors.Blue
            };
            var right = new PointAnnotation
            {
                X = bNum,
                Y = MyMath.Function1(bNum),
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
