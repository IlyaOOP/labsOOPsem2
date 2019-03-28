using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1
{
    static class Calculator
    {
        public static string Calculate(TextBox txt)
        {
            string text = txt.Text;
            string[] compons = text.Split(new char[] { '&', '|', '^', '~' });
            
            if (text.Contains("~"))
            {
                string result = "";
                int ind = text.IndexOf('~');
                if (ind == 0)
                {
                    foreach(char symb in compons[1])
                    {
                        if (symb == '1') result += "0";
                        else if (symb == '0') result += "1";
                        else return "";
                    }
                    compons[0] = result;
                }
                else if(compons.Length==2)
                {
                    MessageBox.Show("для оператора '~' требуется 1 значение");
                }
                else
                {
                    foreach (char symb in compons[2])
                    {
                        if (symb == '1') result += "0";
                        else if (symb == '0') result += "1";
                        else return "";
                    }
                    compons[1] = result;
                }
                if(compons.Length==3)
                {
                    try
                    {
                        string val1 = binTOdec(compons[0]);
                        string val2 = binTOdec(compons[1]);
                        int Ival1 = Convert.ToInt32(val1);
                        int Ival2 = Convert.ToInt32(val2);
                        if (text.Contains("&")) return Convert.ToString((Ival1 & Ival2), 2);
                        else if (text.Contains("|")) return Convert.ToString((Ival1 | Ival2), 2);
                        else if (text.Contains("^")) return Convert.ToString((Ival1 ^ Ival2), 2);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                return result;
            }
            else if (compons.Length == 2)
            {
                int val1 = Convert.ToInt32(binTOdec(compons[0]));
                int val2 = Convert.ToInt32(binTOdec(compons[1]));
                if (text.Contains("&")) return Convert.ToString((val1 & val2),2);
                else if (text.Contains("|")) return Convert.ToString((val1 | val2), 2);
                else if (text.Contains("^")) return Convert.ToString((val1 ^ val2), 2);
                else return "";
            }
            else
            {
                MessageBox.Show("Error");
                return "";
            }
        }

        public static string binTOoct(string inpstr)
        {
            int len = inpstr.Length;
            string revers = "";
            for(int i = len-1; i>=0; i--)
            {
                revers += inpstr[i];
            }
            if(len %3 !=0)
            {
                revers += "0";
            }
            if (len % 3 != 0)
            {
                revers += "0";
            }
            len = revers.Length;
            string resstr = "";
            for(int i = 0; i<len/3; i++)
            {
                int resnum = 0;
                int j = 0;
                while(j!=3)
                {
                    if(revers[3*i+j]=='1')
                    {
                        resnum += Convert.ToInt32(Math.Pow(2,j));
                    }
                    j++;
                }
                resstr += resnum;
            }
            len = resstr.Length;
            revers = "";
            for (int i = len - 1; i >= 0; i--)
            {
                revers += resstr[i];
            }
            if (revers[0] == '0')
            {
                revers = revers.Remove(0, 1);
            }
            return revers;
        }

        public static string binTOdec(string inpstr)
        {
            int len = inpstr.Length;
            string revers = "";
            for (int i = len - 1; i >= 0; i--)
            {
                revers += inpstr[i];
            }
            string resstr = "";
            int resnum = 0;
            for (int i = 0; i < len; i++)
            {
                if (revers[i] == '1')
                {
                    resnum += Convert.ToInt32(Math.Pow(2, i));
                }
            }
            resstr = resnum.ToString();
            return resstr;
        }

        public static string binTOhex(string inpstr)
        {
            Dictionary<int, string> array = new Dictionary<int, string>();
            array.Add(10, "A");
            array.Add(11, "B");
            array.Add(12, "C");
            array.Add(13, "D");
            array.Add(14, "E");
            array.Add(15, "F");
            int len = inpstr.Length;
            string revers = "";
            for (int i = len - 1; i >= 0; i--)
            {
                revers += inpstr[i];
            }
            if (len % 4 != 0)
            {
                revers += "0";
                if (len % 4 != 0)
                {
                    revers += "0";
                }
                if (len % 4 != 0)
                {
                    revers += "0";
                }
            }
            len = revers.Length;
            string resstr = "";
            for (int i = 0; i < len / 4; i++)
            {
                int resnum = 0;
                int j = 0;
                while (j != 4)
                {
                    if (revers[4*i+j] == '1')
                    {
                        resnum += Convert.ToInt32(Math.Pow(2, j));
                    }
                    j++;
                }
                string numstr = "" + resnum;
                if (numstr.Length!=1)
                {
                    array.TryGetValue(resnum, out numstr);
                }
                resstr += numstr;
            }
            len = resstr.Length;
            revers = "";
            for (int i = len - 1; i >= 0; i--)
            {
                revers += resstr[i];
            }
            if(revers[0]=='0')
            {
                revers = revers.Remove(0, 1);
            }
            return revers;
        }
        public static string checkInputLen(string inpstr)
        {
            if (inpstr.Length >= 19)
                return "Ошибка. Достигнута максимальная длина.";
            else return null;
        }
    }
}
