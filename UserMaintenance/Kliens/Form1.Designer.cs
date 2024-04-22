namespace Kliens
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listBox1 = new ListBox();
            textBox1 = new TextBox();
            Cancel = new Button();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox2 = new TextBox();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            label5 = new Label();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.BackColor = Color.FromArgb(36, 36, 35);
            listBox1.ForeColor = Color.White;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 20;
            listBox1.Location = new Point(57, 67);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(243, 344);
            listBox1.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(35, 35, 36);
            textBox1.ForeColor = Color.White;
            textBox1.Location = new Point(57, 23);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 27);
            textBox1.TabIndex = 1;
            // 
            // Cancel
            // 
            Cancel.BackColor = Color.FromArgb(64, 64, 64);
            Cancel.DialogResult = DialogResult.Cancel;
            Cancel.ForeColor = Color.White;
            Cancel.Location = new Point(521, 359);
            Cancel.Name = "Cancel";
            Cancel.Size = new Size(94, 29);
            Cancel.TabIndex = 2;
            Cancel.Text = "Mégse";
            Cancel.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(236, 221, 34);
            button1.Location = new Point(631, 359);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 3;
            button1.Text = "Mentés";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(36, 36, 35);
            label1.ForeColor = Color.White;
            label1.Location = new Point(513, 220);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 4;
            label1.Text = "Elérhető:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(36, 36, 35);
            label2.ForeColor = Color.White;
            label2.Location = new Point(683, 220);
            label2.Name = "label2";
            label2.Size = new Size(27, 20);
            label2.TabIndex = 5;
            label2.Text = "db";
//            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(64, 64, 64);
            label3.ForeColor = Color.White;
            label3.Location = new Point(463, 290);
            label3.Name = "label3";
            label3.Size = new Size(119, 20);
            label3.TabIndex = 6;
            label3.Text = "Újonnan eladott:";
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.Silver;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Location = new Point(605, 290);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(51, 20);
            textBox2.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(64, 64, 64);
            label4.ForeColor = Color.White;
            label4.Location = new Point(685, 290);
            label4.Name = "label4";
            label4.Size = new Size(27, 20);
            label4.TabIndex = 8;
            label4.Text = "db";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(36, 36, 35);
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.Location = new Point(418, 67);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(345, 344);
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
//            pictureBox1.Click += pictureBox1_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.FromArgb(36, 36, 35);
            label5.ForeColor = Color.White;
            label5.Location = new Point(631, 220);
            label5.Name = "label5";
            label5.Size = new Size(25, 20);
            label5.TabIndex = 10;
            label5.Text = "50";
            // 
            // pictureBox2
            // 
            pictureBox2.BorderStyle = BorderStyle.Fixed3D;
            pictureBox2.Location = new Point(454, 273);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(271, 51);
            pictureBox2.TabIndex = 11;
            pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(pictureBox2);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(Cancel);
            Controls.Add(textBox1);
            Controls.Add(listBox1);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private TextBox textBox1;
        private Button Cancel;
        private Button button1;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox2;
        private Label label4;
        private PictureBox pictureBox1;
        private Label label5;
        private PictureBox pictureBox2;
    }
}