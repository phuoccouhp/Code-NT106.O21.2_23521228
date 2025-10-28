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
using System.Runtime.Serialization.Formatters.Binary; 

namespace Code_NT106.O21._2_Lab02_23521228
{
    public partial class Bai4 : Form
    {
        private List<SinhVien> danhSachThem = new List<SinhVien>();
        private List<SinhVien> danhSachDoc = new List<SinhVien>();
        private int chiSoHienTai = 0; 
        public Bai4()
        {
            InitializeComponent();
            TB7.ReadOnly = true;
            LB_STT.Text = "0";
        }
        private void HienThiDanhSachTrungTam()
        {
            richTextBox1.Clear();
            foreach (var sv in danhSachThem)
            {
                richTextBox1.AppendText($"{sv.HoVaTen}\n");
                richTextBox1.AppendText($"{sv.MSSV}\n");
                richTextBox1.AppendText($"{sv.DienThoai}\n");
                richTextBox1.AppendText($"{sv.DiemMon1}\n");
                richTextBox1.AppendText($"{sv.DiemMon2}\n");
                richTextBox1.AppendText($"{sv.DiemMon3}\n");
                richTextBox1.AppendText($"---\n"); 
            }
        }
        private void HienThiSinhVienDoc(int index)
        {
            if (danhSachDoc == null || danhSachDoc.Count == 0) return;
            if (index < 0 || index >= danhSachDoc.Count) return;

            SinhVien sv = danhSachDoc[index];
            TB8.Text = sv.HoVaTen;
            TB9.Text = sv.MSSV.ToString();
            TB10.Text = sv.DienThoai;
            TB11.Text = sv.DiemMon1.ToString();
            TB12.Text = sv.DiemMon2.ToString();
            TB13.Text = sv.DiemMon3.ToString();
            TB14.Text = sv.DiemTrungBinh.ToString("F2");
            LB_STT.Text = (index + 1).ToString();
        }

        private void BTN_Ghi_Click_1(object sender, EventArgs e)
        {

            if (danhSachThem.Count == 0)
            {
                MessageBox.Show("Chưa có sinh viên nào để ghi file.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                using (FileStream fs = new FileStream("input4.txt", FileMode.Create))
                {
                #pragma warning disable SYSLIB0011
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, danhSachThem);
                #pragma warning restore SYSLIB0011
                }

                MessageBox.Show("Đã ghi danh sách sinh viên xuống file input4.txt thành công!", "Thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch 
            {
                MessageBox.Show("Lỗi khi ghi file: " , "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTN_Doc_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (FileStream fs = new FileStream("input4.txt", FileMode.Open))
                {
#pragma warning disable SYSLIB0011
                    BinaryFormatter formatter = new BinaryFormatter();
                    danhSachDoc = (List<SinhVien>)formatter.Deserialize(fs);
#pragma warning restore SYSLIB0011
                }

                if (danhSachDoc == null || danhSachDoc.Count == 0)
                {
                    MessageBox.Show("File không có dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                List<string> outputLines = new List<string>();

                foreach (SinhVien sv in danhSachDoc)
                {
                    sv.DiemTrungBinh = (sv.DiemMon1 + sv.DiemMon2 + sv.DiemMon3) / 3;

                    outputLines.Add($"Họ tên: {sv.HoVaTen}");
                    outputLines.Add($"MSSV: {sv.MSSV}");
                    outputLines.Add($"SĐT: {sv.DienThoai}");
                    outputLines.Add($"Điểm 1: {sv.DiemMon1}");
                    outputLines.Add($"Điểm 2: {sv.DiemMon2}");
                    outputLines.Add($"Điểm 3: {sv.DiemMon3}");
                    outputLines.Add($"ĐTB: {sv.DiemTrungBinh:F2}"); 
                    outputLines.Add("====================");
                }
                File.WriteAllLines("output4.txt", outputLines);
                chiSoHienTai = 0;
                HienThiSinhVienDoc(chiSoHienTai);

                MessageBox.Show("Đọc file, tính ĐTB và ghi output4.txt thành công!", "Thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Không tìm thấy file input4.txt!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch 
            {
                MessageBox.Show("Lỗi khi đọc file: " , "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTN_Add_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TB1.Text))
            {
                MessageBox.Show("Vui lòng nhập Họ và tên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(TB2.Text, out int mssv) || TB2.Text.Length != 8)
            {
                MessageBox.Show("Mã số sinh viên phải là 8 chữ số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (TB3.Text.Length != 10 || !TB3.Text.StartsWith("0") || TB3.Text.Any(c => !char.IsDigit(c)))
            {
                MessageBox.Show("Số điện thoại phải là 10 chữ số, bắt đầu bằng 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!float.TryParse(TB4.Text, out float c1) || c1 < 0 || c1 > 10 ||
                !float.TryParse(TB5.Text, out float c2) || c2 < 0 || c2 > 10 ||
                !float.TryParse(TB6.Text, out float c3) || c3 < 0 || c3 > 10)
            {
                MessageBox.Show("Điểm các môn học phải là số từ 0 đến 10.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SinhVien sv = new SinhVien
            {
                HoVaTen = TB1.Text,
                MSSV = mssv,
                DienThoai = TB3.Text,
                DiemMon1 = c1,
                DiemMon2 = c2,
                DiemMon3 = c3,
                DiemTrungBinh = 0 
            };

            danhSachThem.Add(sv);
            HienThiDanhSachTrungTam();

            TB1.Clear();
            TB2.Clear();
            TB3.Clear();
            TB4.Clear();
            TB5.Clear();
            TB6.Clear();
            TB7.Clear();
        }

        private void BTN_Back_Click_1(object sender, EventArgs e)
        {
            if (chiSoHienTai > 0)
            {
                chiSoHienTai--;
                HienThiSinhVienDoc(chiSoHienTai);
            }
        }

        private void BTN_Next_Click_1(object sender, EventArgs e)
        {
            if (chiSoHienTai < danhSachDoc.Count - 1)
            {
                chiSoHienTai++;
                HienThiSinhVienDoc(chiSoHienTai);
            }
        }
    }
    [Serializable]
    public class SinhVien
    {
        public string HoVaTen { get; set; }
        public int MSSV { get; set; }
        public string DienThoai { get; set; }
        public float DiemMon1 { get; set; }
        public float DiemMon2 { get; set; }
        public float DiemMon3 { get; set; }
        public float DiemTrungBinh { get; set; }
    }
}