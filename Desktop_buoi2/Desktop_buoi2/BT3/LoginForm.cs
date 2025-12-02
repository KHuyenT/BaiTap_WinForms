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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        private bool KiemTraLoi()
        {
            bool isError = false;

            //Kiểm tra Username
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                errorProvider1.SetError(txtUsername, "Tên đăng nhập không được để trống!");
                isError = true;
            }
            else
            {
                errorProvider1.SetError(txtUsername, ""); // Xóa lỗi nếu đã nhập
            }

            //Kiểm tra Password
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "Mật khẩu không được để trống!");
                isError = true;
            }
            else
            {
                errorProvider1.SetError(txtPassword, "");
            }

            return isError;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Kiểm tra và thoát nếu có lỗi để trống
            if (KiemTraLoi())
            {
                return;
            }

            string username = txtUsername.Text;
            string password = txtPassword.Text;

            //Đăng nhập thành công
            if (username == "admin" && password == "123")
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                BT3 mainForm = new BT3();
                mainForm.Show();

                // Ẩn Form đăng nhập hiện tại
                this.Hide();
            }
            //Đăng nhập thất bại
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear(); // Xóa mật khẩu cũ
                txtPassword.Focus();
            }
        }
    }
}
