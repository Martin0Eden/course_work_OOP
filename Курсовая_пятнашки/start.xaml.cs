using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Курсовая_пятнашки
{
    public partial class start : Window
    {
        public start()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        int t = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (theme1.IsChecked == true)t = 0;
            if(theme2.IsChecked == true) t = 1;
            if(theme3.IsChecked == true)t = 2;

            MainWindow mainWindow = new MainWindow(4,t);
            mainWindow.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (theme1.IsChecked == true) t = 0;
            if (theme2.IsChecked == true) t = 1;
            if (theme3.IsChecked == true) t = 2;
            MainWindow mainWindow = new MainWindow(3, t);
            mainWindow.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (theme1.IsChecked == true) t = 0;
            if (theme2.IsChecked == true) t = 1;
            if (theme3.IsChecked == true) t = 2;
            MainWindow mainWindow = new MainWindow(5, t);
            mainWindow.Show();
        }
    }
}
