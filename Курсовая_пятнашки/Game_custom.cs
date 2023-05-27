using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;

namespace Курсовая_пятнашки
{
    internal class Game_custom:Game
    {
        public BitmapSource[,] BitmapSources;

        public Game_custom(int size, int theme):base(size,theme)
        { }

        public Game_custom(int size, int theme, BitmapSource[,] BitmapSources) : base(size, theme)
        { 
            this.BitmapSources = BitmapSources;
        }

        public static BitmapSource[,] SplitImage(BitmapSource image, int size)
        {
            int targetWidth = 420;
            int targetHeight = 420;

            Transform transform = new ScaleTransform(targetWidth / image.PixelWidth, targetHeight / image.PixelHeight);
            TransformedBitmap scaledImage = new TransformedBitmap(image, transform);

            BitmapSource[,] imageParts = new BitmapSource[size, size];

            int partWidth = scaledImage.PixelWidth / size;
            int partHeight = scaledImage.PixelHeight / size;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Int32Rect partRect = new Int32Rect(j * partWidth, i * partHeight, partWidth, partHeight);
                    CroppedBitmap croppedBitmap = new CroppedBitmap(scaledImage, partRect);
                    imageParts[i, j] = croppedBitmap;
                }
            }

            return imageParts;
        }

        public override void buttonfill()
        {
            double windowSize = 650;
            double buttonMargin = 10;
            double buttonSize = (windowSize - (size + 1) * buttonMargin) / (size + 0.5);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    button[i, j] = new Button();
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
                    button[i, j].Background = new ImageBrush(this.BitmapSources[i, j]);
                }
            }
        }

    }
}
