using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace Desktop_buoi3
{
    public partial class FormHoaDon : Form
    {
        // Danh sách sản phẩm (giả lập CSDL)
        private List<SanPham> dsSanPham = new List<SanPham>();
        public FormHoaDon()
        {
            InitializeComponent();
            // Gọi hàm thiết lập cột cho DataGridView
            ThietLapCotDataGridView();
        }
        // Hàm này rất quan trọng để DataGridView có cột
        private void ThietLapCotDataGridView()
        {
            // Xóa các cột tự động (nếu có)
            dgvChiTietHoaDon.Columns.Clear();

            // Thiết lập không cho phép tự động tạo cột
            dgvChiTietHoaDon.AutoGenerateColumns = false;

            // Thêm các cột thủ công
            dgvChiTietHoaDon.Columns.Add("MaSP", "Mã SP");
            dgvChiTietHoaDon.Columns.Add("TenSP", "Tên Sản Phẩm");
            dgvChiTietHoaDon.Columns.Add("SoLuong", "Số Lượng");
            dgvChiTietHoaDon.Columns.Add("DonGia", "Đơn Giá");
            dgvChiTietHoaDon.Columns.Add("ThanhTien", "Thành Tiền");

            // Tùy chỉnh độ rộng cột
            dgvChiTietHoaDon.Columns["TenSP"].Width = 200;

            // Định dạng cột số (cho đẹp)
            dgvChiTietHoaDon.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            dgvChiTietHoaDon.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
        }

        private void FormHoaDon_Load(object sender, EventArgs e)
        {
            // --- 1. Tạo dữ liệu sản phẩm mẫu ---
            dsSanPham.Add(new SanPham { MaSP = "SP001", TenSP = "Bánh mì ngọt", DonGia = 15000 });
            dsSanPham.Add(new SanPham { MaSP = "SP002", TenSP = "Sữa tươi Vinamilk", DonGia = 7000 });
            dsSanPham.Add(new SanPham { MaSP = "SP003", TenSP = "Nước suối Aquafina", DonGia = 5000 });
            dsSanPham.Add(new SanPham { MaSP = "SP004", TenSP = "Xúc xích CP", DonGia = 10000 });

            // --- 2. Tải dữ liệu vào ComboBox (cboSanPham) ---
            cboSanPham.DataSource = dsSanPham;
            cboSanPham.DisplayMember = "TenSP"; // Hiển thị tên
            cboSanPham.ValueMember = "MaSP";   // Lấy giá trị là Mã

            // --- 3. Cài đặt ban đầu ---
            txtTongTien.Text = "0 VNĐ";
            txtTongTien.ReadOnly = true;

            printPreview.Document = printDoc;
            printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);
        }

        private void CapNhatTongTien()
        {
            decimal tongTien = 0;

            // Lặp qua tất cả các dòng trong lưới
            foreach (DataGridViewRow row in dgvChiTietHoaDon.Rows)
            {
                // Bỏ qua dòng mới (dòng trống ở cuối) để tránh lỗi
                if (row.IsNewRow) continue;

                // Kiểm tra cell value không bị null
                if (row.Cells["ThanhTien"].Value != null)
                {
                    tongTien += Convert.ToDecimal(row.Cells["ThanhTien"].Value);
                }
            }

            // Giả sử TextBox tổng tiền tên là 'txtTongTien'
            txtTongTien.Text = tongTien.ToString("N0") + " VNĐ";
        }
        private void btnThemVaoHD_Click(object sender, EventArgs e)
        {
            // --- 1. Lấy thông tin ---
            SanPham spChon = cboSanPham.SelectedItem as SanPham;
            if (spChon == null)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm!");
                return;
            }

            int soLuong = Convert.ToInt32(nudSoLuong.Value);

            // Kiểm tra logic
            if (soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên lớn hơn 0!");
                return;
            }

            // --- 2. Tính thành tiền ---
            decimal thanhTien = soLuong * spChon.DonGia;

            // --- 3. Kiểm tra xem sản phẩm đã có trong lưới chưa ---
            foreach (DataGridViewRow row in dgvChiTietHoaDon.Rows)
            {
                if (row.IsNewRow) continue;
                // Nếu đã có, thì cập nhật lại số lượng và thành tiền
                if (row.Cells["MaSP"].Value.ToString() == spChon.MaSP)
                {
                    int slMoi = Convert.ToInt32(row.Cells["SoLuong"].Value) + soLuong;
                    decimal ttMoi = slMoi * spChon.DonGia;

                    row.Cells["SoLuong"].Value = slMoi;
                    row.Cells["ThanhTien"].Value = ttMoi;

                    // Cập nhật tổng tiền và thoát
                    CapNhatTongTien();
                    return;
                }
            }

            // --- 4. Nếu chưa có, thêm dòng mới vào DataGridView ---
            dgvChiTietHoaDon.Rows.Add(
                spChon.MaSP,
                spChon.TenSP,
                soLuong,
                spChon.DonGia,
                thanhTien
            );

            // --- 5. Cập nhật lại tổng tiền ---
            CapNhatTongTien();
        }

        private void btnXoaKhoiHD_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có chọn dòng nào không
            if (dgvChiTietHoaDon.SelectedRows.Count > 0)
            {
                // Lấy dòng đang chọn
                DataGridViewRow selectedRow = dgvChiTietHoaDon.SelectedRows[0];

                // Hỏi xác nhận
                DialogResult dr = MessageBox.Show($"Bạn có chắc muốn xóa sản phẩm {selectedRow.Cells["TenSP"].Value}?",
                                                    "Xác nhận",
                                                    MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    // Xóa dòng đó khỏi lưới
                    dgvChiTietHoaDon.Rows.Remove(selectedRow);

                    // Cập nhật lại tổng tiền
                    CapNhatTongTien();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm trong lưới để xóa!");
            }
        }

        private void btnLuuHoaDon_Click(object sender, EventArgs e)
        {
            // --- Giả lập lưu ---
            string khachHang = txtTenKhach.Text;
            int soLuongMatHang = dgvChiTietHoaDon.Rows.Count;
            string tongTien = txtTongTien.Text;

            if (soLuongMatHang == 0)
            {
                MessageBox.Show("Hóa đơn chưa có sản phẩm nào!");
                return;
            }

            // Thông báo lưu thành công
            MessageBox.Show(
                $"Đã lưu hóa đơn cho khách: {khachHang}\n" +
                $"Tổng số mặt hàng: {soLuongMatHang}\n" +
                $"Tổng tiền: {tongTien}",
                "Lưu Thành Công (Giả lập)",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            // Xóa trắng Form để chuẩn bị cho hóa đơn tiếp theo
            txtTenKhach.Text = "";
            nudSoLuong.Value = 0;
            dgvChiTietHoaDon.Rows.Clear();
            CapNhatTongTien();
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            // Hiển thị cửa sổ xem trước
            // (Giả sử printPreview.Document đã được gán = printDoc)
            printPreview.ShowDialog();
        }

        // Sự kiện này sẽ "vẽ" nội dung lên trang in
        private void printDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // --- Định nghĩa Font ---
            Font fontTieuDe = new Font("Arial", 16, FontStyle.Bold);
            Font fontTieuDeNho = new Font("Arial", 12, FontStyle.Bold);
            Font fontNoiDung = new Font("Arial", 10, FontStyle.Regular);
            Brush brushDen = Brushes.Black;

            // --- Vị trí bắt đầu (X, Y) ---
            float leTrai = 10;
            float Y = 10;

            // --- 1. Tên cửa hàng (Logo) ---
            e.Graphics.DrawString("CỬA HÀNG MINI ABC", fontTieuDe, brushDen, new PointF(leTrai, Y));
            Y += 40;

            // --- 2. Tiêu đề Hóa đơn ---
            e.Graphics.DrawString("BIÊN LAI BÁN HÀNG", fontTieuDeNho, brushDen, new PointF(leTrai, Y));
            Y += 25;

            // --- 3. Ngày giờ in ---
            e.Graphics.DrawString("Ngày: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), fontNoiDung, brushDen, new PointF(leTrai, Y));
            Y += 25;

            // --- 4. Tên khách hàng (Đọc từ TextBox) ---
            string khachHang = "Khách hàng: " + txtTenKhach.Text;
            e.Graphics.DrawString(khachHang, fontNoiDung, brushDen, new PointF(leTrai, Y));
            Y += 40;

            // --- 5. Tiêu đề cột (Danh sách sản phẩm) ---
            e.Graphics.DrawString("Tên SP", fontTieuDeNho, brushDen, new PointF(leTrai, Y));
            e.Graphics.DrawString("SL", fontTieuDeNho, brushDen, new PointF(leTrai + 200, Y));
            e.Graphics.DrawString("Đơn Giá", fontTieuDeNho, brushDen, new PointF(leTrai + 250, Y));
            e.Graphics.DrawString("Thành Tiền", fontTieuDeNho, brushDen, new PointF(leTrai + 320, Y));
            Y += 25;

            // --- 6. Lặp qua DataGridView để in chi tiết (Đọc từ DataGridView) ---
            foreach (DataGridViewRow row in dgvChiTietHoaDon.Rows)
            {
                string tenSP = row.Cells["TenSP"].Value.ToString();
                string soLuong = row.Cells["SoLuong"].Value.ToString();
                decimal donGia = Convert.ToDecimal(row.Cells["DonGia"].Value);
                decimal thanhTien = Convert.ToDecimal(row.Cells["ThanhTien"].Value);

                // Vẽ 1 dòng sản phẩm
                e.Graphics.DrawString(tenSP, fontNoiDung, brushDen, new PointF(leTrai, Y));
                e.Graphics.DrawString(soLuong, fontNoiDung, brushDen, new PointF(leTrai + 200, Y));
                e.Graphics.DrawString(donGia.ToString("N0"), fontNoiDung, brushDen, new PointF(leTrai + 250, Y));
                e.Graphics.DrawString(thanhTien.ToString("N0"), fontNoiDung, brushDen, new PointF(leTrai + 320, Y));
                Y += 20;
            }

            Y += 40;

            // --- 7. Tổng tiền (Đọc từ TextBox) ---
            string chuoiTongTien = "Tổng tiền: " + txtTongTien.Text;
            e.Graphics.DrawString(chuoiTongTien, fontTieuDeNho, brushDen, new PointF(leTrai, Y));
            Y += 25;

            // --- 8. Lời cảm ơn ---
            e.Graphics.DrawString("Cảm ơn quý khách!", fontNoiDung, brushDen, new PointF(leTrai, Y));
        }
    }
    public class SanPham
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public decimal DonGia { get; set; }

        // Ghi đè ToString để ComboBox hiển thị đẹp
        public override string ToString()
        {
            return this.TenSP;
        }
    }
}
