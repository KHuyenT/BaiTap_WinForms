namespace LMS_tuan4
{
    partial class Form1
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
            this.btnTaoCSDL = new System.Windows.Forms.Button();
            this.btnTaoDuLieu = new System.Windows.Forms.Button();
            this.btnTruyVanDuLieu = new System.Windows.Forms.Button();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTaoCSDL
            // 
            this.btnTaoCSDL.Location = new System.Drawing.Point(31, 21);
            this.btnTaoCSDL.Name = "btnTaoCSDL";
            this.btnTaoCSDL.Size = new System.Drawing.Size(209, 63);
            this.btnTaoCSDL.TabIndex = 0;
            this.btnTaoCSDL.Text = "Tạo CSDL";
            this.btnTaoCSDL.UseVisualStyleBackColor = true;
            this.btnTaoCSDL.Click += new System.EventHandler(this.btnTaoCSDL_Click);
            // 
            // btnTaoDuLieu
            // 
            this.btnTaoDuLieu.Location = new System.Drawing.Point(287, 21);
            this.btnTaoDuLieu.Name = "btnTaoDuLieu";
            this.btnTaoDuLieu.Size = new System.Drawing.Size(211, 63);
            this.btnTaoDuLieu.TabIndex = 1;
            this.btnTaoDuLieu.Text = "Tạo dữ liệu";
            this.btnTaoDuLieu.UseVisualStyleBackColor = true;
            this.btnTaoDuLieu.Click += new System.EventHandler(this.btnTaoDuLieu_Click);
            // 
            // btnTruyVanDuLieu
            // 
            this.btnTruyVanDuLieu.Location = new System.Drawing.Point(547, 21);
            this.btnTruyVanDuLieu.Name = "btnTruyVanDuLieu";
            this.btnTruyVanDuLieu.Size = new System.Drawing.Size(214, 63);
            this.btnTruyVanDuLieu.TabIndex = 2;
            this.btnTruyVanDuLieu.Text = "Truy vấn dữ liệu";
            this.btnTruyVanDuLieu.UseVisualStyleBackColor = true;
            this.btnTruyVanDuLieu.Click += new System.EventHandler(this.btnTruyVanDuLieu_Click);
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new System.Drawing.Point(28, 110);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(0, 16);
            this.lblTrangThai.TabIndex = 3;
            // 
            // dgvData
            // 
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(31, 148);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersWidth = 51;
            this.dgvData.RowTemplate.Height = 24;
            this.dgvData.Size = new System.Drawing.Size(730, 280);
            this.dgvData.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.btnTruyVanDuLieu);
            this.Controls.Add(this.btnTaoDuLieu);
            this.Controls.Add(this.btnTaoCSDL);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTaoCSDL;
        private System.Windows.Forms.Button btnTaoDuLieu;
        private System.Windows.Forms.Button btnTruyVanDuLieu;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.DataGridView dgvData;
    }
}

