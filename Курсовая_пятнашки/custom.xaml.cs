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
    /// <summary>
    /// Логика взаимодействия для custom.xaml
    /// </summary>
    public partial class custom : Window
    {
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
    }
}
