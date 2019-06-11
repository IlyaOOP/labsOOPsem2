using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace lab13
{
    interface shape
    {
        void DrawShape();
        UIElement clone();
    }
    class drawCircle : shape
    {
        public Ellipse e = new Ellipse();
        public drawCircle()
        {
            DrawShape();
        }

        public UIElement clone()
        {
            Ellipse ce = new Ellipse();
            ce.Width = e.Width;
            ce.Height = e.Height;
            ce.Fill = e.Fill;
            return ce;
        }

        public void DrawShape()
        {
            int left, top;
            Random random = new Random(DateTime.Now.Millisecond);
            left = random.Next(0,400);
            top = random.Next(0,500);            
            e.Height = 30;
            e.Width = 30;
            e.Fill = new SolidColorBrush(Color.FromArgb(255, 15, 46, 200));
            Canvas.SetLeft(e, left);
            Canvas.SetTop(e, top);
        }
    }
    class drawQuad : shape
    {
        public Rectangle r = new Rectangle();
        public drawQuad()
        {
            DrawShape();
        }

        public UIElement clone()
        {
            Rectangle re = new Rectangle();
            re.Width = r.Width;
            re.Height = r.Height;
            re.Fill = r.Fill;
            return re;
        }

        public void DrawShape()
        {
            int left, top;
            Random random = new Random(DateTime.Now.Millisecond);
            left = random.Next(0,400);
            top = random.Next(0,500);
            r.Height = 20;
            r.Width = 20;
            r.Fill = new SolidColorBrush(Color.FromArgb(255, 200, 46, 15));
            Canvas.SetLeft(r, left);
            Canvas.SetTop(r, top);
        }
    }
    class drawRect : shape
    {
        public Rectangle r = new Rectangle();
        public drawRect()
        {
            DrawShape();
        }

        public UIElement clone()
        {
            Rectangle re = new Rectangle();
            re.Width = r.Width;
            re.Height = r.Height;
            re.Fill = r.Fill;
            return re;
        }

        public void DrawShape()
        {
            int left, top;
            Random random = new Random(DateTime.Now.Millisecond);
            left = random.Next(0, 400);
            top = random.Next(0, 500);
            r.Height = 10;
            r.Width =40;
            r.Fill = new SolidColorBrush(Color.FromArgb(255, 250, 46, 105));
            Canvas.SetLeft(r, left);
            Canvas.SetTop(r, top);
        }
    }

    interface abstractShapesFactory
    {
        object makeShape();
    }
    class CircleFactory : abstractShapesFactory
    {
        public object makeShape()
        {
            return new drawCircle();
        }
    }
    class QuadFactory : abstractShapesFactory
    {
        public object makeShape()
        {
            return new drawQuad();
        }
    }
    class RectFactory : abstractShapesFactory
    {
        public object makeShape()
        {
            return new drawRect();
        }
    }
}
