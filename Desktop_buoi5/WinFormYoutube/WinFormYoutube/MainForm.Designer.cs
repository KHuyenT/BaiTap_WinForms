using Microsoft.Web.WebView2.WinForms;

namespace WinFormsApp2
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Controls (Designer)
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnTrending;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Label lblStatus;

        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.DataGridView dgvVideos;

        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.PictureBox picThumbnail;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                httpClient?.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelTop = new Panel();
            btnTrending = new Button();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnPlay = new Button();
            lblStatus = new Label();
            splitContainerMain = new SplitContainer();
            txtDescription = new TextBox();
            dgvVideos = new DataGridView();
            panelRight = new Panel();
            webView = new WebView2();
            picThumbnail = new PictureBox();
            panel1 = new Panel();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVideos).BeginInit();
            panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picThumbnail).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = SystemColors.ControlLight;
            panelTop.Controls.Add(btnTrending);
            panelTop.Controls.Add(txtSearch);
            panelTop.Controls.Add(btnSearch);
            panelTop.Controls.Add(btnPlay);
            panelTop.Controls.Add(lblStatus);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Padding = new Padding(6);
            panelTop.Size = new Size(1100, 50);
            panelTop.TabIndex = 1;
            // 
            // btnTrending
            // 
            btnTrending.Location = new Point(8, 10);
            btnTrending.Name = "btnTrending";
            btnTrending.Size = new Size(140, 23);
            btnTrending.TabIndex = 0;
            btnTrending.Text = "Load Trending (VN)";
            btnTrending.Click += BtnTrending_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(160, 12);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(420, 27);
            txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(590, 10);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(90, 23);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.Click += BtnSearch_Click;
            // 
            // btnPlay
            // 
            btnPlay.Location = new Point(690, 10);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(110, 23);
            btnPlay.TabIndex = 3;
            btnPlay.Text = "Play Selected";
            btnPlay.Click += BtnPlay_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(810, 15);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(50, 20);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "Ready";
            // 
            // splitContainerMain
            // 
            splitContainerMain.Dock = DockStyle.Fill;
            splitContainerMain.Location = new Point(0, 50);
            splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            splitContainerMain.Panel1.Controls.Add(dgvVideos);
            splitContainerMain.Panel1.Controls.Add(panel1);
            // 
            // splitContainerMain.Panel2
            // 
            splitContainerMain.Panel2.Controls.Add(panelRight);
            splitContainerMain.Size = new Size(1100, 670);
            splitContainerMain.SplitterDistance = 887;
            splitContainerMain.TabIndex = 0;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(0, 0);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ReadOnly = true;
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(887, 77);
            txtDescription.TabIndex = 2;
            // 
            // dgvVideos
            // 
            dgvVideos.AllowUserToAddRows = false;
            dgvVideos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVideos.ColumnHeadersHeight = 29;
            dgvVideos.Dock = DockStyle.Fill;
            dgvVideos.Location = new Point(0, 0);
            dgvVideos.MultiSelect = false;
            dgvVideos.Name = "dgvVideos";
            dgvVideos.ReadOnly = true;
            dgvVideos.RowHeadersWidth = 51;
            dgvVideos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVideos.Size = new Size(887, 593);
            dgvVideos.TabIndex = 0;
            dgvVideos.CellDoubleClick += DgvVideos_CellDoubleClick;
            dgvVideos.SelectionChanged += DgvVideos_SelectionChanged;
            // 
            // panelRight
            // 
            panelRight.Controls.Add(webView);
            panelRight.Controls.Add(picThumbnail);
            panelRight.Dock = DockStyle.Fill;
            panelRight.Location = new Point(0, 0);
            panelRight.Name = "panelRight";
            panelRight.Padding = new Padding(8);
            panelRight.Size = new Size(209, 670);
            panelRight.TabIndex = 0;
            // 
            // webView
            // 
            webView.AllowExternalDrop = true;
            webView.CreationProperties = null;
            webView.DefaultBackgroundColor = Color.White;
            webView.Dock = DockStyle.Fill;
            webView.Location = new Point(8, 238);
            webView.Name = "webView";
            webView.Size = new Size(193, 424);
            webView.TabIndex = 0;
            webView.ZoomFactor = 1D;
            // 
            // picThumbnail
            // 
            picThumbnail.BorderStyle = BorderStyle.FixedSingle;
            picThumbnail.Dock = DockStyle.Top;
            picThumbnail.Location = new Point(8, 8);
            picThumbnail.Margin = new Padding(0, 0, 0, 8);
            picThumbnail.Name = "picThumbnail";
            picThumbnail.Size = new Size(193, 230);
            picThumbnail.SizeMode = PictureBoxSizeMode.Zoom;
            picThumbnail.TabIndex = 1;
            picThumbnail.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(txtDescription);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 593);
            panel1.Name = "panel1";
            panel1.Size = new Size(887, 77);
            panel1.TabIndex = 5;
            // 
            // MainForm
            // 
            ClientSize = new Size(1100, 720);
            Controls.Add(splitContainerMain);
            Controls.Add(panelTop);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "YouTube Trending (VN) - Designer Layout";
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            splitContainerMain.Panel1.ResumeLayout(false);
            splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvVideos).EndInit();
            panelRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)webView).EndInit();
            ((System.ComponentModel.ISupportInitialize)picThumbnail).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtDescription;
        private Panel panel1;
    }
}
