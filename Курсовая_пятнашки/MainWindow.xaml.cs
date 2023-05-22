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
        private DispatcherTimer timer;
        public MainWindow(int size, int theme)
        {
            timer = timer = new DispatcherTimer();
            game = new Game(size, theme);
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1); // Интервал в 1 секунду
            timer.Tick += timer_Tick;
            timer.Start();
            DispatcherTimer ani = new DispatcherTimer();
            ani.Interval = TimeSpan.FromSeconds(1); // Интервал в 1 секунду
            ani.Tick += timer_Tick;
            ani.Start();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
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

        private void timer_animation(object sender, EventArgs e)
        {
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                StartGame();
                for (int i = 0; i < game.button.GetLength(0); i++)
                {


                    for (int j = 0; j < game.button.GetLength(1); j++)
                    {
                        if (game.field[i, j] != 0)
                        {
                            game.button[i,j].Click+=buuton_click;
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
            clickedButton.sdvig(game.field, row, column);
            if (game.win() == true)
                MessageBox.Show("победа");

        }
    }
    public static class ButtonH
    {
        public static void sdvig(this Button s, int[,] mas, int i, int j)
        {
            try
            {
                double x = s.Margin.Left;
                double y = s.Margin.Top;
                switch(metod.HasNeighborZero(mas, i, j))
                {
                    case 1:
                        {
                            (mas[i - 1, j], mas[i, j]) = (mas[i, j], mas[i - 1, j]);
                            s.Margin = new Thickness(x, y - 150, 0, 0);
                        }
                        break;
                    case 2: 
                        {
                            (mas[i + 1, j], mas[i, j]) = (mas[i, j], mas[i + 1, j]);
                            s.Margin = new Thickness(x, y + 150, 0, 0);
                        }
                        break;
                    case 3:
                        {
                            (mas[i, j + 1], mas[i, j]) = (mas[i, j], mas[i, j + 1]);
                            s.Margin = new Thickness(x + 150, y, 0, 0);
                        }
                        break;
                    case 4:
                        {
                            (mas[i, j - 1], mas[i, j]) = (mas[i, j], mas[i, j - 1]);
                            s.Margin = new Thickness(x - 150, y, 0, 0);
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
