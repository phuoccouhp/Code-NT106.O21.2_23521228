using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Code_NT106.O21._2_Lab02_23521228
{
    public partial class Bai1 : Form
    {
        public Bai1()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void BTN_Doc_Click(object sender, EventArgs e)
        {
            string inputFilePath = "input1.txt";

            try
            {
                if (!File.Exists(inputFilePath))
                {
                    MessageBox.Show("Không tìm thấy file input1.txt!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                using (StreamReader sr = new StreamReader(inputFilePath))
                {
                    string content = sr.ReadToEnd();
                    RTB.Text = content;
                }
            }
            catch
            {
                MessageBox.Show("Đã xảy ra lỗi khi đọc file: ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
        }

        private void BTN_Ghi_Click(object sender, EventArgs e)
        {
          
                string outputFilePath = "output1.txt"; 

                try
                {
                if (!File.Exists(outputFilePath))
                {
                    MessageBox.Show("Không tìm thấy file output1.txt!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string content = RTB.Text;
                    string upperCaseContent = content.ToUpper();
                    using (StreamWriter sw = new StreamWriter(outputFilePath))
                    {
                        sw.Write(upperCaseContent);
                    }
                    MessageBox.Show("Đã ghi file output1.txt thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch 
                {
                    MessageBox.Show("Đã xảy ra lỗi khi ghi file: " , "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
        }
    }
}
