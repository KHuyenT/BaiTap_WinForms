using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT3
{
    public partial class BT3 : Form
    {
        //Khai báo DataTable để lưu trữ dữ liệu sản phẩm
        private DataTable dtSanPham = new DataTable();
        public BT3()
        {
            InitializeComponent();
            // Gọi hàm khởi tạo CSDL giả lập
            SetupDataTable();
        }
        private void SetupDataTable()
        {
            dtSanPham.Columns.Add("TenSP", typeof(string));
            dtSanPham.Columns.Add("LoaiSP", typeof(string));
            dtSanPham.Columns.Add("SoLuong", typeof(int));

            // Gán DataTable làm nguồn dữ liệu cho DataGridView
            dgvSanPham.DataSource = dtSanPham;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenSP.Text) || cboLoaiSP.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng nhập Tên sản phẩm và chọn Loại sản phẩm.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRow newRow = dtSanPham.NewRow();

            //Gán giá trị từ controls vào các cột của DataRow
            newRow["TenSP"] = txtTenSP.Text;
            newRow["LoaiSP"] = cboLoaiSP.SelectedItem.ToString();
            newRow["SoLuong"] = (int)nudSoLuong.Value;

            dtSanPham.Rows.Add(newRow);

            MessageBox.Show("Đã thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnLamMoi_Click(sender, e); // Tái sử dụng code Làm mới
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTenSP.Clear();
            cboLoaiSP.SelectedIndex = -1; // Bỏ chọn ComboBox
            nudSoLuong.Value = nudSoLuong.Minimum; // Đặt lại số lượng về giá trị nhỏ nhất 
            txtTenSP.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //Kiểm tra xem có dòng nào được chọn không
            if (dgvSanPham.SelectedRows.Count > 0)
            {
                //Lấy chỉ số của dòng đầu tiên được chọn
                int rowIndex = dgvSanPham.SelectedRows[0].Index;

                DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    //Dùng Rows.RemoveAt vì dgvSanPham.Rows có thể chứa các dòng không phải DataRow (ví dụ: dòng thêm mới)
                    dtSanPham.Rows.RemoveAt(rowIndex);
                    MessageBox.Show("Đã xóa sản phẩm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng sản phẩm để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

 
    }
}
