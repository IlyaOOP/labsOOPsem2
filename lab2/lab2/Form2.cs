using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2
{
    public partial class Информация : Form
    {
        public Информация(string data)
        {
            InitializeComponent();
            outputInfo.Text = data;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
