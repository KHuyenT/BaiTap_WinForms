using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Desktop_buoi3
{
    public partial class FormSanPham : Form
    {
        public FormSanPham()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // 1. Xóa danh sách sản phẩm cũ
            listView1.Items.Clear();

            // 2. Lấy tên danh mục đang được chọn
            string danhMuc = e.Node.Text;

            // 3. Giả lập dữ liệu sản phẩm (Trong thực tế, bạn sẽ gọi hàm truy vấn CSDL tại đây)
            List<SanPham> sanPhams = LayDuLieuSanPhamTheoDanhMuc(danhMuc);

            // 4. Hiển thị dữ liệu lên ListView
            foreach (var sp in sanPhams)
            {
                ListViewItem item = new ListViewItem(sp.Ma);
                item.SubItems.Add(sp.Ten);
                item.SubItems.Add(sp.Gia.ToString("N0")); // Định dạng giá có dấu phẩy
                item.SubItems.Add(sp.TonKho.ToString());
                listView1.Items.Add(item);
            }

            // Tùy chọn: Tự động điều chỉnh độ rộng cột (AutoResizeColumns)
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        // Hàm giả lập dữ liệu (Cần định nghĩa Class SanPham)
        private List<SanPham> LayDuLieuSanPhamTheoDanhMuc(string danhMuc)
        {
            // Bạn có thể định nghĩa lớp SanPham và trả về dữ liệu mẫu
            // Ví dụ:
            if (danhMuc == "Thực phẩm")
            {
                return new List<SanPham>
        {
            new SanPham { Ma = "TP001", Ten = "Gạo Tẻ", Gia = 15000, TonKho = 500 },
            new SanPham { Ma = "TP002", Ten = "Thịt Bò", Gia = 250000, TonKho = 50 }
        };
            }
            // ... code cho các danh mục khác
            return new List<SanPham>();
        }

        // Khai báo lớp mẫu cho dễ quản lý dữ liệu
        public class SanPham
        {
            public string Ma { get; set; }
            public string Ten { get; set; }
            public decimal Gia { get; set; }
            public int TonKho { get; set; }
        }

        private void xemChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                // Lấy Mã sản phẩm (là cột đầu tiên)
                string maSP = listView1.SelectedItems[0].Text;
                MessageBox.Show($"Xem chi tiết sản phẩm có Mã: {maSP}", "Thông báo");
            }
        }

        private void xóaSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string maSP = listView1.SelectedItems[0].Text;
                if (MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm Mã: {maSP}?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // Thực hiện lệnh xóa trong CSDL
                    // Sau khi xóa thành công:
                    listView1.SelectedItems[0].Remove(); // Xóa khỏi ListView
                    MessageBox.Show("Xóa sản phẩm thành công!");
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            // 1. Thiết lập cho OpenFileDialog
            openFileDialog1.Title = "Chọn file CSV để import";
            openFileDialog1.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";

            // 2. Hiển thị Dialog và kiểm tra xem người dùng có chọn "OK" không
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 3. Lấy đường dẫn file
                    string filePath = openFileDialog1.FileName;

                    // 4. Xóa dữ liệu cũ trên ListView
                    listView1.Items.Clear();

                    // 5. Đọc file
                    string[] lines = File.ReadAllLines(filePath);

                    // 6. Bỏ qua dòng tiêu đề (giả sử dòng đầu tiên là header)
                    // và lặp qua các dòng dữ liệu
                    for (int i = 1; i < lines.Length; i++)
                    {
                        string line = lines[i];
                        if (string.IsNullOrWhiteSpace(line)) continue;

                        // 7. Tách dữ liệu bằng dấu phẩy
                        string[] parts = line.Split(',');

                        // 8. Tạo ListViewItem (cột đầu tiên)
                        ListViewItem item = new ListViewItem(parts[0]); // Mã

                        // 9. Thêm các SubItems (các cột tiếp theo)
                        item.SubItems.Add(parts[1]); // Tên
                        item.SubItems.Add(parts[2]); // Giá
                        item.SubItems.Add(parts[3]); // Tồn kho

                        // 10. Thêm item vào ListView
                        listView1.Items.Add(item);
                    }

                    MessageBox.Show("Import dữ liệu thành công!", "Thông báo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Import thất bại. Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // 1. Thiết lập cho SaveFileDialog
            saveFileDialog1.Title = "Lưu file báo cáo";
            saveFileDialog1.Filter = "CSV Files (*.csv)|*.csv";
            saveFileDialog1.FileName = "BaoCaoSanPham.csv"; // Tên file mặc định

            // 2. Hiển thị Dialog và kiểm tra
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 3. Lấy đường dẫn file
                    string filePath = saveFileDialog1.FileName;

                    // 4. Dùng StringBuilder để xây dựng nội dung file CSV
                    StringBuilder sb = new StringBuilder();

                    // 5. Thêm dòng tiêu đề (header)
                    sb.AppendLine("Mã,Tên,Giá,Tồn kho");

                    // 6. Lặp qua tất cả các dòng (Items) trong ListView
                    foreach (ListViewItem item in listView1.Items)
                    {
                        // 7. Lấy dữ liệu từ các cột
                        string ma = item.SubItems[0].Text;
                        string ten = item.SubItems[1].Text;
                        string gia = item.SubItems[2].Text;
                        string tonkho = item.SubItems[3].Text;

                        // 8. Ghép thành 1 dòng CSV
                        string line = $"{ma},{ten},{gia},{tonkho}";
                        sb.AppendLine(line);
                    }

                    // 9. Ghi tất cả nội dung vào file
                    File.WriteAllText(filePath, sb.ToString());

                    MessageBox.Show("Export dữ liệu thành công!", "Thông báo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Export thất bại. Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnSimulateExport_Click(object sender, EventArgs e)
        {
            int totalItems = listView1.Items.Count;

            if (totalItems == 0)
            {
                MessageBox.Show("Không có sản phẩm nào để mô phỏng export.", "Thông báo");
                return;
            }

            // 1. Hiển thị và thiết lập ProgressBar
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Maximum = totalItems;

            // 2. Vô hiệu hóa các nút để tránh người dùng nhấn
            btnImport.Enabled = false;
            btnExport.Enabled = false;
            btnSimulateExport.Enabled = false;

            // 3. Lặp qua từng sản phẩm (giả lập)
            for (int i = 0; i < totalItems; i++)
            {
                // Lấy tên sản phẩm để hiển thị (tùy chọn)
                string tenSP = listView1.Items[i].SubItems[1].Text;

                // Cập nhật StatusStrip trên FormMain (nếu bạn muốn)
                // (Giả sử bạn có cách truy cập StatusStrip từ FormMain)
                // (FormMain.Instance.toolStripStatusLabelForm.Text = $"Đang export: {tenSP}...";)

                // 4. DỪNG 1 GIÂY (1000ms) mà không làm treo UI
                // Dùng await Task.Delay thay vì Thread.Sleep
                await Task.Delay(1000);

                // 5. Cập nhật ProgressBar (tăng giá trị lên 1)
                progressBar1.Value = i + 1;
            }

            // 6. Hoàn tất
            progressBar1.Visible = false;
            MessageBox.Show("Mô phỏng export hoàn tất!", "Thông báo");

            // 7. Kích hoạt lại các nút
            btnImport.Enabled = true;
            btnExport.Enabled = true;
            btnSimulateExport.Enabled = true;
        }
    }
}
