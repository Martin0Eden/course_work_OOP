using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Data;

namespace Курсовая_пятнашки
{
    internal class Game: InterfaceGame
    {
        public delegate void game();
        public int size;
        public int[,] field;
        public Button[,] button;
        public int theme;
        сolor color;

        public Game(int size, int theme)
        {
            this.size = size;
            field = new int[size, size];
            button = new Button[size, size];
            this.theme = theme;
        }

        public void fill()
        {
            Random rand = new Random();
            List<int> nums = Enumerable.Range(0, size * size).ToList();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    int index = rand.Next(nums.Count);
                    if (index == size * size - 1)
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
            (this.field[size - 1, size - 1], this.field[zeroi, zeroj]) = (this.field[zeroi, zeroj], this.field[size - 1, size - 1]);
        }

        public virtual void buttonfill()
        {
            double windowSize = 650;
            double buttonMargin = 10;
            double buttonSize = (windowSize - (size + 1) * buttonMargin) / (size + 0.5);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    button[i, j] = new Button();
                    button[i, j].Content = this.field[i, j];

                    double horizontalMargin = buttonMargin + 0.3 * buttonSize + (buttonSize + buttonMargin) * j;
                    double verticalMargin = buttonMargin + 0.3 * buttonSize + (buttonSize + buttonMargin) * i;

                    button[i, j].Width = buttonSize;
                    button[i, j].Height = buttonSize;
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

        public virtual void paint()
        {
            switch (this.theme)
            {
                case 0:
                    color = new сolor("theme1");
                    break;
                case 1:
                    color = new сolor("theme2");
                    break;
                case 2:
                    color = new сolor("theme3");
                    break;
                case 3:
                    color = new сolor("theme4");
                    break;
            }
            DataTable d = color.fill();
            int k = 0;
            int n = 0;
            while (n < this.size * this.size)
            {
                for (int i = 0; i < this.button.GetLength(0); i++)
                {
                    for (int j = 0; j < this.button.GetLength(1); j++)
                    {
                        int a = (int)d.Rows[k][1];
                        int b = (int)this.field[i, j];
                    if (a == b)
                    {
                        this.button[i, j].Background = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(
                                d.Rows[k][2].ToString()));
                            this.button[i, j].Foreground = Brushes.Black;
                            k++;
                }

            }
                }
            n++;
        }
    }

        public virtual void OnVisible()
        {
            DoubleAnimation btn = new DoubleAnimation();
            btn.From = 1;
            btn.To = 0;
            btn.Duration = TimeSpan.FromSeconds(1.5);
            for (int i = 0; i < this.button.GetLength(0); i++)
            {
                for (int j = 0; j < this.button.GetLength(1); j++)
                {
                    this.button[i, j].BeginAnimation(Button.OpacityProperty, btn);
                }
            }
        }

        public static bool IsSolvable(int[,] array)
        {
            int[] flattenedArray = new int[array.Length];
            int index = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    flattenedArray[index] = array[i, j];
                    index++;
                }
            }

            int inversions = 0;

            for (int i = 0; i < flattenedArray.Length - 1; i++)
            {
                for (int j = i + 1; j < flattenedArray.Length; j++)
                {
                    if (flattenedArray[j] > 0 && flattenedArray[i] > 0 && flattenedArray[i] > flattenedArray[j])
                    {
                        inversions++;
                    }
                }
            }
            return inversions % 2 == 0;
        }

    }
}
