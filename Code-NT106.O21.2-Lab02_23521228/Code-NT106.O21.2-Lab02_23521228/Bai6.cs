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
using System.Data.SQLite;

namespace Code_NT106.O21._2_Lab02_23521228
{
    public partial class Bai6 : Form
    {
        private SQLiteConnection ketNoi;
        private string tenTepDb = "food_db.sqlite";
        private Random ngauNhien = new Random();
        private List<int> cacIdMonAnCoSan = new List<int>();

        public Bai6()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Bai6_Load);
        }

        private void Bai6_Load(object sender, EventArgs e)
        {
            InitializeDatabase();
            LoadMonAnList();

            this.BT_Tim.Click += new System.EventHandler(this.BT_Tim_Click);
            this.BT_Xoa.Click += new System.EventHandler(this.BT_Xoa_Click);
            this.BT_Thoat.Click += new System.EventHandler(this.BT_Thoat_Click);
            this.BTN1.Click += new System.EventHandler(this.button1_Click);
        }

        private void InitializeDatabase()
        {
            if (!File.Exists(tenTepDb))
            {
                SQLiteConnection.CreateFile(tenTepDb);
            }

            ketNoi = new SQLiteConnection($"Data Source={tenTepDb};Version=3;");
            ketNoi.Open();

            string lenhTaoBangNguoiDung = @"
                CREATE TABLE IF NOT EXISTS NguoiDung (
                    IDNCC INTEGER PRIMARY KEY AUTOINCREMENT,
                    HoVaTen TEXT NOT NULL UNIQUE,
                    QuyenHan TEXT
                );";
            using (SQLiteCommand lenh = new SQLiteCommand(lenhTaoBangNguoiDung, ketNoi))
            {
                lenh.ExecuteNonQuery();
            }

            string lenhTaoBangMonAn = @"
                CREATE TABLE IF NOT EXISTS MonAn (
                    IDMA INTEGER PRIMARY KEY AUTOINCREMENT,
                    TenMonAn TEXT NOT NULL,
                    HinhAnh TEXT,
                    IDNCC INTEGER,
                    FOREIGN KEY (IDNCC) REFERENCES NguoiDung(IDNCC)
                );";
            using (SQLiteCommand lenh = new SQLiteCommand(lenhTaoBangMonAn, ketNoi))
            {
                lenh.ExecuteNonQuery();
            }

            InsertSampleDataIfNotExists();

            ketNoi.Close();
        }

        private void InsertSampleDataIfNotExists()
        {
            string sqlKiemTraNguoiDung = "SELECT COUNT(*) FROM NguoiDung";
            long soLuongNguoiDung = 0;
            bool banDauDaDong = ketNoi.State == ConnectionState.Closed;
            if (banDauDaDong) ketNoi.Open();
            try
            {
                using (SQLiteCommand lenhKiemTra = new SQLiteCommand(sqlKiemTraNguoiDung, ketNoi))
                {
                    soLuongNguoiDung = (long)lenhKiemTra.ExecuteScalar();
                }

                if (soLuongNguoiDung == 0)
                {
                    string sqlChenNguoiDung = "INSERT OR IGNORE INTO NguoiDung (HoVaTen, QuyenHan) VALUES (@HoVaTen, @QuyenHan)";
                    using (SQLiteCommand lenh = new SQLiteCommand(sqlChenNguoiDung, ketNoi))
                    {
                        lenh.Parameters.AddWithValue("@HoVaTen", "Alice");
                        lenh.Parameters.AddWithValue("@QuyenHan", "Admin");
                        lenh.ExecuteNonQuery();

                        lenh.Parameters.Clear();
                        lenh.Parameters.AddWithValue("@HoVaTen", "Bob");
                        lenh.Parameters.AddWithValue("@QuyenHan", "User");
                        lenh.ExecuteNonQuery();
                    }
                }

                string sqlKiemTraMonAn = "SELECT COUNT(*) FROM MonAn";
                long soLuongMonAn = 0;
                using (SQLiteCommand lenhKiemTra = new SQLiteCommand(sqlKiemTraMonAn, ketNoi))
                {
                    soLuongMonAn = (long)lenhKiemTra.ExecuteScalar();
                }

                if (soLuongMonAn == 0)
                {
                    string sqlChenMonAn = "INSERT INTO MonAn (TenMonAn, HinhAnh, IDNCC) VALUES (@TenMonAn, @HinhAnh, @IDNCC)";
                    using (SQLiteCommand lenh = new SQLiteCommand(sqlChenMonAn, ketNoi))
                    {
                        lenh.Parameters.AddWithValue("@TenMonAn", "Bún riêu");
                        lenh.Parameters.AddWithValue("@HinhAnh", "images/bun_rieu.jpg");
                        lenh.Parameters.AddWithValue("@IDNCC", 1);
                        lenh.ExecuteNonQuery();

                        lenh.Parameters.Clear();
                        lenh.Parameters.AddWithValue("@TenMonAn", "Phở");
                        lenh.Parameters.AddWithValue("@HinhAnh", "images/pho.jpg");
                        lenh.Parameters.AddWithValue("@IDNCC", 2);
                        lenh.ExecuteNonQuery();

                        lenh.Parameters.Clear();
                        lenh.Parameters.AddWithValue("@TenMonAn", "Cơm tấm");
                        lenh.Parameters.AddWithValue("@HinhAnh", "images/com_tam.jpg");
                        lenh.Parameters.AddWithValue("@IDNCC", 1);
                        lenh.ExecuteNonQuery();
                    }
                }

                string sqlLayTatCaAnh = "SELECT IDMA, HinhAnh FROM MonAn";
                using (SQLiteCommand lenhLayAnh = new SQLiteCommand(sqlLayTatCaAnh, ketNoi))
                using (SQLiteDataReader boDoc = lenhLayAnh.ExecuteReader())
                {
                    while (boDoc.Read())
                    {
                        int id = Convert.ToInt32(boDoc["IDMA"]);
                        string duongDan = boDoc["HinhAnh"]?.ToString();

                        if (!string.IsNullOrEmpty(duongDan) && !File.Exists(duongDan))
                        {
                            string duongDanMoi = null;
                            if (duongDan.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase))
                            {
                                string duongDanJpeg = duongDan[..^4] + ".jpeg";
                                if (File.Exists(duongDanJpeg))
                                    duongDanMoi = duongDanJpeg;
                            }
                            else if (duongDan.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase))
                            {
                                string duongDanJpg = duongDan[..^5] + ".jpg";
                                if (File.Exists(duongDanJpg))
                                    duongDanMoi = duongDanJpg;
                            }

                            if (duongDanMoi != null)
                            {
                                using (SQLiteCommand lenhUpdate = new SQLiteCommand("UPDATE MonAn SET HinhAnh=@HinhAnh WHERE IDMA=@IDMA", ketNoi))
                                {
                                    lenhUpdate.Parameters.AddWithValue("@HinhAnh", duongDanMoi);
                                    lenhUpdate.Parameters.AddWithValue("@IDMA", id);
                                    lenhUpdate.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }
            }
            finally
            {
                if (banDauDaDong && ketNoi.State == ConnectionState.Open) ketNoi.Close();
            }
        }

        private void LoadMonAnList()
        {
            LV.Items.Clear();
            cacIdMonAnCoSan.Clear();

            try
            {
                if (ketNoi.State == ConnectionState.Closed)
                    ketNoi.Open();

                string cauLenhSql = "SELECT IDMA, TenMonAn FROM MonAn ORDER BY TenMonAn";
                using (SQLiteCommand lenh = new SQLiteCommand(cauLenhSql, ketNoi))
                using (SQLiteDataReader boDoc = lenh.ExecuteReader())
                {
                    while (boDoc.Read())
                    {
                        int idMonAn = Convert.ToInt32(boDoc["IDMA"]);
                        string tenMonAn = boDoc["TenMonAn"].ToString();

                        ListViewItem mucListView = new ListViewItem(tenMonAn);
                        mucListView.Tag = idMonAn;
                        LV.Items.Add(mucListView);

                        cacIdMonAnCoSan.Add(idMonAn);
                    }
                }
            }
            catch (Exception loi)
            {
                MessageBox.Show("Lỗi khi tải danh sách món ăn: " + loi.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (ketNoi.State == ConnectionState.Open)
                    ketNoi.Close();
            }

            if (LV.Columns.Count > 0)
            {
                LV.Columns[0].Width = -1;
                if (LV.Columns[0].Width < TextRenderer.MeasureText(LV.Columns[0].Text, LV.Font).Width + 10)
                {
                    LV.Columns[0].Width = -2;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tenNguoiThem = TB1.Text.Trim();
            string tenMonAnMoi = TB2.Text.Trim();

            if (string.IsNullOrEmpty(tenNguoiThem))
            {
                MessageBox.Show("Vui lòng nhập tên người thêm.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TB1.Focus();
                return;
            }
            if (string.IsNullOrEmpty(tenMonAnMoi))
            {
                MessageBox.Show("Vui lòng nhập tên món ăn.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TB2.Focus();
                return;
            }

            long idNguoiCungCap = -1;

            try
            {
                if (ketNoi.State == ConnectionState.Closed) ketNoi.Open();

                string sqlTimNguoiDung = "SELECT IDNCC FROM NguoiDung WHERE HoVaTen = @HoVaTen";
                using (SQLiteCommand lenhTim = new SQLiteCommand(sqlTimNguoiDung, ketNoi))
                {
                    lenhTim.Parameters.AddWithValue("@HoVaTen", tenNguoiThem);
                    object ketQuaTim = lenhTim.ExecuteScalar();
                    if (ketQuaTim != null && ketQuaTim != DBNull.Value)
                    {
                        idNguoiCungCap = Convert.ToInt64(ketQuaTim);
                    }
                }

                if (idNguoiCungCap == -1)
                {
                    string sqlChenNguoiDung = "INSERT INTO NguoiDung (HoVaTen, QuyenHan) VALUES (@HoVaTen, @QuyenHan); SELECT last_insert_rowid();";
                    using (SQLiteCommand lenhChenNguoiDung = new SQLiteCommand(sqlChenNguoiDung, ketNoi))
                    {
                        lenhChenNguoiDung.Parameters.AddWithValue("@HoVaTen", tenNguoiThem);
                        lenhChenNguoiDung.Parameters.AddWithValue("@QuyenHan", "User");
                        idNguoiCungCap = (long)lenhChenNguoiDung.ExecuteScalar();
                    }
                    if (idNguoiCungCap == -1)
                    {
                        throw new Exception("Không thể thêm người dùng mới.");
                    }
                    MessageBox.Show($"Đã thêm người dùng mới: {tenNguoiThem} (ID: {idNguoiCungCap})", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                string sqlChenMonAn = "INSERT INTO MonAn (TenMonAn, IDNCC) VALUES (@TenMonAn, @IDNCC)";
                using (SQLiteCommand lenhChenMonAn = new SQLiteCommand(sqlChenMonAn, ketNoi))
                {
                    lenhChenMonAn.Parameters.AddWithValue("@TenMonAn", tenMonAnMoi);
                    lenhChenMonAn.Parameters.AddWithValue("@IDNCC", idNguoiCungCap);
                    int soHangAnhHuong = lenhChenMonAn.ExecuteNonQuery();

                    if (soHangAnhHuong > 0)
                    {
                        MessageBox.Show($"Đã thêm món ăn '{tenMonAnMoi}' bởi '{tenNguoiThem}'.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TB1.Clear();
                        TB2.Clear();
                        LoadMonAnList();
                    }
                    else
                    {
                        MessageBox.Show("Thêm món ăn thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception loi)
            {
                if (loi is SQLiteException loiSql && loiSql.ErrorCode == (int)SQLiteErrorCode.Constraint_Unique)
                {
                    MessageBox.Show($"Người dùng '{tenNguoiThem}' đã tồn tại. Đang tiến hành thêm món ăn cho người dùng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    try
                    {
                        string sqlChenMonAnThuLai = "INSERT INTO MonAn (TenMonAn, IDNCC) VALUES (@TenMonAn, @IDNCC)";
                        using (SQLiteCommand lenhChenMonAnThuLai = new SQLiteCommand(sqlChenMonAnThuLai, ketNoi))
                        {
                            lenhChenMonAnThuLai.Parameters.AddWithValue("@TenMonAn", tenMonAnMoi);
                            lenhChenMonAnThuLai.Parameters.AddWithValue("@IDNCC", idNguoiCungCap);
                            int soHangAnhHuongThuLai = lenhChenMonAnThuLai.ExecuteNonQuery();
                            if (soHangAnhHuongThuLai > 0)
                            {
                                MessageBox.Show($"Đã thêm món ăn '{tenMonAnMoi}' bởi '{tenNguoiThem}'.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                TB1.Clear();
                                TB2.Clear();
                                LoadMonAnList();
                            }
                            else
                            {
                                MessageBox.Show("Thêm món ăn thất bại sau khi tìm thấy người dùng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception loiThuLai)
                    {
                        MessageBox.Show("Lỗi khi thử thêm lại món ăn: " + loiThuLai.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Lỗi khi thêm dữ liệu: " + loi.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                if (ketNoi.State == ConnectionState.Open) ketNoi.Close();
            }
        }

        private void BT_Tim_Click(object sender, EventArgs e)
        {
            if (cacIdMonAnCoSan.Count == 0)
            {
                MessageBox.Show("Danh sách món ăn trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int chiSoNgauNhien = ngauNhien.Next(0, cacIdMonAnCoSan.Count);
            int idMonAnNgauNhien = cacIdMonAnCoSan[chiSoNgauNhien];

            try
            {
                if (ketNoi.State == ConnectionState.Closed) ketNoi.Open();
                string cauLenhSql = @"SELECT m.TenMonAn, m.HinhAnh, n.HoVaTen
                                      FROM MonAn m
                                      JOIN NguoiDung n ON m.IDNCC = n.IDNCC
                                      WHERE m.IDMA = @IDMA";
                using (SQLiteCommand lenh = new SQLiteCommand(cauLenhSql, ketNoi))
                {
                    lenh.Parameters.AddWithValue("@IDMA", idMonAnNgauNhien);
                    using (SQLiteDataReader boDoc = lenh.ExecuteReader())
                    {
                        if (boDoc.Read())
                        {
                            string tenMonAn = boDoc["TenMonAn"].ToString();
                            string duongDanHinh = boDoc["HinhAnh"] != DBNull.Value ? boDoc["HinhAnh"].ToString() : null;
                            string nguoiDongGop = boDoc["HoVaTen"].ToString();

                            TB_KQ.Text = tenMonAn;
                            LB_TenNgDG.Text = nguoiDongGop;

                            if (!string.IsNullOrEmpty(duongDanHinh) && File.Exists(duongDanHinh))
                            {
                                if (PB_Monan.Image != null) PB_Monan.Image.Dispose();
                                try
                                {
                                    PB_Monan.Image = Image.FromFile(duongDanHinh);
                                    PB_Monan.SizeMode = PictureBoxSizeMode.Zoom;
                                }
                                catch (OutOfMemoryException)
                                {
                                    if (PB_Monan.Image != null) PB_Monan.Image.Dispose();
                                    PB_Monan.Image = null;
                                }

                            }
                            else
                            {
                                if (PB_Monan.Image != null) PB_Monan.Image.Dispose();
                                PB_Monan.Image = null;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thông tin cho món ăn đã chọn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception loi)
            {
                MessageBox.Show("Lỗi khi tìm món ăn: " + loi.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { if (ketNoi.State == ConnectionState.Open) ketNoi.Close(); }
        }

        private void BT_Xoa_Click(object sender, EventArgs e)
        {
            TB_KQ.Clear();
            LB_TenNgDG.Text = "";
            if (PB_Monan.Image != null)
            {
                PB_Monan.Image.Dispose();
                PB_Monan.Image = null;
            }
        }

        private void BT_Thoat_Click(object sender, EventArgs e)
        {
            if (ketNoi != null && ketNoi.State == ConnectionState.Open)
            {
                ketNoi.Close();
            }
            this.Close();
        }
    }
}
