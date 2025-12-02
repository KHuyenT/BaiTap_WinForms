using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop_buoi1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn mở ứng dụng không?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                this.Close();
            }
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            string noiDung = txtNoiDung.Text;
            MessageBox.Show(noiDung, "Nội dung bạn đã nhập");
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.H)
            {
                txtNoiDung.Text = "Xin chào Khoa CNTTKD";
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            { MessageBox.Show("Bạn mới nhấn chuột phải đó nha!"); }
            if (e.Button == MouseButtons.Left)
            { MessageBox.Show("Bạn mới nhấn chuột trái đó nha!"); }
            if (e.Button == MouseButtons.Middle)
            { MessageBox.Show("Lần đầu mình mới thấy có người nhấn chuột giữa như bạn đó!"); }    
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }

        }
    }
}
