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
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;

namespace lab8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static int i = 0;
        static string connectionString = @"Data Source=DESKTOP-P7C21AR\SQLEXPRESS;Initial Catalog=libruary;Integrated Security=True;User ID=user_lab8;password=password1234567;MultipleActiveResultSets=True";
        static SqlConnection connection = new SqlConnection(connectionString); 

        public MainWindow()
        {
            InitializeComponent();
            connectdb();
            readDBauthor();
            readDBbook();
            objgrid.ItemsSource = listbook;
            authgrid.ItemsSource = listauth;
            //disconnectdb();
        }

        static List<book> listbook = new List<book>
        {
            new book {key="0", name="err", size="1111111111"},
            new book {key = "0", name="err", size="1111111111"}
        };
        static List<Author> listauth = new List<Author>
        {
            new Author { authornamecode="err", name="err"}
        };
        static List<string> images = new List<string>
        {

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

        public static void readDBauthor()
        {
            listauth.Clear();
            SqlCommand cmm = new SqlCommand();
            cmm.CommandText = "select authorname, authornamecode, photo from authors";
            cmm.Connection = connection;
            using (SqlDataReader reader = cmm.ExecuteReader())
            {
                string ext;
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        ext = GetImageBinaryFromDb(reader.GetValue(0).ToString());                        
                        listauth.Add(new Author { name = reader.GetValue(0).ToString(), authornamecode= reader.GetValue(1).ToString() });
                        images.Add(@"C:\Users\илья\Desktop\OOP\labs\labsOOPsem2\lab8\lab8\tmp\result_new"+ext);
                    }
                }
            }
            int number = cmm.ExecuteNonQuery();            
        }
        public static void readDBbook()
        {
            listbook.Clear();
            SqlCommand cmm = new SqlCommand();
            cmm.CommandText = "select id, bookname, size, (select authorname from authors where authornamecode=b.authornamecode) from books b";
            cmm.Connection = connection;
            using (SqlDataReader reader = cmm.ExecuteReader())
            {
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        listbook.Add(new book {key= reader.GetValue(0).ToString(), name = reader.GetValue(1).ToString(), size = reader.GetValue(2).ToString(), authorname = reader.GetValue(3).ToString() });
                    }
                }
            }
            int number = cmm.ExecuteNonQuery();
        }
        private static string GetImageBinaryFromDb(string param)
        {
            // получаем данные их БД
            List<byte[]> iScreen = new List<byte[]>(); // сделав запрос к БД мы получим множество строк в ответе, поэтому мы их сможем загнать в массив/List
            List<string> iScreen_format = new List<string>();
//            using (SqlConnection sqlConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=dbtest; User Id=sa; Password=pass"))
 //           {
                //connection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection;
                sqlCommand.CommandText = @"SELECT [photo], [photo_format] FROM [authors] where [authorname]=@authcode"; // наша запись в БД под id=1, поэтому в запросе "WHERE [id] = 1"
                sqlCommand.Parameters.AddWithValue("@authcode", param);
                SqlDataReader sqlReader = sqlCommand.ExecuteReader();
                byte[] iTrimByte = null;
                string iTrimText = null;
                while (sqlReader.Read()) // считываем и вносим в лист результаты
                {
                    iTrimByte = (byte[])sqlReader["photo"]; // читаем строки с изображениями
                    iScreen.Add(iTrimByte);
                    iTrimText = sqlReader["photo_format"].ToString().TrimStart().TrimEnd(); // читаем строки с форматом изображения
                    iScreen_format.Add(iTrimText);
                }
                sqlCommand.Dispose();
                sqlReader.Close();
                //connection.Close();
 //           }

            // конвертируем бинарные данные в изображение
            byte[] imageData = iScreen[0]; // возвращает массив байт из БД. Так как у нас SQL вернёт одну запись и в ней хранится нужное нам изображение, то из листа берём единственное значение с индексом '0'
            MemoryStream ms = new MemoryStream(imageData);
            System.Drawing.Image newImage = System.Drawing.Image.FromStream(ms);
            i++;
            // сохраняем изоражение на диск
            string iImageExtension = iScreen_format[0]; // получаем расширение текущего изображения хранящееся в БД
            string iImageName = @"C:\Users\илья\Desktop\OOP\labs\labsOOPsem2\lab8\lab8\tmp\result_new"+i + "." + iImageExtension; // задаём путь сохранения и имя нового изображения
            if (iImageExtension == "png") { newImage.Save(iImageName, System.Drawing.Imaging.ImageFormat.Png); }
            else if (iImageExtension == "jpg" || iImageExtension == "jpeg") { newImage.Save(iImageName, System.Drawing.Imaging.ImageFormat.Jpeg); }
            else if (iImageExtension == "gif") { newImage.Save(iImageName, System.Drawing.Imaging.ImageFormat.Gif); }
            // и т.д., можно все if заменить на одну строку "newImage.Save(iImageName)", насколько это правильно сказать не могу, но работает
            return i+"."+iImageExtension;
        }
        

        public static void writeDBBook(string bookname, int size, string authname)
        {
            try
            {
                SqlCommand cmm = new SqlCommand();
                cmm.CommandText = "insert into books (bookname, size, authornamecode) values (@bookname, @size, (select authornamecode from authors where authorname=@name))";
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
            readDBbook();
        }

        public static void writeDBAuthor(string authnamecode, string authname)
        {
            if(authnamecode.Length>3)
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
            readDBauthor();
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

        private void Authdblclc(object sender, MouseButtonEventArgs e)
        {
            int index = authgrid.SelectedIndex;
            if (images.Count > index)
            {
                photobox.Source = new BitmapImage(new Uri(images.ElementAt(index)));
            }
            else MessageBox.Show("err");
        }

        private void updateclick(object sender, RoutedEventArgs e)
        {
            objgrid.Items.Refresh();
            authgrid.Items.Refresh();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//delete author
        {
            try
            {
                Author selected;
                int index = -1;
                if (authgrid.SelectedItem != null)
                {
                    index = authgrid.SelectedIndex;
                    selected = (Author)authgrid.SelectedItem;
                    listauth.RemoveAt(index);
                    authgrid.Items.Refresh();
                }
                else
                {
                    MessageBox.Show("элемент не  выделен");
                    return;
                }
                string commandText = "delete from books where authornamecode=@code;delete from authors where authornamecode = @code";
                SqlCommand command = new SqlCommand(commandText, connection);
                command.Parameters.AddWithValue("@code", selected.authornamecode);
                MessageBox.Show("удалено " + command.ExecuteNonQuery());
            }
            catch
            {
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)//delete book
        {
            try
            {
                book selected;
                int index = -1;
                if (objgrid.SelectedItem != null)
                {
                    index = objgrid.SelectedIndex;
                    selected = (book)objgrid.SelectedItem;
                    listbook.RemoveAt(index);
                    objgrid.Items.Refresh();
                }
                else
                {
                    MessageBox.Show("элемент не  выделен");
                    return;
                }
                string commandText = "delete from books where id=@key";
                SqlCommand command = new SqlCommand(commandText, connection);
                command.Parameters.AddWithValue("@key", selected.key);
                MessageBox.Show("удалено " + command.ExecuteNonQuery());
            }
            catch
            {
            }
        }

        private void bookchanged(object sender, SelectedCellsChangedEventArgs e)
        {
            DataGrid dgr = (DataGrid)sender;
            List<string> dblist = new List<string>();
            List<string> applist = new List<string>();

            dblist.Clear();//заполнение dblist
            SqlCommand cmm = new SqlCommand();
            cmm.CommandText = "select id, bookname, size, (select authorname from authors where authornamecode=b.authornamecode) from books b";
            cmm.Connection = connection;
            using (SqlDataReader reader = cmm.ExecuteReader())
            {
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        dblist.Add( reader.GetValue(0).ToString() + reader.GetValue(1).ToString() + reader.GetValue(2).ToString() + reader.GetValue(3).ToString() );
                    }
                }
            }
            cmm.ExecuteNonQuery();

            applist.Clear();//заполнение applist
            for(int i=0; i<objgrid.Items.Count-1;i++)
            {
                applist.Add(objgrid.Items.GetItemAt(i).ToString());
            }

            IEnumerable<string> s = dblist.Except(applist);
            if (s.Count()>0)
            {
                string res="";
                string id = s.ElementAt(0).Substring(0, 4);
                book changedbook;
                foreach(var v in objgrid.Items)
                {
                    changedbook = (book)v;
                    if(changedbook.key==id)
                    {
                        int sz, iid;
                        int.TryParse(changedbook.size, out sz);
                        int.TryParse(id, out iid);
                        try
                        {
                        SqlCommand cmmd = new SqlCommand();
                            cmmd.CommandText = "update books set bookname=@bookname, size=@size where id=@id";
                            cmmd.Parameters.AddWithValue("@bookname", changedbook.name);
                            cmmd.Parameters.AddWithValue("@size", sz);
                            cmmd.Parameters.AddWithValue("@id", iid);
                            cmmd.Connection = connection;
                            cmmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        break;
                    }
                }
                
                for (int i=0;i<s.Count();i++)
                {
                    res = s.ElementAt(i);
                }
                MessageBox.Show("Изменено: " + res);
            }
        }

        private void authorchanged(object sender, SelectedCellsChangedEventArgs e)
        {
            DataGrid dgr = (DataGrid)sender;
            List<string> dblist = new List<string>();
            List<string> applist = new List<string>();

            dblist.Clear();//заполнение dblist

            SqlCommand cmm = new SqlCommand();
            cmm.CommandText = "select authorname, authornamecode from authors";
            cmm.Connection = connection;
            using (SqlDataReader reader = cmm.ExecuteReader())
            {
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        dblist.Add(reader.GetValue(1).ToString()  + "|" + reader.GetValue(0).ToString() );                        
                    }
                }
            }

            applist.Clear();//заполнение applist
            for (int i = 0; i < authgrid.Items.Count - 1; i++)
            {
                applist.Add(authgrid.Items.GetItemAt(i).ToString());
            }

            IEnumerable<string> s = dblist.Except(applist);
            if (s.Count() > 0)
            {
                string res = "";
                int ind = s.ElementAt(0).IndexOf("|");
                string id = s.ElementAt(0).Substring(0, ind);
                Author changedauthor;
                foreach (var v in authgrid.Items)
                {
                    changedauthor = (Author)v;
                    if (changedauthor.authornamecode == id)
                    {
                        try
                        {
                            SqlCommand cmmd = new SqlCommand();
                            cmmd.CommandText = "update authors set authorname=@authorname where authornamecode=@id";
                            cmmd.Parameters.AddWithValue("@authorname", changedauthor.name);
                            cmmd.Parameters.AddWithValue("@id", id);
                            cmmd.Connection = connection;
                            cmmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        break;
                    }
                }

                for (int i = 0; i < s.Count(); i++)
                {
                    res = s.ElementAt(i);
                }
                MessageBox.Show("Изменено: " + res);
                
            }
            readDBbook();
        }
    }

    public class book
    {
        public override string ToString()//return key + name + size + authorname 
        {
            string str="";
            str = key + name + size + authorname;
            return str;
        }
        public string key { get; set; }
        public string name { get; set; }
        public string size { get; set; }
        public string authorname { get; set; }
        
    }
    public class Author
    {
        public override string ToString()
        {
            string str = "";
            str += authornamecode + "|" + name;
            return str;
        }
        public string authornamecode { get; set; }
        public string name { get; set; }
    }
}
