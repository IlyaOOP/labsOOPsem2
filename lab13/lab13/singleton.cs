using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace lab13
{
    class singleton
    {
        private static singleton instance;

        public Rectangle r = new Rectangle();

        private singleton()
        {
            int left, top;
            Random random = new Random(DateTime.Now.Millisecond);
            left = random.Next(0, 400);
            top = random.Next(0, 500);
            r.Height = 40;
            r.Width = 40;
            r.Fill = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\илья\Desktop\OOP\labs\labsOOPsem2\lab13\lab13\n.jpg")));
            Canvas.SetLeft(r, left);
            Canvas.SetTop(r, top);
        }

        public static singleton GetInstance()
        {
            if (instance == null)
                instance = new singleton();
            return instance;
        }
    }
}
