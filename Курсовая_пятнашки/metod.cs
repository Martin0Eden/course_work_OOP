using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Курсовая_пятнашки
{
    internal class metod
    {
        public static int HasNeighborZero(int[,] array, int i, int j)
        {
            int rows = array.GetLength(0);
            int columns = array.GetLength(1);

            if (i > 0 && array[i - 1, j] == 0)
                return 1;

            if (i < rows - 1 && array[i + 1, j] == 0)
                return 2;

            if (j < columns - 1 && array[i, j + 1] == 0)
                return 3;

            if (j > 0 && array[i, j - 1] == 0)
                return 4;

            return 0;
        }

        public static void onbut(Button b, Label l)
        {
            DoubleAnimation btn = new DoubleAnimation();
            btn.From = 0;
            btn.To = 1;
            btn.Duration = TimeSpan.FromSeconds(3);
            l.BeginAnimation(Label.OpacityProperty, btn);
            b.BeginAnimation(Button.OpacityProperty, btn);

        }
    }
}
