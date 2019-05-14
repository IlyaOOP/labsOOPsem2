using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace lab7
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

        private void onClick(object sender, MouseButtonEventArgs e)
        {
            string login = fields.field1.Text;
            string password = fields.field2.Password.ToString();
            MessageBox.Show("Логин - " + login + ", Пароль - " + password);
        }

        private void Control_MouseDown(object sender, MouseButtonEventArgs e)
        {
            textBlock1.Text = textBlock1.Text + "\n" + "sender: " + sender.ToString();
            textBlock1.Text = textBlock1.Text + "\n" + "source: " + e.Source.ToString()+ "\n";
        }

        private void Control_MouseDown1(object sender, MouseButtonEventArgs e)
        {
            textBlock2.Text = textBlock2.Text + "\n" + "sender: " + sender.ToString();
            textBlock2.Text = textBlock2.Text + "\n" + "source: " + e.Source.ToString() + "\n";
        }

        private void Control_MouseDown2(object sender, MouseButtonEventArgs e)
        {
            textBlock3.Text = textBlock3.Text + "\n" + "sender: " + sender.ToString();
            textBlock3.Text = textBlock3.Text + "\n" + "source: " + e.Source.ToString() + "\n";
        }

        private void Reload_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "lab7.exe";
            Process.Start(path);
            System.Windows.Application.Current.Shutdown();
        }
    }

    public class Comm
    {
        static Comm()
        {
            Reload = new RoutedCommand("Reload", typeof(MainWindow));
        }
        public static RoutedCommand Reload { get; set; }
    }
}
