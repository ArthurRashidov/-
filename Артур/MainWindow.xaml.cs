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
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Артур
{  
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string login1 = login.Text.ToString();
            string password1 = password.Password.ToString();
            if (login1 == "Артур" && password1 == "лох")
            {
                home_page taskWindow = new home_page();
                taskWindow.Show();
                this.Close();
            }
            else
                MessageBox.Show("Неправильный пароль");
        }
    }
}