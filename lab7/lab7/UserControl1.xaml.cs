using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
    }

    public class Reg:DependencyObject
    {
        public static readonly DependencyProperty loginProperty;
        
        static Reg()
        {
            FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata();
            loginProperty = DependencyProperty.Register("Login", typeof(string), typeof(Reg));
        }
        private static bool ValidateValue(object value)
        {
            Regex regex = new Regex(@"A-Z");
            string currentValue = (string)value;
            if (regex.IsMatch(currentValue))
                return true;
            return false;
        }
        
        public string Login
        {
            get { return (string)GetValue(loginProperty); }
            set { SetValue(loginProperty, value); }
        }
    }
}
