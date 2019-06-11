using System;
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

namespace lab14
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

        public class RectangleNew
        {
            Random r = new Random(DateTime.Now.Millisecond);
            public Rectangle rectangle = new Rectangle();
            public RectangleNew()
            {
                rectangle.Width = 50;
                rectangle.Height = 50;
                Canvas.SetLeft(rectangle, r.Next(500));
                Canvas.SetTop(rectangle, r.Next(500));
                rectangle.Fill = Brushes.Green;

            }
            public Rectangle[] func()
            {
                return null;
            }
        }
        //Адаптер — это структурный паттерн проектирования, который позволяет объектам с несовместимыми интерфейсами работать вместе.
        class Adapter
        {
            private RectangleNew adaptee;
            public Adapter(RectangleNew rectangle)
            {
                adaptee = rectangle;
            }

            public Rectangle GetRectangle()
            {
                return adaptee.rectangle;
            }
        }

        private void AdapterClick(object sender, RoutedEventArgs e)
        {
            RectangleNew rectangleaa = new RectangleNew();
            Adapter adapter = new Adapter(rectangleaa);
            canvas.Children.Add(adapter.GetRectangle());
        }
        //-------------------------------------------
        //Декоратор(Decorator) представляет структурный шаблон проектирования, который позволяет динамически подключать к объекту
        //дополнительную функциональность.
        public class Decorator : RectangleNew
        {
            protected RectangleNew component;

            public void SetComponent(RectangleNew component)
            {
                this.component = component;
            }

            public void OperationSetColorBlack()
            {
                component.rectangle.Fill = Brushes.Black;
            }
            public Rectangle Show()
            {
                return component.rectangle;
            }
        }

        private void DecoratorClick(object sender, RoutedEventArgs e)
        {
            RectangleNew rectangle = new RectangleNew();
            Decorator decorator = new Decorator();
            decorator.SetComponent(rectangle);
            decorator.OperationSetColorBlack();
            canvas.Children.Add(decorator.Show());
        }
        //-------------------------------------------------
        //Паттерн Компоновщик(Composite) объединяет группы объектов в древовидную структуру по принципу 
        //"часть-целое и позволяет клиенту одинаково работать как с отдельными объектами, так и с группой объектов.
        abstract class Component
        {
            public string name;
            public Component(string name)
            {
                this.name = name;
            }
            public abstract List<Component> Give();
            public abstract void Add(Component c);
            public abstract void Remove(Component c);
            public abstract void print();
            }
        class Composite : Component
        {
            List<Component> children = new List<Component>();

            public Composite(string name):base(name)
            {

            }

            public override void Add(Component component)
            {
                children.Add(component);
            }

            public override void Remove(Component component)
            {
                children.Remove(component);
            }

            public override List<Component> Give()
            {
                return children;
            }

            public override void print()
            {
                string res = name+"->";
                foreach(Component ch in children)
                {
                    res += ch.name + " ";
                }
                MessageBox.Show(res);
            }
        }

        private void CompositeClick(object sender, RoutedEventArgs e)
        {
            Component root = new Composite("root");
            Component child = new Composite("child");
            root.Add(child);
            Component childChilds = new Composite("childchild");
            child.Add(childChilds);
            root.print();
            child.print();
            childChilds.print();
           
            
        }

    }
}
