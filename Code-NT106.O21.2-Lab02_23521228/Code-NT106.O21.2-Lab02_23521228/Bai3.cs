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
using System.Collections.Generic;
using System.Globalization;
namespace Code_NT106.O21._2_Lab02_23521228
{
    public partial class Bai3 : Form
    {
        public Bai3()
        {
            InitializeComponent();
        }

        private void BTN_Doc_Click(object sender, EventArgs e)
        {
            string inputFile = "input3.txt";
            try
            {
                if (!File.Exists(inputFile))
                {
                    MessageBox.Show("Không tìm thấy file input3.txt!", "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string[] allLines = File.ReadAllLines(inputFile);
                RTB.Lines = allLines;

                MessageBox.Show("Đọc file input3.txt thành công!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch 
            {
                MessageBox.Show("Đã xảy ra lỗi khi đọc file: " , "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTN_Tinh_Click(object sender, EventArgs e)
        {
            string outputFile = "output3.txt";
            try
            {
                string[] lines = RTB.Lines;

                if (lines.Length == 0)
                {
                    MessageBox.Show("Không có nội dung để tính toán. Vui lòng đọc file trước.", "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                List<string> outputLines = new List<string>();
                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        outputLines.Add("");
                        continue;
                    }

                    try
                    {
                        double result = tinhtoan(line);
                        string resultString = result.ToString("#.#", CultureInfo.InvariantCulture);
                        string outputLine = $"{line} = {resultString}";

                        outputLines.Add(outputLine);
                    }
                    catch (Exception ex)
                    {
                        outputLines.Add($"{line} = LỖI: {ex.Message}");
                    }
                }
                RTB.Lines = outputLines.ToArray();
                File.WriteAllLines(outputFile, outputLines);

                MessageBox.Show("Tính toán và ghi file output3.txt thành công!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch 
            {
                MessageBox.Show("Đã xảy ra lỗi khi tính toán hoặc ghi file: " , "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private double tinhtoan(string expression)
        {
            string[] parts = expression.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length == 0)
                return 0;
            double result = double.Parse(parts[0], CultureInfo.InvariantCulture);
            for (int i = 1; i < parts.Length; i += 2)
            {
                string op = parts[i];

                if (i + 1 >= parts.Length)
                    throw new FormatException("Biểu thức không đầy đủ.");

                double operand = double.Parse(parts[i + 1], CultureInfo.InvariantCulture); // Số hạng

                switch (op)
                {
                    case "+":
                        result += operand;
                        break;
                    case "-":
                        result -= operand;
                        break;
                    default:
                        throw new NotSupportedException($"Toán tử '{op}' không được hỗ trợ.");
                }
            }

            return result;
        }
    }
}
