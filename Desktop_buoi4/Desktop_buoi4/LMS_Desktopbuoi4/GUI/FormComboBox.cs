using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LMS_Desktopbuoi4.GUI
{
    public partial class FormComboBox : Form
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
        public FormComboBox()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                // 1. Khởi tạo và Mở kết nối
                conn = new SqlConnection(strConnectionString);
                conn.Open();

                // 2. Vận chuyển dữ liệu từ bảng SanPham
                string sqlQuery = "SELECT MaSP, TenSP FROM SanPham";
                da = new SqlDataAdapter(sqlQuery, conn);

                // 3. Khởi tạo và Đổ dữ liệu vào DataSet
                ds = new DataSet();
                da.Fill(ds);

                // 4. Đưa dữ liệu lên ComboBox (cboSanPham)
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    // Gán nguồn dữ liệu
                    cboSanPham.DataSource = ds.Tables[0];

                    // Cột hiển thị (tên sản phẩm)
                    cboSanPham.DisplayMember = "TenSP";

                    // Cột giá trị (mã sản phẩm)
                    cboSanPham.ValueMember = "MaSP";

                    // Tùy chọn: Chọn mục đầu tiên làm mặc định
                    cboSanPham.SelectedIndex = 0;
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được dữ liệu, có lỗi rồi! Vui lòng kiểm tra chuỗi kết nối và tên bảng.", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi không xác định: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi;

            // Hiện hộp thoại hỏi đáp
            traloi = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?", "Xác nhận Thoát",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            // Kiểm tra có nhắp chọn nút Ok không?
            if (traloi == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Giải phóng tài nguyên DataSet
            if (ds != null)
            {
                ds.Dispose();
                ds = null;
            }

            // Đóng và hủy kết nối
            if (conn != null && conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
            conn = null;
        }

        private void btnChuyenForm_Click(object sender, EventArgs e)
        {
            FormListBox formMoi = new FormListBox();
            formMoi.Show();
            this.Hide();
        }
    }
}
