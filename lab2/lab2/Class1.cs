using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2
{
    public class data
    {
        public List<Library> lbr = new List<Library>();

        public string ToString(int index)
        {
            if(lbr.Count!=0)
            {
                Library lb = lbr.ElementAt(index);
                string output = "";
                output += "Формат книги: "+lb.format + "\nНазвание: " + lb.name + "\nРазмер: " + lb.file_size + "\nУДК: " + lb.uDK + "\nКоличество страниц: " + lb.count_of_pages + "\nИздательство: " + lb.publ + "\nГод издания: " + lb.year + "\nДата загрузки: " + lb.dataLoad.ToShortDateString() + "\nАвтор: " + lb.author.FIO+ "\n\tСтрана: " + lb.author.country + "\n\tID: " + lb.author.id;
                return output;
            }
            return null;
        }
    }
    static class ObjArr
    {
        public static void Add(Library objLib, DataGridView table, data dat)
        {
            dat.lbr.Add(objLib);
            if(objLib is Library)
            {
                Library lr = (Library)objLib;
                table.Rows.Add(lr.name, lr.year, lr.author.fio);
            }                
        }

        public static void clear(data dat, DataGridView table)
        {
            table.Rows.Clear();
            dat.lbr.Clear();
        }

        public static void delete(int index, data dat)
        {
            dat.lbr.RemoveAt(index);
        }

        public static void print(DataGridView table, List<Library> llb)
        {
            foreach(Library lb in llb)
            {                
                table.Rows.Add(lb.name, lb.year, lb.author.fio);
            }
        }
    }       

    public class Author//агрегируемый объект автор
    {
        public int id;
        public string FIO;
        public string country;

        public int Id => id;
        public string fio => FIO;
        public string Country => country;

        public Author(int id, string FIO, string country )
        {
            this.id = id;
            this.FIO = FIO;
            this.country = country;
        }

        public Author()
        {

        }
    }
    [System.Serializable]
    public class Library
    {
        public string format;
        public int file_size;
        public string name;
        public string uDK;
        public int count_of_pages;
        public string publ;
        public int year;
        public DateTime dataLoad;
        public Author author;

        public Library()
        {

        }
        public Library(string frm, int fl_sz, string name, string udk, int c_o_p, string publ, int year, DateTime dtl, int authID, string authName, string Country)
        {
            format = frm;
            file_size = fl_sz;
            this.name = name;
            uDK = udk;
            count_of_pages = c_o_p;
            this.publ = publ;
            this.year = year;
            dataLoad = dtl;
            author = new Author(authID, authName, Country);
        }
    }
}
