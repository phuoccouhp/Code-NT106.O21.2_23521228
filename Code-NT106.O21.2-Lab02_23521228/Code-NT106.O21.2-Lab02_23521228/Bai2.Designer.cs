namespace Code_NT106.O21._2_Lab02_23521228
{
    partial class Bai2
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
            RTB = new RichTextBox();
            BTN_Doc = new Button();
            BTN_Exit = new Button();
            LB1 = new Label();
            LB2 = new Label();
            LB3 = new Label();
            LB4 = new Label();
            LB5 = new Label();
            LB6 = new Label();
            TB_Filename = new TextBox();
            TB_Size = new TextBox();
            TB_Url = new TextBox();
            TB_Linecount = new TextBox();
            TB_Wordcount = new TextBox();
            TB_Charcount = new TextBox();
            SuspendLayout();
            // 
            // RTB
            // 
            RTB.Dock = DockStyle.Right;
            RTB.Location = new Point(383, 0);
            RTB.Name = "RTB";
            RTB.Size = new Size(417, 450);
            RTB.TabIndex = 17;
            RTB.Text = "";
            // 
            // BTN_Doc
            // 
            BTN_Doc.Font = new Font("Segoe UI", 12F);
            BTN_Doc.Location = new Point(26, 12);
            BTN_Doc.Name = "BTN_Doc";
            BTN_Doc.Size = new Size(262, 39);
            BTN_Doc.TabIndex = 15;
            BTN_Doc.Text = "Đọc File";
            BTN_Doc.UseVisualStyleBackColor = true;
            BTN_Doc.Click += BTN_Doc_Click;
            // 
            // BTN_Exit
            // 
            BTN_Exit.Font = new Font("Segoe UI", 12F);
            BTN_Exit.Location = new Point(26, 379);
            BTN_Exit.Name = "BTN_Exit";
            BTN_Exit.Size = new Size(262, 39);
            BTN_Exit.TabIndex = 18;
            BTN_Exit.Text = "Exit";
            BTN_Exit.UseVisualStyleBackColor = true;
            BTN_Exit.Click += BTN_Exit_Click;
            // 
            // LB1
            // 
            LB1.AutoSize = true;
            LB1.Font = new Font("Segoe UI", 11F);
            LB1.Location = new Point(2, 70);
            LB1.Name = "LB1";
            LB1.Size = new Size(93, 25);
            LB1.TabIndex = 19;
            LB1.Text = "File name";
            // 
            // LB2
            // 
            LB2.AutoSize = true;
            LB2.Font = new Font("Segoe UI", 11F);
            LB2.Location = new Point(2, 115);
            LB2.Name = "LB2";
            LB2.Size = new Size(46, 25);
            LB2.TabIndex = 20;
            LB2.Text = "Size";
            // 
            // LB3
            // 
            LB3.AutoSize = true;
            LB3.Font = new Font("Segoe UI", 11F);
            LB3.Location = new Point(3, 164);
            LB3.Name = "LB3";
            LB3.Size = new Size(45, 25);
            LB3.TabIndex = 21;
            LB3.Text = "URL";
            // 
            // LB4
            // 
            LB4.AutoSize = true;
            LB4.Font = new Font("Segoe UI", 11F);
            LB4.Location = new Point(2, 212);
            LB4.Name = "LB4";
            LB4.Size = new Size(100, 25);
            LB4.TabIndex = 22;
            LB4.Text = "Line count";
            // 
            // LB5
            // 
            LB5.AutoSize = true;
            LB5.Font = new Font("Segoe UI", 11F);
            LB5.Location = new Point(2, 266);
            LB5.Name = "LB5";
            LB5.Size = new Size(119, 25);
            LB5.TabIndex = 23;
            LB5.Text = "Words count";
            // 
            // LB6
            // 
            LB6.AutoSize = true;
            LB6.Font = new Font("Segoe UI", 11F);
            LB6.Location = new Point(2, 322);
            LB6.Name = "LB6";
            LB6.Size = new Size(147, 25);
            LB6.TabIndex = 24;
            LB6.Text = "Character count";
            // 
            // TB_Filename
            // 
            TB_Filename.Location = new Point(153, 70);
            TB_Filename.Name = "TB_Filename";
            TB_Filename.Size = new Size(213, 27);
            TB_Filename.TabIndex = 25;
            // 
            // TB_Size
            // 
            TB_Size.Location = new Point(153, 113);
            TB_Size.Name = "TB_Size";
            TB_Size.Size = new Size(213, 27);
            TB_Size.TabIndex = 26;
            // 
            // TB_Url
            // 
            TB_Url.Location = new Point(153, 164);
            TB_Url.Name = "TB_Url";
            TB_Url.Size = new Size(213, 27);
            TB_Url.TabIndex = 27;
            // 
            // TB_Linecount
            // 
            TB_Linecount.Location = new Point(153, 213);
            TB_Linecount.Name = "TB_Linecount";
            TB_Linecount.Size = new Size(213, 27);
            TB_Linecount.TabIndex = 28;
            // 
            // TB_Wordcount
            // 
            TB_Wordcount.Location = new Point(153, 267);
            TB_Wordcount.Name = "TB_Wordcount";
            TB_Wordcount.Size = new Size(213, 27);
            TB_Wordcount.TabIndex = 29;
            // 
            // TB_Charcount
            // 
            TB_Charcount.Location = new Point(153, 320);
            TB_Charcount.Name = "TB_Charcount";
            TB_Charcount.Size = new Size(213, 27);
            TB_Charcount.TabIndex = 30;
            // 
            // Bai2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(TB_Charcount);
            Controls.Add(TB_Wordcount);
            Controls.Add(TB_Linecount);
            Controls.Add(TB_Url);
            Controls.Add(TB_Size);
            Controls.Add(TB_Filename);
            Controls.Add(LB6);
            Controls.Add(LB5);
            Controls.Add(LB4);
            Controls.Add(LB3);
            Controls.Add(LB2);
            Controls.Add(LB1);
            Controls.Add(BTN_Exit);
            Controls.Add(RTB);
            Controls.Add(BTN_Doc);
            Name = "Bai2";
            Text = "Bai2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox RTB;
        private Button BTN_Doc;
        private Button BTN_Exit;
        private Label LB1;
        private Label LB2;
        private Label LB3;
        private Label LB4;
        private Label LB5;
        private Label LB6;
        private TextBox TB_Filename;
        private TextBox TB_Size;
        private TextBox TB_Url;
        private TextBox TB_Linecount;
        private TextBox TB_Wordcount;
        private TextBox TB_Charcount;
    }
}