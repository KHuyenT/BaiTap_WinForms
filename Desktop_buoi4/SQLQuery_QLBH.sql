
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 11/9/2023 1:40:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[MaHD] [VARCHAR](10) NOT NULL,
	[MaSP] [VARCHAR](10) NOT NULL,
	[SoLuong] [int] NULL,
	[GiaBan] [int] NULL,
 CONSTRAINT [PK_ChiTietHoaDon] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC,
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 11/9/2023 1:40:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHD] [VARCHAR](10) NOT NULL,
	[MaKH] [VARCHAR](10) NOT NULL,
	[MaNV] [VARCHAR](10) NOT NULL,
	[NgayHD] [datetime] NULL,
	[NgayNhan] [datetime] NULL,
	[ThanhTien] [int] NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 11/9/2023 1:40:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKH] [VARCHAR](10) NOT NULL,
	[TenKH] [nVARCHAR](50) NULL,
	[DiaChi] [nVARCHAR](50) NULL,
	[DienThoai] [VARCHAR](15) NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiSanPham]    Script Date: 11/9/2023 1:40:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiSanPham](
	[MaLoai] [VARCHAR](10) NOT NULL,
	[TenLoai] [nVARCHAR](50) NULL,
 CONSTRAINT [PK_LoaiSanPham] PRIMARY KEY CLUSTERED 
(
	[MaLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 11/9/2023 1:40:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [VARCHAR](10) NOT NULL,
	[TenNV] [nVARCHAR](50) NOT NULL,
	[GioiTinh] [bit] NULL,
	[DiaChi] [nVARCHAR](50) NULL,
	[DienThoai] [VARCHAR](15) NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 11/9/2023 1:40:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[MaSP] [VARCHAR](10) NOT NULL,
	[TenSP] [nVARCHAR](50) NOT NULL,
	[DVTinh] [nVARCHAR](50) NULL,
	[DonGia] [int] NULL,
	[MaLoai] [VARCHAR](10) NOT NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[LoaiSanPham] ([MaLoai], [TenLoai]) VALUES (N'L001', N'Thời trang')
INSERT [dbo].[LoaiSanPham] ([MaLoai], [TenLoai]) VALUES (N'L002', N'Báo')
INSERT [dbo].[LoaiSanPham] ([MaLoai], [TenLoai]) VALUES (N'L003', N'Sách')
INSERT [dbo].[LoaiSanPham] ([MaLoai], [TenLoai]) VALUES (N'L004', N'Đồ công nghệ')
GO
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DVTinh], [DonGia], [MaLoai]) VALUES (N'SP001', N'Giáo trình Tin học đại cương', N'quyển', 45000, N'L003')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DVTinh], [DonGia], [MaLoai]) VALUES (N'SP002', N'Giáo trình C# toàn tập', N'quyển', 70000, N'L003')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DVTinh], [DonGia], [MaLoai]) VALUES (N'SP003', N'Thiết kế Web chuyên nghiệp', N'quyển', 30000, N'L003')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DVTinh], [DonGia], [MaLoai]) VALUES (N'SP004', N'Áo thun 3 lỗ', N'cái', 50000, N'L001')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DVTinh], [DonGia], [MaLoai]) VALUES (N'SP005', N'Quần Jean', N'cái', 200000, N'L001')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DVTinh], [DonGia], [MaLoai]) VALUES (N'SP006', N'Giáo trình OOP1', N'quyển', 40000, N'L003')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DVTinh], [DonGia], [MaLoai]) VALUES (N'SP007', N'Giáo trình OOP2', N'quyển', 50000, N'L003')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DVTinh], [DonGia], [MaLoai]) VALUES (N'SP008', N'Giáo trình Kế toán', N'quyển', 45000, N'L003')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DVTinh], [DonGia], [MaLoai]) VALUES (N'SP009', N'Iphone 4s', N'cái', 4500000, N'L004')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DVTinh], [DonGia], [MaLoai]) VALUES (N'SP010', N'Iphone 5', N'cái', 8000000, N'L004')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DVTinh], [DonGia], [MaLoai]) VALUES (N'SP011', N'Iphone 5s', N'cái', 11000000, N'L004')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [DVTinh], [DonGia], [MaLoai]) VALUES (N'SP012', N'Máy tính bảng S', N'cái', 7000000, N'L004')
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_HoaDon] FOREIGN KEY([MaHD])
REFERENCES [dbo].[HoaDon] ([MaHD])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_HoaDon]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_SanPham] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SanPham] ([MaSP])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_SanPham]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_KhachHang] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_KhachHang]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_NhanVien] FOREIGN KEY([MaKH])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_NhanVien]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_LoaiSanPham] FOREIGN KEY([MaLoai])
REFERENCES [dbo].[LoaiSanPham] ([MaLoai])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_LoaiSanPham]
GO