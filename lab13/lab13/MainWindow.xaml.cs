using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace lab13
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string objtype;
        public int objnum;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Form1 f1 = new Form1(this);
            f1.Show();
            f1.FormClosed += F1_FormClosed;
        }

        private void F1_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {            
            for (int i=0; i<objnum; i++)
            {                
                switch(objtype)
                {
                    case "круг":
                        CircleFactory cf = new CircleFactory();
                        drawCircle crc = (drawCircle)cf.makeShape();
                        crc.e.MouseDown += circleclick;
                        canvas.Children.Add(crc.e);
                        Thread.Sleep(2);
                        break;
                    case "квадрат":                        
                        QuadFactory qf = new QuadFactory();
                        drawQuad qd = (drawQuad)qf.makeShape();
                        canvas.Children.Add(qd.r);
                        Thread.Sleep(2);
                        break;
                    case "прямоугольник":
                        RectFactory rf = new RectFactory();
                        drawRect rct = (drawRect)rf.makeShape();
                        canvas.Children.Add(rct.r);
                        Thread.Sleep(2);
                        break;
                }
            }
        }

        private void circleclick(object sender, MouseButtonEventArgs e)
        {
            Ellipse se = (Ellipse)sender;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                singleton sng = singleton.GetInstance();
                canvas.Children.Add(sng.r);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }        

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                builder builder = new ConcreteBuilder();
                Director dir = new Director(builder);

                dir.Construct((bool)checkcircle.IsChecked, (bool)checkquad.IsChecked, (bool)checkrecct.IsChecked);
                Product prod = builder.GetResult();
                int left, top;
                Random random = new Random(DateTime.Now.Millisecond);
                left = random.Next(0, 400);
                top = random.Next(0, 500);
                foreach (UIElement el in prod.prod)
                {
                    if(el is Ellipse)
                    {
                        Ellipse ellipse = (Ellipse)el;
                        ellipse.Fill= new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
                        Canvas.SetLeft(ellipse, left);
                        Canvas.SetTop(ellipse, top);
                        canvas.Children.Add(ellipse);
                    }
                    else if(el is Rectangle)
                    {
                        Rectangle rectang = (Rectangle)el;
                        rectang.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
                        Canvas.SetLeft(rectang, left);
                        Canvas.SetTop(rectang, top);
                        canvas.Children.Add(rectang);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
