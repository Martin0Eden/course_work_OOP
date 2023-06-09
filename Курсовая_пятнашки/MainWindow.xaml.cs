﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Windows.Media.Animation;

namespace Курсовая_пятнашки
{

    public partial class MainWindow : Window
    {
        Game game;
        private event Game.game StartGame;
        private int minutes;
        private int seconds;
        private DispatcherTimer Timer;
        int anime;
        int theme1;
        int size1;
        TimeSpan time = TimeSpan.Parse("00:00:00");
        public MainWindow(int size, int theme, int a)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            anime = a;
            theme1 = theme;
            size1= size;
            Timer = new DispatcherTimer();
            game = new Game(size, theme);
            Timer = new DispatcherTimer();
            Timer.Interval = TimeSpan.FromSeconds(1); 
            Timer.Tick += timer_Tick;
            Timer.Start();
            StartGame += game.fill;
            StartGame += game.buttonfill;
            StartGame += game.paint;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            seconds++;
            if (seconds == 60)
            {
                minutes++;
                seconds = 0;
            }

            timerLabel.Content = $"{minutes:D2}:{seconds:D2}";
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                do
                {
                    StartGame();
                }
                while (Game.IsSolvable(game.field) == true);

                for (int i = 0; i < game.button.GetLength(0); i++)
                    {


                        for (int j = 0; j < game.button.GetLength(1); j++)
                        {
                            if (game.field[i, j] != 0)
                            {
                                game.button[i, j].Click += buuton_click;
                                MainGrid.Children.Add(game.button[i, j]);
                            }
                        }
                    }
                

            }
            catch (Exception ex) { }
        }

        private void buuton_click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            int row = 0;
            int column = 0;
            clickedButton.serch(game.field, ref row, ref column);
            if (anime == 1)
            {
                clickedButton.Sdvig(game.field, row, column);
            }
            else
            {
                clickedButton.SdvigAmi(game.field, row, column);
            }
            if (game.win() == true)
            {
                game.OnVisible();
                metod.onbut(restard, win);
                time = TimeSpan.Parse($"00:{timerLabel.Content}");
                lider lider = new lider("player","user",$"{game.size}:{game.size}", time);;
                lider.ExecuteInsertQuery();
                Lider.Click += Button_Click_3;
                restard.Click += restarding;
                Timer.Stop();
            }

        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            player player = new player();
            this.Visibility = Visibility.Collapsed;
            player.ShowDialog();
        }

        private void restarding(object sender, RoutedEventArgs e)
        {
            this.Visibility= Visibility.Collapsed;
            MainWindow mainWindow = new MainWindow(size1,theme1,anime);
            mainWindow.Show();

        }
    }
    public static class ButtonH
    {
        public static void Sdvig(this Button s, int[,] mas, int i, int j)
        {
            double x = s.Margin.Left;
            double y = s.Margin.Top;
            double shift = s.Width + 10;

            switch (metod.HasNeighborZero(mas, i, j))
            {
                case 1:
                    {
                        (mas[i - 1, j], mas[i, j]) = (mas[i, j], mas[i - 1, j]);
                        s.Margin = new Thickness(x, y - shift, 0, 0);
                    }
                    break;
                case 2:
                    {
                        (mas[i + 1, j], mas[i, j]) = (mas[i, j], mas[i + 1, j]);
                        s.Margin = new Thickness(x, y + shift, 0, 0);
                    }
                    break;
                case 3:
                    {
                        (mas[i, j + 1], mas[i, j]) = (mas[i, j], mas[i, j + 1]);
                        s.Margin = new Thickness(x + shift, y, 0, 0);
                    }
                    break;
                case 4:
                    {
                        (mas[i, j - 1], mas[i, j]) = (mas[i, j], mas[i, j - 1]);
                        s.Margin = new Thickness(x - shift, y, 0, 0);
                    }
                    break;
            }
        }


        public static void SdvigAmi(this Button s, int[,] mas, int i, int j)
        {
            try
            {
                
                double x = s.Margin.Left;
                double y = s.Margin.Top;
                double shift = s.Width + 10;
                ThicknessAnimation btn = new ThicknessAnimation();
                btn.Duration = TimeSpan.FromSeconds(0.2);

                switch (metod.HasNeighborZero(mas, i, j))
                {
                    case 1:
                        {
                            (mas[i - 1, j], mas[i, j]) = (mas[i, j], mas[i - 1, j]);
                            btn.From = s.Margin;
                            btn.To = new Thickness(s.Margin.Left, s.Margin.Top - shift, s.Margin.Right, s.Margin.Bottom);

                            s.BeginAnimation(Button.MarginProperty, btn);
                        }
                        break;
                    case 2:
                        {
                            (mas[i + 1, j], mas[i, j]) = (mas[i, j], mas[i + 1, j]);
                            btn.From = s.Margin;
                            btn.To = new Thickness(s.Margin.Left, s.Margin.Top + shift, s.Margin.Right, s.Margin.Bottom);

                            s.BeginAnimation(Button.MarginProperty, btn);

                        }
                        break;
                    case 3:
                        {
                            (mas[i, j + 1], mas[i, j]) = (mas[i, j], mas[i, j + 1]);
                            btn.From = s.Margin;
                            btn.To = new Thickness(s.Margin.Left+shift, s.Margin.Top, s.Margin.Right, s.Margin.Bottom);

                            s.BeginAnimation(Button.MarginProperty, btn);
                        }
                        break;
                    case 4:
                        {
                            (mas[i, j - 1], mas[i, j]) = (mas[i, j], mas[i, j - 1]);
                            btn.From = s.Margin;
                            btn.To = new Thickness(s.Margin.Left-shift, s.Margin.Top, s.Margin.Right, s.Margin.Bottom);
                            s.BeginAnimation(Button.MarginProperty, btn);
                        }
                        break;
                }
            }
            catch { }
        }




        public static void serch(this Button s, int[,] mas, ref int i, ref int j)
        {
            for (int i1 = 0; i1 < mas.GetLength(0); i1++)
                for (int j1 = 0; j1 < mas.GetLength(1); j1++)
                    if (mas[i1, j1].ToString() == s.Content.ToString())
                    {
                        i = i1;
                        j = j1;
                    }
        }
    }

}
