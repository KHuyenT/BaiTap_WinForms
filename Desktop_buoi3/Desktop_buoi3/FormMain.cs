using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop_buoi3
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Cập nhật thời gian hệ thống vào StatusStrip Label
            toolStripStatusLabelTime.Text = "Thời gian: " + DateTime.Now.ToString("HH:mm:ss");
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == typeof(FormNhanVien))
                {
                    f.Activate();
                    return;
                }
            }
            //Tạo một Form con mới
            FormNhanVien f_nv = new FormNhanVien();

            //Thiết lập Form cha (MDI Parent)
            f_nv.MdiParent = this; // 'this' là FormMain

            //Hiển thị Form con
            f_nv.Show();

            //Cập nhật StatusStrip
            toolStripStatusLabelForm.Text = "Người dùng: Admin | Form đang mở: Nhân Viên";
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem Form đã mở chưa
            foreach (Form f in this.MdiChildren)
            {
                // Nếu đã mở thì kích hoạt (focus) Form đó lên và dừng lại
                if (f.GetType() == typeof(FormSanPham))
                {
                    f.Activate();
                    return;
                }
            }
            //Tạo một Form con mới
            FormSanPham f_sp = new FormSanPham();

            //Thiết lập Form cha (MDI Parent)
            f_sp.MdiParent = this; // 'this' là FormMain

            //Hiển thị Form con
            f_sp.Show();

            //Cập nhật StatusStrip
            toolStripStatusLabelForm.Text = "Người dùng: Admin | Form đang mở: Sản Phẩm";

        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem Form đã mở chưa
            foreach (Form f in this.MdiChildren)
            {
                // Nếu đã mở thì kích hoạt (focus) Form đó lên
                if (f.GetType() == typeof(FormHoaDon))
                {
                    f.Activate();
                    return; // Dừng lại, không tạo form mới
                }
            }

            // 2. Nếu chưa mở, thì tạo Form mới
            FormHoaDon f_hd = new FormHoaDon();
            f_hd.MdiParent = this; // 'this' là FormMain
            f_hd.WindowState = FormWindowState.Maximized; // 👈 Đặt trạng thái full màn hình
            f_hd.Show();

            // 3. (Tùy chọn) Cập nhật StatusStrip
            // Giả sử label Form đang mở là toolStripStatusLabelForm
            // toolStripStatusLabelForm.Text = "Người dùng: Admin | Form đang mở: Hóa Đơn";
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            // Nếu Form bị thu nhỏ (Minimize)
            if (this.WindowState == FormWindowState.Minimized)
            {
                // Ẩn Form khỏi Taskbar
                this.ShowInTaskbar = false;

                // Ẩn Form (nhưng ứng dụng vẫn chạy)
                this.Hide();
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Hiển thị lại Form
    this.Show();

            // Khôi phục Form về trạng thái bình thường
            this.WindowState = FormWindowState.Normal;

            // Hiển thị lại Form trên Taskbar
            this.ShowInTaskbar = true;
        }

        private void txtTimKiemNhanh_KeyDown(object sender, KeyEventArgs e)
        {
            // Chỉ thực hiện khi nhấn phím Enter
            if (e.KeyCode == Keys.Enter)
            {
                string tuKhoa = txtTimKiemNhanh.Text;

                // --- 1. Mở hoặc Kích hoạt FormNhanVien ---
                FormNhanVien f_nv = null;

                // Tìm xem FormNhanVien đã mở chưa
                foreach (Form f in this.MdiChildren)
                {
                    if (f.GetType() == typeof(FormNhanVien))
                    {
                        f_nv = (FormNhanVien)f; // Lấy tham chiếu đến Form đã mở
                        break;
                    }
                }

                // Nếu Form chưa mở, tạo mới
                if (f_nv == null)
                {
                    f_nv = new FormNhanVien();
                    f_nv.MdiParent = this;
                    f_nv.Show();
                }

                // --- 2. Gọi hàm Tìm kiếm ---
                f_nv.Activate(); // Đưa Form lên trên
                f_nv.TimKiemNhanh(tuKhoa); // Gọi hàm public bạn vừa tạo
            }
        }
    }
}
