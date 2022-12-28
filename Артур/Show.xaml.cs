using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
using System.Data;

namespace Артур
{ 
    /// <summary>
    /// Логика взаимодействия для Show.xaml
    /// </summary>
    public partial class Show : Window
    {

        private SqlConnection SqlConnection = null;
        public Show()
        {
            InitializeComponent();
            SqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
            SqlConnection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * From Students", SqlConnection);
            DataTable dt = new DataTable("Students");
            adapter.Fill(dt);
            dataGrid.ItemsSource = dt.DefaultView;
        }



        private void btn_Show_Click(object sender, RoutedEventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("Select * From Students", SqlConnection);
            DataTable dt = new DataTable("Students");
            adapter.Fill(dt);
            dataGrid.ItemsSource = dt.DefaultView;
        }
    }
}
