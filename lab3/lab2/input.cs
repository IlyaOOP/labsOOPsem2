using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2
{
    
    public partial class input : Form
    {
        DataGridView datagrid;
        data dat;
        public E_library main;
        public input(string str, DataGridView dgrid, data dat, E_library main)
        {
            this.main = main;
            datagrid = dgrid;
            this.dat = dat;
            InitializeComponent();
            label1.Text = str;
            if (label1.Text== "Введите диапазон страниц")
            {
                textBox1.Visible = false;
                numericUpDown1.Visible = true;
                numericUpDown2.Visible = true;
                checkBox1.Visible = false;
            }  
            else if(label1.Text == "Введите год издания")
            {
                checkBox1.Text = "диапазон лет";
            }
        }

        private void input_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch(label1.Text)
            {
                case "Введите издательство":
                    finder.findbypubl(textBox1.Text, checkBox1.Checked, datagrid, dat, main);
                    break;
                case "Введите год издания":
                    finder.findbyyear(textBox1.Text, datagrid, dat, main);
                    break;
                case "Введите диапазон лет":
                    finder.findbydiapyear((int)numericUpDown1.Value, (int)numericUpDown2.Value, datagrid, dat, main);
                    break;
                case "Введите диапазон страниц":                    
                    finder.findbydiappages((int)numericUpDown1.Value, (int)numericUpDown2.Value, datagrid, dat, main);
                    break;
            }
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked==true&& label1.Text== "Введите год издания")
            {
                label1.Text = "Введите диапазон лет";
                textBox1.Visible = false;
                numericUpDown1.Visible = true;
                numericUpDown2.Visible = true;
            }
            else if(checkBox1.Checked == false && label1.Text == "Введите диапазон лет")
            {
                label1.Text = "Введите год издания";
                textBox1.Visible = true;
                numericUpDown1.Visible = false;
                numericUpDown2.Visible = false;
            }

        }
    }
    static class finder
    {
        public static void findbypubl(string value, bool ispart, DataGridView datagrid, data dat, E_library main)
        {
            Regex regexp = new Regex(@"\w*"+value+@"\w*");
            data finddata = new data();
            if (ispart==false) 
            {
                foreach (Library lb in dat.lbr)
                {
                    if (lb.publ == value)
                        ObjArr.Add(lb, datagrid, finddata);
                }
            }
            else
            {
                foreach (Library lb in dat.lbr)
                {
                    if (/*Regex.IsMatch(lb.publ, value)*/regexp.Matches(lb.publ).Count!=0)
                        ObjArr.Add(lb, datagrid, finddata);
                }
            }
            main.findresult = finddata;
        }
        public static void findbyyear(string value, DataGridView datagrid, data dat, E_library main)
        {
            int val;
            data finddata = new data();
            if (Int32.TryParse(value, out val) == true&&val>0)
            {
                foreach (Library lb in dat.lbr)
                {
                    if (lb.year == val)
                        ObjArr.Add(lb, datagrid, finddata);
                }
                main.findresult = finddata;
            }
            else
                MessageBox.Show("Ошибка. Введено не число");
        }
        public static void findbydiapyear(int firstpos, int secpos, DataGridView datagrid, data dat, E_library main)//complete
        {
            data finddata = new data();
            int start;
            int stop;
            if(firstpos>secpos)
            {
                start = secpos;
                stop = firstpos;
            }
            else
            {
                start = firstpos;
                stop = secpos;
            }
            foreach (Library lb in dat.lbr)
            {
                if (lb.year >= start && lb.year<=stop)
                    ObjArr.Add(lb, datagrid, finddata);
            }
            main.findresult = finddata;
        }
        public static void findbydiappages(int firstpos, int secpos, DataGridView datagrid, data dat, E_library main)//complete
        {
            data finddata = new data();
            int start;
            int stop;
            if (firstpos > secpos)
            {
                start = secpos;
                stop = firstpos;
            }
            else
            {
                start = firstpos;
                stop = secpos;
            }
            foreach (Library lb in dat.lbr)
            {
                if (lb.count_of_pages >= start && lb.count_of_pages <= stop)
                    ObjArr.Add(lb, datagrid, finddata);
            }
            main.findresult = finddata;
        }
    }

}
