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

namespace lab8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            connectdb();
        }

        static void connectdb()
        {
            string connectionString = @"Data Source=DESKTOP-P7C21AR\SQLEXPRESS;Initial Catalog=libruary;Integrated Security=True;User ID=user_lab8;password=password1234567";

            SqlConnection connection = new SqlConnection(connectionString);
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
            finally
            {
                // закрываем подключение
                connection.Close();
                MessageBox.Show("Подключение закрыто...");
            }            
        }        
    }
}
