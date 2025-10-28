using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Code_NT106.O21._2_Lab02_23521228
{
    public partial class Bai2 : Form
    {
        public Bai2()
        {
            InitializeComponent();
            Color darkBackground = Color.FromArgb(45, 45, 48);
            Color labelBlue = Color.DeepSkyBlue;
            Color textWhite = Color.White;
            Color buttonGray = Color.FromArgb(63, 63, 70);
            foreach (Control c in this.Controls)
            {
                if (c is Label)
                {
                    ((Label)c).ForeColor = labelBlue;
                }
            }
            this.BackColor = darkBackground;
            RTB.BackColor = buttonGray;
            RTB.ForeColor = labelBlue; 
            RTB.ReadOnly = true;
            BTN_Exit.FlatStyle = FlatStyle.Flat;
            BTN_Exit.FlatAppearance.BorderSize = 0;
            BTN_Exit.BackColor = Color.Lime; 
            BTN_Exit.ForeColor = Color.Black;
        }

        private void BTN_Doc_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files (*.txt)|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = ofd.FileName;
                    using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        TB_Url.Text = fs.Name;
                        TB_Size.Text = fs.Length.ToString() + " bytes";
                        using (StreamReader sr = new StreamReader(fs))
                        {
                            string content = sr.ReadToEnd();
                            RTB.Text = content;
                            TB_Filename.Text = ofd.SafeFileName;
                            TB_Charcount.Text = content.Length.ToString();
                            string[] lines = content.Split(new[] { "\r\n", "\r", "\n" },
                                                         StringSplitOptions.None);
                            TB_Linecount.Text = lines.Length.ToString();
                            char[] delimiters = new char[] { ' ', '\r', '\n', '\t' };
                            string[] words = content.Split(delimiters,
                                                       StringSplitOptions.RemoveEmptyEntries);
                            TB_Wordcount.Text = words.Length.ToString();
                        }
                    }
                }
                catch 
                {
                    MessageBox.Show("Đã xảy ra lỗi khi đọc file: " , "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BTN_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
