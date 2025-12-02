namespace BT5
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
            this.txtA = new System.Windows.Forms.TextBox();
            this.lblA = new System.Windows.Forms.Label();
            this.lblB = new System.Windows.Forms.Label();
            this.txtB = new System.Windows.Forms.TextBox();
            this.txtKetQua = new System.Windows.Forms.TextBox();
            this.lblKetQua = new System.Windows.Forms.Label();
            this.btnTim = new System.Windows.Forms.Button();
            this.btnBoQua = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.rdoUSCLN = new System.Windows.Forms.RadioButton();
            this.rdoBSCNN = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // txtA
            // 
            this.txtA.Location = new System.Drawing.Point(87, 43);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(247, 22);
            this.txtA.TabIndex = 0;
            this.txtA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtA_KeyPress);
            // 
            // lblA
            // 
            this.lblA.AutoSize = true;
            this.lblA.Location = new System.Drawing.Point(26, 46);
            this.lblA.Name = "lblA";
            this.lblA.Size = new System.Drawing.Size(19, 16);
            this.lblA.TabIndex = 1;
            this.lblA.Text = "A:";
            // 
            // lblB
            // 
            this.lblB.AutoSize = true;
            this.lblB.Location = new System.Drawing.Point(26, 104);
            this.lblB.Name = "lblB";
            this.lblB.Size = new System.Drawing.Size(19, 16);
            this.lblB.TabIndex = 2;
            this.lblB.Text = "B:";
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(87, 104);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(247, 22);
            this.txtB.TabIndex = 3;
            this.txtB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtB_KeyPress);
            // 
            // txtKetQua
            // 
            this.txtKetQua.Location = new System.Drawing.Point(87, 181);
            this.txtKetQua.Name = "txtKetQua";
            this.txtKetQua.Size = new System.Drawing.Size(247, 22);
            this.txtKetQua.TabIndex = 4;
            // 
            // lblKetQua
            // 
            this.lblKetQua.AutoSize = true;
            this.lblKetQua.Location = new System.Drawing.Point(26, 187);
            this.lblKetQua.Name = "lblKetQua";
            this.lblKetQua.Size = new System.Drawing.Size(55, 16);
            this.lblKetQua.TabIndex = 5;
            this.lblKetQua.Text = "Kết quả:";
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(87, 262);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(75, 23);
            this.btnTim.TabIndex = 6;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // btnBoQua
            // 
            this.btnBoQua.Location = new System.Drawing.Point(240, 261);
            this.btnBoQua.Name = "btnBoQua";
            this.btnBoQua.Size = new System.Drawing.Size(75, 23);
            this.btnBoQua.TabIndex = 7;
            this.btnBoQua.Text = "Bỏ qua";
            this.btnBoQua.UseVisualStyleBackColor = true;
            this.btnBoQua.Click += new System.EventHandler(this.btnBoQua_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(386, 261);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 8;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // rdoUSCLN
            // 
            this.rdoUSCLN.AutoSize = true;
            this.rdoUSCLN.Location = new System.Drawing.Point(444, 76);
            this.rdoUSCLN.Name = "rdoUSCLN";
            this.rdoUSCLN.Size = new System.Drawing.Size(73, 20);
            this.rdoUSCLN.TabIndex = 9;
            this.rdoUSCLN.TabStop = true;
            this.rdoUSCLN.Text = "USCLN";
            this.rdoUSCLN.UseVisualStyleBackColor = true;
            // 
            // rdoBSCNN
            // 
            this.rdoBSCNN.AutoSize = true;
            this.rdoBSCNN.Location = new System.Drawing.Point(444, 127);
            this.rdoBSCNN.Name = "rdoBSCNN";
            this.rdoBSCNN.Size = new System.Drawing.Size(75, 20);
            this.rdoBSCNN.TabIndex = 10;
            this.rdoBSCNN.TabStop = true;
            this.rdoBSCNN.Text = "BSCNN";
            this.rdoBSCNN.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rdoBSCNN);
            this.Controls.Add(this.rdoUSCLN);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnBoQua);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.lblKetQua);
            this.Controls.Add(this.txtKetQua);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.lblB);
            this.Controls.Add(this.lblA);
            this.Controls.Add(this.txtA);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.Label lblA;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.TextBox txtKetQua;
        private System.Windows.Forms.Label lblKetQua;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Button btnBoQua;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.RadioButton rdoUSCLN;
        private System.Windows.Forms.RadioButton rdoBSCNN;
    }
}

