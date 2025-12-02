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

namespace BT8
{
    public partial class FormPhanTrang : Form
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
        // Bảng chứa Sản phẩm để thuận tiện trong quá trình di chuyển
        DataTable dtSP;
        // Biến lưu vị trí dòng
        int vitri = -1;
        public FormPhanTrang()
        {
            InitializeComponent();
        }

        // --- 3. SỰ KIỆN FORM LOAD ---
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // Khởi tạo và Mở kết nối
                conn = new SqlConnection(strConnectionString);
                conn.Open();

                // Tải ComboBox Loại Sản Phẩm
                LoadLoaiSanPham();

                // Đưa dữ liệu vào Bảng sản phẩm dtSP (dùng chung cho cả Form)
                da = new SqlDataAdapter("SELECT * FROM SanPham", conn);
                ds = new DataSet();
                da.Fill(ds, "SanPham");
                dtSP = ds.Tables["SanPham"]; // Gán dữ liệu vào DataTable

                // Tự động nhấn nút First (<<) khi Form vừa load
                btFirst.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải Form: " + ex.Message);
            }
        }
        // --- 4. HÀM TẢI LOẠI SẢN PHẨM (CHO COMBOBOX) ---
        void LoadLoaiSanPham()
        {
            // Vận chuyển dữ liệu vào ComboBox
            // (Dùng Adapter và DataSet cục bộ để không ảnh hưởng đến 'da' và 'ds' chính)
            SqlDataAdapter daLoai = new SqlDataAdapter("SELECT * FROM LoaiSanPham", conn);
            DataSet dsLoai = new DataSet();
            daLoai.Fill(dsLoai, "LoaiSanPham");

            cboLoaiSP.DataSource = dsLoai.Tables["LoaiSanPham"];
            cboLoaiSP.DisplayMember = "TenLoai";
            cboLoaiSP.ValueMember = "MaLoai";

            daLoai.Dispose();
            dsLoai.Dispose();
        }

        // --- 5. HÀM HỖ TRỢ: HIỂN THỊ DỮ LIỆU LÊN TEXTBOX ---
        // (Tách ra để các nút cùng gọi, tránh lặp code)
        void HienThiDuLieu()
        {
            if (vitri < 0 || vitri >= dtSP.Rows.Count) return; // Kiểm tra vị trí hợp lệ

            try
            {
                txtMaSP.Text = dtSP.Rows[vitri]["MaSP"].ToString();
                txtTenSP.Text = dtSP.Rows[vitri]["TenSP"].ToString();
                txtDVT.Text = dtSP.Rows[vitri]["DVTinh"].ToString();
                txtDonGia.Text = dtSP.Rows[vitri]["DonGia"].ToString();
                cboLoaiSP.SelectedValue = dtSP.Rows[vitri]["MaLoai"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị dữ liệu: " + ex.Message);
            }
        }

        // --- 6. CÁC NÚT PHÂN TRANG (LOGIC BÀI 8) ---

        private void btFirst_Click(object sender, EventArgs e)
        {
            if (dtSP.Rows.Count == 0) return;
            vitri = 0;
            HienThiDuLieu();
        }

        private void btLast_Click(object sender, EventArgs e)
        {
            if (dtSP.Rows.Count == 0) return;
            vitri = dtSP.Rows.Count - 1;
            HienThiDuLieu();
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            if (dtSP.Rows.Count == 0) return;
            vitri++;
            if (vitri > dtSP.Rows.Count - 1) vitri = dtSP.Rows.Count - 1;
            HienThiDuLieu();
        }

        private void btPrevious_Click(object sender, EventArgs e)
        {
            if (dtSP.Rows.Count == 0) return;
            vitri--;
            if (vitri < 0) vitri = 0;
            HienThiDuLieu();
        }

        // --- 7. SỰ KIỆN FORM CLOSING ---
        // Đóng kết nối khi Form tắt
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (conn != null && conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
            if (ds != null) ds.Dispose();
            if (da != null) da.Dispose();
        }
    }
}
