namespace lab13
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
            this.type = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.objtype = new System.Windows.Forms.ComboBox();
            this.objnum = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.objnum)).BeginInit();
            this.SuspendLayout();
            // 
            // type
            // 
            this.type.Location = new System.Drawing.Point(27, 29);
            this.type.Name = "type";
            this.type.ReadOnly = true;
            this.type.Size = new System.Drawing.Size(90, 22);
            this.type.TabIndex = 0;
            this.type.TabStop = false;
            this.type.Text = "тип объекта";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(27, 112);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(153, 22);
            this.textBox1.TabIndex = 1;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "количество объектов";
            // 
            // objtype
            // 
            this.objtype.FormattingEnabled = true;
            this.objtype.Location = new System.Drawing.Point(263, 29);
            this.objtype.Name = "objtype";
            this.objtype.Size = new System.Drawing.Size(121, 24);
            this.objtype.TabIndex = 2;
            // 
            // objnum
            // 
            this.objnum.Location = new System.Drawing.Point(263, 111);
            this.objnum.Name = "objnum";
            this.objnum.Size = new System.Drawing.Size(120, 22);
            this.objnum.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 191);
            this.Controls.Add(this.objnum);
            this.Controls.Add(this.objtype);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.type);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.objnum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox type;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox objtype;
        private System.Windows.Forms.NumericUpDown objnum;
    }
}