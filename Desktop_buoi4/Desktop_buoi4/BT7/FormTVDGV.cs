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
    public partial class FormTVDGV : Form
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
        public FormTVDGV()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // Khởi tạo và Mở kết nối
                conn = new SqlConnection(strConnectionString);
                conn.Open(); // Kết nối sẽ được giữ mở

                // Vận chuyển dữ liệu vào TreeView
                da = new SqlDataAdapter("SELECT * FROM LoaiSanPham", conn);
                ds = new DataSet();
                da.Fill(ds, "LoaiSanPham");

                // Xóa các node cũ (nếu có)
                trvLoaiSanPham.Nodes.Clear();

                TreeNode node;
                // Duyệt qua từng dòng trong bảng LoaiSanPham
                foreach (DataRow dr in ds.Tables["LoaiSanPham"].Rows)
                {
                    node = new TreeNode();
                    node.Text = dr["TenLoai"].ToString(); // Tên hiển thị
                    node.Tag = dr["MaLoai"].ToString();  // Giá trị ẩn (Mã)
                    trvLoaiSanPham.Nodes.Add(node);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không lấy được dữ liệu, có lỗi rồi! \n" + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // --- 4. HÀM LỌC SẢN PHẨM ---
        // Tải danh sách sản phẩm vào DataGridView dựa trên MaLoai
        void LoadSanPham(string maloai)
        {
            try
            {
                // Vận chuyển dữ liệu vào DataGridView
                if (da != null) da.Dispose();
                if (ds != null) ds.Dispose();

                da = null;
                ds = new DataSet();

                // Tạo câu truy vấn (LƯU Ý: Nối chuỗi dễ bị lỗi SQL Injection)
                string sql = "SELECT * FROM SanPham Where MaLoai='" + maloai + "'";

                // Sử dụng lại kết nối 'conn' đã mở ở Form_Load
                da = new SqlDataAdapter(sql, conn);
                da.Fill(ds, "SanPham");

                dgSanPham.DataSource = ds.Tables["SanPham"];

                SetDataGridViewHeaders();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi tải sản phẩm: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- 5. SỰ KIỆN CHỌN NODE TRÊN TREEVIEW ---
        // Khi người dùng nhấp vào một Loại Sản Phẩm
        private void trvLoaiSanPham_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Kiểm tra xem node được chọn có tồn tại không
            if (trvLoaiSanPham.SelectedNode != null)
            {
                // Lấy MaLoai từ thuộc tính .Tag của node đã chọn
                string maLoaiDuocChon = trvLoaiSanPham.SelectedNode.Tag.ToString();

                // Gọi hàm tải sản phẩm
                LoadSanPham(maLoaiDuocChon);
            }
        }

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

        // --- 7. SỰ KIỆN FORM CLOSING ---
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Giải phóng DataSet
            if (ds != null)
            {
                ds.Dispose();
                ds = null;
            }

            // Đóng kết nối
            if (conn != null && conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
            conn = null;
        }
    }
}
