using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return Math.Abs(a);
        }

        private int LCM(int a, int b)
        {
            return Math.Abs(a * b) / GCD(a, b);
        }
        private void txtA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;  // chặn không cho nhập ký tự khác số
            }
        }

        private void txtB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private void btnTim_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu nhập
            if (string.IsNullOrWhiteSpace(txtA.Text) || string.IsNullOrWhiteSpace(txtB.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ A và B!");
                return;
            }

            int a, b;
            if (!int.TryParse(txtA.Text, out a) || !int.TryParse(txtB.Text, out b))
            {
                MessageBox.Show("A và B phải là số nguyên!");
                return;
            }

            if (rdoUSCLN.Checked)
            {
                txtKetQua.Text = GCD(a, b).ToString();
            }
            else if (rdoBSCNN.Checked)
            {
                txtKetQua.Text = LCM(a, b).ToString();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn USCLN hoặc BSCNN!");
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            txtA.Clear();
            txtB.Clear();
            txtKetQua.Clear();
            rdoUSCLN.Checked = false;
            rdoBSCNN.Checked = false;
            txtA.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có chắc muốn thoát không?",
                                              "Xác nhận",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
