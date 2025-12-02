using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT5
{
    public partial class QuanLySanPhamForm : Form
    {
        public class Product
        {
            public string Ten { get; set; }
            public string Loai { get; set; }
            public int SoLuong { get; set; }
            public string TinhTrang { get; set; } // "Còn hàng" hoặc "Hết hàng"
        }
        private BindingList<Product> productList = new BindingList<Product>();
        public QuanLySanPhamForm()
        {
            InitializeComponent();
            dgvSanPham.DataSource = productList; // Gán nguồn dữ liệu
            rdoConHang.Checked = true; // Mặc định chọn Còn hàng
        }
        private void ClearControls()
        {
            // Xóa nội dung của các ô nhập liệu
            txtTenSP.Clear();
            cboLoaiSP.SelectedIndex = -1; // Bỏ chọn ComboBox
            nudSoLuong.Value = nudSoLuong.Minimum; // Đặt về giá trị mặc định
            rdoConHang.Checked = true; // Mặc định chọn lại "Còn hàng"

            // Xóa tất cả các thông báo lỗi
            errorProvider1.Clear();

            txtTenSP.Focus();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra lỗi (Yêu cầu d)
            if (string.IsNullOrEmpty(txtTenSP.Text))
            {
                errorProvider1.SetError(txtTenSP, "Tên sản phẩm không được trống!");
                return;
            }
            if (nudSoLuong.Value <= 0)
            {
                errorProvider1.SetError(nudSoLuong, "Số lượng phải lớn hơn 0!");
                return;
            }

            // Xóa lỗi nếu nhập đúng
            errorProvider1.Clear();

            Product newProduct = new Product
            {
                Ten = txtTenSP.Text,
                Loai = cboLoaiSP.SelectedItem?.ToString() ?? "Chưa phân loại",
                SoLuong = (int)nudSoLuong.Value,
                // Xác định tình trạng sản phẩm
                TinhTrang = rdoConHang.Checked ? "Còn hàng" : "Hết hàng"
            };

            productList.Add(newProduct);

            // Cập nhật StatusStrip (Yêu cầu e.ii)
            lblTongSanPham.Text = $"Tổng số sản phẩm: {productList.Count}";

            // Xóa dữ liệu nhập để tiếp tục
            txtTenSP.Clear();
            nudSoLuong.Value = nudSoLuong.Minimum;
            txtTenSP.Focus();
            ClearControls();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.SelectedRows.Count > 0)
            {
                // Lấy chỉ số của đối tượng trong List
                int index = dgvSanPham.SelectedRows[0].Index;

                // Xác nhận xóa
                DialogResult confirm = MessageBox.Show("Xác nhận xóa sản phẩm này?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    productList.RemoveAt(index);
                    lblTongSanPham.Text = $"Tổng số sản phẩm: {productList.Count}"; // Cập nhật lại
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa.", "Thông báo");
            }
        }
        private int selectedProductIndex = -1;
        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Đảm bảo người dùng click vào một hàng hợp lệ (không phải hàng header)
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSanPham.Rows[e.RowIndex];

                //Tải dữ liệu lên các controls
                txtTenSP.Text = row.Cells["ColTenSP"].Value.ToString();
                cboLoaiSP.SelectedItem = row.Cells["ColLoaiSP"].Value.ToString();
                nudSoLuong.Value = Convert.ToInt32(row.Cells["ColSoLuong"].Value);

                string tinhTrang = row.Cells["ColTinhTrang"].Value.ToString();
                if (tinhTrang == "Còn hàng")
                {
                    rdoConHang.Checked = true;
                }
                else
                {
                    rdoHetHang.Checked = true;
                }
            }
            else
            {
                // Nếu click vào Header (RowIndex < 0)
                selectedProductIndex = -1;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //Kiểm tra xem đã chọn dòng nào để sửa chưa
    if (selectedProductIndex < 0 || selectedProductIndex >= productList.Count)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm từ danh sách để sửa.", "Lỗi Sửa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Kiểm tra lỗi nhập liệu trước khi sửa (Tái sử dụng code kiểm tra lỗi nếu cần)
            if (string.IsNullOrEmpty(txtTenSP.Text))
            {
                errorProvider1.SetError(txtTenSP, "Tên sản phẩm không được trống!");
                return;
            }
            if (nudSoLuong.Value <= 0)
            {
                errorProvider1.SetError(nudSoLuong, "Số lượng phải lớn hơn 0!");
                return;
            }
            errorProvider1.Clear(); // Xóa lỗi nếu dữ liệu hợp lệ

            //Lấy đối tượng Product cần sửa từ List
            Product productToEdit = productList[selectedProductIndex];

            //Cập nhật các thuộc tính của đối tượng
            productToEdit.Ten = txtTenSP.Text;
            productToEdit.Loai = cboLoaiSP.SelectedItem?.ToString() ?? "Chưa phân loại";
            productToEdit.SoLuong = (int)nudSoLuong.Value;
            productToEdit.TinhTrang = rdoConHang.Checked ? "Còn hàng" : "Hết hàng";

            //Thông báo và làm mới giao diện
            MessageBox.Show("Sản phẩm đã được cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Đặt lại index về -1 để tránh sửa nhầm lần sau
            selectedProductIndex = -1;

            // Gọi hàm làm sạch controls
            ClearControls();

        }
    }
}
