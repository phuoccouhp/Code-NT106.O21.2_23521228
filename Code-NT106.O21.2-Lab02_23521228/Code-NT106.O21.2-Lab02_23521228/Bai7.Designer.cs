namespace Code_NT106.O21._2_Lab02_23521228
{
    partial class Bai7
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
            splitContainer1 = new SplitContainer();
            TV = new TreeView();
            PB = new PictureBox();
            RTB = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PB).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(TV);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(PB);
            splitContainer1.Panel2.Controls.Add(RTB);
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 266;
            splitContainer1.TabIndex = 0;
            // 
            // TV
            // 
            TV.Dock = DockStyle.Fill;
            TV.Location = new Point(0, 0);
            TV.Name = "TV";
            TV.Size = new Size(266, 450);
            TV.TabIndex = 0;
            // 
            // PB
            // 
            PB.Location = new Point(3, 0);
            PB.Name = "PB";
            PB.Size = new Size(524, 447);
            PB.SizeMode = PictureBoxSizeMode.Zoom;
            PB.TabIndex = 2;
            PB.TabStop = false;
            // 
            // RTB
            // 
            RTB.Dock = DockStyle.Fill;
            RTB.Location = new Point(0, 0);
            RTB.Name = "RTB";
            RTB.ReadOnly = true;
            RTB.Size = new Size(530, 450);
            RTB.TabIndex = 1;
            RTB.Text = "";
            // 
            // Bai7
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Name = "Bai7";
            Text = "Bai7";
            Load += Bai7_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PB).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private TreeView TV;
        private RichTextBox RTB;
        private PictureBox PB;
    }
}