namespace lab2
{
    partial class Информация
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
            this.outputInfo = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // outputInfo
            // 
            this.outputInfo.BackColor = System.Drawing.SystemColors.Menu;
            this.outputInfo.Location = new System.Drawing.Point(12, 12);
            this.outputInfo.Name = "outputInfo";
            this.outputInfo.Size = new System.Drawing.Size(551, 344);
            this.outputInfo.TabIndex = 0;
            this.outputInfo.Text = "";
            // 
            // Информация
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 368);
            this.Controls.Add(this.outputInfo);
            this.Name = "Информация";
            this.Text = "Form2";
            this.TransparencyKey = System.Drawing.Color.White;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox outputInfo;
    }
}