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

namespace Курсовая_пятнашки
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Game game = new Game(4);
        private event Game.game StartGame;
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            StartGame += game.fill;
            StartGame += game.buttonfill;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
                StartGame();
                for (int i = 0; i < game.button.GetLength(0); i++)
                {
                   

                    for (int j = 0; j < game.button.GetLength(1); j++)
                    {
                        if (game.field[i, j] != 0)
                        {
                            MainGrid.Children.Add(game.button[i,j]);
                        }
                    }
                }

            

        }

    }
    
}
