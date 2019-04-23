using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab8
{
    public partial class Form1 : Form
    {
        string filename;
        List<string> authornames;
        MainWindow mw;
        public Form1(MainWindow mw, List<string> authnames)
        {
            this.mw = mw;
            authornames = authnames;
            InitializeComponent();
            foreach(string st in authornames)
            {
                comboFIO.Items.Add(st);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            filename = openFileDialog1.FileName;
            // читаем файл в строку
            
        }

        private void addauthbut_Click(object sender, EventArgs e)
        {
            string authnamecode="";
            string authname="";
            string file = filename;
            
            authnamecode = authorcode.Text;
            if(authnamecode=="")
            {
                MessageBox.Show("Error.Поле *код автора* не может быть пустым");
                return;
            }
            authname = authornamemain.Text;
            if(authname == "")
            {
                authname = "NULL";
            }
            MainWindow.writeDBAuthor(authnamecode, authname);
            if (file == null || file == "")
            {
                file = "NULL";
            }
            else
            {
                MainWindow.PutImageBinaryInDbAuthor(file, authnamecode);
            }
        }
    }
}
