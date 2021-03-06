USE [master]
GO
/****** Object:  Database [GalaxyMobile]    Script Date: 9/23/2018 3:24:42 PM ******/
CREATE DATABASE [GalaxyMobile]

GO
ALTER DATABASE [GalaxyMobile] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GalaxyMobile] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GalaxyMobile] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GalaxyMobile] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GalaxyMobile] SET ARITHABORT OFF 
GO
ALTER DATABASE [GalaxyMobile] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GalaxyMobile] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [GalaxyMobile] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GalaxyMobile] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GalaxyMobile] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GalaxyMobile] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GalaxyMobile] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GalaxyMobile] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GalaxyMobile] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GalaxyMobile] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GalaxyMobile] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GalaxyMobile] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GalaxyMobile] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GalaxyMobile] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GalaxyMobile] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GalaxyMobile] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GalaxyMobile] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GalaxyMobile] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GalaxyMobile] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GalaxyMobile] SET  MULTI_USER 
GO
ALTER DATABASE [GalaxyMobile] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GalaxyMobile] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GalaxyMobile] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GalaxyMobile] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [GalaxyMobile]
GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 9/23/2018 3:24:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[MaHoaDon] [varchar](15) NOT NULL,
	[MaKieu] [varchar](50) NOT NULL,
	[MaCuaHang] [varchar](10) NOT NULL,
	[SoluongSP] [int] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ChiTietSP]    Script Date: 9/23/2018 3:24:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ChiTietSP](
	[MaSP] [varchar](30) NOT NULL,
	[MaKieu] [varchar](50) NOT NULL,
	[MaMau] [varchar](20) NOT NULL,
	[Giá] [decimal](18, 2) NOT NULL,
	[SoluongSP] [int] NOT NULL,
	[Anh] [image] NULL,
 CONSTRAINT [PK_ChiTietSP] PRIMARY KEY CLUSTERED 
(
	[MaKieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CuaHang]    Script Date: 9/23/2018 3:24:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CuaHang](
	[MaCuaHang] [varchar](10) NOT NULL,
	[TenCuaHang] [nvarchar](50) NOT NULL,
	[DiaChi] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_CuaHang] PRIMARY KEY CLUSTERED 
(
	[MaCuaHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DongSanPham]    Script Date: 9/23/2018 3:24:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DongSanPham](
	[MaDSP] [nvarchar](50) NOT NULL,
	[TenDong] [nvarchar](100) NOT NULL,
	[MaHSX] [varchar](15) NOT NULL,
	[MaLSP] [varchar](10) NOT NULL,
 CONSTRAINT [PK_DongSanPham] PRIMARY KEY CLUSTERED 
(
	[MaDSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 9/23/2018 3:24:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHoaDon] [varchar](15) NOT NULL,
	[MaKH] [varchar](10) NOT NULL,
	[MaNV] [varchar](10) NOT NULL,
	[MaCuaHang] [varchar](10) NOT NULL,
	[TinhTrang] [int] NOT NULL,
	[HTGiaoHang] [nvarchar](20) NOT NULL,
	[NgayLapHD] [date] NOT NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC,
	[MaCuaHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HSX]    Script Date: 9/23/2018 3:24:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HSX](
	[MaHSX] [varchar](15) NOT NULL,
	[TenHSX] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_HSX] PRIMARY KEY CLUSTERED 
(
	[MaHSX] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 9/23/2018 3:24:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKH] [varchar](10) NOT NULL,
	[TenKH] [nvarchar](50) NOT NULL,
	[DiaChi] [nvarchar](100) NOT NULL,
	[SDT] [varchar](13) NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KhoHang]    Script Date: 9/23/2018 3:24:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KhoHang](
	[MaKieu] [varchar](50) NOT NULL,
	[MaCuaHang] [varchar](10) NOT NULL,
	[SoLuong] [int] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LoaiNV]    Script Date: 9/23/2018 3:24:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LoaiNV](
	[MaLoaiNV] [varchar](15) NOT NULL,
	[TenLoaiNV] [nvarchar](20) NULL,
 CONSTRAINT [PK_LoaiNV] PRIMARY KEY CLUSTERED 
(
	[MaLoaiNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LoaiSP]    Script Date: 9/23/2018 3:24:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LoaiSP](
	[MaLSP] [varchar](10) NOT NULL,
	[TenLSP] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_LoaiSP] PRIMARY KEY CLUSTERED 
(
	[MaLSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LoaiTaiKhoan]    Script Date: 9/23/2018 3:24:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LoaiTaiKhoan](
	[MaLoaiTK] [varchar](10) NOT NULL,
	[TenLoaiTK] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_LoaiTaiKhoan] PRIMARY KEY CLUSTERED 
(
	[MaLoaiTK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MauSP]    Script Date: 9/23/2018 3:24:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MauSP](
	[MaMau] [varchar](20) NOT NULL,
	[Mau] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_MauSP] PRIMARY KEY CLUSTERED 
(
	[MaMau] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 9/23/2018 3:24:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [varchar](10) NOT NULL,
	[MaCuaHang] [varchar](10) NOT NULL,
	[MaLoaiNV] [varchar](15) NOT NULL,
	[TenNV] [nvarchar](50) NOT NULL,
	[GioiTinh] [nvarchar](5) NOT NULL,
	[DiaChi] [nvarchar](100) NULL,
	[SDT] [varchar](13) NULL,
	[Luong] [decimal](18, 0) NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 9/23/2018 3:24:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SanPham](
	[MaSP] [varchar](30) NOT NULL,
	[TenSP] [nvarchar](30) NOT NULL,
	[CPU] [nvarchar](100) NOT NULL,
	[Ram] [varchar](10) NULL,
	[BoNhoTrong] [varchar](10) NULL,
	[BoNhoNgoai] [nvarchar](50) NULL,
	[Sim] [nvarchar](50) NULL,
	[ManHinh] [nvarchar](50) NULL,
	[DungLuongPin] [nvarchar](50) NULL,
	[Camera] [nvarchar](60) NULL,
	[CardManHinh] [nvarchar](50) NULL,
	[OS] [varchar](20) NULL,
	[Port] [nvarchar](50) NULL,
	[TrongLuong] [varchar](20) NULL,
	[ThongTinKhac] [nvarchar](100) NULL,
	[MaDSP] [nvarchar](50) NOT NULL,
	[NămSX] [varchar](10) NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 9/23/2018 3:24:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[UserName] [nvarchar](20) NOT NULL,
	[Password] [nchar](10) NOT NULL,
	[MaCuaHang] [varchar](10) NOT NULL,
	[MaLoaiTK] [varchar](10) NOT NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaKieu], [MaCuaHang], [SoluongSP]) VALUES (N'hd0001', N'ipX256Gray', N'cs1', 1)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaKieu], [MaCuaHang], [SoluongSP]) VALUES (N'hd0002', N'ipX256Gray', N'cs2', 1)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaKieu], [MaCuaHang], [SoluongSP]) VALUES (N'hd0002', N'ipX256Silver', N'cs2', 1)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaKieu], [MaCuaHang], [SoluongSP]) VALUES (N'hd0003', N'ssNote9_128_Black', N'cs1', 1)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaKieu], [MaCuaHang], [SoluongSP]) VALUES (N'hd0004', N'ssNote9_128_Blue', N'cs1', 1)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaKieu], [MaCuaHang], [SoluongSP]) VALUES (N'hd0005', N'ipX64Gray', N'cs1', 2)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaKieu], [MaCuaHang], [SoluongSP]) VALUES (N'hd0006', N'ipX64Silver', N'cs2', 3)
INSERT [dbo].[ChiTietSP] ([MaSP], [MaKieu], [MaMau], [Giá], [SoluongSP], [Anh]) VALUES (N'ipX256', N'ipX256Gray', N'gray', CAST(34790000.00 AS Decimal(18, 2)), 100, NULL)
INSERT [dbo].[ChiTietSP] ([MaSP], [MaKieu], [MaMau], [Giá], [SoluongSP], [Anh]) VALUES (N'ipX256', N'ipX256Silver', N'silver', CAST(34790000.00 AS Decimal(18, 2)), 100, NULL)
INSERT [dbo].[ChiTietSP] ([MaSP], [MaKieu], [MaMau], [Giá], [SoluongSP], [Anh]) VALUES (N'ipX64', N'ipX64Gray', N'gray', CAST(29990000.00 AS Decimal(18, 2)), 150, NULL)
INSERT [dbo].[ChiTietSP] ([MaSP], [MaKieu], [MaMau], [Giá], [SoluongSP], [Anh]) VALUES (N'ipX64', N'ipX64Silver', N'silver', CAST(29990000.00 AS Decimal(18, 2)), 120, NULL)
INSERT [dbo].[ChiTietSP] ([MaSP], [MaKieu], [MaMau], [Giá], [SoluongSP], [Anh]) VALUES (N'ssNote9_128', N'ssNote9_128_Black', N'black', CAST(22800000.00 AS Decimal(18, 2)), 100, NULL)
INSERT [dbo].[ChiTietSP] ([MaSP], [MaKieu], [MaMau], [Giá], [SoluongSP], [Anh]) VALUES (N'ssNote9_128', N'ssNote9_128_Blue', N'blue', CAST(22990000.00 AS Decimal(18, 2)), 200, NULL)
INSERT [dbo].[CuaHang] ([MaCuaHang], [TenCuaHang], [DiaChi]) VALUES (N'cs1', N'Galaxy Mobile 1', N'4 Hồ Bá Phấn')
INSERT [dbo].[CuaHang] ([MaCuaHang], [TenCuaHang], [DiaChi]) VALUES (N'cs2', N'Galaxy Mobile 2', N'1268 Định Hòa, Thủ Dầu Một,Tỉnh Bình Dương')
INSERT [dbo].[CuaHang] ([MaCuaHang], [TenCuaHang], [DiaChi]) VALUES (N'ts', N'Galaxy Center', N'1 Võ Văn Ngân, Thủ Đức, Tp.HCM')
INSERT [dbo].[DongSanPham] ([MaDSP], [TenDong], [MaHSX], [MaLSP]) VALUES (N'dellXps', N'Dell Xps', N'dell', N'lap')
INSERT [dbo].[DongSanPham] ([MaDSP], [TenDong], [MaHSX], [MaLSP]) VALUES (N'ipX', N'Iphone X', N'apple', N'dt')
INSERT [dbo].[DongSanPham] ([MaDSP], [TenDong], [MaHSX], [MaLSP]) VALUES (N'ipXR', N'Iphone XR', N'apple', N'dt')
INSERT [dbo].[DongSanPham] ([MaDSP], [TenDong], [MaHSX], [MaLSP]) VALUES (N'ipXS', N'Iphone XS', N'apple', N'dt')
INSERT [dbo].[DongSanPham] ([MaDSP], [TenDong], [MaHSX], [MaLSP]) VALUES (N'ipXSMax', N'Iphone XS Max', N'apple', N'dt')
INSERT [dbo].[DongSanPham] ([MaDSP], [TenDong], [MaHSX], [MaLSP]) VALUES (N'lnvK', N'Lenovo K', N'lenovo', N'dt')
INSERT [dbo].[DongSanPham] ([MaDSP], [TenDong], [MaHSX], [MaLSP]) VALUES (N'lnvS', N'Lenovo S', N'lenovo', N'dt')
INSERT [dbo].[DongSanPham] ([MaDSP], [TenDong], [MaHSX], [MaLSP]) VALUES (N'lnvVibe', N'Lenovo Vibe', N'lenovo', N'dt')
INSERT [dbo].[DongSanPham] ([MaDSP], [TenDong], [MaHSX], [MaLSP]) VALUES (N'macbookair', N'Macbook Air', N'apple', N'lap')
INSERT [dbo].[DongSanPham] ([MaDSP], [TenDong], [MaHSX], [MaLSP]) VALUES (N'macbookpro', N'Macbook Pro', N'apple', N'lap')
INSERT [dbo].[DongSanPham] ([MaDSP], [TenDong], [MaHSX], [MaLSP]) VALUES (N'ssA', N'Sam Sung A', N'samsung', N'dt')
INSERT [dbo].[DongSanPham] ([MaDSP], [TenDong], [MaHSX], [MaLSP]) VALUES (N'ssJ', N'SamSung J', N'samsung', N'dt')
INSERT [dbo].[DongSanPham] ([MaDSP], [TenDong], [MaHSX], [MaLSP]) VALUES (N'ssNote', N'SamSung Note', N'samsung', N'dt')
INSERT [dbo].[DongSanPham] ([MaDSP], [TenDong], [MaHSX], [MaLSP]) VALUES (N'ssS', N'SamSung S', N'samsung', N'dt')
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKH], [MaNV], [MaCuaHang], [TinhTrang], [HTGiaoHang], [NgayLapHD]) VALUES (N'hd0001', N'1', N'006', N'cs1', 1, N'Trực tiếp', CAST(0xBC3E0B00 AS Date))
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKH], [MaNV], [MaCuaHang], [TinhTrang], [HTGiaoHang], [NgayLapHD]) VALUES (N'hd0002', N'2', N'007', N'cs2', 0, N'Trực tiếp', CAST(0xBD3E0B00 AS Date))
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKH], [MaNV], [MaCuaHang], [TinhTrang], [HTGiaoHang], [NgayLapHD]) VALUES (N'hd0003', N'2', N'006', N'cs1', 0, N'Trực tiếp', CAST(0xBE3E0B00 AS Date))
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKH], [MaNV], [MaCuaHang], [TinhTrang], [HTGiaoHang], [NgayLapHD]) VALUES (N'hd0004', N'3', N'006', N'cs1', 1, N'Trực tiếp', CAST(0xBE3E0B00 AS Date))
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKH], [MaNV], [MaCuaHang], [TinhTrang], [HTGiaoHang], [NgayLapHD]) VALUES (N'hd0005', N'4', N'006', N'cs1', 1, N'Trực tiếp', CAST(0xBE3E0B00 AS Date))
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKH], [MaNV], [MaCuaHang], [TinhTrang], [HTGiaoHang], [NgayLapHD]) VALUES (N'hd0006', N'4', N'007', N'cs2', 0, N'Trực tiếp', CAST(0xBF3E0B00 AS Date))
INSERT [dbo].[HSX] ([MaHSX], [TenHSX]) VALUES (N'apple', N'Apple')
INSERT [dbo].[HSX] ([MaHSX], [TenHSX]) VALUES (N'dell', N'Dell')
INSERT [dbo].[HSX] ([MaHSX], [TenHSX]) VALUES (N'google', N'Google')
INSERT [dbo].[HSX] ([MaHSX], [TenHSX]) VALUES (N'htc', N'HTC')
INSERT [dbo].[HSX] ([MaHSX], [TenHSX]) VALUES (N'lenovo', N'Lenovo')
INSERT [dbo].[HSX] ([MaHSX], [TenHSX]) VALUES (N'lg', N'LG')
INSERT [dbo].[HSX] ([MaHSX], [TenHSX]) VALUES (N'microsoft', N'Microsoft')
INSERT [dbo].[HSX] ([MaHSX], [TenHSX]) VALUES (N'nokia', N'Nokia')
INSERT [dbo].[HSX] ([MaHSX], [TenHSX]) VALUES (N'oppo', N'Oppo')
INSERT [dbo].[HSX] ([MaHSX], [TenHSX]) VALUES (N'samsung', N'SamSung')
INSERT [dbo].[HSX] ([MaHSX], [TenHSX]) VALUES (N'sony', N'Sony')
INSERT [dbo].[HSX] ([MaHSX], [TenHSX]) VALUES (N'toshiba', N'Toshiba')
INSERT [dbo].[HSX] ([MaHSX], [TenHSX]) VALUES (N'vivo', N'Vivo')
INSERT [dbo].[HSX] ([MaHSX], [TenHSX]) VALUES (N'xiaomi', N'Xiaomi')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [DiaChi], [SDT]) VALUES (N'1', N'Phan Thanh Nam', N'1 Võ Văn Ngân', N'01231232423')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [DiaChi], [SDT]) VALUES (N'2', N'Lâm Phước Bảo', N'2 Võ Văn Ngân', N'0923423423')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [DiaChi], [SDT]) VALUES (N'3', N'Nguyễn Thiên Quốc', N'nguyễn Văn Cừ', N'01231241434')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [DiaChi], [SDT]) VALUES (N'4', N'Trần Đăng Khôi Nguyên', N'Dokao, Quận 1', N'0923242344')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [DiaChi], [SDT]) VALUES (N'5', N'Nguyễn Văn A', N'abc', N'0123456789')
INSERT [dbo].[KhoHang] ([MaKieu], [MaCuaHang], [SoLuong]) VALUES (N'ipX256Gray', N'ts', 50)
INSERT [dbo].[KhoHang] ([MaKieu], [MaCuaHang], [SoLuong]) VALUES (N'ipX256Gray', N'cs1', 25)
INSERT [dbo].[KhoHang] ([MaKieu], [MaCuaHang], [SoLuong]) VALUES (N'ipX256Gray', N'cs2', 25)
INSERT [dbo].[KhoHang] ([MaKieu], [MaCuaHang], [SoLuong]) VALUES (N'ipX256Silver', N'ts', 0)
INSERT [dbo].[KhoHang] ([MaKieu], [MaCuaHang], [SoLuong]) VALUES (N'ipX256Silver', N'cs1', 50)
INSERT [dbo].[KhoHang] ([MaKieu], [MaCuaHang], [SoLuong]) VALUES (N'ipX256Silver', N'cs2', 50)
INSERT [dbo].[KhoHang] ([MaKieu], [MaCuaHang], [SoLuong]) VALUES (N'ipX64Gray', N'ts', 50)
INSERT [dbo].[KhoHang] ([MaKieu], [MaCuaHang], [SoLuong]) VALUES (N'ipX64Gray', N'cs1', 50)
INSERT [dbo].[KhoHang] ([MaKieu], [MaCuaHang], [SoLuong]) VALUES (N'ipX64Gray', N'cs2', 50)
INSERT [dbo].[KhoHang] ([MaKieu], [MaCuaHang], [SoLuong]) VALUES (N'ipX64Silver', N'ts', 0)
INSERT [dbo].[KhoHang] ([MaKieu], [MaCuaHang], [SoLuong]) VALUES (N'ipX64Silver', N'cs1', 60)
INSERT [dbo].[KhoHang] ([MaKieu], [MaCuaHang], [SoLuong]) VALUES (N'ipX64Silver', N'cs2', 60)
INSERT [dbo].[KhoHang] ([MaKieu], [MaCuaHang], [SoLuong]) VALUES (N'ssNote9_128_Blue', N'ts', 0)
INSERT [dbo].[KhoHang] ([MaKieu], [MaCuaHang], [SoLuong]) VALUES (N'ssNote9_128_Blue', N'cs1', 100)
INSERT [dbo].[KhoHang] ([MaKieu], [MaCuaHang], [SoLuong]) VALUES (N'ssNote9_128_Blue', N'cs2', 100)
INSERT [dbo].[KhoHang] ([MaKieu], [MaCuaHang], [SoLuong]) VALUES (N'ssNote9_128_Black', N'ts', 25)
INSERT [dbo].[KhoHang] ([MaKieu], [MaCuaHang], [SoLuong]) VALUES (N'ssNote9_128_Black', N'cs1', 50)
INSERT [dbo].[KhoHang] ([MaKieu], [MaCuaHang], [SoLuong]) VALUES (N'ssNote9_128_Black', N'cs2', 25)
INSERT [dbo].[LoaiNV] ([MaLoaiNV], [TenLoaiNV]) VALUES (N'admin', N'Admintrastor')
INSERT [dbo].[LoaiNV] ([MaLoaiNV], [TenLoaiNV]) VALUES (N'bh', N'Nhân viên bán hàng')
INSERT [dbo].[LoaiNV] ([MaLoaiNV], [TenLoaiNV]) VALUES (N'bv', N'Bảo vệ')
INSERT [dbo].[LoaiNV] ([MaLoaiNV], [TenLoaiNV]) VALUES (N'qlch', N'Quản lí cửa hàng')
INSERT [dbo].[LoaiNV] ([MaLoaiNV], [TenLoaiNV]) VALUES (N'qlk', N'Quản lí kho hàng')
INSERT [dbo].[LoaiNV] ([MaLoaiNV], [TenLoaiNV]) VALUES (N'qlns', N'Quản lí nhân sự')
INSERT [dbo].[LoaiNV] ([MaLoaiNV], [TenLoaiNV]) VALUES (N'tn', N'Nhân viên thu ngân')
INSERT [dbo].[LoaiSP] ([MaLSP], [TenLSP]) VALUES (N'dt', N'Điện Thoại')
INSERT [dbo].[LoaiSP] ([MaLSP], [TenLSP]) VALUES (N'lap', N'Laptop')
INSERT [dbo].[LoaiTaiKhoan] ([MaLoaiTK], [TenLoaiTK]) VALUES (N'admin', N'Admintrastor')
INSERT [dbo].[LoaiTaiKhoan] ([MaLoaiTK], [TenLoaiTK]) VALUES (N'qlch', N'Quản li cửa hàng')
INSERT [dbo].[LoaiTaiKhoan] ([MaLoaiTK], [TenLoaiTK]) VALUES (N'qlk', N'Quản lí kho hàng')
INSERT [dbo].[LoaiTaiKhoan] ([MaLoaiTK], [TenLoaiTK]) VALUES (N'qlns', N'Quản lí nhân sự')
INSERT [dbo].[LoaiTaiKhoan] ([MaLoaiTK], [TenLoaiTK]) VALUES (N'tn', N'Thu ngân')
INSERT [dbo].[MauSP] ([MaMau], [Mau]) VALUES (N'black', N'Đen')
INSERT [dbo].[MauSP] ([MaMau], [Mau]) VALUES (N'blue', N'Xanh biển')
INSERT [dbo].[MauSP] ([MaMau], [Mau]) VALUES (N'coral blue', N'Xanh da trời (Coral Blue)')
INSERT [dbo].[MauSP] ([MaMau], [Mau]) VALUES (N'gold', N'Vàng kim')
INSERT [dbo].[MauSP] ([MaMau], [Mau]) VALUES (N'gray', N'Xám')
INSERT [dbo].[MauSP] ([MaMau], [Mau]) VALUES (N'jet black', N'Đen Thẩm (Jet Black)')
INSERT [dbo].[MauSP] ([MaMau], [Mau]) VALUES (N'purple', N'Tím (Purple)')
INSERT [dbo].[MauSP] ([MaMau], [Mau]) VALUES (N'red', N'Đỏ')
INSERT [dbo].[MauSP] ([MaMau], [Mau]) VALUES (N'rose gold', N'Vàng Hồng (Rose Gold)')
INSERT [dbo].[MauSP] ([MaMau], [Mau]) VALUES (N'silver', N'Bạc')
INSERT [dbo].[MauSP] ([MaMau], [Mau]) VALUES (N'space gray', N'Xám không gian')
INSERT [dbo].[MauSP] ([MaMau], [Mau]) VALUES (N'titanium gray', N'Xám Titan(Titanium Gray)')
INSERT [dbo].[MauSP] ([MaMau], [Mau]) VALUES (N'white', N'Trắng')
INSERT [dbo].[NhanVien] ([MaNV], [MaCuaHang], [MaLoaiNV], [TenNV], [GioiTinh], [DiaChi], [SDT], [Luong]) VALUES (N'001', N'ts', N'admin', N'Admin', N'nam', NULL, NULL, NULL)
INSERT [dbo].[NhanVien] ([MaNV], [MaCuaHang], [MaLoaiNV], [TenNV], [GioiTinh], [DiaChi], [SDT], [Luong]) VALUES (N'002', N'ts', N'qlk', N'Phan Thanh Nam', N'nam', NULL, N'01232333232', CAST(10000000 AS Decimal(18, 0)))
INSERT [dbo].[NhanVien] ([MaNV], [MaCuaHang], [MaLoaiNV], [TenNV], [GioiTinh], [DiaChi], [SDT], [Luong]) VALUES (N'003', N'ts', N'qlns', N'Lâm Phước Bảo', N'nam', NULL, N'43432342342', CAST(10000000 AS Decimal(18, 0)))
INSERT [dbo].[NhanVien] ([MaNV], [MaCuaHang], [MaLoaiNV], [TenNV], [GioiTinh], [DiaChi], [SDT], [Luong]) VALUES (N'004', N'cs1', N'qlch', N'Nguyễn Thiên Quốc', N'nam', NULL, N'12363463453', CAST(5000000 AS Decimal(18, 0)))
INSERT [dbo].[NhanVien] ([MaNV], [MaCuaHang], [MaLoaiNV], [TenNV], [GioiTinh], [DiaChi], [SDT], [Luong]) VALUES (N'005', N'cs2', N'qlch', N'Trần Đăng Khôi Nguyên', N'nam', NULL, N'42342342343', CAST(5000000 AS Decimal(18, 0)))
INSERT [dbo].[NhanVien] ([MaNV], [MaCuaHang], [MaLoaiNV], [TenNV], [GioiTinh], [DiaChi], [SDT], [Luong]) VALUES (N'006', N'cs1', N'tn', N'Tiểu Vy', N'nữ', NULL, N'32432432432', CAST(2500000 AS Decimal(18, 0)))
INSERT [dbo].[NhanVien] ([MaNV], [MaCuaHang], [MaLoaiNV], [TenNV], [GioiTinh], [DiaChi], [SDT], [Luong]) VALUES (N'007', N'cs2', N'tn', N'Nguyễn Thị Nữ', N'nữ', NULL, N'34234234343', CAST(2500000 AS Decimal(18, 0)))
INSERT [dbo].[NhanVien] ([MaNV], [MaCuaHang], [MaLoaiNV], [TenNV], [GioiTinh], [DiaChi], [SDT], [Luong]) VALUES (N'008', N'cs1', N'bh', N'Nguyễn Văn A', N'nam', NULL, N'33423343324', CAST(1000000 AS Decimal(18, 0)))
INSERT [dbo].[NhanVien] ([MaNV], [MaCuaHang], [MaLoaiNV], [TenNV], [GioiTinh], [DiaChi], [SDT], [Luong]) VALUES (N'009', N'cs2', N'bh', N'Nguyễn Thị  B', N'nữ', NULL, N'53534534634', CAST(1000000 AS Decimal(18, 0)))
INSERT [dbo].[NhanVien] ([MaNV], [MaCuaHang], [MaLoaiNV], [TenNV], [GioiTinh], [DiaChi], [SDT], [Luong]) VALUES (N'010', N'cs1', N'bv', N'Nguyễn Văn C', N'nam', NULL, N'12131231434', CAST(500000 AS Decimal(18, 0)))
INSERT [dbo].[NhanVien] ([MaNV], [MaCuaHang], [MaLoaiNV], [TenNV], [GioiTinh], [DiaChi], [SDT], [Luong]) VALUES (N'011', N'cs2', N'bv', N'Nguyễn Văn D', N'nam', NULL, N'42342354353', CAST(500000 AS Decimal(18, 0)))
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [CPU], [Ram], [BoNhoTrong], [BoNhoNgoai], [Sim], [ManHinh], [DungLuongPin], [Camera], [CardManHinh], [OS], [Port], [TrongLuong], [ThongTinKhac], [MaDSP], [NămSX]) VALUES (N'ipX256', N'Iphone X 256 GB', N'Apple A11 Bionic 6 nhân', N'3 GB', N'256 GB', N'Không hổ trợ', N'1 sim nano', N'OLED, 5.8", Super Retina', N'2716 mAh, có sạc nhanh', N'Camera sau:2 camera 12 MP
,Camera trước:7 MP', N'', N'IOS 11', N'Lightning,không Jac 3.5', N'174 g', N'	Nhận diện khuôn mặt Face ID, 	3D Touch', N'ipX', N'09/2017')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [CPU], [Ram], [BoNhoTrong], [BoNhoNgoai], [Sim], [ManHinh], [DungLuongPin], [Camera], [CardManHinh], [OS], [Port], [TrongLuong], [ThongTinKhac], [MaDSP], [NămSX]) VALUES (N'ipX64', N'Iphone X 64GB', N'Apple A11 Bionic 6 nhân', N'3 GB', N'64 GB', N'Không hổ trợ', N'1 sim nano', N'	OLED, 5.8", Super Retina', N'2716 mAh, có sạc nhanh', N'Camera sau:2 camera 12 MP
,Camera trước:7 MP', N'', N'IOS 11', N'Lightning,không Jac 3.5', N'174 g', N'	Nhận diện khuôn mặt Face ID, 	3D Touch', N'ipX', N'09/2017')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [CPU], [Ram], [BoNhoTrong], [BoNhoNgoai], [Sim], [ManHinh], [DungLuongPin], [Camera], [CardManHinh], [OS], [Port], [TrongLuong], [ThongTinKhac], [MaDSP], [NămSX]) VALUES (N'ipXM256', N'Iphone XS Max 256 GB', N'Apple A12 Bionic 6 nhân', N'4 GB', N'256 GB', N'Không hổ trợ', N'1 sim nano', N'OLED, 6.5", Super Retina', NULL, N'Camera sau:2 camera 12 MP
,Camera trước:7 MP', N'Apple GPU 4 nhân', N'IOS 12', N'Lightning,không Jac 3.5', N'208 g', N'	Nhận diện khuôn mặt Face ID, 	3D Touch', N'ipXSMax', N'09/2018')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [CPU], [Ram], [BoNhoTrong], [BoNhoNgoai], [Sim], [ManHinh], [DungLuongPin], [Camera], [CardManHinh], [OS], [Port], [TrongLuong], [ThongTinKhac], [MaDSP], [NămSX]) VALUES (N'ipXR64', N'Iphone XR 64GB', N'Apple A12 Bionic', N'3 GB', N'64 GB', N'Không hổ trợ', N'2 sim nano', N'	Liquid Retina LCD, 6.1''''', N'2700mAh, có sạc nhanh', N'Camera sau:12 MP
,Camera trước:7 MP', N'8 lỗi', N'IOS 12', N'Lightning,không Jac 3.5', N'194 g', N'	Nhận diện khuôn mặt Face ID, 	3D Touch', N'ipXR', N'09/2018')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [CPU], [Ram], [BoNhoTrong], [BoNhoNgoai], [Sim], [ManHinh], [DungLuongPin], [Camera], [CardManHinh], [OS], [Port], [TrongLuong], [ThongTinKhac], [MaDSP], [NămSX]) VALUES (N'ipXS64', N'Iphone XS 64GB', N'	Apple A12 Bionic 6 nhân', N'4 GB', N'64 GB', N'Không hổ trợ', N'2 sim nano', N'OLED, 5.8", Super Retina', NULL, N'Camera sau:12 MP
,Camera trước:7 MP', N'Apple GPU 4 nhân', N'IOS 12', N'Lightning,không Jac 3.5', N'177 g', N'	Nhận diện khuôn mặt Face ID, 	3D Touch', N'ipXS', N'09/2018')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [CPU], [Ram], [BoNhoTrong], [BoNhoNgoai], [Sim], [ManHinh], [DungLuongPin], [Camera], [CardManHinh], [OS], [Port], [TrongLuong], [ThongTinKhac], [MaDSP], [NămSX]) VALUES (N'ssNote9_128', N'Samsung Note 9 128GB', N'	Exynos 9810 8 nhân 64 bit', N'6 GB', N'128 GB', N'MicroSD, hỗ trợ tối đa 512 GB', N'2 sim nano', N'Super AMOLED, 6.4", Quad HD+ (2K+)', N'4000 mAh, có sạc nhanh', N'Camera sau:2 camera 12 MP
,Camera trước:8 MP', N'Exynos 9810 8 nhân 64 bit', N'Android 8.1 (Oreo)', N'	USB Type-C', N'201 g', N'	Mở khóa bằng vân tay, Mở khóa bằng khuôn mặt, Quét mống mắt', N'ssNote', N'08/2018')
INSERT [dbo].[TaiKhoan] ([UserName], [Password], [MaCuaHang], [MaLoaiTK]) VALUES (N'admin', N'admin     ', N'ts', N'admin')
INSERT [dbo].[TaiKhoan] ([UserName], [Password], [MaCuaHang], [MaLoaiTK]) VALUES (N'baobao', N'123       ', N'ts', N'qlns')
INSERT [dbo].[TaiKhoan] ([UserName], [Password], [MaCuaHang], [MaLoaiTK]) VALUES (N'nam', N'123       ', N'ts', N'qlk')
INSERT [dbo].[TaiKhoan] ([UserName], [Password], [MaCuaHang], [MaLoaiTK]) VALUES (N'nguyen', N'123       ', N'cs2', N'qlch')
INSERT [dbo].[TaiKhoan] ([UserName], [Password], [MaCuaHang], [MaLoaiTK]) VALUES (N'quoc', N'123       ', N'cs1', N'qlch')
INSERT [dbo].[TaiKhoan] ([UserName], [Password], [MaCuaHang], [MaLoaiTK]) VALUES (N'thungan1', N'123       ', N'cs1', N'tn')
INSERT [dbo].[TaiKhoan] ([UserName], [Password], [MaCuaHang], [MaLoaiTK]) VALUES (N'thungan2', N'123       ', N'cs2', N'tn')
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_ChiTietSP1] FOREIGN KEY([MaKieu])
REFERENCES [dbo].[ChiTietSP] ([MaKieu])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_ChiTietSP1]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_HoaDon1] FOREIGN KEY([MaHoaDon], [MaCuaHang])
REFERENCES [dbo].[HoaDon] ([MaHoaDon], [MaCuaHang])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_HoaDon1]
GO
ALTER TABLE [dbo].[ChiTietSP]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietSP_MauSP] FOREIGN KEY([MaMau])
REFERENCES [dbo].[MauSP] ([MaMau])
GO
ALTER TABLE [dbo].[ChiTietSP] CHECK CONSTRAINT [FK_ChiTietSP_MauSP]
GO
ALTER TABLE [dbo].[ChiTietSP]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietSP_SanPham] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SanPham] ([MaSP])
GO
ALTER TABLE [dbo].[ChiTietSP] CHECK CONSTRAINT [FK_ChiTietSP_SanPham]
GO
ALTER TABLE [dbo].[DongSanPham]  WITH CHECK ADD  CONSTRAINT [FK_DongSanPham_HSX] FOREIGN KEY([MaHSX])
REFERENCES [dbo].[HSX] ([MaHSX])
GO
ALTER TABLE [dbo].[DongSanPham] CHECK CONSTRAINT [FK_DongSanPham_HSX]
GO
ALTER TABLE [dbo].[DongSanPham]  WITH CHECK ADD  CONSTRAINT [FK_DongSanPham_LoaiSP] FOREIGN KEY([MaLSP])
REFERENCES [dbo].[LoaiSP] ([MaLSP])
GO
ALTER TABLE [dbo].[DongSanPham] CHECK CONSTRAINT [FK_DongSanPham_LoaiSP]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_KhachHang] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_KhachHang]
GO
ALTER TABLE [dbo].[KhoHang]  WITH CHECK ADD  CONSTRAINT [FK_KhoHang_ChiTietSP] FOREIGN KEY([MaKieu])
REFERENCES [dbo].[ChiTietSP] ([MaKieu])
GO
ALTER TABLE [dbo].[KhoHang] CHECK CONSTRAINT [FK_KhoHang_ChiTietSP]
GO
ALTER TABLE [dbo].[KhoHang]  WITH CHECK ADD  CONSTRAINT [FK_KhoHang_CuaHang] FOREIGN KEY([MaCuaHang])
REFERENCES [dbo].[CuaHang] ([MaCuaHang])
GO
ALTER TABLE [dbo].[KhoHang] CHECK CONSTRAINT [FK_KhoHang_CuaHang]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_CuaHang] FOREIGN KEY([MaCuaHang])
REFERENCES [dbo].[CuaHang] ([MaCuaHang])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_CuaHang]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_LoaiNV] FOREIGN KEY([MaLoaiNV])
REFERENCES [dbo].[LoaiNV] ([MaLoaiNV])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_LoaiNV]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_DongSanPham] FOREIGN KEY([MaDSP])
REFERENCES [dbo].[DongSanPham] ([MaDSP])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_DongSanPham]
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_TaiKhoan_CuaHang] FOREIGN KEY([MaCuaHang])
REFERENCES [dbo].[CuaHang] ([MaCuaHang])
GO
ALTER TABLE [dbo].[TaiKhoan] CHECK CONSTRAINT [FK_TaiKhoan_CuaHang]
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_TaiKhoan_LoaiTaiKhoan] FOREIGN KEY([MaLoaiTK])
REFERENCES [dbo].[LoaiTaiKhoan] ([MaLoaiTK])
GO
ALTER TABLE [dbo].[TaiKhoan] CHECK CONSTRAINT [FK_TaiKhoan_LoaiTaiKhoan]
GO
USE [master]
GO
ALTER DATABASE [GalaxyMobile] SET  READ_WRITE 
GO
