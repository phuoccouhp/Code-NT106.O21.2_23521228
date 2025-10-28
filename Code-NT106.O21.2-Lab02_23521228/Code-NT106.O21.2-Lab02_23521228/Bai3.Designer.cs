namespace Code_NT106.O21._2_Lab02_23521228
{
    partial class Bai3
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
            BTN_Tinh = new Button();
            BTN_Doc = new Button();
            SuspendLayout();
            // 
            // RTB
            // 
            RTB.Dock = DockStyle.Right;
            RTB.Location = new Point(246, 0);
            RTB.Name = "RTB";
            RTB.ReadOnly = true;
            RTB.Size = new Size(554, 450);
            RTB.TabIndex = 17;
            RTB.TabStop = false;
            RTB.Text = "";
            // 
            // BTN_Tinh
            // 
            BTN_Tinh.Font = new Font("Segoe UI", 12F);
            BTN_Tinh.Location = new Point(43, 242);
            BTN_Tinh.Name = "BTN_Tinh";
            BTN_Tinh.Size = new Size(139, 49);
            BTN_Tinh.TabIndex = 16;
            BTN_Tinh.Text = "Tính Toán";
            BTN_Tinh.UseVisualStyleBackColor = true;
            BTN_Tinh.Click += BTN_Tinh_Click;
            // 
            // BTN_Doc
            // 
            BTN_Doc.Font = new Font("Segoe UI", 12F);
            BTN_Doc.Location = new Point(43, 109);
            BTN_Doc.Name = "BTN_Doc";
            BTN_Doc.Size = new Size(139, 49);
            BTN_Doc.TabIndex = 15;
            BTN_Doc.Text = "Đọc File";
            BTN_Doc.UseVisualStyleBackColor = true;
            BTN_Doc.Click += BTN_Doc_Click;
            // 
            // Bai3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(RTB);
            Controls.Add(BTN_Tinh);
            Controls.Add(BTN_Doc);
            Name = "Bai3";
            Text = "Bai3";
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox RTB;
        private Button BTN_Tinh;
        private Button BTN_Doc;
    }
}