USE [master]
GO
/****** Object:  Database [DAMH_PTPM]    Script Date: 8/14/2020 3:12:00 AM ******/
CREATE DATABASE [DAMH_PTPM]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DAMH_PTPM', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\DAMH_PTPM.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DAMH_PTPM_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\DAMH_PTPM_log.ldf' , SIZE = 1040KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DAMH_PTPM] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DAMH_PTPM].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DAMH_PTPM] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DAMH_PTPM] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DAMH_PTPM] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DAMH_PTPM] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DAMH_PTPM] SET ARITHABORT OFF 
GO
ALTER DATABASE [DAMH_PTPM] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DAMH_PTPM] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DAMH_PTPM] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DAMH_PTPM] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DAMH_PTPM] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DAMH_PTPM] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DAMH_PTPM] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DAMH_PTPM] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DAMH_PTPM] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DAMH_PTPM] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DAMH_PTPM] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DAMH_PTPM] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DAMH_PTPM] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DAMH_PTPM] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DAMH_PTPM] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DAMH_PTPM] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DAMH_PTPM] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DAMH_PTPM] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DAMH_PTPM] SET  MULTI_USER 
GO
ALTER DATABASE [DAMH_PTPM] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DAMH_PTPM] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DAMH_PTPM] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DAMH_PTPM] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [DAMH_PTPM]
GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 8/14/2020 3:12:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[MaHoaDon] [varchar](50) NOT NULL,
	[MaSanPham] [varchar](50) NOT NULL,
	[SoLuong] [int] NULL,
	[ThanhTien] [money] NULL,
 CONSTRAINT [PK_ChiTietHoaDon] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC,
	[MaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietPhieuCungCap]    Script Date: 8/14/2020 3:12:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuCungCap](
	[MaCungCap] [varchar](50) NOT NULL,
	[MaNguyenLieu] [varchar](50) NOT NULL,
	[SoLuong] [int] NULL,
	[GiaMua] [money] NULL,
	[ThanhTien] [money] NULL,
 CONSTRAINT [PK_ChiTietPhieuCungCap] PRIMARY KEY CLUSTERED 
(
	[MaCungCap] ASC,
	[MaNguyenLieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CongThucSanPham]    Script Date: 8/14/2020 3:12:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CongThucSanPham](
	[MaSanPham] [varchar](50) NOT NULL,
	[MaNguyenLieu] [varchar](50) NOT NULL,
	[SoLuongDung] [int] NULL,
 CONSTRAINT [PK_CongThucSanPham] PRIMARY KEY CLUSTERED 
(
	[MaSanPham] ASC,
	[MaNguyenLieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 8/14/2020 3:12:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHoaDon] [varchar](50) NOT NULL,
	[MaNhanVien] [varchar](50) NULL,
	[MaKhachHang] [varchar](50) NULL,
	[NgayBan] [date] NULL,
	[TongTien] [money] NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 8/14/2020 3:12:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKhachHang] [varchar](50) NOT NULL,
	[TenKhachHang] [nvarchar](50) NULL,
	[SDT] [varchar](50) NULL,
	[GioiTinh] [bit] NULL,
	[Email] [varchar](50) NULL,
	[CMND] [varchar](50) NULL,
	[DiaChi] [nvarchar](500) NULL,
	[LoaiKhachHang] [varchar](50) NULL,
	[Diem] [int] NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiKhachHang]    Script Date: 8/14/2020 3:12:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiKhachHang](
	[MaLoai] [varchar](50) NOT NULL,
	[TenLoai] [nvarchar](50) NULL,
	[DiemTichLuy] [int] NULL,
 CONSTRAINT [PK_LoaiKhachHang] PRIMARY KEY CLUSTERED 
(
	[MaLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiNhanVien]    Script Date: 8/14/2020 3:12:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiNhanVien](
	[MaLoaiNV] [varchar](50) NOT NULL,
	[TenLoai] [nvarchar](50) NULL,
	[LuongCoBan] [float] NULL,
 CONSTRAINT [PK_LoaiNhanVien] PRIMARY KEY CLUSTERED 
(
	[MaLoaiNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NguyenLieu]    Script Date: 8/14/2020 3:12:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguyenLieu](
	[MaNguyenLieu] [varchar](50) NOT NULL,
	[TenNguyenLieu] [nvarchar](50) NULL,
	[SoLuongCon] [int] NULL,
	[TinhTrang] [bit] NULL,
 CONSTRAINT [PK_NguyenLieu] PRIMARY KEY CLUSTERED 
(
	[MaNguyenLieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 8/14/2020 3:12:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[MaNhaCungCap] [varchar](50) NOT NULL,
	[TenNhaCungCap] [nvarchar](50) NULL,
	[SDT] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[DiaChi] [nvarchar](500) NULL,
	[GhiChu] [nvarchar](500) NULL,
 CONSTRAINT [PK_NhaCungCap] PRIMARY KEY CLUSTERED 
(
	[MaNhaCungCap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 8/14/2020 3:12:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNhanVien] [varchar](50) NOT NULL,
	[TenNhanVien] [nvarchar](50) NULL,
	[SDT] [varchar](50) NULL,
	[GioiTinh] [bit] NULL,
	[NgaySinh] [date] NULL,
	[Email] [varchar](50) NULL,
	[CMND] [varchar](50) NULL,
	[DiaChi] [nvarchar](500) NULL,
	[NgayVaoLam] [date] NULL,
	[MatKhau] [varchar](50) NULL,
	[TinhTrang] [bit] NULL,
	[TongGioLam] [int] NULL,
	[Luong] [float] NULL,
	[LoaiNhanVien] [varchar](50) NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhomSanPham]    Script Date: 8/14/2020 3:12:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhomSanPham](
	[MaNhomSP] [varchar](50) NOT NULL,
	[TenNhom] [nvarchar](50) NULL,
 CONSTRAINT [PK_NhomSanPham] PRIMARY KEY CLUSTERED 
(
	[MaNhomSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuCungCap]    Script Date: 8/14/2020 3:12:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuCungCap](
	[MaCungCap] [varchar](50) NOT NULL,
	[MaNhaCungCap] [varchar](50) NULL,
	[MaNhanVien] [varchar](50) NULL,
	[NgayTao] [date] NULL,
	[TongTien] [money] NULL,
 CONSTRAINT [PK_PhieuCungCap] PRIMARY KEY CLUSTERED 
(
	[MaCungCap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 8/14/2020 3:12:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[HinhAnh] [varchar](50) NULL,
	[MaSanPham] [varchar](50) NOT NULL,
	[TenSanPham] [nvarchar](100) NULL,
	[Gia] [float] NULL,
	[MoTa] [nvarchar](500) NULL,
	[TinhTrang] [bit] NULL,
	[Nhom] [varchar](50) NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[MaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong], [ThanhTien]) VALUES (N'2020813HD300', N'20200813SP1021', 1, 32000.0000)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong], [ThanhTien]) VALUES (N'2020813HD351', N'20200813SP1021', 1, 32000.0000)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong], [ThanhTien]) VALUES (N'2020813HD395', N'20200813SP1021', 1, 32000.0000)
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong], [ThanhTien]) VALUES (N'2020813HD395', N'20200813SP1106', 1, 39000.0000)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaNhanVien], [MaKhachHang], [NgayBan], [TongTien]) VALUES (N'2020813HD300', N'20200813NV2037', NULL, CAST(N'2020-08-13' AS Date), 32000.0000)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaNhanVien], [MaKhachHang], [NgayBan], [TongTien]) VALUES (N'2020813HD351', N'20200813NV2037', NULL, CAST(N'2020-08-13' AS Date), 32000.0000)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaNhanVien], [MaKhachHang], [NgayBan], [TongTien]) VALUES (N'2020813HD395', N'20200813NV2037', N'20200813KH2341', CAST(N'2020-08-13' AS Date), 71000.0000)
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [SDT], [GioiTinh], [Email], [CMND], [DiaChi], [LoaiKhachHang], [Diem]) VALUES (N'20200813KH2314', N'Hoàng Thái Thanh Nhàn', N'0975741356', 0, N'thanhnhanht@gmail.com', N'097574135', N'24 Hồ Huấn Nghiệp, Phường Bến Nghé, Quận 1', N'CAP1', 0)
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [SDT], [GioiTinh], [Email], [CMND], [DiaChi], [LoaiKhachHang], [Diem]) VALUES (N'20200813KH2341', N'Thái Hữu Nhân', N'0975743444', 1, N'nhanth@gmail.com', N'025847332', N'150 Đường số 5, Phường 4, Quận 8', N'CAP1', 0)
INSERT [dbo].[LoaiKhachHang] ([MaLoai], [TenLoai], [DiemTichLuy]) VALUES (N'CAP1', N'Thành viên mới', 0)
INSERT [dbo].[LoaiKhachHang] ([MaLoai], [TenLoai], [DiemTichLuy]) VALUES (N'CAP2', N'Đồng', 100)
INSERT [dbo].[LoaiKhachHang] ([MaLoai], [TenLoai], [DiemTichLuy]) VALUES (N'CAP3', N'Bạc', 200)
INSERT [dbo].[LoaiKhachHang] ([MaLoai], [TenLoai], [DiemTichLuy]) VALUES (N'CAP4', N'Vàng', 300)
INSERT [dbo].[LoaiNhanVien] ([MaLoaiNV], [TenLoai], [LuongCoBan]) VALUES (N'1', N'Quản lý cửa hàng', 50000)
INSERT [dbo].[LoaiNhanVien] ([MaLoaiNV], [TenLoai], [LuongCoBan]) VALUES (N'2', N'Bộ phận bán hàng', 30000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [SDT], [GioiTinh], [NgaySinh], [Email], [CMND], [DiaChi], [NgayVaoLam], [MatKhau], [TinhTrang], [TongGioLam], [Luong], [LoaiNhanVien]) VALUES (N'20200813NV2037', N'Hoàng Thái Thanh Nhàn', N'0975741463', 0, CAST(N'1999-09-21' AS Date), N'thanhnhanht219@gmail.com', N'025847330', N'140 Lê Trọng Tấn, Phường Tây Thạnh, Quận Tân Phú', CAST(N'2020-08-13' AS Date), N'112233', 1, 0, 0, N'1')
INSERT [dbo].[NhomSanPham] ([MaNhomSP], [TenNhom]) VALUES (N'N1', N'Macchiato')
INSERT [dbo].[NhomSanPham] ([MaNhomSP], [TenNhom]) VALUES (N'N2', N'Đá xay')
INSERT [dbo].[NhomSanPham] ([MaNhomSP], [TenNhom]) VALUES (N'N3', N'Trà')
INSERT [dbo].[NhomSanPham] ([MaNhomSP], [TenNhom]) VALUES (N'N4', N'Coffee')
INSERT [dbo].[SanPham] ([HinhAnh], [MaSanPham], [TenSanPham], [Gia], [MoTa], [TinhTrang], [Nhom]) VALUES (N'bacsiu.png', N'20200813SP1021', N'Bạc xỉu', 32000, N'-', 1, N'N4')
INSERT [dbo].[SanPham] ([HinhAnh], [MaSanPham], [TenSanPham], [Gia], [MoTa], [TinhTrang], [Nhom]) VALUES (N'americano.png', N'20200813SP1106', N'Americano ', 39000, N'-', 1, N'N4')
INSERT [dbo].[SanPham] ([HinhAnh], [MaSanPham], [TenSanPham], [Gia], [MoTa], [TinhTrang], [Nhom]) VALUES (N'cafedaxay.png', N'20200814SP0108', N'Cà phê đá xay', 38000, N'-', 1, N'N2')
INSERT [dbo].[SanPham] ([HinhAnh], [MaSanPham], [TenSanPham], [Gia], [MoTa], [TinhTrang], [Nhom]) VALUES (N'caramelmacchiato.png', N'20200814SP0113', N'Caramel Macchiato', 40000, N'-', 1, N'N1')
INSERT [dbo].[SanPham] ([HinhAnh], [MaSanPham], [TenSanPham], [Gia], [MoTa], [TinhTrang], [Nhom]) VALUES (N'cappuccino.png', N'20200814SP0114', N'Cappuccino', 42000, N'-', 1, N'N4')
INSERT [dbo].[SanPham] ([HinhAnh], [MaSanPham], [TenSanPham], [Gia], [MoTa], [TinhTrang], [Nhom]) VALUES (N'espressonong.png', N'20200814SP0128', N'Espresso Nóng', 40000, N'-', 1, N'N4')
INSERT [dbo].[SanPham] ([HinhAnh], [MaSanPham], [TenSanPham], [Gia], [MoTa], [TinhTrang], [Nhom]) VALUES (N'campbtdaxay.png', N'20200814SP0130', N'Phúc Bồn Tử Đá Xay', 50000, N'-', 1, N'N2')
INSERT [dbo].[SanPham] ([HinhAnh], [MaSanPham], [TenSanPham], [Gia], [MoTa], [TinhTrang], [Nhom]) VALUES (N'tralaimacchiato.png', N'20200814SP0142', N'Tra Lai Macchiato', 48000, N'', 1, N'N1')
INSERT [dbo].[SanPham] ([HinhAnh], [MaSanPham], [TenSanPham], [Gia], [MoTa], [TinhTrang], [Nhom]) VALUES (N'travai.png', N'20200814SP0149', N'Trà Vải', 32000, N'', 1, N'N3')
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_HoaDon] FOREIGN KEY([MaHoaDon])
REFERENCES [dbo].[HoaDon] ([MaHoaDon])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_HoaDon]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_SanPham] FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([MaSanPham])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_SanPham]
GO
ALTER TABLE [dbo].[ChiTietPhieuCungCap]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuCungCap_NguyenLieu] FOREIGN KEY([MaNguyenLieu])
REFERENCES [dbo].[NguyenLieu] ([MaNguyenLieu])
GO
ALTER TABLE [dbo].[ChiTietPhieuCungCap] CHECK CONSTRAINT [FK_ChiTietPhieuCungCap_NguyenLieu]
GO
ALTER TABLE [dbo].[ChiTietPhieuCungCap]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuCungCap_PhieuCungCap] FOREIGN KEY([MaCungCap])
REFERENCES [dbo].[PhieuCungCap] ([MaCungCap])
GO
ALTER TABLE [dbo].[ChiTietPhieuCungCap] CHECK CONSTRAINT [FK_ChiTietPhieuCungCap_PhieuCungCap]
GO
ALTER TABLE [dbo].[CongThucSanPham]  WITH CHECK ADD  CONSTRAINT [FK_CongThucSanPham_NguyenLieu] FOREIGN KEY([MaNguyenLieu])
REFERENCES [dbo].[NguyenLieu] ([MaNguyenLieu])
GO
ALTER TABLE [dbo].[CongThucSanPham] CHECK CONSTRAINT [FK_CongThucSanPham_NguyenLieu]
GO
ALTER TABLE [dbo].[CongThucSanPham]  WITH CHECK ADD  CONSTRAINT [FK_CongThucSanPham_SanPham] FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([MaSanPham])
GO
ALTER TABLE [dbo].[CongThucSanPham] CHECK CONSTRAINT [FK_CongThucSanPham_SanPham]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_KhachHang] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([MaKhachHang])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_KhachHang]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_NhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_NhanVien]
GO
ALTER TABLE [dbo].[KhachHang]  WITH CHECK ADD  CONSTRAINT [FK_KhachHang_LoaiKhachHang] FOREIGN KEY([LoaiKhachHang])
REFERENCES [dbo].[LoaiKhachHang] ([MaLoai])
GO
ALTER TABLE [dbo].[KhachHang] CHECK CONSTRAINT [FK_KhachHang_LoaiKhachHang]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_LoaiNhanVien] FOREIGN KEY([LoaiNhanVien])
REFERENCES [dbo].[LoaiNhanVien] ([MaLoaiNV])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_LoaiNhanVien]
GO
ALTER TABLE [dbo].[PhieuCungCap]  WITH CHECK ADD  CONSTRAINT [FK_PhieuCungCap_NhaCungCap] FOREIGN KEY([MaNhaCungCap])
REFERENCES [dbo].[NhaCungCap] ([MaNhaCungCap])
GO
ALTER TABLE [dbo].[PhieuCungCap] CHECK CONSTRAINT [FK_PhieuCungCap_NhaCungCap]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_NhomSanPham] FOREIGN KEY([Nhom])
REFERENCES [dbo].[NhomSanPham] ([MaNhomSP])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_NhomSanPham]
GO
USE [master]
GO
ALTER DATABASE [DAMH_PTPM] SET  READ_WRITE 
GO
