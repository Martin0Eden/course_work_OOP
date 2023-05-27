using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using static Курсовая_пятнашки.Game;
using System.Xml.Linq;

namespace Курсовая_пятнашки
{
    
    public partial class MainWindow_Сustom : Window
    {
        private int minutes;
        private int seconds;
        Game_custom game_Custom;
        private DispatcherTimer Timer;
        public MainWindow_Сustom(BitmapSource[,] imageParts,int size)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Timer = new DispatcherTimer();
            Timer = new DispatcherTimer();
            Timer.Interval = TimeSpan.FromSeconds(1);
            Timer.Tick += timer_Tick;
            Timer.Start();
            game_Custom = new Game_custom(size,0, imageParts);
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                do
                {
                    game_Custom.fill();
                    game_Custom.buttonfill();
                   /* StartGame();*/
                }
                while (Game.IsSolvable(game_Custom.field) == true);

                for (int i = 0; i < game_Custom.BitmapSources.GetLength(0); i++)
                {


                    for (int j = 0; j < game_Custom.BitmapSources.GetLength(1); j++)
                    {
                        if (game_Custom.field[i, j] != 0)
                        {
                            /*game_Custom.button[i, j].Click += buuton_click;*/
                            brid.Children.Add(game_Custom.button[i, j]);
                        }
                    }
                }


            }
            catch (Exception ex) { }
        }
    }
}
