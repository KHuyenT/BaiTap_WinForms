namespace BT5
{
    partial class QuanLySanPhamForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.cboLoaiSP = new System.Windows.Forms.ComboBox();
            this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
            this.grpTinhTrang = new System.Windows.Forms.GroupBox();
            this.rdoConHang = new System.Windows.Forms.RadioButton();
            this.rdoHetHang = new System.Windows.Forms.RadioButton();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblTongSanPham = new System.Windows.Forms.StatusStrip();
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.ColSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColLoaiSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTinhTrangSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlLeft.SuspendLayout();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
            this.grpTinhTrang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BT5.Properties.Resources.Logo_UEH_xanh;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(83, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lblTongSanPham);
            this.pnlLeft.Controls.Add(this.pictureBox1);
            this.pnlLeft.Controls.Add(this.btnXoa);
            this.pnlLeft.Controls.Add(this.btnSua);
            this.pnlLeft.Controls.Add(this.btnThem);
            this.pnlLeft.Controls.Add(this.grpTinhTrang);
            this.pnlLeft.Controls.Add(this.nudSoLuong);
            this.pnlLeft.Controls.Add(this.cboLoaiSP);
            this.pnlLeft.Controls.Add(this.txtTenSP);
            this.pnlLeft.Controls.Add(this.label3);
            this.pnlLeft.Controls.Add(this.label2);
            this.pnlLeft.Controls.Add(this.label1);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(300, 468);
            this.pnlLeft.TabIndex = 1;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.dgvSanPham);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(0, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(884, 468);
            this.pnlRight.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên sản phẩm:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Loại sản phẩm:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Số lượng:";
            // 
            // txtTenSP
            // 
            this.txtTenSP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenSP.Location = new System.Drawing.Point(117, 63);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(164, 22);
            this.txtTenSP.TabIndex = 3;
            this.toolTip1.SetToolTip(this.txtTenSP, "Nhập tên sản phẩm");
            // 
            // cboLoaiSP
            // 
            this.cboLoaiSP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboLoaiSP.FormattingEnabled = true;
            this.cboLoaiSP.Items.AddRange(new object[] {
            "Cà phê",
            "Trà",
            "Nước ngọt"});
            this.cboLoaiSP.Location = new System.Drawing.Point(117, 124);
            this.cboLoaiSP.Name = "cboLoaiSP";
            this.cboLoaiSP.Size = new System.Drawing.Size(164, 24);
            this.cboLoaiSP.TabIndex = 4;
            this.toolTip1.SetToolTip(this.cboLoaiSP, "Chọn loại sản phẩm từ danh sách có sẵn.");
            // 
            // nudSoLuong
            // 
            this.nudSoLuong.Location = new System.Drawing.Point(117, 186);
            this.nudSoLuong.Name = "nudSoLuong";
            this.nudSoLuong.Size = new System.Drawing.Size(164, 22);
            this.nudSoLuong.TabIndex = 5;
            this.toolTip1.SetToolTip(this.nudSoLuong, "Nhập số lượng tồn kho hiện tại.");
            // 
            // grpTinhTrang
            // 
            this.grpTinhTrang.Controls.Add(this.rdoHetHang);
            this.grpTinhTrang.Controls.Add(this.rdoConHang);
            this.grpTinhTrang.Location = new System.Drawing.Point(15, 244);
            this.grpTinhTrang.Name = "grpTinhTrang";
            this.grpTinhTrang.Size = new System.Drawing.Size(266, 113);
            this.grpTinhTrang.TabIndex = 6;
            this.grpTinhTrang.TabStop = false;
            this.grpTinhTrang.Text = "Tình trạng sản phẩm";
            // 
            // rdoConHang
            // 
            this.rdoConHang.AutoSize = true;
            this.rdoConHang.Location = new System.Drawing.Point(16, 33);
            this.rdoConHang.Name = "rdoConHang";
            this.rdoConHang.Size = new System.Drawing.Size(85, 20);
            this.rdoConHang.TabIndex = 0;
            this.rdoConHang.TabStop = true;
            this.rdoConHang.Text = "Còn hàng";
            this.rdoConHang.UseVisualStyleBackColor = true;
            // 
            // rdoHetHang
            // 
            this.rdoHetHang.AutoSize = true;
            this.rdoHetHang.Location = new System.Drawing.Point(16, 71);
            this.rdoHetHang.Name = "rdoHetHang";
            this.rdoHetHang.Size = new System.Drawing.Size(82, 20);
            this.rdoHetHang.TabIndex = 1;
            this.rdoHetHang.TabStop = true;
            this.rdoHetHang.Text = "Hết hàng";
            this.rdoHetHang.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            this.btnThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnThem.Location = new System.Drawing.Point(15, 396);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 7;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSua.Location = new System.Drawing.Point(110, 396);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 8;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnXoa.Location = new System.Drawing.Point(209, 396);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 9;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblTongSanPham
            // 
            this.lblTongSanPham.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.lblTongSanPham.Location = new System.Drawing.Point(0, 446);
            this.lblTongSanPham.Name = "lblTongSanPham";
            this.lblTongSanPham.Size = new System.Drawing.Size(300, 22);
            this.lblTongSanPham.TabIndex = 10;
            this.lblTongSanPham.Text = "Tổng số sản phẩm: 0";
            // 
            // dgvSanPham
            // 
            this.dgvSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSanPham.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColTenSP,
            this.ColTinhTrangSP,
            this.ColLoaiSP,
            this.ColSoLuong});
            this.dgvSanPham.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgvSanPham.Location = new System.Drawing.Point(308, 0);
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.RowHeadersWidth = 51;
            this.dgvSanPham.RowTemplate.Height = 24;
            this.dgvSanPham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSanPham.Size = new System.Drawing.Size(576, 468);
            this.dgvSanPham.TabIndex = 0;
            this.dgvSanPham.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSanPham_CellClick);
            // 
            // ColSoLuong
            // 
            this.ColSoLuong.DataPropertyName = "SoLuong";
            this.ColSoLuong.FillWeight = 32.5092F;
            this.ColSoLuong.HeaderText = "Số Lượng";
            this.ColSoLuong.MinimumWidth = 6;
            this.ColSoLuong.Name = "ColSoLuong";
            // 
            // ColLoaiSP
            // 
            this.ColLoaiSP.DataPropertyName = "Loai";
            this.ColLoaiSP.FillWeight = 51.70206F;
            this.ColLoaiSP.HeaderText = "Loại Sản Phẩm";
            this.ColLoaiSP.MinimumWidth = 6;
            this.ColLoaiSP.Name = "ColLoaiSP";
            // 
            // ColTinhTrangSP
            // 
            this.ColTinhTrangSP.DataPropertyName = "TinhTrang";
            this.ColTinhTrangSP.FillWeight = 101.885F;
            this.ColTinhTrangSP.HeaderText = "Tình Trạng Sản Phẩm";
            this.ColTinhTrangSP.MinimumWidth = 6;
            this.ColTinhTrangSP.Name = "ColTinhTrangSP";
            // 
            // ColTenSP
            // 
            this.ColTenSP.DataPropertyName = "Ten";
            this.ColTenSP.FillWeight = 213.9037F;
            this.ColTenSP.HeaderText = "Tên Sản Phẩm";
            this.ColTenSP.MinimumWidth = 6;
            this.ColTenSP.Name = "ColTenSP";
            this.ColTenSP.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // QuanLySanPhamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(884, 468);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlRight);
            this.Name = "QuanLySanPhamForm";
            this.Text = "Quản lý sản phẩm cửa hàng";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).EndInit();
            this.grpTinhTrang.ResumeLayout(false);
            this.grpTinhTrang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.GroupBox grpTinhTrang;
        private System.Windows.Forms.RadioButton rdoHetHang;
        private System.Windows.Forms.RadioButton rdoConHang;
        private System.Windows.Forms.NumericUpDown nudSoLuong;
        private System.Windows.Forms.ComboBox cboLoaiSP;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.StatusStrip lblTongSanPham;
        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTinhTrangSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColLoaiSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSoLuong;
    }
}

