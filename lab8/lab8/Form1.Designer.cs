namespace lab8
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboFIO = new System.Windows.Forms.ComboBox();
            this.addbookbut = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.booksizefield = new System.Windows.Forms.TextBox();
            this.booknamefield = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.addauthbut = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.authornamemain = new System.Windows.Forms.TextBox();
            this.authorcode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "название книги";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "размер книги";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboFIO);
            this.groupBox1.Controls.Add(this.addbookbut);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.booksizefield);
            this.groupBox1.Controls.Add(this.booknamefield);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(383, 425);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "добавление книги";
            // 
            // comboFIO
            // 
            this.comboFIO.FormattingEnabled = true;
            this.comboFIO.Location = new System.Drawing.Point(7, 155);
            this.comboFIO.Name = "comboFIO";
            this.comboFIO.Size = new System.Drawing.Size(121, 24);
            this.comboFIO.TabIndex = 11;
            // 
            // addbookbut
            // 
            this.addbookbut.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addbookbut.Location = new System.Drawing.Point(78, 330);
            this.addbookbut.Name = "addbookbut";
            this.addbookbut.Size = new System.Drawing.Size(210, 89);
            this.addbookbut.TabIndex = 10;
            this.addbookbut.Text = "Добавить";
            this.addbookbut.UseVisualStyleBackColor = true;
            this.addbookbut.Click += new System.EventHandler(this.addbookbut_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "ФИО автора";
            // 
            // booksizefield
            // 
            this.booksizefield.Location = new System.Drawing.Point(9, 100);
            this.booksizefield.Name = "booksizefield";
            this.booksizefield.Size = new System.Drawing.Size(370, 22);
            this.booksizefield.TabIndex = 3;
            this.booksizefield.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // booknamefield
            // 
            this.booknamefield.Location = new System.Drawing.Point(7, 51);
            this.booknamefield.Name = "booknamefield";
            this.booknamefield.Size = new System.Drawing.Size(370, 22);
            this.booknamefield.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.addauthbut);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.authornamemain);
            this.groupBox2.Controls.Add(this.authorcode);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(405, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(383, 425);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "добавление автора";
            // 
            // addauthbut
            // 
            this.addauthbut.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addauthbut.Location = new System.Drawing.Point(99, 330);
            this.addauthbut.Name = "addauthbut";
            this.addauthbut.Size = new System.Drawing.Size(210, 89);
            this.addauthbut.TabIndex = 9;
            this.addauthbut.Text = "Добавить";
            this.addauthbut.UseVisualStyleBackColor = true;
            this.addauthbut.Click += new System.EventHandler(this.addauthbut_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 152);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "выбрать фото";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // authornamemain
            // 
            this.authornamemain.Location = new System.Drawing.Point(6, 100);
            this.authornamemain.Name = "authornamemain";
            this.authornamemain.Size = new System.Drawing.Size(370, 22);
            this.authornamemain.TabIndex = 6;
            // 
            // authorcode
            // 
            this.authorcode.Location = new System.Drawing.Point(6, 50);
            this.authorcode.Name = "authorcode";
            this.authorcode.Size = new System.Drawing.Size(370, 22);
            this.authorcode.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "ФИО автора";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "код автора";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Добавить запись";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox booksizefield;
        private System.Windows.Forms.TextBox booknamefield;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox authornamemain;
        private System.Windows.Forms.TextBox authorcode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button addbookbut;
        private System.Windows.Forms.Button addauthbut;
        private System.Windows.Forms.ComboBox comboFIO;
    }
}