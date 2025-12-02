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


namespace LMS_Desktopbuoi4.GUI
{
    public partial class FormBT456 : Form
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
        public FormBT456()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Gọi hàm TimKiem với từ khóa rỗng để tải tất cả sản phẩm
            TimKiem(txtKeyWord.Text);
            LoadLoaiSanPhamComboBox();
        }
        // --- 4. HÀM TÌM KIẾM (TÁI SỬ DỤNG) ---
        // Hàm này xử lý cả việc Tải Tất Cả (keyword rỗng) và Tìm Kiếm (có keyword)
        void TimKiem(string keyword)
        {
            // Dọn dẹp tài nguyên cũ (nếu có) trước khi tìm kiếm mới
            if (ds != null)
            {
                ds.Dispose();
                ds = null;
            }
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                // Mở kết nối
                conn = new SqlConnection(strConnectionString);
                conn.Open();

                // Xây dựng câu truy vấn SQL
                string sql = "";
                if (!string.IsNullOrEmpty(keyword))
                {
                    // Chức năng Tìm kiếm
                    sql = "SELECT * FROM SanPham Where TenSP like N'%" + keyword + "%'";
                }
                else
                {
                    // Chức năng Tải tất cả (khi Form_Load)
                    sql = "SELECT * FROM SanPham";
                }

                // Đổ dữ liệu
                da = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                da.Fill(ds, "SanPhamTable");

                // Gán nguồn cho DataGridView
                dgSanPham.DataSource = ds.Tables["SanPhamTable"];

                // Thiết lập tiêu đề cột
                SetDataGridViewHeaders();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không lấy được dữ liệu, có lỗi! \n" + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Luôn đóng kết nối sau khi làm xong
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

        }
        void LoadLoaiSanPhamComboBox()
        {
            // Hàm này chỉ tải dữ liệu cho ComboBox, 
            // nó dùng DataSet và DataAdapter riêng để không ảnh hưởng đến DataGridView
            DataSet dsCombo = new DataSet();
            SqlDataAdapter daCombo;
            SqlConnection connCombo = null; // Dùng kết nối riêng

            try
            {
                connCombo = new SqlConnection(strConnectionString);
                connCombo.Open();

                daCombo = new SqlDataAdapter("SELECT * FROM LoaiSanPham", connCombo);
                daCombo.Fill(dsCombo, "LoaiSanPham"); // Đổ dữ liệu vào dsCombo

                cboLoaiSP.DataSource = dsCombo.Tables["LoaiSanPham"];
                cboLoaiSP.DisplayMember = "TenLoai";
                cboLoaiSP.ValueMember = "MaLoai";
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi tải danh sách Loại Sản Phẩm: " + ex.Message);
            }
            finally
            {
                if (connCombo != null && connCombo.State == ConnectionState.Open)
                {
                    connCombo.Close();
                }
            }
        }
        // --- 6. HÀM LỌC SẢN PHẨM (CỦA BÀI 6) ---
        // Hàm này lọc DataGridView theo MaLoai
        void LoadSanPham(string maloai)
        {
            // Dọn dẹp tài nguyên cũ của DataGridView
            if (ds != null) ds.Dispose();
            if (conn != null && conn.State == ConnectionState.Open) conn.Close();

            try
            {
                conn = new SqlConnection(strConnectionString);
                conn.Open();

                // LƯU Ý: Nối chuỗi trực tiếp dễ bị lỗi SQL Injection
                string sql = "SELECT * FROM SanPham Where MaLoai='" + maloai + "'";

                da = new SqlDataAdapter(sql, conn);
                ds = new DataSet(); // Tạo mới DataSet cho DataGridView
                da.Fill(ds, "SanPham");

                dgSanPham.DataSource = ds.Tables["SanPham"];

                // Thiết lập tiêu đề cột
                SetDataGridViewHeaders();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi lọc sản phẩm: " + ex.Message);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open) conn.Close();
            }
        }
        // --- 7. HÀM HỖ TRỢ: THIẾT LẬP TIÊU ĐỀ CỘT ---
        // Tách ra hàm riêng để TimKiem và LoadSanPham cùng gọi
        void SetDataGridViewHeaders()
        {
            if (dgSanPham.Columns.Count >= 5)
            {
                dgSanPham.Columns[0].HeaderText = "Mã sản phẩm";
                dgSanPham.Columns[1].HeaderText = "Tên sản phẩm";
                dgSanPham.Columns[2].HeaderText = "Đơn vị tính";
                dgSanPham.Columns[3].HeaderText = "Đơn giá";
                dgSanPham.Columns[4].HeaderText = "Mã loại sản phẩm";
            }
        }
        // --- 5. SỰ KIỆN NÚT TÌM KIẾM ---
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            // Gọi hàm TimKiem với từ khóa người dùng nhập (bỏ khoảng trắng thừa)
            TimKiem(txtKeyWord.Text.Trim());
        }

        // --- 6. SỰ KIỆN FORM CLOSING ---
        // Giải phóng tài nguyên khi đóng Form
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Thêm kiểm tra "null" để đảm bảo chương trình không bị crash
            if (ds != null)
            {
                ds.Dispose();
                ds = null;
            }
            if (conn != null && conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
            conn = null;
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            if (cboLoaiSP.SelectedValue != null)
            {
                LoadSanPham(cboLoaiSP.SelectedValue.ToString());
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một loại sản phẩm để lọc.");
            }
        }
    }
}
