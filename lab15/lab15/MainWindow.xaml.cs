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

namespace lab15
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int[] coord = new int[2] { 0, 0 };
        Ellipse pl = new Ellipse();

        public MainWindow()
        {
            InitializeComponent();            
            pl.Name = "player";
            SolidColorBrush br = new SolidColorBrush();
            br.Color = Color.FromRgb(200, 20, 200);
            pl.Fill = br;
            pl.Height = 20;
            pl.Width = 20;
            Canvas.SetLeft(pl, 10);
            Canvas.SetTop(pl, 10);
            canvas.Children.Add(pl);
        }

        public class Player
        {
            public IPlayerState State { get; set; }

            public Player(IPlayerState ps)
            {
                State = ps;
            }

            public int[] changeState(commands.ICommand cmd,int[] c, KeyEventArgs key)
            {
                if (key.Key == Key.A)
                {                    
                    LeftState s = new LeftState();
                    s.changeState(cmd, c);
                }
                else if (key.Key == Key.D)
                {
                    RightState s = new RightState();
                    s.changeState(cmd, c);
                }
                else if (key.Key == Key.S)
                {
                    DownState s = new DownState();
                    s.changeState(cmd, c);
                }
                else if (key.Key == Key.W)
                {
                    UpState s = new UpState();
                    s.changeState(cmd, c);
                }
                return State.changeState(cmd, c);
            }
        };

        private void pressed(object sender, KeyEventArgs e)
        {            
            Player p = new Player(new UpState());
            commands.LeftCommand cLeft;
            commands.RightCommand cRight;
            commands.DownCommand cDown;
            commands.UpCommand cUp;
                if (e.Key == Key.A)
                {
                    currentstate.Text = "влево";
                    cLeft = new commands.LeftCommand();
                    coord = p.changeState(cLeft, coord, e);
                }
                else if (e.Key == Key.D)
                {
                    currentstate.Text = "вправо";
                    cRight = new commands.RightCommand();
                    coord = p.changeState(cRight, coord, e);
                }
                else if (e.Key == Key.S)
                {
                    currentstate.Text = "вниз";
                    cDown = new commands.DownCommand();
                    coord = p.changeState(cDown, coord, e);
                }
                else if (e.Key == Key.W)
                {
                    currentstate.Text = "вверх";
                    cUp = new commands.UpCommand();
                    coord = p.changeState(cUp, coord, e);
                }
                Canvas.SetLeft(pl, coord[0]);
                Canvas.SetTop(pl, coord[1]);
                canvas.Children.RemoveAt(0);
                canvas.Children.Add(pl);                
        }
    }
}
