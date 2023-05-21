using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            button = new Button[size, size];
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
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (this.field[i, j] != 0)
                    {
                        button[i, j] = new Button();
                        button[i, j].Content = this.field[i, j];

                        double horizontalMargin = 50 + 150 * j;
                        double verticalMargin = 50 + 150 * i;

                        button[i, j].HorizontalAlignment = HorizontalAlignment.Left;
                        button[i, j].VerticalAlignment = VerticalAlignment.Top;
                        button[i, j].Margin = new Thickness(horizontalMargin, verticalMargin, 0, 0);
                        Style buttonStyle = (Style)Application.Current.Resources["button"];
                        if (buttonStyle != null)
                        {
                            button[i, j].Style = buttonStyle;
                        }
                    }
                }
            }
        }

        public bool win()
        {
            int expectedNumber = 1;

            for (int i = 0; i < this.field.GetLength(0); i++)
            {
                for (int j = 0; j < this.field.GetLength(1); j++)
                {
                    int currentNumber = this.field[i, j];
                    if (currentNumber != expectedNumber)
                    {
                        if (this.field[i, j] != 0 || expectedNumber != this.field.GetLength(0) * this.field.GetLength(1))
                            return false;
                    }
                    expectedNumber++;
                }
            }

            return true;
        }
    }
}
