namespace Chuong_5
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnTaoCSDL = new Button();
            btnTaoDuLieu = new Button();
            btnTruyVanDuLieu = new Button();
            dgvData = new DataGridView();
            lblTrangThai = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            SuspendLayout();
            // 
            // btnTaoCSDL
            // 
            btnTaoCSDL.BackColor = Color.FromArgb(128, 255, 255);
            btnTaoCSDL.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnTaoCSDL.ForeColor = SystemColors.ControlText;
            btnTaoCSDL.Location = new Point(12, 26);
            btnTaoCSDL.Name = "btnTaoCSDL";
            btnTaoCSDL.Size = new Size(196, 67);
            btnTaoCSDL.TabIndex = 0;
            btnTaoCSDL.Text = "Tạo CSDL";
            btnTaoCSDL.UseVisualStyleBackColor = false;
            btnTaoCSDL.Click += button1_Click;
            // 
            // btnTaoDuLieu
            // 
            btnTaoDuLieu.BackColor = Color.FromArgb(128, 255, 255);
            btnTaoDuLieu.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnTaoDuLieu.ForeColor = SystemColors.ControlText;
            btnTaoDuLieu.Location = new Point(214, 26);
            btnTaoDuLieu.Name = "btnTaoDuLieu";
            btnTaoDuLieu.Size = new Size(209, 67);
            btnTaoDuLieu.TabIndex = 1;
            btnTaoDuLieu.Text = "Tạo dữ liệu";
            btnTaoDuLieu.UseVisualStyleBackColor = false;
            btnTaoDuLieu.Click += btnTaoDuLieu_Click;
            // 
            // btnTruyVanDuLieu
            // 
            btnTruyVanDuLieu.BackColor = Color.FromArgb(128, 255, 255);
            btnTruyVanDuLieu.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnTruyVanDuLieu.ForeColor = SystemColors.ControlText;
            btnTruyVanDuLieu.Location = new Point(429, 26);
            btnTruyVanDuLieu.Name = "btnTruyVanDuLieu";
            btnTruyVanDuLieu.Size = new Size(226, 67);
            btnTruyVanDuLieu.TabIndex = 2;
            btnTruyVanDuLieu.Text = "Truy vấn dữ liệu";
            btnTruyVanDuLieu.UseVisualStyleBackColor = false;
            btnTruyVanDuLieu.Click += btnTruyVanDuLieu_Click;
            // 
            // dgvData
            // 
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Dock = DockStyle.Bottom;
            dgvData.Location = new Point(0, 166);
            dgvData.Name = "dgvData";
            dgvData.RowHeadersWidth = 51;
            dgvData.Size = new Size(667, 321);
            dgvData.TabIndex = 3;
            // 
            // lblTrangThai
            // 
            lblTrangThai.AutoSize = true;
            lblTrangThai.Location = new Point(18, 111);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(75, 20);
            lblTrangThai.TabIndex = 4;
            lblTrangThai.Text = "Trạng thái";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(667, 487);
            Controls.Add(lblTrangThai);
            Controls.Add(dgvData);
            Controls.Add(btnTruyVanDuLieu);
            Controls.Add(btnTaoDuLieu);
            Controls.Add(btnTaoCSDL);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Demo kết nối SQLite trong C#";
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnTaoCSDL;
        private Button btnTaoDuLieu;
        private Button btnTruyVanDuLieu;
        private DataGridView dgvData;
        private Label lblTrangThai;
    }
}
