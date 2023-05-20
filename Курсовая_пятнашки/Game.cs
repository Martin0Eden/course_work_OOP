using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Курсовая_пятнашки
{
    internal class Game
    {
        public delegate void game();
        public int size;
        public int[,] field;
        public Button[,] button;
        public Game(int size)
        {
            this.size = size;
            field=new int[size,size];
            button=new Button[size,size];
        }

        public void fill()
        {
            Random rand = new Random();
            List<int> nums = Enumerable.Range(0, size*size).ToList();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    int index = rand.Next(nums.Count);
                    if (index == size * size -1)
                        this.field[i, j] = 0;
                    this.field[i, j] = nums[index];
                    nums.RemoveAt(index);
                }
            }
            int zeroi = 0;
            int zeroj = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (this.field[i, j] == 0)
                    {
                        zeroi = i;
                        zeroj = j;
                    }
                }
            }
            (this.field[size-1, size-1], this.field[zeroi, zeroj]) = (this.field[zeroi, zeroj], this.field[3, 3]);
        }

        public void buttonfill()
        {
            double buttonSize = 150;
            double horizontalMargin = (650 - (4 * buttonSize)) / 5; 
            double verticalMargin = (650 - (4 * buttonSize)) / 5;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    button[i, j] = new Button();
                    button[i, j].Content = this.field[i, j];
                    button[i, j].Width = buttonSize;
                    button[i, j].Height = buttonSize;
                    double leftMargin = (j + 1) * horizontalMargin + j * buttonSize;
                    double topMargin = (i + 1) * verticalMargin + i * buttonSize;
                    button[i, j].Margin = new System.Windows.Thickness(leftMargin, topMargin, 0, 0);
                }
            }
        }
    }
}
