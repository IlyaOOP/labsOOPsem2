namespace lab1
{
    partial class Form2
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
            this.sizebox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ascendingSort = new System.Windows.Forms.Button();
            this.descendingSort = new System.Windows.Forms.Button();
            this.LINQ1 = new System.Windows.Forms.Button();
            this.LINQ2 = new System.Windows.Forms.Button();
            this.LINQ3 = new System.Windows.Forms.Button();
            this.generatedCollection = new System.Windows.Forms.ListBox();
            this.finalCollection = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(385, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Размер коллекции";
            // 
            // sizebox
            // 
            this.sizebox.Location = new System.Drawing.Point(388, 29);
            this.sizebox.MaxLength = 5;
            this.sizebox.Name = "sizebox";
            this.sizebox.Size = new System.Drawing.Size(128, 22);
            this.sizebox.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(262, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(392, 88);
            this.button1.TabIndex = 2;
            this.button1.Text = "сгенерировать коллекцию";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ascendingSort
            // 
            this.ascendingSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ascendingSort.Location = new System.Drawing.Point(696, 70);
            this.ascendingSort.Name = "ascendingSort";
            this.ascendingSort.Size = new System.Drawing.Size(126, 88);
            this.ascendingSort.TabIndex = 3;
            this.ascendingSort.Text = "сортировать по возрастанию";
            this.ascendingSort.UseVisualStyleBackColor = true;
            this.ascendingSort.Click += new System.EventHandler(this.ascendingSort_Click);
            // 
            // descendingSort
            // 
            this.descendingSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.descendingSort.Location = new System.Drawing.Point(98, 70);
            this.descendingSort.Name = "descendingSort";
            this.descendingSort.Size = new System.Drawing.Size(126, 88);
            this.descendingSort.TabIndex = 4;
            this.descendingSort.Text = "сортировать по убыванию";
            this.descendingSort.UseVisualStyleBackColor = true;
            this.descendingSort.Click += new System.EventHandler(this.descendingSort_Click);
            // 
            // LINQ1
            // 
            this.LINQ1.Location = new System.Drawing.Point(98, 176);
            this.LINQ1.Name = "LINQ1";
            this.LINQ1.Size = new System.Drawing.Size(126, 46);
            this.LINQ1.TabIndex = 5;
            this.LINQ1.Text = "запрос №1";
            this.LINQ1.UseVisualStyleBackColor = true;
            this.LINQ1.Click += new System.EventHandler(this.LINQ1_Click);
            // 
            // LINQ2
            // 
            this.LINQ2.Location = new System.Drawing.Point(388, 176);
            this.LINQ2.Name = "LINQ2";
            this.LINQ2.Size = new System.Drawing.Size(128, 46);
            this.LINQ2.TabIndex = 6;
            this.LINQ2.Text = "запрос №2";
            this.LINQ2.UseVisualStyleBackColor = true;
            this.LINQ2.Click += new System.EventHandler(this.LINQ2_Click);
            // 
            // LINQ3
            // 
            this.LINQ3.Location = new System.Drawing.Point(696, 176);
            this.LINQ3.Name = "LINQ3";
            this.LINQ3.Size = new System.Drawing.Size(126, 46);
            this.LINQ3.TabIndex = 7;
            this.LINQ3.Text = "запрос №3";
            this.LINQ3.UseVisualStyleBackColor = true;
            this.LINQ3.Click += new System.EventHandler(this.LINQ3_Click);
            // 
            // generatedCollection
            // 
            this.generatedCollection.FormattingEnabled = true;
            this.generatedCollection.ItemHeight = 16;
            this.generatedCollection.Location = new System.Drawing.Point(98, 240);
            this.generatedCollection.Name = "generatedCollection";
            this.generatedCollection.Size = new System.Drawing.Size(292, 196);
            this.generatedCollection.TabIndex = 8;
            // 
            // finalCollection
            // 
            this.finalCollection.FormattingEnabled = true;
            this.finalCollection.ItemHeight = 16;
            this.finalCollection.Location = new System.Drawing.Point(517, 240);
            this.finalCollection.Name = "finalCollection";
            this.finalCollection.Size = new System.Drawing.Size(305, 196);
            this.finalCollection.TabIndex = 9;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(882, 450);
            this.Controls.Add(this.finalCollection);
            this.Controls.Add(this.generatedCollection);
            this.Controls.Add(this.LINQ3);
            this.Controls.Add(this.LINQ2);
            this.Controls.Add(this.LINQ1);
            this.Controls.Add(this.descendingSort);
            this.Controls.Add(this.ascendingSort);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.sizebox);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox sizebox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button ascendingSort;
        private System.Windows.Forms.Button descendingSort;
        private System.Windows.Forms.Button LINQ1;
        private System.Windows.Forms.Button LINQ2;
        private System.Windows.Forms.Button LINQ3;
        private System.Windows.Forms.ListBox generatedCollection;
        private System.Windows.Forms.ListBox finalCollection;
    }
}