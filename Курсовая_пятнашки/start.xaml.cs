﻿using System;
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
using System.Xml.Linq;

namespace Курсовая_пятнашки
{
    public partial class start : Window
    {
        public start()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        int a;
        int t = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (anime.IsChecked == true)
            {
                a = 0;
            }
            else a = 1;

            if (theme1.IsChecked == true) t = 0;
            if (theme2.IsChecked == true) t = 1;
            if (theme3.IsChecked == true) t = 2;
            MainWindow mainWindow = new MainWindow(4,t,a);
            this.Visibility = Visibility.Collapsed;
            mainWindow.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (anime.IsChecked == true)
            {
                a = 0;
            }
            else a = 1;

            if (theme1.IsChecked == true) t = 0;
            if (theme2.IsChecked == true) t = 1;
            if (theme3.IsChecked == true) t = 2;
            MainWindow mainWindow = new MainWindow(3, t, a);
            this.Visibility = Visibility.Collapsed;
            mainWindow.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (anime.IsChecked == true)
            {
                a = 0;
            }
            else a = 1;

            if (theme1.IsChecked == true) t = 0;
            if (theme2.IsChecked == true) t = 1;
            if (theme3.IsChecked == true) t = 2;
            MainWindow mainWindow = new MainWindow(5, t, a);
            this.Visibility = Visibility.Collapsed;
            mainWindow.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            player player = new player();
            player.Show();
        }

        private void theme1_Checked(object sender, RoutedEventArgs e)
        {
            сolor.cmena("#dda800",three,four,five,lider);
        }

        private void theme2_Checked(object sender, RoutedEventArgs e)
        {
            сolor.cmena("#7d0f70", three, four, five, lider);
        }

        private void theme3_Checked(object sender, RoutedEventArgs e)
        {
            сolor.cmena("#85cd23", three, four, five, lider);
        }
        private void theme4_Checked(object sender, RoutedEventArgs e)
        {
            сolor.cmena("#85cd23", three, four, five, lider);
        }
    }
}
