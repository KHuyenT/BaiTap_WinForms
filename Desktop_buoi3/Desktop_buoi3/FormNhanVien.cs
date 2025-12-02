using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Desktop_buoi3
{
    public partial class FormNhanVien : Form
    {
        // Danh sách giả lập CSDL
        private List<NhanVien> dsNhanVien = new List<NhanVien>();

        // Biến cờ để biết đang Thêm mới hay Sửa
        private bool isNew = false;
        public FormNhanVien()
        {
            InitializeComponent();
        }
        // Hàm tải dữ liệu lên DataGridView
        private void LoadData()
        {
            // Tạm thời gánDataSource là null để tránh lỗi
            dgvNhanVien.DataSource = null;
            // Gán danh sách dsNhanVien làm nguồn dữ liệu
            dgvNhanVien.DataSource = dsNhanVien;
        }

        // Hàm bật/tắt các control nhập liệu
        private void SetControls(bool status)
        {
            // Bật/tắt các TextBox
            txtMaNV.ReadOnly = !status;
            txtHoTen.ReadOnly = !status;
            txtDiaChi.ReadOnly = !status;
            txtSDT.ReadOnly = !status;
            dtpNgaySinh.Enabled = status; // DateTimePicker dùng Enabled

            // Bật/tắt các nút
            btnThem.Enabled = !status;
            btnSua.Enabled = !status;
            btnXoa.Enabled = !status;

            btnLuu.Enabled = status;
            btnHuy.Enabled = status;
        }

        // Hàm xóa trắng các ô nhập liệu
        private void ClearInputs()
        {
            txtMaNV.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            dtpNgaySinh.Value = DateTime.Now;
        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            // Thêm một vài dữ liệu mẫu
            dsNhanVien.Add(new NhanVien
            {
                MaNV = "NV001",
                HoTen = "Nguyễn Văn A",
                DiaChi = "123 Q1",
                DienThoai = "0909123456",
                NgaySinh = new DateTime(1990, 5, 15)
            });
            dsNhanVien.Add(new NhanVien
            {
                MaNV = "NV002",
                HoTen = "Trần Thị B",
                DiaChi = "456 Q3",
                DienThoai = "0909789012",
                NgaySinh = new DateTime(1995, 10, 20)
            });

            // Tải dữ liệu lên lưới
            LoadData();
            // Đặt trạng thái ban đầu (chỉ xem)
            SetControls(false);
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Đảm bảo click vào dòng hợp lệ (không phải header)
            if (e.RowIndex >= 0)
            {
                // Lấy dòng được chọn
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];

                // Lấy dữ liệu từ dòng đó
                txtMaNV.Text = row.Cells["MaNV"].Value.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                txtSDT.Text = row.Cells["DienThoai"].Value.ToString();
                dtpNgaySinh.Value = (DateTime)row.Cells["NgaySinh"].Value;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Đặt cờ là "Thêm mới"
            isNew = true;

            // Xóa trắng ô nhập
            ClearInputs();

            // Bật các control để nhập
            SetControls(true);

            // Focus vào ô Mã NV
            txtMaNV.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn dòng nào chưa
            if (dgvNhanVien.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa.");
                return;
            }

            // Đặt cờ là "Sửa"
            isNew = false;

            // Bật các control để sửa
            SetControls(true);

            // Không cho sửa Mã NV
            txtMaNV.ReadOnly = true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Tắt các control
            SetControls(false);

            // Xóa trắng ô nhập
            ClearInputs();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu (đơn giản)
            if (string.IsNullOrEmpty(txtMaNV.Text))
            {
                MessageBox.Show("Mã nhân viên không được để trống!");
                return;
            }

            if (isNew)
            {
                // --- Chế độ THÊM MỚI ---

                // (Nâng cao: Nên kiểm tra xem Mã NV đã tồn tại chưa)

                // Tạo đối tượng NhanVien mới
                NhanVien nv = new NhanVien();
                nv.MaNV = txtMaNV.Text;
                nv.HoTen = txtHoTen.Text;
                nv.DiaChi = txtDiaChi.Text;
                nv.DienThoai = txtSDT.Text;
                nv.NgaySinh = dtpNgaySinh.Value;

                // Thêm vào danh sách (CSDL giả)
                dsNhanVien.Add(nv);
            }
            else
            {
                // --- Chế độ SỬA ---

                // Tìm nhân viên trong danh sách
                NhanVien nv = dsNhanVien.Find(x => x.MaNV == txtMaNV.Text);

                if (nv != null)
                {
                    // Cập nhật thông tin
                    nv.HoTen = txtHoTen.Text;
                    nv.DiaChi = txtDiaChi.Text;
                    nv.DienThoai = txtSDT.Text;
                    nv.NgaySinh = dtpNgaySinh.Value;
                }
            }

            // Tải lại dữ liệu lên lưới
            LoadData();
            // Đặt lại trạng thái ban đầu
            SetControls(false);
            ClearInputs();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn dòng nào chưa
            if (dgvNhanVien.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa.");
                return;
            }

            // Lấy Mã NV từ dòng chọn (giả sử chọn 1 dòng)
            string maNV_canXoa = dgvNhanVien.SelectedRows[0].Cells["MaNV"].Value.ToString();

            // Hiển thị hộp thoại xác nhận
            DialogResult dr = MessageBox.Show($"Bạn có chắc muốn xóa nhân viên {maNV_canXoa}?",
                                                "Xác nhận",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                // Tìm và xóa nhân viên
                NhanVien nv = dsNhanVien.Find(x => x.MaNV == maNV_canXoa);
                if (nv != null)
                {
                    dsNhanVien.Remove(nv);
                }

                // Tải lại lưới và xóa trắng ô nhập
                LoadData();
                ClearInputs();
            }
        }
        public void TimKiemNhanh(string tuKhoa)
        {
            // 1. Chuyển từ khóa về chữ thường để tìm không phân biệt hoa/thường
            string tuKhoaTim = tuKhoa.ToLower().Trim();

            if (string.IsNullOrEmpty(tuKhoaTim))
            {
                // Nếu ô tìm kiếm trống, tải lại toàn bộ danh sách
                LoadData(); // (Hàm LoadData() bạn đã viết)
            }
            else
            {
                // 2. Lọc danh sách (dùng LINQ)
                var ketQua = dsNhanVien.Where(nv =>
                    nv.MaNV.ToLower().Contains(tuKhoaTim) ||
                    nv.HoTen.ToLower().Contains(tuKhoaTim) ||
                    nv.DienThoai.ToLower().Contains(tuKhoaTim)
                ).ToList();

                // 3. Hiển thị kết quả lên DataGridView
                dgvNhanVien.DataSource = null;
                dgvNhanVien.DataSource = ketQua;
            }
        }
    }
}
