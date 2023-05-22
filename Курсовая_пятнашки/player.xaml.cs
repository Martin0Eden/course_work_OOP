using System;
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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            сolor color = new сolor("color");
            color.type = "theme1";
            DataTable data1 = new DataTable();
            data1=color.fill();
            data.ItemsSource = data1.DefaultView;

        }
    }
}
