using System;
using System.Data;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Configuration;
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
using System.IO;

namespace lab8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string connectionString = @"Data Source=DESKTOP-P7C21AR\SQLEXPRESS;Initial Catalog=libruary;Integrated Security=True;User ID=user_lab8;password=password1234567";
        static SqlConnection connection = new SqlConnection(connectionString);

        public MainWindow()
        {
            InitializeComponent();
            connectdb();
            /*objgrid.ItemsSource = listbook;
            PutImageBinaryInDb(@"C:\Users\илья\Desktop\КП\sliced.png", "as");
            writeDB("as", "qw");
            disconnectdb();*/
        }

        List<book> listbook = new List<book>
        {
            new book { name="asd", size="520"},
            new book {name="qwe", size="1040"}
        };        

        static void connectdb()
        {                    
            try
            {
                // Открываем подключение
                connection.Open();
                MessageBox.Show("Подключение открыто");
                MessageBox.Show("Свойства подключения:\n\tСтрока подключения: " + connection.ConnectionString + "\n\tБаза данных: " + connection.Database + "\n\tСервер: " + connection.DataSource + "\n\tВерсия сервера: " + connection.ServerVersion + "\n\tСостояние: " + connection.State + "\n\tWorkstationld: " + connection.WorkstationId);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }          
        }   
        static void disconnectdb()
        {
            connection.Close();
            MessageBox.Show("Подключение закрыто...");
        }

        public static void writeDBBook(string bookname, int size, string authname)
        {
            try
            {
                SqlCommand cmm = new SqlCommand();
                cmm.CommandText = "insert into books (bookname, size, authornamecode) values ('asdfr', 5, (select authornamecode from authors where authorname=@name))";
                cmm.Parameters.AddWithValue("@bookname", bookname);
                cmm.Parameters.AddWithValue("@size", size);
                cmm.Parameters.AddWithValue("@name", authname);
                cmm.Connection = connection;
                int number = cmm.ExecuteNonQuery();
                MessageBox.Show("Записано " + number.ToString() + " строк");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void writeDBAuthor(string authnamecode, string authname)
        {
            if(authname.Length>3)
            {
                MessageBox.Show("DataError");
                return;
            }
            try
            {
                SqlCommand cmm = new SqlCommand();
                cmm.CommandText = "insert into authors (authornamecode, authorname) values (@authnamecode, @authname)";
                cmm.Parameters.AddWithValue("@authnamecode", authnamecode);
                cmm.Parameters.AddWithValue("@authname", authname);
                cmm.Connection = connection;
                int number = cmm.ExecuteNonQuery();
                MessageBox.Show("Записано " + number.ToString() + " строк");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void PutImageBinaryInDbAuthor(string iFile, string where)
        {
            // конвертация изображения в байты
            byte[] imageData = null;
            FileInfo fInfo = new FileInfo(iFile);
            long numBytes = fInfo.Length;
            FileStream fStream = new FileStream(iFile, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fStream);
            imageData = br.ReadBytes((int)numBytes);

            // получение расширения файла изображения не забыв удалить точку перед расширением
            string iImageExtension = (System.IO.Path.GetExtension(iFile)).Replace(".", "").ToLower();

            // запись изображения в БД
                string commandText = "update authors set photo = @screen, photo_format = @screen_format where authornamecode=@where"; // запрос на вставку
                SqlCommand command = new SqlCommand(commandText, connection);
                command.Parameters.AddWithValue("@screen", (object)imageData); // записываем само изображение
                command.Parameters.AddWithValue("@screen_format", iImageExtension); // записываем расширение изображения
                command.Parameters.AddWithValue("@where", where);
            command.ExecuteNonQuery();
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<string> authornames = new List<string>();
            SqlCommand cmm = new SqlCommand();
            cmm.CommandText = "select authorname from authors";
            cmm.Connection = connection;
            using (SqlDataReader reader = cmm.ExecuteReader())
            {
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        authornames.Add(reader.GetValue(0).ToString());
                    }
                }
            }
            int number = cmm.ExecuteNonQuery();
            Form1 f1 = new Form1(this, authornames);
            f1.Show();
        }
    }

    public class book
    {
        public string name { get; set; }
        public string size { get; set; }
        
    }
}
