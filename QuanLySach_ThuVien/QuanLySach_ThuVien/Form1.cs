using System.Globalization;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using QuanLySach_ThuVien.Models;

namespace QuanLySach_ThuVien
{
    public partial class Form1 : Form
    {
        private string? _maDangChon;   
        private static readonly CultureInfo VN = new("vi-VN");   
        private static string HienThiGia(string giaDb) =>
            decimal.TryParse(giaDb, NumberStyles.Number, CultureInfo.InvariantCulture, out var g)
                ? g.ToString("#,##0.##", VN) : giaDb;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                LoadSach();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không kết nối được CSDL:\n" + (ex.InnerException?.Message ?? ex.Message));
            }
            TrangThaiBanDau();
        }

        private void LoadSach()
        {
            using var db = new DuLieuContext();
            var ds = db.CongViecs.AsNoTracking().OrderBy(s => s.MaSach).ToList();
            
            dgvSach.DataSource = ds.Select(s => new
            {
                s.MaSach,
                s.TenSach,
                GiaTien = HienThiGia(s.GiaTien)
            }).ToList();
            dgvSach.Columns["MaSach"]!.HeaderText = "Mã Sách";
            dgvSach.Columns["TenSach"]!.HeaderText = "Tên Sách";
            dgvSach.Columns["GiaTien"]!.HeaderText = "Giá Tiền";
            dgvSach.Columns["GiaTien"]!.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            
            dgvSach.Columns["MaSach"]!.Width = 110;
            dgvSach.Columns["TenSach"]!.Width = 200;
            dgvSach.Columns["GiaTien"]!.Width = 110;
            dgvSach.ClearSelection();
        }

        private void TrangThaiBanDau()
        {
            _maDangChon = null;
            txtMaSach.Clear();
            txtTenSach.Clear();
            txtGiaTien.Clear();
            errProvider.Clear();
            btnThem.Enabled = true;
            btnThoat.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            dgvSach.ClearSelection();
        }

        private void txtGiaTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar)) return;
            bool khongDauDong = txtGiaTien.SelectionStart > 0;
            if (e.KeyChar == '.' && khongDauDong && !txtGiaTien.Text.Contains(',')) return;
            if (e.KeyChar == ',' && khongDauDong && !txtGiaTien.Text.Contains(',')) return;
            e.Handled = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không", "Thoát",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraNhap()) return;
            string ma = txtMaSach.Text.Trim();
            try
            {
                using var db = new DuLieuContext();
                if (db.CongViecs.Any(s => s.MaSach == ma))
                {
                    MessageBox.Show("Mã sách đã tồn tại, vui lòng nhập lại!", "Trùng mã",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    errProvider.SetError(txtMaSach, "Mã sách đã tồn tại");
                    txtMaSach.Focus();
                    txtMaSach.SelectAll();
                    return;
                }
                db.CongViecs.Add(new CongViec
                {
                    MaSach = ma,
                    TenSach = txtTenSach.Text.Trim(),
                    GiaTien = GiaLuuDb()
                });
                db.SaveChanges();
            }
            catch (DbUpdateException ex) when (ex.InnerException is SqlException { Number: 2627 or 2601 })
            {
                MessageBox.Show("Mã sách đã tồn tại, vui lòng nhập lại!");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + (ex.InnerException?.Message ?? ex.Message));
                return;
            }
            MessageBox.Show("Thêm sách thành công!");
            LoadSach();
            TrangThaiBanDau();
            btnThem.Enabled = false;  
        }

        private void txtMaSach_TextChanged(object sender, EventArgs e)
        {
            if (!btnThem.Enabled && txtMaSach.Text.Trim().Length > 0)
                btnThem.Enabled = true;
        }

        private void dgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;   
            string? ma = dgvSach.Rows[e.RowIndex].Cells["MaSach"].Value?.ToString();
            if (ma == null) return;

            using var db = new DuLieuContext();
            var s = db.CongViecs.Find(ma);   
            if (s == null) return;
            _maDangChon = s.MaSach;
            txtMaSach.Text = s.MaSach;
            txtTenSach.Text = s.TenSach;
            txtGiaTien.Text = HienThiGia(s.GiaTien);   
            errProvider.Clear();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_maDangChon == null) return;
            if (MessageBox.Show("Muốn xóa cuốn sách này không?", "Xác nhận xóa",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;   
            try
            {
                using var db = new DuLieuContext();
                var s = db.CongViecs.Find(_maDangChon);
                if (s != null)
                {
                    db.CongViecs.Remove(s);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + (ex.InnerException?.Message ?? ex.Message));
                return;
            }
            LoadSach();
            TrangThaiBanDau();   
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_maDangChon == null) return;
            if (!KiemTraNhap()) return;
            if (txtMaSach.Text.Trim() != _maDangChon)
            {
                
                MessageBox.Show("Không được sửa Mã sách. Muốn tạo sách mới hãy dùng nút Thêm.");
                txtMaSach.Text = _maDangChon;
                return;
            }
            try
            {
                using var db = new DuLieuContext();
                var s = db.CongViecs.Find(_maDangChon);
                if (s == null) { MessageBox.Show("Sách không còn tồn tại."); return; }
                s.TenSach = txtTenSach.Text.Trim();
                s.GiaTien = GiaLuuDb();
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + (ex.InnerException?.Message ?? ex.Message));
                return;
            }
            MessageBox.Show("Cập nhật sách thành công!");
            LoadSach();
            TrangThaiBanDau();   
        }

        
        private string GiaLuuDb() =>
            decimal.Parse(txtGiaTien.Text.Trim(), NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint, VN)
                .ToString(CultureInfo.InvariantCulture);

        private bool KiemTraNhap()
        {
            errProvider.Clear();
            Control? dau = null;
            void Loi(Control c, string m) { errProvider.SetError(c, m); dau ??= c; }

            if (txtMaSach.Text.Trim().Length == 0) Loi(txtMaSach, "Chưa nhập mã sách");
            if (txtTenSach.Text.Trim().Length == 0) Loi(txtTenSach, "Chưa nhập tên sách");
            string gia = txtGiaTien.Text.Trim();
            if (gia.Length == 0) Loi(txtGiaTien, "Chưa nhập giá tiền");
            else if (!decimal.TryParse(gia, NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint, VN, out var g) || g.ToString(CultureInfo.InvariantCulture).Length > 12)
                Loi(txtGiaTien, "Giá tiền phải là số nguyên hoặc số thực (tối đa 12 ký tự)");

            if (dau == null) return true;
            MessageBox.Show("Vui lòng nhập đầy đủ và đúng dữ liệu!", "Thiếu dữ liệu",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dau.Focus();
            return false;
        }
    }
}
