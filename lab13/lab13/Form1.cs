using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab13
{
    public partial class Form1 : Form
    {
        MainWindow mw = null;
        public Form1(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            objtype.Items.Add("круг");
            objtype.Items.Add("квадрат");
            objtype.Items.Add("прямоугольник");
            objtype.SelectedIndex = 0;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            mw.objtype = objtype.SelectedItem.ToString();
            mw.objnum = (int)objnum.Value;
        }
    }
}
