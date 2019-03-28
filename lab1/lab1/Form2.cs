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
    public partial class Form2 : Form
    {    
        delegate void comparator();
        comparator comp;
        List<int> list = new List<int>();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            generatedCollection.Items.Clear();
            Random rand = new Random();
            int sz;
            if (int.TryParse(sizebox.Text, out sz) && sz > 0)
            {
                for (int i = 0; i < sz; i++)
                {
                    list.Add(rand.Next(100));
                    generatedCollection.Items.Add(list.Last());
                }
            }
            else
                MessageBox.Show("размер введен неверно");
        }

        private void descendingSort_Click(object sender, EventArgs e)
        {
            comp = sortDown;
            comp();
        }

        void sortUp()
        {
            list.Sort();
            finalCollection.Items.Clear();

            for (int i = 0; i < list.Count; i++)
            {
                finalCollection.Items.Add(list[i]);
            }
        }
        void sortDown()
        {
            finalCollection.Items.Clear();
            list.Sort();
            list.Reverse();

            for (int i = 0; i < list.Count; i++)
            {
                finalCollection.Items.Add(list[i]);
            }
        }

        private void ascendingSort_Click(object sender, EventArgs e)
        {
            comp = sortUp;
            comp();
        }

        private void LINQ1_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedItems = from t in list
                                    where t % 2 == 0 & t!=0
                                    orderby t
                                    select t;
                string even = "Чётные элементы: ";
                foreach (int t in selectedItems)
                {
                    even += t + ", ";
                }
                even = even.TrimEnd(' ');
                even = even.TrimEnd(',');
                MessageBox.Show(even);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LINQ2_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedItems = from t in list
                                    where t % 2 != 0
                                    orderby t
                                    select t;
                string even = "Нечётные элементы: ";
                foreach (int t in selectedItems)
                {
                    even += t + ", ";
                }
                even = even.TrimEnd(' ');
                even = even.TrimEnd(',');
                MessageBox.Show(even);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LINQ3_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Минимальный элемент: " + list.Min(a => a));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
           
    }
}
