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
    public partial class FormListBox : Form
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
        public FormListBox()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // 1. Khởi tạo và Mở kết nối
                conn = new SqlConnection(strConnectionString);
                conn.Open();

                // 2. Vận chuyển dữ liệu từ bảng SanPham vào SqlDataAdapter
                string sqlQuery = "SELECT MaSP, TenSP FROM SanPham"; // Chỉ cần lấy 2 cột Mã và Tên
                da = new SqlDataAdapter(sqlQuery, conn);

                // 3. Khởi tạo và Đổ dữ liệu vào DataSet
                ds = new DataSet();
                da.Fill(ds);

                // 4. Đưa dữ liệu lên ListBox (lstSanPham)
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    lstSanPham.DataSource = ds.Tables[0];
                    // Hiển thị tên sản phẩm cho người dùng thấy
                    lstSanPham.DisplayMember = "TenSP";
                    // Giá trị thật (ẩn) được liên kết với mỗi mục
                    lstSanPham.ValueMember = "MaSP";
                }
            }
            catch (SqlException)
            {
                // Bẫy lỗi SQL: Lỗi kết nối, tên CSDL/Bảng sai, v.v.
                MessageBox.Show("Không lấy được dữ liệu, có lỗi rồi! Vui lòng kiểm tra chuỗi kết nối và tên bảng.", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Bẫy các lỗi khác
                MessageBox.Show("Đã xảy ra lỗi không xác định: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Quan trọng: Đóng kết nối ngay sau khi Fill dữ liệu
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            // Khai báo biến traloi
            DialogResult traloi;

            // Hiện hộp thoại hỏi đáp
            traloi = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?", "Xác nhận Thoát",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            // Kiểm tra có nhắp chọn nút Ok không?
            if (traloi == DialogResult.OK)
            {
                // Dừng toàn bộ ứng dụng
                Application.Exit();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Giải phóng tài nguyên DataSet/DataAdapter
            if (ds != null)
            {
                ds.Dispose();
                ds = null;
            }

            // Đóng và hủy kết nối (dù đã Close ở Form_Load, đây là biện pháp phòng ngừa)
            if (conn != null && conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
            conn = null;
        }

        private void btnChuyenForm_Click(object sender, EventArgs e)
        {          
            FormComboBox formMoi = new FormComboBox();
            formMoi.Show();
            this.Hide();

        }
    }
}
