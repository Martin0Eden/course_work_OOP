﻿using System;
using System.Collections.Generic;
using System.Data;
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
    
    public partial class player : Window
    {
        public player()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            сolor color = new сolor("theme1");
            DataTable data1;
            data1=color.fill();
            data.ItemsSource = data1.DefaultView;

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
