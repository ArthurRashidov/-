using System.Windows;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Windows.Controls;
using Word = Microsoft.Office.Interop.Word;
using System.Configuration;

namespace Артур
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Print : Window
    {
        Word._Application oWord = new Word.Application();
        object oMissing = System.Reflection.Missing.Value;
        private SqlConnection SqlConnection = null;
        public Print()
        { 
            InitializeComponent();
            SqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
            SqlConnection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * From Students", SqlConnection);
            DataTable dt = new DataTable("Students");
            adapter.Fill(dt);
            dataGrid1.ItemsSource = dt.DefaultView;
        }
        private void btn_Show_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
            SqlConnection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * From Students", SqlConnection);
            DataTable dt = new DataTable("Students");
            adapter.Fill(dt);
            dataGrid1.ItemsSource = dt.DefaultView;
        }


        private void Window1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            oWord.Quit();
        }

        private void SetTemplate(Word._Document oDoc)
        {
            TextBox textBox1 = new TextBox();
            TextBox textBox2 = new TextBox();
            TextBox textBox3 = new TextBox();
            TextBox textBox4 = new TextBox();
            TextBox textBox5 = new TextBox();
            TextBox textBox6 = new TextBox();
            textBox2.Text = ((DataRowView)dataGrid1.SelectedItem).Row[1].ToString();
            textBox3.Text = ((DataRowView)dataGrid1.SelectedItem).Row[2].ToString();
            textBox4.Text = ((DataRowView)dataGrid1.SelectedItem).Row[3].ToString();
            textBox5.Text = ((DataRowView)dataGrid1.SelectedItem).Row[4].ToString();
            textBox6.Text = ((DataRowView)dataGrid1.SelectedItem).Row[5].ToString();
            object oBookMark1 = "Фамилия";
            oDoc.Bookmarks.get_Item(ref oBookMark1).Range.Text = textBox3.Text;
            object oBookMark2 = "Имя";
            oDoc.Bookmarks.get_Item(ref oBookMark2).Range.Text = textBox2.Text;
            object oBookMark = "Отчество";
            oDoc.Bookmarks.get_Item(ref oBookMark).Range.Text = textBox4.Text;
            object oBookMark3 = "Год_рождения";
            oDoc.Bookmarks.get_Item(ref oBookMark3).Range.Text = textBox5.Text;
            object oBookMark5 = "Адрес";
            oDoc.Bookmarks.get_Item(ref oBookMark5).Range.Text = textBox6.Text;

        }
        private Word._Document GetDoc(string path)
        {
            Word._Document oDoc = oWord.Documents.Add(path);
            SetTemplate(oDoc);
            return oDoc;
        }

        private void bntExport_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog print = new PrintDialog();
            if (print.ShowDialog() == true)
            {
                Word._Document oDoc = GetDoc(Environment.CurrentDirectory + "\\Шаблон1.dotx");
                oDoc.SaveAs(FileName: Environment.CurrentDirectory + "\\Отчет.docx");
                oDoc.Close();
            }
            MessageBox.Show("Документ готов");
            oWord.Quit();
            Close();
        }
    }
}
