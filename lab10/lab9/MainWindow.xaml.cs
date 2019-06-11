using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace lab9
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            authList.Items.Clear();
            using (Model1 db = new Model1())
            {
                var auth = db.authors;
                foreach (authors a in auth)
                {
                    authList.Items.Add(a);
                }
            }
            selectALL();
        }
        private void selectALL()
        {
            view.Items.Clear();
            using (LibruaryContext db = new LibruaryContext())
            {
                var bok = db.books;
                foreach (book b in bok)
                {
                    view.Items.Add(b);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)//удалить
        {
            if (view.SelectedIndex > -1)
            {
                string selected = view.SelectedItem.ToString();
                using (LibruaryContext db = new LibruaryContext())
                {
                    var bok = db.books;
                    foreach (book b in bok)
                    {
                        if (b.ToString() == selected)
                            db.books.Remove(b);
                    }
                    db.SaveChanges();
                }
                selectALL();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//добавить
        {
            int sz = 0;
            int.TryParse(sizefield.Text, out sz);
            string authcode = "";
            using (Model1 db = new Model1())
            {
                var auth = db.authors;
                foreach (authors a in auth)
                {
                    if (a.ToString() == authList.SelectedValue.ToString())
                        authcode = a.authornamecode;
                }
            }
            book bk = new book(booknamefield.Text, sz, authcode);
            using (LibruaryContext db = new LibruaryContext())
            {
                db.books.Add(bk);
                db.SaveChanges();
            }
            selectALL();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)//find
        {
            string bookname = FBN.Text;
            using (LibruaryContext db = new LibruaryContext())
            {
                var b = from d in db.books where d.bookname==bookname select d;
                if (b.Count() > 0)
                {
                    foreach (book eachb in b)
                    {
                        MessageBox.Show(eachb.ToString());
                    }
                }
                else
                    MessageBox.Show("ничего не найдено");
            }            
        }
    }

    public class book
    {
        public book(string bookname, int size, string authornamecode)
        {
            this.bookname = bookname;
            this.size = size;
            this.authornamecode = authornamecode;
        }
        public book()
        { }
        public override string ToString()
        {
            string res = "ID: " + id + ", название книги: " + bookname + ", размер: " + size + ", код автора: " + authornamecode;
            return res;
        }
        public int id { get; set; }
        public string bookname { get; set; }
        public int size { get; set; }
        public string authornamecode { get; set; }
    }

    public class LibruaryContext : DbContext
    {
        public LibruaryContext() : base("DbConnection"){ }

        public DbSet<book> books { get; set; }
    }
}
