using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace lab2
{
    public partial class E_library : Form
    {
        public data dat = new data();
        data sortresult = new data();
        public data findresult = new data();
        public E_library()
        {
            InitializeComponent();
            toolStripStatusLabel1.Text = DateTime.Now.ToLongDateString();
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

                StreamWriter sw = new StreamWriter(@"C:\Users\илья\Desktop\OOP\labs\lab3\data.xml");
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

                StreamReader sr = new StreamReader(@"C:\Users\илья\Desktop\OOP\labs\lab3\data.xml");
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
        //----------------------------------------------------------------------------------
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("V1.0.1 Коваленко Илья Олегович");
        }

        private void libview_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            libview.BackColor = Color.Green;
            findview.BackColor = SystemColors.Control;
            sortview.BackColor = SystemColors.Control;
        }
        private void findview_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;
            dataGridView3.Visible = false;
            libview.BackColor = SystemColors.Control;
            findview.BackColor = Color.Green;
            sortview.BackColor = SystemColors.Control;
        }

        private void sortview_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = true;
            libview.BackColor = SystemColors.Control;
            findview.BackColor = SystemColors.Control;
            sortview.BackColor = Color.Green;
        }

        //поиск
        private void поИздательствуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            input inp = new input("Введите издательство", dataGridView2, dat, this);
            inp.Show();
        }

        private void поГодуИзданияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            input inp = new input("Введите год издания", dataGridView2, dat, this);
            inp.Show();
        }

        private void диапазонуСтраницToolStripMenuItem_Click(object sender, EventArgs e)
        {
            input inp = new input("Введите диапазон страниц", dataGridView2, dat, this);
            inp.Show();
        }
        //сортировка
        private void годуИзданияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XDocument xdoc = XDocument.Load(@"C:\Users\илья\Desktop\OOP\labs\lab3\data.xml");
            Dictionary<int, int> sortarr = new Dictionary<int, int>();            
            data sorteddata = new data();
            int i = 0;
            foreach(XElement element in xdoc.Element("ArrayOfLibrary").Elements("Library"))
            {
                XElement yearelement = element.Element("year");
                sortarr.Add(i, (int)yearelement);
                i++;
            }
            sortarr = sortarr.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            int index;
            XElement selement = xdoc.Element("ArrayOfLibrary");
            dataGridView3.Rows.Clear();
            for (int l = 0; l < sortarr.Count; l++)
            {
                index = sortarr.ElementAt(l).Key;
                XElement elements = selement.Elements("Library").ElementAt(index);
                XElement formatement = elements.Element("format");
                XElement flsizeement = elements.Element("file_size");
                XElement nameement = elements.Element("name");
                XElement udkement = elements.Element("uDK");
                XElement copement = elements.Element("count_of_pages");
                XElement publement = elements.Element("publ");
                XElement yearelement = elements.Element("year");
                XElement dtloadement = elements.Element("dataLoad");
                XElement idement = elements.Element("author").Element("id");
                XElement fioement = elements.Element("author").Element("FIO");
                XElement countryement = elements.Element("author").Element("country");
                DateTime dtt;
                DateTime.TryParse(dtloadement.ToString(), out dtt);
                Library lbr = new Library(formatement.Value, (int)flsizeement, nameement.Value, udkement.Value, (int)copement, publement.Value, (int)yearelement, dtt, (int)idement, fioement.Value, countryement.Value);
                
                ObjArr.Add(lbr, dataGridView3, sorteddata);
            }
            sortresult = sorteddata;
        }

        private void датеЗагрузкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XDocument xdoc = XDocument.Load(@"C:\Users\илья\Desktop\OOP\labs\lab3\data.xml");
            Dictionary<int, double> sortarr = new Dictionary<int, double>();
            data sorteddata = new data();
            int i = 0;
            foreach (XElement elem in xdoc.Element("ArrayOfLibrary").Elements("Library"))
            {
                string dat = elem.Element("dataLoad").Value;
                string datcut = "";
                for (int l = 0; l < 10; l++)
                {
                    datcut += dat[l];
                }
                string[] datarr = datcut.Split('-');
                int y;
                int m;
                int d;                
                Int32.TryParse(datarr[0], out y);
                Int32.TryParse(datarr[1], out m);
                Int32.TryParse(datarr[2], out d);
                DateTime dt0 = new DateTime();
                DateTime dtt = new DateTime(y, m, d);
                TimeSpan ts = dtt.Subtract(dt0);
                double seconds = ts.TotalSeconds;
                sortarr.Add(i, seconds);
                i++;
            }
            sortarr = sortarr.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            XElement element = xdoc.Element("ArrayOfLibrary");
            int index;
            dataGridView3.Rows.Clear();
            for (int l =0; l<sortarr.Count; l++)
            {
                index = sortarr.ElementAt(l).Key;
                XElement elements = element.Elements("Library").ElementAt(index);
                XElement formatement = elements.Element("format");
                XElement flsizeement = elements.Element("file_size");
                XElement nameement = elements.Element("name");
                XElement udkement = elements.Element("uDK");
                XElement copement = elements.Element("count_of_pages");
                XElement publement = elements.Element("publ");
                XElement yearelement = elements.Element("year");
                XElement dtloadement = elements.Element("dataLoad");
                XElement idement = elements.Element("author").Element("id");
                XElement fioement = elements.Element("author").Element("FIO");
                XElement countryement = elements.Element("author").Element("country");
                DateTime dtt;
                DateTime.TryParse(dtloadement.ToString(), out dtt);
                Library lbr = new Library(formatement.Value, (int)flsizeement, nameement.Value, udkement.Value, (int)copement, publement.Value, (int)yearelement, dtt, (int)idement, fioement.Value, countryement.Value);
                ObjArr.Add(lbr, dataGridView3, sorteddata);
            }
            sortresult = sorteddata;
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(findview.BackColor == Color.Green)//find
            {
                try
                {
                    XmlSerializer xs = new XmlSerializer(typeof(List<Library>));

                    StreamWriter sw = new StreamWriter(@"C:\Users\илья\Desktop\OOP\labs\lab3\findresult.xml");
                    xs.Serialize(sw, findresult .lbr);
                    sw.Close();
                    MessageBox.Show("сохранено");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error serialisation: " + ex.Message);
                }
            }
            else if(sortview.BackColor == Color.Green)//sort
            {
                try
                {
                    XmlSerializer xs = new XmlSerializer(typeof(List<Library>));

                    StreamWriter sw = new StreamWriter(@"C:\Users\илья\Desktop\OOP\labs\lab3\sortresult.xml");
                    xs.Serialize(sw, sortresult.lbr);
                    sw.Close();
                    MessageBox.Show("сохранено");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error serialisation: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("выберите таблицу для сохранения!");
            }
        }
        //tool strip
        private void поИздательствуToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            поИздательствуToolStripMenuItem.PerformClick();
        }

        private void поГодуИзданияToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            поГодуИзданияToolStripMenuItem.PerformClick();
        }

        private void поДиапазонуСтраницToolStripMenuItem_Click(object sender, EventArgs e)
        {
            поДиапазонуСтраницToolStripMenuItem.PerformClick();
        }

        private void годуИзданияToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            годуИзданияToolStripMenuItem.PerformClick();
        }

        private void датеЗагрузкиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            датеЗагрузкиToolStripMenuItem.PerformClick();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            сохранитьToolStripMenuItem.PerformClick();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            оПрограммеToolStripMenuItem.PerformClick();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            
        }
    }
    public class MyValid : ValidationAttribute//атрибут валидации
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                string AuthorName = value.ToString();
                if (!AuthorName.StartsWith(" "))
                    return true;
                else
                    this.ErrorMessage = "Имя не должно начинаться с пробела";
            }
            return false;
        }
    }
}
