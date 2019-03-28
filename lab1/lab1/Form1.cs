using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1
{
    public partial class Form1 : Form
    {
        string binvalue;
        int datatype=1;//1-bin2-oct3-dec4-hex
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void Button1_Click(object sender, EventArgs e)//bin
        {            
            if (datatype==1)
                binvalue = textBox1.Text;
            textBox1.Text = binvalue;
            datatype = 1;
        }
        private void button2_Click(object sender, EventArgs e)//oct
        {
            if (textBox1.Text.Contains("&") | textBox1.Text.Contains("|") | textBox1.Text.Contains("^") | textBox1.Text.Contains("~"))
            {
                MessageBox.Show("Введено выражение!");
                return;
            }
            if (datatype == 1)
            {
                binvalue = textBox1.Text;
                textBox1.Text = Calculator.binTOoct(textBox1.Text);
            }
            else
            {
                textBox1.Text = Calculator.binTOoct(binvalue);
            }
            datatype = 2;
        }

        private void button3_Click(object sender, EventArgs e)//dec
        {
            if (textBox1.Text.Contains("&") | textBox1.Text.Contains("|") | textBox1.Text.Contains("^") | textBox1.Text.Contains("~"))
            {
                MessageBox.Show("Введено выражение!");
                return;
            }
            if (datatype == 1)
            {
                binvalue = textBox1.Text;
                textBox1.Text = Calculator.binTOdec(textBox1.Text);
            }
            else
            {
                textBox1.Text = Calculator.binTOdec(binvalue);
            }
            datatype = 3;
        }

        private void button4_Click(object sender, EventArgs e)//hex
        {
            if (textBox1.Text.Contains("&") | textBox1.Text.Contains("|") | textBox1.Text.Contains("^") | textBox1.Text.Contains("~"))
            {
                MessageBox.Show("Введено выражение!");
                return;
            }
            if (datatype == 1)
            {
                binvalue = textBox1.Text;
                textBox1.Text = Calculator.binTOhex(textBox1.Text);
            }
            else
            {
                textBox1.Text = Calculator.binTOhex(binvalue);
            }
            datatype = 4;
        }

        private void button7_Click(object sender, EventArgs e)//calculate
        {
            try
            {
                string res = Calculator.Calculate(textBox1);
                textBox1.Text = res;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: "+ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "〉" && !textBox1.Text.Contains("2") && !textBox1.Text.Contains("3") && !textBox1.Text.Contains("4") && !textBox1.Text.Contains("5") && !textBox1.Text.Contains("6") && !textBox1.Text.Contains("7") && !textBox1.Text.Contains("8") && !textBox1.Text.Contains("9"))
            {
                if (Calculator.checkInputLen(textBox1.Text) == null)
                    textBox1.Text += "0";
                else
                    MessageBox.Show(Calculator.checkInputLen(textBox1.Text));
            }
            else
            {
                textBox1.Text = "0";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "〉"&& !textBox1.Text.Contains("2") && !textBox1.Text.Contains("3") && !textBox1.Text.Contains("4") && !textBox1.Text.Contains("5") && !textBox1.Text.Contains("6") && !textBox1.Text.Contains("7") && !textBox1.Text.Contains("8") && !textBox1.Text.Contains("9"))
            {
                if (Calculator.checkInputLen(textBox1.Text) == null)
                    textBox1.Text += "1";
                else
                    MessageBox.Show(Calculator.checkInputLen(textBox1.Text));
            }
            else
            {
                textBox1.Text = "1";
            }
        }

        private void button8_Click(object sender, EventArgs e)//and
        {
            if (textBox1.Text != "〉" & textBox1.Text != "" & textBox1.Text != "|" & textBox1.Text != "^" & textBox1.Text != "~")
            {
                textBox1.Text += "&";
            }
            else
            {
                MessageBox.Show("Ошибка в выражении");
            }
        }

        private void button9_Click(object sender, EventArgs e)//or
        {
            if (textBox1.Text != "〉" & textBox1.Text != "" & textBox1.Text != "&" & textBox1.Text != "^" & textBox1.Text != "~")
            {
                textBox1.Text += "|";
            }
            else
            {
                MessageBox.Show("Ошибка в выражении");
            }
        }

        private void button10_Click(object sender, EventArgs e)//xor
        {
            if (textBox1.Text != "〉" & textBox1.Text != "" & textBox1.Text.Last() != '|' & textBox1.Text.Last() != '&' & textBox1.Text.Last() != '~')
            {
                textBox1.Text += "^";
            }
            else
            {
                MessageBox.Show("Ошибка в выражении");
            }
        }

        private void button11_Click(object sender, EventArgs e)//not
        {
            if(textBox1.Text==""|| textBox1.Text== "〉")
                textBox1.Text = "~";
            else textBox1.Text += "~";
        }

        private void C_Click(object sender, EventArgs e)//clear
        {
            textBox1.Text = "〉";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0 && textBox1.Text != "〉")
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            else
                textBox1.Text = "〉";
        }

        private void button13_Click(object sender, EventArgs e)//next
        {
            Form2 f2 = new Form2();
            f2.Hide();
            f2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
