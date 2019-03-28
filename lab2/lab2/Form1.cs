using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace lab2
{
    public partial class E_library : Form
    {
        public data dat = new data();
        public E_library()
        {
            InitializeComponent();
        }

        private void add_book_Click(object sender, EventArgs e)
        {
            this.Width = 800;
            groupBox1.Visible = true;
        }

        private void ADD_Click(object sender, EventArgs e)
        {            
            try
            {
                string format = fileFormatBox.Text;
                int fl_sz = Convert.ToInt32(sizebookBox.Text);
                string name = namebookBox.Text;
                string udk = UDKBox.Text;
                int c_o_p = Convert.ToInt32(pagescountBox.Text);
                string publ = publBox.Text;
                int year = Convert.ToInt32(yearBox.Value);
                DateTime dt = dateTimePickerBox.Value.Date;
                string fio = FIOBox.Text;
                string country = CountryBox.Text;
                int id = (int)idBox.Value;
                Library lib = new Library(format, fl_sz, name, udk, c_o_p, publ, year, dt, id, fio, country);
                ObjArr.Add(lib, dataGridView1, dat);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка во введенных данных. " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int selectedRow = dataGridView1.CurrentRow.Index;
            Информация f2 = new Информация(dat.ToString(selectedRow));
            f2.Show();

        }

        private void delete_book_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                int selectedRow = dataGridView1.CurrentRow.Index;
                dataGridView1.Rows.RemoveAt(selectedRow);
                ObjArr.delete(selectedRow, dat);
            }
            else
                MessageBox.Show("Таблица пуста");
        }

        private void button1_Click(object sender, EventArgs e)//сериализация
        {
            try
            {               
                XmlSerializer xs = new XmlSerializer(typeof(List<Library>));

                StreamWriter sw = new StreamWriter(@"C:\Users\илья\Desktop\OOP\labs\lab2\data.xml");
                xs.Serialize(sw, dat.lbr);
                sw.Close();                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error serialisation: "+ex.Message);
            }
                
        }

        private void load_Click(object sender, EventArgs e)
        {
            try
            {
                ObjArr.clear(dat ,dataGridView1);
                XmlSerializer xs = new XmlSerializer(typeof(List<Library>));

                StreamReader sr = new StreamReader(@"C:\Users\илья\Desktop\OOP\labs\lab2\data.xml");
                dat.lbr = (List<Library>)xs.Deserialize(sr);
                ObjArr.print(dataGridView1, dat.lbr);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Deserialisation Error: " + ex.Message);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void E_library_Load(object sender, EventArgs e)
        {
            this.Width = 450;            
        }

        private void fileFormatBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.BackColor = Color.LightGray;
            checkBox2.Checked = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            this.BackColor = Color.DarkGray;
            checkBox1.Checked = false;
        }

        private void idBox_ValueChanged(object sender, EventArgs e)
        {
            foreach(Library lb in dat.lbr)
            {
                if(lb.author.id == idBox.Value)
                {
                    errorProvider1.SetError(idBox, "автор с данным id уже существует");
                    break;
                }
                else
                {
                   errorProvider1.SetError(idBox, "");
                }
            }
        }
    }
}
