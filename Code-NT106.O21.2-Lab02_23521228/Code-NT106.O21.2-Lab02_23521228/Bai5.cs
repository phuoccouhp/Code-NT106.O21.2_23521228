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
    public partial class Bai5 : Form
    {
        Dictionary<string, TabPage> anhXaPhong = new Dictionary<string, TabPage>();

        List<FilmInfo> danhSachPhim = new List<FilmInfo>();
        HashSet<CheckBox> veDaBanGlobal = new HashSet<CheckBox>();

        public Bai5()
        {
            InitializeComponent();

            this.Load += new System.EventHandler(this.Bai5_Load);
        }
        private void Bai5_Load(object sender, EventArgs e)
        {
            anhXaPhong.Add("Phòng 1", tabPage1);
            anhXaPhong.Add("Phòng 2", tabPage2);
            anhXaPhong.Add("Phòng 3", tabPage3);
            foreach (TabPage trangTab in tabControl1.TabPages)
            {
                foreach (Control dieuKhien in trangTab.Controls)
                {
                    if (dieuKhien is CheckBox oKiem)
                    {
                        oKiem.CheckedChanged += Ghe_CheckedChanged;
                    }
                }
            }
            tabControl1.TabPages.Clear();
            CB_Phim.Items.Clear();

            this.BTN_Doc.Click += new System.EventHandler(this.BTN_Doc_Click);
            this.BTN_Xuat.Click += new System.EventHandler(this.BTN_Xuat_Click);
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            this.CB_Phim.SelectedIndexChanged += new System.EventHandler(this.CB_Phim_SelectedIndexChanged);


            CB_Phim.Enabled = false;
            btnThanhToan.Enabled = false;
            BTN_Xuat.Enabled = false;
        }

        private void BTN_Doc_Click(object sender, EventArgs e)
        {
            try
            {
                string tepDauVao = "input5.txt";
                if (!File.Exists(tepDauVao))
                {
                    MessageBox.Show("Không tìm thấy file 'input5.txt'.\n" +
                                    "Vui lòng tạo file theo hướng dẫn.", "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (StreamReader boDoc = new StreamReader(tepDauVao))
                {
                    int soLuongPhim = int.Parse(boDoc.ReadLine());
                    danhSachPhim.Clear();
                    CB_Phim.Items.Clear();

                    for (int i = 0; i < soLuongPhim; i++)
                    {
                        FilmInfo phim = new FilmInfo();
                        phim.TenPhim = boDoc.ReadLine();
                        phim.GiaVe = int.Parse(boDoc.ReadLine());
                        phim.PhongChieu = boDoc.ReadLine().Split(',').ToList();

                        phim.TongSoGhe = 0;
                        foreach (string tenPhong in phim.PhongChieu)
                        {
                            if (anhXaPhong.ContainsKey(tenPhong))
                            {
                                phim.TongSoGhe += anhXaPhong[tenPhong].Controls.OfType<CheckBox>().Count();
                            }
                        }

                        danhSachPhim.Add(phim);
                        CB_Phim.Items.Add(phim.TenPhim);
                    }
                }

                MessageBox.Show("Đọc file " + tepDauVao + " thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CB_Phim.Enabled = true;
                btnThanhToan.Enabled = true;
                BTN_Xuat.Enabled = true;
                veDaBanGlobal.Clear();
                if (CB_Phim.Items.Count > 0)
                {
                    CB_Phim.SelectedIndex = 0;
                }
            }
            catch (Exception loi)
            {
                MessageBox.Show("Lỗi khi đọc file input5.txt: " + loi.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CB_Phim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_Phim.SelectedItem == null) return;

            string tenPhim = CB_Phim.SelectedItem.ToString();
            FilmInfo phimHienTai = danhSachPhim.FirstOrDefault(f => f.TenPhim == tenPhim);

            if (phimHienTai == null) return;

            tabControl1.TabPages.Clear();
            foreach (string tenPhong in phimHienTai.PhongChieu)
            {
                if (anhXaPhong.ContainsKey(tenPhong))
                {
                    tabControl1.TabPages.Add(anhXaPhong[tenPhong]);
                }
            }
            foreach (TabPage trangTab in tabControl1.TabPages)
            {
                foreach (CheckBox oKiem in trangTab.Controls.OfType<CheckBox>())
                {
                    if (veDaBanGlobal.Contains(oKiem))
                    {
                        oKiem.Enabled = false;
                        oKiem.Checked = true;
                    }
                    else
                    {
                        oKiem.Enabled = true;
                        oKiem.Checked = false;
                    }
                }
            }
        }

        private void Ghe_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox oKiemDuocNhan = sender as CheckBox;
            if (oKiemDuocNhan == null || !oKiemDuocNhan.Focused)
            {
                return;
            }

            int soPhongCoGhe = 0;
            int tongGhe = 0;

            foreach (TabPage trangTab in tabControl1.TabPages)
            {
                int soGheTrongPhong = trangTab.Controls.OfType<CheckBox>().Count(oKiem => oKiem.Checked && oKiem.Enabled);
                if (soGheTrongPhong > 0)
                    soPhongCoGhe++;
                tongGhe += soGheTrongPhong;
            }

            if (soPhongCoGhe > 1 && tongGhe > 2)
            {
                if (oKiemDuocNhan.Enabled)
                {
                    oKiemDuocNhan.Checked = false;
                    MessageBox.Show("Khi chọn ghế ở nhiều phòng, bạn chỉ được tối đa 2 ghế tổng cộng!",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TB_HT.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên khách hàng!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (CB_Phim.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn phim!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string tenPhim = CB_Phim.SelectedItem.ToString();
            FilmInfo phimHienTai = danhSachPhim.FirstOrDefault(f => f.TenPhim == tenPhim);
            if (phimHienTai == null) return;

            int giaVe = phimHienTai.GiaVe;
            List<string> danhSachGheText = new List<string>();
            List<CheckBox> gheVuaChon = new List<CheckBox>();

            foreach (TabPage trangTab in tabControl1.TabPages)
            {
                foreach (CheckBox oKiem in trangTab.Controls.OfType<CheckBox>())
                {
                    if (oKiem.Checked && oKiem.Enabled)
                    {
                        danhSachGheText.Add($"{trangTab.Text} - {oKiem.Text}");
                        gheVuaChon.Add(oKiem);
                    }
                }
            }

            if (gheVuaChon.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn ghế!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int tongTien = giaVe * gheVuaChon.Count;
            string gheText = string.Join(", ", danhSachGheText);

            MessageBox.Show(
                $"Khách hàng: {TB_HT.Text}\n" +
                $"Phim: {phimHienTai.TenPhim}\n" +
                $"Số ghế: {gheVuaChon.Count}\n" +
                $"Vị trí ghế: {gheText}\n" +
                $"Tổng tiền: {tongTien:N0}đ",
                "Thông tin thanh toán",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
            phimHienTai.VeDaBan += gheVuaChon.Count;
            phimHienTai.DoanhThu += tongTien;
            foreach (CheckBox oKiem in gheVuaChon)
            {
                oKiem.Enabled = false;
                veDaBanGlobal.Add(oKiem);
            }
            TB_HT.Clear();
        }
        private async void BTN_Xuat_Click(object sender, EventArgs e)
        {
            ProgressBar pb = this.PB;

            pb.Value = 0;
            pb.Minimum = 0;
            pb.Maximum = danhSachPhim.Count * 2;
            pb.Step = 1;

            StringBuilder boXayDungChuoi = new StringBuilder();
            boXayDungChuoi.AppendLine("--- THỐNG KÊ DOANH THU PHÒNG VÉ ---");
            boXayDungChuoi.AppendLine();

            var phimDaXepHang = danhSachPhim.OrderByDescending(f => f.DoanhThu).ToList();

            for (int i = 0; i < phimDaXepHang.Count; i++)
            {
                FilmInfo phim = phimDaXepHang[i];
                int hang = i + 1;

                int veTon = phim.TongSoGhe - phim.VeDaBan;
                double tiLeVeBan = (phim.TongSoGhe > 0) ? (double)phim.VeDaBan / phim.TongSoGhe : 0;

                await Task.Delay(150);
                pb.PerformStep();
                boXayDungChuoi.AppendLine($"HẠNG: {hang}");
                boXayDungChuoi.AppendLine($"Tên phim: {phim.TenPhim}");
                boXayDungChuoi.AppendLine($"Số lượng vé bán ra: {phim.VeDaBan}");
                boXayDungChuoi.AppendLine($"Số lượng vé tồn: {veTon}");
                boXayDungChuoi.AppendLine($"Tỉ lệ vé bán ra: {tiLeVeBan:P2}");
                boXayDungChuoi.AppendLine($"Doanh thu: {phim.DoanhThu:N0}đ");
                boXayDungChuoi.AppendLine("-----------------------------------");
                boXayDungChuoi.AppendLine();
                await Task.Delay(100);
                pb.PerformStep();
            }
            try
            {
                File.WriteAllText("output5.txt", boXayDungChuoi.ToString());
                MessageBox.Show("Xuất file thống kê output5.txt thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception loi)
            {
                MessageBox.Show("Lỗi khi ghi file output5.txt: " + loi.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                pb.Value = 0;
            }
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
    public class FilmInfo
    {
        public string TenPhim { get; set; }
        public int GiaVe { get; set; }
        public List<string> PhongChieu { get; set; }
        public int TongSoGhe { get; set; }
        public int VeDaBan { get; set; }
        public double DoanhThu { get; set; }

        public FilmInfo()
        {
            PhongChieu = new List<string>();
            VeDaBan = 0;
            DoanhThu = 0;
            TongSoGhe = 0;
        }
    }
}