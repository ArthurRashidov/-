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


namespace Артур
{ 
    /// <summary>
    /// Логика взаимодействия для input.xaml
    /// </summary>
    public partial class home_page : Window
    {
        public home_page()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Show win = new Show();
            win.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Insert win = new Insert();
            win.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Print win = new Print();
            win.Show();
        }

        //private void Button_Click_3(object sender, RoutedEventArgs e)
        //{
        //    Game win = new Game();
        //    win.Show();
        //}
    }
}
