using Microsoft.Win32;
using System;
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
using System.Windows.Shapes;

namespace Курсовая_пятнашки
{
    public partial class custom : Window
    {
        BitmapImage bitmap;
        int size = 4;
        public custom()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void close_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void nazad_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            start player = new start();
            this.Visibility = Visibility.Collapsed;
            player.ShowDialog();
        }

        private void dobavlenie(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string imagePath = openFileDialog.FileName;
                bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(imagePath);
                bitmap.EndInit();
                label_img.Content = "изображение добавленно";

            }
        }

        private void startgame_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (theme1.IsChecked == true) size = 3;
                if (theme2.IsChecked == true) size = 4;
                if (theme3.IsChecked == true) size = 5;

                BitmapSource bitmapSource = (BitmapSource)bitmap;
                BitmapSource[,] imageParts = Game_custom.SplitImage(bitmapSource, size);

                if (imageParts != null)
                {
                    MainWindow_Сustom mainWindow_Custom = new MainWindow_Сustom(imageParts);
                    this.Visibility = Visibility.Collapsed;
                    mainWindow_Custom.ShowDialog();
                }
            }
            catch
            {
                MessageBox.Show("файл не выбран");

            }
        }
    }
}
