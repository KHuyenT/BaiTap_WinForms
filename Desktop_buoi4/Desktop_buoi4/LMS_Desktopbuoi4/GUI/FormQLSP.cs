// Đã loại bỏ using System.Data.SqlClient;

using LMS_Desktopbuoi4.BUS; // <-- Tầng Business
using LMS_Desktopbuoi4.DAL;
using LMS_Desktopbuoi4.DTO; // <-- Tầng Data Transfer Object
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMS_Desktopbuoi4.GUI
{
    public partial class FormQLSP : Form
    {
        // 1. Chỉ khai báo đối tượng BUS (Không còn Connection/Adapter/DataSet)
        SanPhamBUS busSP = new SanPhamBUS();

        // Cờ hiệu để biết đang ở chế độ Thêm hay Sửa (Nếu dùng chung nút Lưu)
        private bool isAdding = false;

        public FormQLSP()
        {
            InitializeComponent();
        }

        private void FormQLSP_Load(object sender, EventArgs e) // Đổi tên hàm từ Form1_Load sang FormQLSP_Load
        {
            try
            {
                // Gọi hàm Tải dữ liệu để hiển thị
                LoadLoaiSanPham();
                LoadSanPham();
            }
            catch (Exception ex)
            {
                // Lỗi có thể xảy ra do ConnectionString trong DAL bị sai
                MessageBox.Show("Lỗi khi tải Form: " + ex.Message + "\nVui lòng kiểm tra lại kết nối trong tầng DAL.", "Lỗi CSDL");
            }
        }

        // --- 4. HÀM TẢI LOẠI SẢN PHẨM (CHO COMBOBOX) ---
        void LoadLoaiSanPham()
        {
            // Gọi BUS để lấy danh sách Loại Sản Phẩm (BUS sẽ gọi DAL)
            // BUS trả về DataTable hoặc List<DTO>
            DataTable dtLoai = busSP.LayDSLoaiSanPham();

            cboLoaiSP.DataSource = dtLoai;
            cboLoaiSP.DisplayMember = "TenLoai";
            cboLoaiSP.ValueMember = "MaLoai";
        }

        // --- 5. HÀM TẢI SẢN PHẨM (CHO DATAGRIDVIEW) ---
        void LoadSanPham()
        {
            // Gọi BUS để lấy danh sách Sản Phẩm
            // BUS trả về DataTable hoặc List<DTO>
            dgSanPham.DataSource = busSP.LayDSSanPham();

            // Đặt lại trạng thái ban đầu
            txtMaSP.Enabled = false;
        }

        // --- 6. SỰ KIỆN ROWENTER CỦA DATAGRIDVIEW ---
        // Đã đổi thành CellClick theo hướng dẫn trước (Nếu bạn dùng RowEnter thì giữ nguyên)
        private void dgSanPham_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgSanPham.Rows[e.RowIndex].IsNewRow) return;

            try
            {
                // Lấy dữ liệu từ dòng đang chọn
                txtMaSP.Text = dgSanPham.Rows[e.RowIndex].Cells["MaSP"].Value.ToString();
                txtTenSP.Text = dgSanPham.Rows[e.RowIndex].Cells["TenSP"].Value.ToString();
                // Tên cột DVTinh trong DB của bạn có thể là DVT hoặc DVTinh
                txtDVT.Text = dgSanPham.Rows[e.RowIndex].Cells["DVTinh"].Value.ToString();
                txtDonGia.Text = dgSanPham.Rows[e.RowIndex].Cells["DonGia"].Value.ToString();
                cboLoaiSP.SelectedValue = dgSanPham.Rows[e.RowIndex].Cells["MaLoai"].Value;

                // Tắt ô Mã SP đi khi sửa hoặc xem
                txtMaSP.Enabled = false;
            }
            catch (Exception)
            {
                // Bỏ qua lỗi nếu dữ liệu đang tải hoặc không hợp lệ
            }
        }

        // --- 7. CÁC NÚT THAO TÁC CRUD ---

        private void btThem_Click(object sender, EventArgs e)
        {
            // Thiết lập chế độ Thêm
            isAdding = true;

            // Xóa trống các ô và cho phép nhập Mã SP
            txtMaSP.Enabled = true;
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtDVT.Text = "";
            txtDonGia.Text = "";
            cboLoaiSP.SelectedIndex = 0; // Chọn loại đầu tiên
            txtMaSP.Focus(); // Đặt con trỏ vào ô Mã SP
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            // Bước này dùng cho cả Thêm mới và Sửa
            try
            {
                // --- SỬA Ở ĐÂY: Dùng class 'SanPham' thay vì 'SanPhamDTO' ---
                SanPham sp = new SanPham();
                sp.MaSP = txtMaSP.Text;
                sp.TenSP = txtTenSP.Text;
                sp.DVTinh = txtDVT.Text;
                // Chú ý: Kiểm tra DB của bạn cột DonGia là int hay decimal
                // Nếu DB là int thì dùng int.Parse, nếu Money thì dùng decimal.Parse
                sp.DonGia = int.Parse(txtDonGia.Text);
                sp.MaLoai = cboLoaiSP.SelectedValue.ToString();

                bool result = false;

                if (isAdding)
                {
                    // Sẽ hết lỗi bool khi bạn cập nhật BUS ở Bước 2
                    result = busSP.ThemSanPham(sp);
                }
                else
                {
                    result = busSP.SuaSanPham(sp);
                }

                if (result)
                {
                    MessageBox.Show("Thao tác thành công!");
                    LoadSanPham();
                    isAdding = false;
                }
                else
                {
                    MessageBox.Show("Thất bại! Có thể mã bị trùng hoặc dữ liệu sai.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            // Khi bấm Sửa, ta chuyển về chế độ "Sửa" và cho phép người dùng nhập
            isAdding = false;
            txtMaSP.Enabled = false; // Mã SP vẫn phải tắt
            txtTenSP.Focus();
            // Người dùng sẽ bấm nút LƯU để lưu thay đổi
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Xác nhận
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa Sản phẩm có Mã: " + txtMaSP.Text + "?", "Xác nhận Xóa",
                    MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }

                // Lấy Mã SP từ ô nhập
                string maSP = txtMaSP.Text;

                // Gọi BUS để Xóa
                if (busSP.XoaSanPham(maSP)) // Giả sử hàm XoaSanPham(string maSP) đã được code trong BUS
                {
                    MessageBox.Show("Xóa thành công!");
                }
                else
                {
                    MessageBox.Show("Xóa không thành công!");
                }

                // Tải lại dữ liệu 
                LoadSanPham();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi Xóa: " + ex.Message);
                LoadSanPham();
            }
        }

        // --- 8. SỰ KIỆN FORM CLOSING ---
        // Bây giờ không cần đóng kết nối nữa vì kết nối đã được đóng/mở trong DAL
        // Hàm này có thể bỏ đi, hoặc chỉ dùng để dọn dẹp các đối tượng UI khác
        private void FormQLSP_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Có thể dọn dẹp các đối tượng BUS, DTO nếu cần (nhưng thường không bắt buộc)
        }
    }
}