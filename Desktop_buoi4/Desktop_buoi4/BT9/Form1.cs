using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BT9
{
    public partial class FormQLSP : Form
    {
        // 1. Chuỗi kết nối
        // Ví dụ sử dụng Integrated Security (Kết nối Windows)
        string strConnectionString = "Data Source = HUYENKHANH; Initial Catalog = QLBH; Integrated Security=True;";

        // 2. Đối tượng kết nối dữ liệu
        SqlConnection conn = null;

        // 3. Đối tượng thực hiện vận chuyển dữ liệu (từ DB vào bộ nhớ)
        SqlDataAdapter da = null;

        // 4. Đối tượng chứa dữ liệu trong bộ nhớ
        DataSet ds = null;
        SqlCommandBuilder cmd = null;
        public FormQLSP()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // Khởi tạo và Mở kết nối (Mô hình Connected)
                conn = new SqlConnection(strConnectionString);
                conn.Open();

                // Tải danh sách Loại Sản Phẩm vào ComboBox
                LoadLoaiSanPham();

                // Tải danh sách Sản Phẩm vào DataGridView
                LoadSanPham();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải Form: " + ex.Message);
            }
        }
        // --- 4. HÀM TẢI LOẠI SẢN PHẨM (CHO COMBOBOX) ---
        void LoadLoaiSanPham()
        {
            // Sử dụng Adapter và DataSet cục bộ để không ảnh hưởng đến 'ds' chính
            SqlDataAdapter daLoai = new SqlDataAdapter("SELECT * FROM LoaiSanPham", conn);
            DataSet dsLoai = new DataSet();
            daLoai.Fill(dsLoai, "LoaiSanPham");

            cboLoaiSP.DataSource = dsLoai.Tables["LoaiSanPham"];
            cboLoaiSP.DisplayMember = "TenLoai";
            cboLoaiSP.ValueMember = "MaLoai";

            daLoai.Dispose();
            dsLoai.Dispose();
        }

        // --- 5. HÀM TẢI SẢN PHẨM (CHO DATAGRIDVIEW) ---
        void LoadSanPham()
        {
            // Khởi tạo Adapter cho bảng SanPham (dùng biến class 'da')
            da = new SqlDataAdapter("SELECT * FROM SanPham", conn);

            // Khởi tạo CommandBuilder (rất quan trọng)
            // Nó tự động tạo lệnh Insert, Update, Delete cho 'da'
            cmd = new SqlCommandBuilder(da);

            // Khởi tạo DataSet (dùng biến class 'ds')
            ds = new DataSet();

            // Đổ dữ liệu
            da.Fill(ds, "SanPham");
            dgSanPham.DataSource = ds.Tables["SanPham"];

            // Tắt MaSP sau khi tải
            txtMaSP.Enabled = false;
        }
        // --- 6. SỰ KIỆN ROWENTER CỦA DATAGRIDVIEW ---
        // Điền dữ liệu vào TextBox khi chọn dòng
        private void dgSanPham_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgSanPham.Rows[e.RowIndex].IsNewRow) return;
            if (ds == null || ds.Tables["SanPham"].Rows.Count == 0) return;

            try
            {
                // Lấy dữ liệu từ dòng đang chọn
                txtMaSP.Text = dgSanPham.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTenSP.Text = dgSanPham.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtDVT.Text = dgSanPham.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtDonGia.Text = dgSanPham.Rows[e.RowIndex].Cells[3].Value.ToString();
                cboLoaiSP.SelectedValue = dgSanPham.Rows[e.RowIndex].Cells[4].Value.ToString();

                // Tắt ô Mã SP đi
                txtMaSP.Enabled = false;
            }
            catch (Exception)
            {
                // Bỏ qua lỗi nếu dữ liệu đang tải hoặc không hợp lệ
            }
        }

        // --- 7. CÁC NÚT THAO TÁC CRUD (LOGIC BÀI 9) ---

        private void btThem_Click(object sender, EventArgs e)
        {
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
            try
            {
                // Thêm dòng mới vào DataSet (bộ nhớ)
                DataRow row = ds.Tables["SanPham"].NewRow();
                row["MaSP"] = txtMaSP.Text;
                row["TenSP"] = txtTenSP.Text;
                row["DVTinh"] = txtDVT.Text;
                row["DonGia"] = txtDonGia.Text;
                row["MaLoai"] = cboLoaiSP.SelectedValue.ToString();

                ds.Tables["SanPham"].Rows.Add(row);

                // Cập nhật (đẩy) thay đổi từ DataSet vào CSDL
                // 'cmd' (SqlCommandBuilder) đã tự tạo lệnh INSERT
                if (da.Update(ds, "SanPham") > 0)
                {
                    MessageBox.Show("Lưu thành công!");
                }
                else
                {
                    MessageBox.Show("Lưu không thành công!");
                }

                // Tải lại dữ liệu để đồng bộ (theo hướng dẫn)
                LoadSanPham();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi Lưu: " + ex.Message + "\n(Mã SP có thể bị trùng)");
                LoadSanPham(); // Tải lại nếu có lỗi
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy vị trí dòng đang chọn trên Grid
                int pos = dgSanPham.CurrentRow.Index;
                // Lấy dòng đó trong DataSet (bộ nhớ)
                DataRow row = ds.Tables["SanPham"].Rows[pos];

                // Cập nhật các trường (trừ MaSP là khóa chính)
                row["TenSP"] = txtTenSP.Text;
                row["DVTinh"] = txtDVT.Text;
                row["DonGia"] = txtDonGia.Text;
                row["MaLoai"] = cboLoaiSP.SelectedValue.ToString();

                // Cập nhật (đẩy) thay đổi vào CSDL
                if (da.Update(ds, "SanPham") > 0)
                {
                    MessageBox.Show("Cập nhật thành công!");
                }
                else
                {
                    MessageBox.Show("Cập nhật không thành công!");
                }

                // Tải lại dữ liệu (theo hướng dẫn)
                LoadSanPham();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi Sửa: " + ex.Message);
                LoadSanPham(); // Tải lại nếu có lỗi
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Xác nhận
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }

                int pos = dgSanPham.CurrentRow.Index;
                // Đánh dấu dòng là đã xóa (trong DataSet)
                ds.Tables["SanPham"].Rows[pos].Delete();

                // Cập nhật (đẩy) thay đổi vào CSDL
                if (da.Update(ds, "SanPham") > 0)
                {
                    MessageBox.Show("Xóa thành công!");
                }
                else
                {
                    MessageBox.Show("Xóa không thành công!");
                }

                // Tải lại dữ liệu (theo hướng dẫn)
                LoadSanPham();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi Xóa: " + ex.Message);
                LoadSanPham(); // Tải lại nếu có lỗi
            }
        }

        // --- 8. SỰ KIỆN FORM CLOSING ---
        // Đóng kết nối khi Form tắt
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (conn != null && conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
            if (ds != null) ds.Dispose();
            if (da != null) da.Dispose();
            if (cmd != null) cmd.Dispose();
        }
    }
}
