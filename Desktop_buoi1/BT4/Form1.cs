using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtSo1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Cho phép số và phím Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Không cho nhập ký tự khác
            }
        }

        private void txtSo2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Cho phép số và phím Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Không cho nhập ký tự khác
            }
        }

        private void btnCong_Click(object sender, EventArgs e)
        {
            double so1 = double.Parse(txtSo1.Text);
            double so2 = double.Parse(txtSo2.Text);
            double ketQua = so1 + so2;
            txtKetQua.Text = ketQua.ToString();
        }

        private void btnTru_Click(object sender, EventArgs e)
        {
            double so1 = double.Parse(txtSo1.Text);
            double so2 = double.Parse(txtSo2.Text);
            double ketQua = so1 - so2;
            txtKetQua.Text = ketQua.ToString();
        }

        private void btnNhan_Click(object sender, EventArgs e)
        {
            double so1 = double.Parse(txtSo1.Text);
            double so2 = double.Parse(txtSo2.Text);
            double ketQua = so1 * so2;
            txtKetQua.Text = ketQua.ToString();
        }

        private void btnChia_Click(object sender, EventArgs e)
        {
            double so1 = double.Parse(txtSo1.Text);
            double so2 = double.Parse(txtSo2.Text);

            if (so2 == 0)
            {
                MessageBox.Show("Không thể chia cho 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                double ketQua = so1 / so2;
                txtKetQua.Text = ketQua.ToString();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                txtSo1.Clear();
                txtSo2.Clear();
                txtKetQua.Clear();
            }
        }
    }
}
