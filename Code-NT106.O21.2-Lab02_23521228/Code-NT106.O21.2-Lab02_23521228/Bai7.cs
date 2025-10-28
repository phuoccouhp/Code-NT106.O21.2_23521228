using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace Code_NT106.O21._2_Lab02_23521228
{
    public partial class Bai7 : Form
    {
        public Bai7()
        {
            InitializeComponent();
        }

        private void Bai7_Load(object sender, EventArgs e)
        {
            HidePreviews();
            DriveInfo[] danhSachODia = DriveInfo.GetDrives();
            foreach (DriveInfo oDia in danhSachODia)
            {
                if (oDia.IsReady)
                {
                    TreeNode nutGoc = new TreeNode(oDia.Name);
                    nutGoc.Tag = oDia.Name;
                    nutGoc.Nodes.Add("dummy");
                    TV.Nodes.Add(nutGoc);
                }
            }
            TV.BeforeExpand += new TreeViewCancelEventHandler(TV_BeforeExpand);
            TV.AfterSelect += new TreeViewEventHandler(TV_AfterSelect);
        }

        private void TV_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode nut = e.Node;
            if (nut.Nodes.Count == 1 && nut.Nodes[0].Text == "dummy")
            {
                nut.Nodes.Clear();

                try
                {
                    string duongDan = (string)nut.Tag;
                    string[] cacThuMucCon = Directory.GetDirectories(duongDan);
                    foreach (string thuMuc in cacThuMucCon)
                    {
                        DirectoryInfo thongTinThuMuc = new DirectoryInfo(thuMuc);
                        if (thongTinThuMuc.Attributes.HasFlag(FileAttributes.Hidden) || thongTinThuMuc.Attributes.HasFlag(FileAttributes.System))
                            continue;

                        TreeNode nutThuMuc = new TreeNode(thongTinThuMuc.Name);
                        nutThuMuc.Tag = thuMuc;
                        nutThuMuc.Nodes.Add("dummy");
                        nut.Nodes.Add(nutThuMuc);
                    }
                    string[] cacTapTin = Directory.GetFiles(duongDan);
                    foreach (string tapTin in cacTapTin)
                    {
                        FileInfo thongTinTapTin = new FileInfo(tapTin);
                        if (thongTinTapTin.Attributes.HasFlag(FileAttributes.Hidden) || thongTinTapTin.Attributes.HasFlag(FileAttributes.System))
                            continue;

                        TreeNode nutTapTin = new TreeNode(thongTinTapTin.Name);
                        nutTapTin.Tag = tapTin;
                        nut.Nodes.Add(nutTapTin);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    nut.Nodes.Add("Access Denied");
                }
                catch (Exception loi)
                {
                    MessageBox.Show("Error loading directory: " + loi.Message);
                }
            }
        }

        private void TV_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null || e.Node.Tag == null)
            {
                HidePreviews();
                return;
            }

            string duongDan = (string)e.Node.Tag;

            try
            {
                FileAttributes thuocTinh = File.GetAttributes(duongDan);

                if (thuocTinh.HasFlag(FileAttributes.Directory))
                {
                    HidePreviews();
                }
                else
                {
                    string phanMoRong = Path.GetExtension(duongDan).ToLower();
                    string[] cacPhanMoRongAnh = { ".jpg", ".jpeg", ".png" };
                    string[] cacPhanMoRongVanBan = { ".txt", ".log", ".ini", ".cs", ".xml", ".config" };

                    if (cacPhanMoRongAnh.Contains(phanMoRong))
                    {
                        RTB.Visible = false;
                        byte[] duLieuByte = File.ReadAllBytes(duongDan);
                        using (MemoryStream luongNho = new MemoryStream(duLieuByte))
                        {
                            if (PB.Image != null)
                            {
                                PB.Image.Dispose();
                            }
                            PB.Image = Image.FromStream(luongNho);
                        }

                        PB.BringToFront();
                        PB.Visible = true;
                    }
                    else if (cacPhanMoRongVanBan.Contains(phanMoRong))
                    {
                        HidePreviews();

                        RTB.Text = File.ReadAllText(duongDan);
                        RTB.BringToFront();
                        RTB.Visible = true;
                    }
                    else
                    {
                        HidePreviews();
                        RTB.Text = "Không hỗ trợ xem trước file loại: " + phanMoRong;
                        RTB.BringToFront();
                        RTB.Visible = true;
                    }
                }
            }
            catch (Exception loi)
            {
                HidePreviews();
                RTB.Text = "Lỗi khi đọc file: " + loi.Message;
                RTB.BringToFront();
                RTB.Visible = true;
            }
        }

        private void HidePreviews()
        {
            RTB.Visible = false;
            RTB.Clear();
            PB.Visible = false;
            if (PB.Image != null)
            {
                PB.Image.Dispose();
                PB.Image = null;
            }
        }
    }
}