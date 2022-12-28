using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для Insert.xaml
    /// </summary>
    public partial class Insert : Window
    {
        private SqlConnection SqlConnection = null;
        public Insert()
        {
            InitializeComponent();
            SqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);

            SqlConnection.Open();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Regex re = new Regex("[a-zA-Zа-яА-Я]+");
            if ((string.IsNullOrEmpty(textBox1.Text)) || ((string.IsNullOrEmpty(textBox2.Text))) || ((string.IsNullOrEmpty(textBox3.Text))) || ((string.IsNullOrEmpty(date.Text))) || ((string.IsNullOrEmpty(textBox5.Text))) || ((string.IsNullOrEmpty(textBox6.Text))) || ((string.IsNullOrEmpty(sex.Text))) || ((string.IsNullOrEmpty(number.Text))) || ((string.IsNullOrEmpty(mail.Text)))) MessageBox.Show("Данные не введены");
            else
            {
                if (!re.IsMatch(textBox1.Text) || !re.IsMatch(textBox2.Text) || !re.IsMatch(textBox3.Text)) MessageBox.Show("Введите корректные данные");
                else
                {
                    SqlCommand command = new SqlCommand($"INSERT INTO [Students] (Name, Surname, Patronymic, Birthday, Birthplace, Place_of_living, Sex, Phone, Email) VALUES (N'{textBox1.Text}', N'{textBox2.Text}', N'{textBox3.Text}', '{date.Text}', N'{textBox5.Text}', N'{textBox6.Text}', N'{sex.Text}', N'{number.Text}', N'{mail.Text}')", SqlConnection);
                    int a = command.ExecuteNonQuery();
                    if (a > 0)
                    {
                        MessageBox.Show("Данные записаны");
                    }
                }
            }
        }

        private void textBox1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex re = new Regex("[a-zA-Zа-яА-Я]+");
            if (!re.IsMatch(e.Text))
            {
                textBox1.BorderBrush = Brushes.Red;
            }
        }

        private void textBox2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex re = new Regex("[a-zA-Zа-яА-Я]+");
            if (!re.IsMatch(e.Text))
            {
                textBox2.BorderBrush = Brushes.Red;
            }
        }

        private void textBox3_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex re = new Regex("[a-zA-Zа-яА-Я]+");
            if (!re.IsMatch(e.Text))
            {
                textBox3.BorderBrush = Brushes.Red;
            }
        }

        private void textBox8_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex re = new Regex("[a-zA-Zа-яА-Я]+");
            if (re.IsMatch(e.Text))
            {
                number.BorderBrush = Brushes.Red;
            }
        }

        

        
    }
}
