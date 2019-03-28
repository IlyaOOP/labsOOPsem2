namespace lab2
{
    partial class E_library
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.author_list = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.add_book = new System.Windows.Forms.Button();
            this.delete_book = new System.Windows.Forms.Button();
            this.serialisation = new System.Windows.Forms.Button();
            this.load = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.idBox = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.CountryBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FIOBox = new System.Windows.Forms.TextBox();
            this.yearBox = new System.Windows.Forms.NumericUpDown();
            this.dateTimePickerBox = new System.Windows.Forms.DateTimePicker();
            this.ADD = new System.Windows.Forms.Button();
            this.publBox = new System.Windows.Forms.TextBox();
            this.pagescountBox = new System.Windows.Forms.TextBox();
            this.UDKBox = new System.Windows.Forms.TextBox();
            this.sizebookBox = new System.Windows.Forms.TextBox();
            this.namebookBox = new System.Windows.Forms.TextBox();
            this.fileFormatBox = new System.Windows.Forms.TextBox();
            this.Authors = new System.Windows.Forms.Label();
            this.LoadYear = new System.Windows.Forms.Label();
            this.publishedYear = new System.Windows.Forms.Label();
            this.Publ = new System.Windows.Forms.Label();
            this.PagesCount = new System.Windows.Forms.Label();
            this.UDK = new System.Windows.Forms.Label();
            this.FileSize = new System.Windows.Forms.Label();
            this.BookName = new System.Windows.Forms.Label();
            this.fileformat = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.idBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yearBox)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.year,
            this.author_list});
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.Location = new System.Drawing.Point(12, 68);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(544, 370);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // name
            // 
            this.name.HeaderText = "название книги";
            this.name.MinimumWidth = 100;
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 150;
            // 
            // year
            // 
            this.year.HeaderText = "год";
            this.year.Name = "year";
            this.year.ReadOnly = true;
            // 
            // author_list
            // 
            this.author_list.HeaderText = "автор";
            this.author_list.MinimumWidth = 100;
            this.author_list.Name = "author_list";
            this.author_list.ReadOnly = true;
            this.author_list.Width = 200;
            // 
            // add_book
            // 
            this.add_book.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.add_book.Location = new System.Drawing.Point(12, 12);
            this.add_book.Name = "add_book";
            this.add_book.Size = new System.Drawing.Size(157, 37);
            this.add_book.TabIndex = 1;
            this.add_book.Text = "добавить книгу";
            this.add_book.UseVisualStyleBackColor = true;
            this.add_book.Click += new System.EventHandler(this.add_book_Click);
            // 
            // delete_book
            // 
            this.delete_book.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.delete_book.Location = new System.Drawing.Point(397, 12);
            this.delete_book.Name = "delete_book";
            this.delete_book.Size = new System.Drawing.Size(157, 37);
            this.delete_book.TabIndex = 2;
            this.delete_book.Text = "удалить книгу";
            this.delete_book.UseVisualStyleBackColor = true;
            this.delete_book.Click += new System.EventHandler(this.delete_book_Click);
            // 
            // serialisation
            // 
            this.serialisation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.serialisation.Location = new System.Drawing.Point(175, 12);
            this.serialisation.Name = "serialisation";
            this.serialisation.Size = new System.Drawing.Size(110, 37);
            this.serialisation.TabIndex = 3;
            this.serialisation.Text = "сохранить";
            this.serialisation.UseVisualStyleBackColor = true;
            this.serialisation.Click += new System.EventHandler(this.button1_Click);
            // 
            // load
            // 
            this.load.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.load.Location = new System.Drawing.Point(291, 12);
            this.load.Name = "load";
            this.load.Size = new System.Drawing.Size(100, 37);
            this.load.TabIndex = 4;
            this.load.Text = "загрузить";
            this.load.UseVisualStyleBackColor = true;
            this.load.Click += new System.EventHandler(this.load_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.idBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.CountryBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.FIOBox);
            this.groupBox1.Controls.Add(this.yearBox);
            this.groupBox1.Controls.Add(this.dateTimePickerBox);
            this.groupBox1.Controls.Add(this.ADD);
            this.groupBox1.Controls.Add(this.publBox);
            this.groupBox1.Controls.Add(this.pagescountBox);
            this.groupBox1.Controls.Add(this.UDKBox);
            this.groupBox1.Controls.Add(this.sizebookBox);
            this.groupBox1.Controls.Add(this.namebookBox);
            this.groupBox1.Controls.Add(this.fileFormatBox);
            this.groupBox1.Controls.Add(this.Authors);
            this.groupBox1.Controls.Add(this.LoadYear);
            this.groupBox1.Controls.Add(this.publishedYear);
            this.groupBox1.Controls.Add(this.Publ);
            this.groupBox1.Controls.Add(this.PagesCount);
            this.groupBox1.Controls.Add(this.UDK);
            this.groupBox1.Controls.Add(this.FileSize);
            this.groupBox1.Controls.Add(this.BookName);
            this.groupBox1.Controls.Add(this.fileformat);
            this.groupBox1.Location = new System.Drawing.Point(562, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(461, 370);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Добавление книги";
            this.groupBox1.Visible = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // idBox
            // 
            this.idBox.Location = new System.Drawing.Point(68, 329);
            this.idBox.Maximum = new decimal(new int[] {
            2019,
            0,
            0,
            0});
            this.idBox.Name = "idBox";
            this.idBox.Size = new System.Drawing.Size(47, 22);
            this.idBox.TabIndex = 26;
            this.idBox.ValueChanged += new System.EventHandler(this.idBox_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 331);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 17);
            this.label3.TabIndex = 25;
            this.label3.Text = "ID";
            // 
            // CountryBox
            // 
            this.CountryBox.Location = new System.Drawing.Point(103, 295);
            this.CountryBox.Name = "CountryBox";
            this.CountryBox.Size = new System.Drawing.Size(352, 22);
            this.CountryBox.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 295);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 23;
            this.label2.Text = "Страна";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 264);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 22;
            this.label1.Text = "ФИО";
            // 
            // FIOBox
            // 
            this.FIOBox.Location = new System.Drawing.Point(89, 261);
            this.FIOBox.Name = "FIOBox";
            this.FIOBox.Size = new System.Drawing.Size(366, 22);
            this.FIOBox.TabIndex = 21;
            // 
            // yearBox
            // 
            this.yearBox.Location = new System.Drawing.Point(108, 182);
            this.yearBox.Maximum = new decimal(new int[] {
            2019,
            0,
            0,
            0});
            this.yearBox.Name = "yearBox";
            this.yearBox.Size = new System.Drawing.Size(120, 22);
            this.yearBox.TabIndex = 20;
            // 
            // dateTimePickerBox
            // 
            this.dateTimePickerBox.Location = new System.Drawing.Point(120, 213);
            this.dateTimePickerBox.Name = "dateTimePickerBox";
            this.dateTimePickerBox.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerBox.TabIndex = 19;
            // 
            // ADD
            // 
            this.ADD.Location = new System.Drawing.Point(306, 342);
            this.ADD.Name = "ADD";
            this.ADD.Size = new System.Drawing.Size(149, 28);
            this.ADD.TabIndex = 18;
            this.ADD.Text = "Добавить";
            this.ADD.UseVisualStyleBackColor = true;
            this.ADD.Click += new System.EventHandler(this.ADD_Click);
            // 
            // publBox
            // 
            this.publBox.Location = new System.Drawing.Point(117, 154);
            this.publBox.Name = "publBox";
            this.publBox.Size = new System.Drawing.Size(338, 22);
            this.publBox.TabIndex = 14;
            // 
            // pagescountBox
            // 
            this.pagescountBox.Location = new System.Drawing.Point(161, 126);
            this.pagescountBox.Name = "pagescountBox";
            this.pagescountBox.Size = new System.Drawing.Size(294, 22);
            this.pagescountBox.TabIndex = 13;
            // 
            // UDKBox
            // 
            this.UDKBox.Location = new System.Drawing.Point(121, 99);
            this.UDKBox.Name = "UDKBox";
            this.UDKBox.Size = new System.Drawing.Size(334, 22);
            this.UDKBox.TabIndex = 12;
            // 
            // sizebookBox
            // 
            this.sizebookBox.Location = new System.Drawing.Point(121, 73);
            this.sizebookBox.Name = "sizebookBox";
            this.sizebookBox.Size = new System.Drawing.Size(334, 22);
            this.sizebookBox.TabIndex = 11;
            // 
            // namebookBox
            // 
            this.namebookBox.Location = new System.Drawing.Point(124, 45);
            this.namebookBox.Name = "namebookBox";
            this.namebookBox.Size = new System.Drawing.Size(331, 22);
            this.namebookBox.TabIndex = 10;
            // 
            // fileFormatBox
            // 
            this.fileFormatBox.Location = new System.Drawing.Point(124, 16);
            this.fileFormatBox.Name = "fileFormatBox";
            this.fileFormatBox.Size = new System.Drawing.Size(331, 22);
            this.fileFormatBox.TabIndex = 9;
            this.fileFormatBox.TextChanged += new System.EventHandler(this.fileFormatBox_TextChanged);
            // 
            // Authors
            // 
            this.Authors.AutoSize = true;
            this.Authors.Location = new System.Drawing.Point(8, 239);
            this.Authors.Name = "Authors";
            this.Authors.Size = new System.Drawing.Size(61, 17);
            this.Authors.TabIndex = 8;
            this.Authors.Text = "Авторы:";
            // 
            // LoadYear
            // 
            this.LoadYear.AutoSize = true;
            this.LoadYear.Location = new System.Drawing.Point(7, 213);
            this.LoadYear.Name = "LoadYear";
            this.LoadYear.Size = new System.Drawing.Size(107, 17);
            this.LoadYear.TabIndex = 7;
            this.LoadYear.Text = "Дата загрузки:";
            // 
            // publishedYear
            // 
            this.publishedYear.AutoSize = true;
            this.publishedYear.Location = new System.Drawing.Point(7, 186);
            this.publishedYear.Name = "publishedYear";
            this.publishedYear.Size = new System.Drawing.Size(95, 17);
            this.publishedYear.TabIndex = 6;
            this.publishedYear.Text = "Год издания:";
            // 
            // Publ
            // 
            this.Publ.AutoSize = true;
            this.Publ.Location = new System.Drawing.Point(7, 159);
            this.Publ.Name = "Publ";
            this.Publ.Size = new System.Drawing.Size(104, 17);
            this.Publ.TabIndex = 5;
            this.Publ.Text = "Издательство:";
            // 
            // PagesCount
            // 
            this.PagesCount.AutoSize = true;
            this.PagesCount.Location = new System.Drawing.Point(7, 131);
            this.PagesCount.Name = "PagesCount";
            this.PagesCount.Size = new System.Drawing.Size(148, 17);
            this.PagesCount.TabIndex = 4;
            this.PagesCount.Text = "Количество страниц:";
            // 
            // UDK
            // 
            this.UDK.AutoSize = true;
            this.UDK.Location = new System.Drawing.Point(7, 104);
            this.UDK.Name = "UDK";
            this.UDK.Size = new System.Drawing.Size(41, 17);
            this.UDK.TabIndex = 3;
            this.UDK.Text = "УДК:";
            // 
            // FileSize
            // 
            this.FileSize.AutoSize = true;
            this.FileSize.Location = new System.Drawing.Point(7, 78);
            this.FileSize.Name = "FileSize";
            this.FileSize.Size = new System.Drawing.Size(108, 17);
            this.FileSize.TabIndex = 2;
            this.FileSize.Text = "Размер файла:";
            // 
            // BookName
            // 
            this.BookName.AutoSize = true;
            this.BookName.Location = new System.Drawing.Point(7, 50);
            this.BookName.Name = "BookName";
            this.BookName.Size = new System.Drawing.Size(116, 17);
            this.BookName.TabIndex = 1;
            this.BookName.Text = "Название книги:";
            // 
            // fileformat
            // 
            this.fileformat.AutoSize = true;
            this.fileformat.Location = new System.Drawing.Point(7, 22);
            this.fileformat.Name = "fileformat";
            this.fileformat.Size = new System.Drawing.Size(110, 17);
            this.fileformat.TabIndex = 0;
            this.fileformat.Text = "формат файла:";
            this.fileformat.Click += new System.EventHandler(this.label1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(85, 0);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(56, 21);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "light";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(3, 0);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(58, 21);
            this.checkBox2.TabIndex = 7;
            this.checkBox2.Text = "dark";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox2);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Location = new System.Drawing.Point(638, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(255, 22);
            this.panel1.TabIndex = 8;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // E_library
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 448);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.load);
            this.Controls.Add(this.serialisation);
            this.Controls.Add(this.delete_book);
            this.Controls.Add(this.add_book);
            this.Controls.Add(this.dataGridView1);
            this.Name = "E_library";
            this.Text = "Электронная библиотека";
            this.Load += new System.EventHandler(this.E_library_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.idBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yearBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button add_book;
        private System.Windows.Forms.Button delete_book;
        private System.Windows.Forms.Button serialisation;
        private System.Windows.Forms.Button load;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label fileformat;
        private System.Windows.Forms.Label BookName;
        private System.Windows.Forms.Label FileSize;
        private System.Windows.Forms.Label UDK;
        private System.Windows.Forms.Label PagesCount;
        private System.Windows.Forms.Label Publ;
        private System.Windows.Forms.Label publishedYear;
        private System.Windows.Forms.Label LoadYear;
        private System.Windows.Forms.TextBox publBox;
        private System.Windows.Forms.TextBox pagescountBox;
        private System.Windows.Forms.TextBox UDKBox;
        private System.Windows.Forms.TextBox sizebookBox;
        private System.Windows.Forms.TextBox namebookBox;
        private System.Windows.Forms.TextBox fileFormatBox;
        private System.Windows.Forms.Label Authors;
        private System.Windows.Forms.Button ADD;
        private System.Windows.Forms.DateTimePicker dateTimePickerBox;
        private System.Windows.Forms.NumericUpDown yearBox;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown idBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox CountryBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FIOBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn year;
        private System.Windows.Forms.DataGridViewTextBoxColumn author_list;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}

