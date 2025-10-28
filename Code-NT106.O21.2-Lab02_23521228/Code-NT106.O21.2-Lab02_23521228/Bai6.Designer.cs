namespace Code_NT106.O21._2_Lab02_23521228
{
    partial class Bai6
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
            TB_KQ = new TextBox();
            label1 = new Label();
            BT_Tim = new Button();
            BT_Thoat = new Button();
            BT_Xoa = new Button();
            LV = new ListView();
            TenMonAn = new ColumnHeader();
            PB_Monan = new PictureBox();
            LB_NgDongGop = new Label();
            LB_TenNgDG = new Label();
            LB2 = new Label();
            TB1 = new TextBox();
            TB2 = new TextBox();
            LB3 = new Label();
            BTN1 = new Button();
            ((System.ComponentModel.ISupportInitialize)PB_Monan).BeginInit();
            SuspendLayout();
            // 
            // TB_KQ
            // 
            TB_KQ.Location = new Point(281, 568);
            TB_KQ.Name = "TB_KQ";
            TB_KQ.Size = new Size(270, 27);
            TB_KQ.TabIndex = 47;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(61, 568);
            label1.Name = "label1";
            label1.Size = new Size(184, 28);
            label1.TabIndex = 46;
            label1.Text = "Món ăn hôm nay là:";
            // 
            // BT_Tim
            // 
            BT_Tim.Font = new Font("Segoe UI", 12F);
            BT_Tim.Location = new Point(61, 503);
            BT_Tim.Name = "BT_Tim";
            BT_Tim.Size = new Size(151, 42);
            BT_Tim.TabIndex = 45;
            BT_Tim.Text = "Tìm món ăn";
            BT_Tim.UseVisualStyleBackColor = true;
            BT_Tim.Click += BT_Tim_Click;
            // 
            // BT_Thoat
            // 
            BT_Thoat.Font = new Font("Segoe UI", 12F);
            BT_Thoat.Location = new Point(640, 503);
            BT_Thoat.Name = "BT_Thoat";
            BT_Thoat.Size = new Size(113, 42);
            BT_Thoat.TabIndex = 42;
            BT_Thoat.Text = "Thoát";
            BT_Thoat.UseVisualStyleBackColor = true;
            BT_Thoat.Click += BT_Thoat_Click;
            // 
            // BT_Xoa
            // 
            BT_Xoa.Font = new Font("Segoe UI", 12F);
            BT_Xoa.Location = new Point(352, 503);
            BT_Xoa.Name = "BT_Xoa";
            BT_Xoa.Size = new Size(113, 42);
            BT_Xoa.TabIndex = 41;
            BT_Xoa.Text = "Xoá";
            BT_Xoa.UseVisualStyleBackColor = true;
            BT_Xoa.Click += BT_Xoa_Click;
            // 
            // LV
            // 
            LV.Columns.AddRange(new ColumnHeader[] { TenMonAn });
            LV.GridLines = true;
            LV.Location = new Point(385, 125);
            LV.Name = "LV";
            LV.Size = new Size(403, 344);
            LV.TabIndex = 48;
            LV.UseCompatibleStateImageBehavior = false;
            LV.View = View.Details;
            // 
            // TenMonAn
            // 
            TenMonAn.Text = "Tên Món Ăn";
            // 
            // PB_Monan
            // 
            PB_Monan.BorderStyle = BorderStyle.FixedSingle;
            PB_Monan.Location = new Point(38, 125);
            PB_Monan.Name = "PB_Monan";
            PB_Monan.Size = new Size(341, 344);
            PB_Monan.SizeMode = PictureBoxSizeMode.Zoom;
            PB_Monan.TabIndex = 49;
            PB_Monan.TabStop = false;
            // 
            // LB_NgDongGop
            // 
            LB_NgDongGop.AutoSize = true;
            LB_NgDongGop.Font = new Font("Segoe UI", 12F);
            LB_NgDongGop.Location = new Point(352, 472);
            LB_NgDongGop.Name = "LB_NgDongGop";
            LB_NgDongGop.Size = new Size(165, 28);
            LB_NgDongGop.TabIndex = 50;
            LB_NgDongGop.Text = "Người đóng góp:";
            // 
            // LB_TenNgDG
            // 
            LB_TenNgDG.AutoSize = true;
            LB_TenNgDG.Font = new Font("Segoe UI", 12F);
            LB_TenNgDG.Location = new Point(523, 472);
            LB_TenNgDG.Name = "LB_TenNgDG";
            LB_TenNgDG.Size = new Size(17, 28);
            LB_TenNgDG.TabIndex = 51;
            LB_TenNgDG.Text = " ";
            // 
            // LB2
            // 
            LB2.AutoSize = true;
            LB2.Font = new Font("Segoe UI", 12F);
            LB2.Location = new Point(120, 28);
            LB2.Name = "LB2";
            LB2.Size = new Size(152, 28);
            LB2.TabIndex = 52;
            LB2.Text = "Tên người thêm:";
            // 
            // TB1
            // 
            TB1.Location = new Point(284, 29);
            TB1.Name = "TB1";
            TB1.Size = new Size(286, 27);
            TB1.TabIndex = 53;
            // 
            // TB2
            // 
            TB2.Location = new Point(284, 74);
            TB2.Name = "TB2";
            TB2.Size = new Size(286, 27);
            TB2.TabIndex = 54;
            // 
            // LB3
            // 
            LB3.AutoSize = true;
            LB3.Font = new Font("Segoe UI", 12F);
            LB3.Location = new Point(120, 73);
            LB3.Name = "LB3";
            LB3.Size = new Size(103, 28);
            LB3.TabIndex = 55;
            LB3.Text = "Món thêm";
            // 
            // BTN1
            // 
            BTN1.Font = new Font("Segoe UI", 12F);
            BTN1.Location = new Point(624, 46);
            BTN1.Name = "BTN1";
            BTN1.Size = new Size(114, 42);
            BTN1.TabIndex = 56;
            BTN1.Text = "Thêm";
            BTN1.UseVisualStyleBackColor = true;
            BTN1.Click += button1_Click;
            // 
            // Bai6
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 616);
            Controls.Add(BTN1);
            Controls.Add(LB3);
            Controls.Add(TB2);
            Controls.Add(TB1);
            Controls.Add(LB2);
            Controls.Add(LB_TenNgDG);
            Controls.Add(LB_NgDongGop);
            Controls.Add(PB_Monan);
            Controls.Add(LV);
            Controls.Add(TB_KQ);
            Controls.Add(label1);
            Controls.Add(BT_Tim);
            Controls.Add(BT_Thoat);
            Controls.Add(BT_Xoa);
            Name = "Bai6";
            Text = "Bai6";
            ((System.ComponentModel.ISupportInitialize)PB_Monan).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TB_KQ;
        private Label label1;
        private Button BT_Tim;
        private Button BT_Thoat;
        private Button BT_Xoa;
        private ListView LV;
        private ColumnHeader TenMonAn;
        private PictureBox PB_Monan;
        private Label LB_NgDongGop;
        private Label LB_TenNgDG;
        private Label LB2;
        private TextBox TB1;
        private TextBox TB2;
        private Label LB3;
        private Button BTN1;
    }
}