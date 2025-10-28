namespace Code_NT106.O21._2_Lab02_23521228
{
    partial class Bai1
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
            BTN_Ghi = new Button();
            BTN_Doc = new Button();
            RTB = new RichTextBox();
            SuspendLayout();
            // 
            // BTN_Ghi
            // 
            BTN_Ghi.Font = new Font("Segoe UI", 12F);
            BTN_Ghi.Location = new Point(86, 242);
            BTN_Ghi.Name = "BTN_Ghi";
            BTN_Ghi.Size = new Size(139, 49);
            BTN_Ghi.TabIndex = 13;
            BTN_Ghi.Text = "Ghi File";
            BTN_Ghi.UseVisualStyleBackColor = true;
            BTN_Ghi.Click += BTN_Ghi_Click;
            // 
            // BTN_Doc
            // 
            BTN_Doc.Font = new Font("Segoe UI", 12F);
            BTN_Doc.Location = new Point(86, 109);
            BTN_Doc.Name = "BTN_Doc";
            BTN_Doc.Size = new Size(139, 49);
            BTN_Doc.TabIndex = 12;
            BTN_Doc.Text = "Đọc File";
            BTN_Doc.UseVisualStyleBackColor = true;
            BTN_Doc.Click += BTN_Doc_Click;
            // 
            // RTB
            // 
            RTB.Dock = DockStyle.Right;
            RTB.Location = new Point(307, 0);
            RTB.Name = "RTB";
            RTB.Size = new Size(493, 450);
            RTB.TabIndex = 14;
            RTB.Text = "";
            RTB.TextChanged += richTextBox1_TextChanged;
            // 
            // Bai1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(RTB);
            Controls.Add(BTN_Ghi);
            Controls.Add(BTN_Doc);
            Name = "Bai1";
            Text = "Bai1";
            ResumeLayout(false);
        }

        #endregion

        private Button BTN_Ghi;
        private Button BTN_Doc;
        private RichTextBox RTB;
    }
}