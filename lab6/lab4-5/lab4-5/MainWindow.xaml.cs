using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace lab4_5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool ispaste;
        private mycommands addCommand;
        public MainWindow()
        {
            InitializeComponent();
            addCommand= new mycommands(this);
            this.Cursor = Cursors.Hand;
            this.Title = Properties.Resources.mainwin;
            h1.Header = Properties.Resources.h1;
            h2.Header = Properties.Resources.h2;
            foreach (var ff in Fonts.SystemFontFamilies.ToList())
            {
                fonts.Items.Add(ff);
            }
            fonts.SelectedIndex = 0;
            ADDItems();
        }

         
        private void ADDItems()
        {
            StreamReader sr = new StreamReader(@"C:\Users\илья\Desktop\OOP\labs\labsOOPsem2\lab6\lab4-5\files.txt");
            List<string> str = new List<string>();
            string line;
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                str.Add(line);
            }
            str.Distinct();
            for(int i =0;i<10; i++)
            {
                if (str.Count!=0)
                {
                    files.Items.Add(str.Last());
                    str.RemoveAt(str.Count - 1);
                }
                else break;
            }
            sr.Close();
        }
        private void Fonts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            var txbxs = mainGrid.Children;
            RichTextBox rtb;
            foreach (var rt in txbxs)
            {
                if (rt is RichTextBox)
                {
                    rtb = (RichTextBox)rt;
                    rtb.FontFamily = new FontFamily(cb.SelectedItem.ToString());
                }
            }
        }
        private void Fsize_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider cl = (Slider)sender;
            var txbxs = mainGrid.Children;
            RichTextBox rtb;
            foreach (var rt in txbxs)
            {
                if (rt is RichTextBox)
                {
                    rtb = (RichTextBox)rt;
                    rtb.FontSize = cl.Value;
                }
            }
        }

        private void textchanged_boxtextsize(object sender, TextChangedEventArgs e)//привязка слайдера изменения размера шрифта к textbox
        {
            double dbl;
            double.TryParse(tsize.Text, out dbl);
            fsize.Value = dbl;
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)//bold
        {
            var txbxs = mainGrid.Children;
            RichTextBox rtb;
            foreach (var rt in txbxs)
            {
                if (rt is RichTextBox)
                {
                    rtb = (RichTextBox)rt;
                    rtb.FontWeight = FontWeights.Bold;
                }
            }
        }
        private void unchecked_bold(object sender, RoutedEventArgs e)
        {
            var txbxs = mainGrid.Children;
            RichTextBox rtb;
            foreach (var rt in txbxs)
            {
                if (rt is RichTextBox)
                {
                    rtb = (RichTextBox)rt;
                    rtb.FontWeight = FontWeights.Normal;
                }
            }
        }

        private void ToggleButton_Checked_1(object sender, RoutedEventArgs e)//Italic
        {
            var txbxs = mainGrid.Children;
            RichTextBox rtb;
            foreach (var rt in txbxs)
            {
                if (rt is RichTextBox)
                {
                    rtb = (RichTextBox)rt;
                    rtb.FontStyle = FontStyles.Italic;
                }
            }
        }
        private void unchecked_Italic(object sender, RoutedEventArgs e)
        {
            var txbxs = mainGrid.Children;
            RichTextBox rtb;
            foreach (var rt in txbxs)
            {
                if (rt is RichTextBox)
                {
                    rtb = (RichTextBox)rt;
                    rtb.FontStyle = FontStyles.Normal;
                }
            }
        }
        private void ToggleButton_Checked_2(object sender, RoutedEventArgs e)//underline
        {
            var txbxs = mainGrid.Children;
            RichTextBox rtb;
            foreach (var rt in txbxs)
            {
                if (rt is RichTextBox)
                {
                    rtb = (RichTextBox)rt;
                    rtb.SelectAll();
                    TextRange txr = rtb.Selection;
                    txr.ApplyPropertyValue(TextBox.TextDecorationsProperty, "underline");
                }
            }
        }
        private void unchecked_underline(object sender, RoutedEventArgs e)
        {
            var txbxs = mainGrid.Children;
            RichTextBox rtb;
            foreach (var rt in txbxs)
            {
                if (rt is RichTextBox)
                {
                    rtb = (RichTextBox)rt;
                    rtb.SelectAll();
                    TextRange txr = rtb.Selection;
                    txr.ApplyPropertyValue(TextBox.TextDecorationsProperty, null);
                }
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)//new
        {
            createMenuItem();
        }

        private void closeClickevent(object sender, RoutedEventArgs e)
        {
            Button btsender = (Button)sender;
            StackPanel stp = (StackPanel)btsender.Parent;
            ToolBar tlb = (ToolBar)stp.Parent;
            int index = tlb.Items.IndexOf(stp);
            stp.Children.Clear();
            tlb.Items.RemoveAt(index);
            var gridcontent = mainGrid.Children;
            List<RichTextBox> rtblist = new List<RichTextBox>();
            foreach (object rb in gridcontent)
            {
                if (rb is RichTextBox)
                {
                    if (Grid.GetRow((RichTextBox)rb) == 2 && Grid.GetColumn((RichTextBox)rb) == 0)
                    {
                        rtblist.Add((RichTextBox)rb);
                    }
                }
            }
            gridcontent.Remove(rtblist.ElementAt(index));
        }

        private void changeList(object sender, RoutedEventArgs e)//смена активного окна
        {
            TextBlock txb = sender as TextBlock;
            StackPanel stp = (StackPanel)txb.Parent;
            TextBlock tbbb;
            foreach (StackPanel tb in winbar.Items)
            {
                foreach (var tbb in tb.Children)
                {
                    if (tbb is TextBlock)
                    {
                        tbbb = (TextBlock)tbb;
                        tbbb.Background = Brushes.AliceBlue;
                    }
                }
            }
            txb.Background = Brushes.Blue;
            int index = winbar.Items.IndexOf(stp);
            var gridcontent = mainGrid.Children;
            List<RichTextBox> rtblist = new List<RichTextBox>();
            foreach (object rb in gridcontent)
            {
                if (rb is RichTextBox)
                {
                    if (Grid.GetRow((RichTextBox)rb) == 2 && Grid.GetColumn((RichTextBox)rb) == 0)
                    {
                        rtblist.Add((RichTextBox)rb);
                        Canvas.SetZIndex(rtblist.Last(), 1);
                    }
                }
            }
            RichTextBox rtbB = rtblist.ElementAt(index);
            Canvas.SetZIndex(rtbB, 5);
        }

        private void statusBarUPLoad(object sender, RoutedEventArgs e)
        {
            ispaste = false;
            RichTextBox rtbsender = (RichTextBox)sender;
            TextRange txrange = new TextRange(rtbsender.Document.ContentStart, rtbsender.Document.ContentEnd);
            statusbar.Text = "Число символов "+(txrange.Text.Length-2);
            int count=0;
            foreach(char ch in txrange.Text)
            {
                if(ch==' ')
                {
                    count++;
                }
            }
            count++;
            if (txrange.Text.Length == 2)
                count = 0;
            statusbar.Text += " Число слов " + count;
        }

        private void createMenuItem()
        {
            StackPanel stp = new StackPanel();
            stp.Orientation = Orientation.Horizontal;
            winbar.Items.Add(stp);
            TextBlock txb = new TextBlock();
            txb.MouseDown += new MouseButtonEventHandler(changeList);
            txb.Text = "new_doc" + winbar.Items.Count;
            stp.Children.Add(txb);
            Button btclose = new Button();
            btclose.Background = Brushes.Transparent;
            btclose.BorderBrush = Brushes.Transparent;
            btclose.Content = "✖";
            stp.Children.Add(btclose);
            stp.Children.Add(new Separator());
            btclose.Click += new RoutedEventHandler(closeClickevent);
            RichTextBox rtb = new RichTextBox();
            rtb.TextChanged += new TextChangedEventHandler(statusBarUPLoad);
            rtb.AllowDrop = true;
            rtb.PreviewDragEnter += new DragEventHandler(OnDragOver);
            rtb.PreviewDragOver += new DragEventHandler(OnDragOver);
            rtb.PreviewDrop += new DragEventHandler(DROP);
            rtb.Name = txb.Text;
            Canvas.SetZIndex(rtb, 5);
            mainGrid.Children.Add(rtb);
            Grid.SetRow(rtb, 2);
            Grid.SetColumn(rtb, 0);
        }
        private void createMenuItem(string title)
        {
            string[] arr = title.Split('\\');
            string name = arr.Last().Remove(arr.Last().Length - 4);
            StackPanel stp = new StackPanel();
            stp.Orientation = Orientation.Horizontal;
            winbar.Items.Add(stp);
            TextBlock txb = new TextBlock();
            txb.MouseDown += new MouseButtonEventHandler(changeList);
            txb.Text = name;
            stp.Children.Add(txb);
            Button btclose = new Button();
            btclose.Background = Brushes.Transparent;
            btclose.BorderBrush = Brushes.Transparent;
            btclose.Content = "✖";
            stp.Children.Add(btclose);
            stp.Children.Add(new Separator());
            btclose.Click += new RoutedEventHandler(closeClickevent);
            RichTextBox rtb = new RichTextBox();
            rtb.TextChanged += new TextChangedEventHandler(statusBarUPLoad);
            rtb.AllowDrop = true;
            rtb.PreviewDragEnter += new DragEventHandler(OnDragOver);
            rtb.PreviewDragOver += new DragEventHandler(OnDragOver);
            rtb.PreviewDrop += new DragEventHandler(DROP);
            rtb.Name = txb.Text;
            Canvas.SetZIndex(rtb, 5);
            mainGrid.Children.Add(rtb);
            Grid.SetRow(rtb, 2);
            Grid.SetColumn(rtb, 0);
        }

        private void OnDragOver(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.All;
            e.Handled = true;
        }
        private void DROP(object sender, DragEventArgs e)
        {
            string[] text = (string[])e.Data.GetData(DataFormats.FileDrop);
            var gridcontent = mainGrid.Children;
            List<RichTextBox> rtblist = new List<RichTextBox>();
            foreach (object rb in gridcontent)
            {
                if (rb is RichTextBox)
                {
                    if (Grid.GetRow((RichTextBox)rb) == 2 && Grid.GetColumn((RichTextBox)rb) == 0)
                    {
                        rtblist.Add((RichTextBox)rb);
                    }
                }
            }
            RichTextBox rtb;
            TextRange range;
            FileStream fStream;
            foreach (var txbox in rtblist)
            {
                if (txbox is RichTextBox)
                {
                    rtb = (RichTextBox)txbox;
                    if (Canvas.GetZIndex(rtb) == 5)
                    {
                        range = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
                        fStream = new FileStream(text[0], FileMode.Open);
                        range.Load(fStream, DataFormats.Rtf);
                        fStream.Close();
                        break;
                    }
                }
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)//copy
        {
            var gridcontent = mainGrid.Children;
            List<RichTextBox> rtblist = new List<RichTextBox>();
            foreach (object rb in gridcontent)
            {
                if (rb is RichTextBox)
                {
                    if (Grid.GetRow((RichTextBox)rb) == 2 && Grid.GetColumn((RichTextBox)rb) == 0)
                    {
                        rtblist.Add((RichTextBox)rb);
                    }
                }
            }
            RichTextBox rtb;
            foreach (var txbox in rtblist)
            {
                if (txbox is RichTextBox)
                {
                    rtb = (RichTextBox)txbox;
                    if (Canvas.GetZIndex(rtb) == 5)
                    {
                        TextSelection txsel = rtb.Selection;
                        string text = txsel.Text;
                        Clipboard.SetText(text);
                        MessageBox.Show("скопировано в буфер");
                        break;
                    }
                }
            }
        }

        public void past()
        {
            var gridcontent = mainGrid.Children;
            List<RichTextBox> rtblist = new List<RichTextBox>();
            foreach (object rb in gridcontent)
            {
                if (rb is RichTextBox)
                {
                    if (Grid.GetRow((RichTextBox)rb) == 2 && Grid.GetColumn((RichTextBox)rb) == 0)
                    {
                        rtblist.Add((RichTextBox)rb);
                    }
                }
            }
            RichTextBox rtb;
            foreach (var txbox in rtblist)
            {
                if (txbox is RichTextBox)
                {
                    rtb = (RichTextBox)txbox;
                    if (Canvas.GetZIndex(rtb) == 5)
                    {
                        rtb.AppendText(Clipboard.GetText());
                        break;
                    }
                }
            }
        }
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)//paste
        {
            addCommand.Execute();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)//font/color
        {
            var gridcontent = mainGrid.Children;
            List<RichTextBox> rtblist = new List<RichTextBox>();
            foreach (object rb in gridcontent)
            {
                if (rb is RichTextBox)
                {
                    if (Grid.GetRow((RichTextBox)rb) == 2 && Grid.GetColumn((RichTextBox)rb) == 0)
                    {
                        rtblist.Add((RichTextBox)rb);
                    }
                }
            }
            RichTextBox rtb;
            foreach (var txbox in rtblist)
            {
                if (txbox is RichTextBox)
                {
                    rtb = (RichTextBox)txbox;
                    if (Canvas.GetZIndex(rtb) == 5)
                    {
                        TextSelection tsl = rtb.Selection;
                        System.Windows.Forms.FontDialog fdialog = new System.Windows.Forms.FontDialog();
                        var result = fdialog.ShowDialog();
                        if (result == System.Windows.Forms.DialogResult.OK)
                        {
                            try
                            {
                                tsl.ApplyPropertyValue(RichTextBox.FontFamilyProperty, fdialog.Font.Name);
                                tsl.ApplyPropertyValue(RichTextBox.FontSizeProperty, fdialog.Font.Size * 96.0 / 72.0);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        break;
                    }
                }
            }
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)//save
        {
            var gridcontent = mainGrid.Children;
            List<RichTextBox> rtblist = new List<RichTextBox>();
            foreach (object rb in gridcontent)
            {
                if (rb is RichTextBox)
                {
                    if (Grid.GetRow((RichTextBox)rb) == 2 && Grid.GetColumn((RichTextBox)rb) == 0)
                    {
                        rtblist.Add((RichTextBox)rb);
                    }
                }
            }
            RichTextBox rtb;
            TextRange range;
            foreach (var txbox in rtblist)
            {
                if (txbox is RichTextBox)
                {
                    rtb = (RichTextBox)txbox;
                    if (Canvas.GetZIndex(rtb) == 5)
                    {
                        range = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
                        SaveFileDialog dlg = new SaveFileDialog(); dlg.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*"; if (dlg.ShowDialog() == true)
                        {
                            FileStream fileStream = new FileStream(dlg.FileName, FileMode.Create);
                            range.Save(fileStream, DataFormats.Rtf);
                        }
                        break;
                    }
                }
            }
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)//open
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*"; if (dlg.ShowDialog() == true)
            {
                createMenuItem(dlg.FileName);
                var gridcontent = mainGrid.Children;
                List<RichTextBox> rtblist = new List<RichTextBox>();
                foreach (object rb in gridcontent)
                {
                    if (rb is RichTextBox)
                    {
                        if (Grid.GetRow((RichTextBox)rb) == 2 && Grid.GetColumn((RichTextBox)rb) == 0)
                        {
                            rtblist.Add((RichTextBox)rb);
                        }
                    }
                }
                RichTextBox rtb;
                foreach (var txbox in rtblist)
                {
                    if (txbox is RichTextBox)
                    {
                        rtb = (RichTextBox)txbox;
                        if (Canvas.GetZIndex(rtb) == 5)
                        {
                            FileStream fileStream = new FileStream(dlg.FileName, FileMode.Open);
                            TextRange range = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
                            range.Load(fileStream, DataFormats.Rtf);
                        }
                        break;
                    }
                }
                using (StreamWriter strW = File.AppendText(@"C:\Users\илья\Desktop\OOP\labs\labsOOPsem2\lab6\lab4-5\files.txt"))
                {
                    strW.WriteLine(dlg.FileName);
                }
                files.Items.Clear();
                ADDItems();
            }
        }

        private void Files_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cbb = (ComboBox)sender;
            string name = cbb.SelectedItem.ToString();
            createMenuItem(name);
            var gridcontent = mainGrid.Children;
            List<RichTextBox> rtblist = new List<RichTextBox>();
            foreach (object rb in gridcontent)
            {
                if (rb is RichTextBox)
                {
                    if (Grid.GetRow((RichTextBox)rb) == 2 && Grid.GetColumn((RichTextBox)rb) == 0)
                    {
                        rtblist.Add((RichTextBox)rb);
                    }
                }
            }
            RichTextBox rtb;
            foreach (var txbox in rtblist)
            {
                if (txbox is RichTextBox)
                {
                    rtb = (RichTextBox)txbox;
                    if (Canvas.GetZIndex(rtb) == 5)
                    {
                        FileStream fileStream = new FileStream(name, FileMode.Open);
                        TextRange range = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
                        range.Load(fileStream, DataFormats.Rtf);
                    }
                    break;
                }
            }
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)//undo
        {           
                var gridcontent = mainGrid.Children;
                List<RichTextBox> rtblist = new List<RichTextBox>();
                foreach (object rb in gridcontent)
                {
                    if (rb is RichTextBox)
                    {
                        if (Grid.GetRow((RichTextBox)rb) == 2 && Grid.GetColumn((RichTextBox)rb) == 0)
                        {
                            rtblist.Add((RichTextBox)rb);
                        }
                    }
                }
                RichTextBox rtb;
                foreach (var txbox in rtblist)
                {
                    if (txbox is RichTextBox)
                    {
                        rtb = (RichTextBox)txbox;
                        if (Canvas.GetZIndex(rtb) == 5)
                        {
                            rtb.Undo();
                            break;
                        }
                    }
                }
        }

        private void MenuItem_Click_7(object sender, RoutedEventArgs e)//redo
        {
            var gridcontent = mainGrid.Children;
            List<RichTextBox> rtblist = new List<RichTextBox>();
            foreach (object rb in gridcontent)
            {
                if (rb is RichTextBox)
                {
                    if (Grid.GetRow((RichTextBox)rb) == 2 && Grid.GetColumn((RichTextBox)rb) == 0)
                    {
                        rtblist.Add((RichTextBox)rb);
                    }
                }
            }
            RichTextBox rtb;
            foreach (var txbox in rtblist)
            {
                if (txbox is RichTextBox)
                {
                    rtb = (RichTextBox)txbox;
                    if (Canvas.GetZIndex(rtb) == 5)
                    {
                        rtb.Redo();
                        break;
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("pressed button");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//theme
        {
            Button bt = sender as Button;
            if(bt.Background==Brushes.Pink)
            {
                var uri = new Uri("gray.xaml", UriKind.Relative);
                ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                // очищаем коллекцию ресурсов приложения 
                Application.Current.Resources.Clear();
                // добавляем загруженный словарь ресурсов 
                Application.Current.Resources.MergedDictionaries.Add(resourceDict); 
            }
            else
            {
                var uri = new Uri("pink.xaml", UriKind.Relative);
                ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                Application.Current.Resources.Clear(); 
                Application.Current.Resources.MergedDictionaries.Add(resourceDict);
            }
        }
    }
}

