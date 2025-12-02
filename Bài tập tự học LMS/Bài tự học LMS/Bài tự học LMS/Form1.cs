using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Bài_tự_học_LMS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void mnuTileH_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void mnuTileV_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void mnuCascade_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Áp dụng class MyMenuRenderer bên dưới vào MenuStrip
            menuStrip1.Renderer = new ToolStripProfessionalRenderer(new MyMenuRenderer());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Hàm này đang trống, bạn có thể xóa hoặc để đó
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            // Cập nhật giờ hệ thống liên tục
            lblDongHo.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void Form1_MdiChildActivate(object sender, EventArgs e)
        {
            // Code xử lý khi chuyển đổi Form con (bạn kiểm tra lại logic chỗ này nhé, thường là đổi tên Form chứ không phải set đồng hồ)
            Form f = this.ActiveMdiChild;
            if (f != null)
                lblTenForm.Text = "[" + f.Text + "]";
            else
                lblTenForm.Text = "";
        }

        // --- HÀM NÀY PHẢI NẰM TRONG CLASS FORM1 ---
        public async void BatDauTienTrinh(string tenCongViec)
        {
            lblTrangThai.Text = "Đang xử lý: " + tenCongViec + "...";
            prgTienDo.Visible = true;
            prgTienDo.Value = 0;

            // Giả lập chạy từ 0 đến 100%
            for (int i = 0; i <= 100; i += 10)
            {
                prgTienDo.Value = i;
                await Task.Delay(50); // Nghỉ 50ms tạo hiệu ứng chạy
            }

            lblTrangThai.Text = "Sẵn sàng";
            prgTienDo.Visible = false;
        }
        public class MyMenuRenderer : ProfessionalColorTable
        {
            public override Color MenuItemSelected => Color.FromArgb(240, 128, 128);
            public override Color MenuItemBorder => Color.FromArgb(255, 255, 255);
            public override Color MenuItemPressedGradientBegin => Color.FromArgb(205, 92, 92);
            public override Color MenuItemPressedGradientEnd => Color.FromArgb(205, 92, 92);
        }

    }

}