using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BT7;
using BT8;
using LMS_Desktopbuoi4.GUI;

namespace LMS_Desktopbuoi4
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btn456_Click(object sender, EventArgs e)
        {
            FormBT456 f = new FormBT456();
            f.ShowDialog();
        }

        private void btnComboBox_Click(object sender, EventArgs e)
        {
            FormComboBox g = new FormComboBox();
            g.ShowDialog();
        }

        private void btnListBox_Click(object sender, EventArgs e)
        {
            FormListBox a = new FormListBox();
            a.ShowDialog();
        }

        private void btnPhanTrang_Click(object sender, EventArgs e)
        {
            FormPhanTrang b = new FormPhanTrang();
            b.ShowDialog();
        }

        private void btnQLSP_Click(object sender, EventArgs e)
        {
            FormQLSP c = new FormQLSP();
            c.ShowDialog();
        }

        private void btnTVDGV_Click(object sender, EventArgs e)
        {
            FormTVDGV d = new FormTVDGV();
            d.ShowDialog();
        }
    }
}
