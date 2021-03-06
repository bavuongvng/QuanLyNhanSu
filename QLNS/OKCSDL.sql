USE [master]
GO
/****** Object:  Database [QUANLYNHANSU]    Script Date: 08-Jun-18 6:40:30 PM ******/
CREATE DATABASE [QUANLYNHANSU]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QUANLYNHANSU', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\QUANLYNHANSU.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QUANLYNHANSU_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\QUANLYNHANSU_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [QUANLYNHANSU] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QUANLYNHANSU].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QUANLYNHANSU] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QUANLYNHANSU] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QUANLYNHANSU] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QUANLYNHANSU] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QUANLYNHANSU] SET ARITHABORT OFF 
GO
ALTER DATABASE [QUANLYNHANSU] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QUANLYNHANSU] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QUANLYNHANSU] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QUANLYNHANSU] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QUANLYNHANSU] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QUANLYNHANSU] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QUANLYNHANSU] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QUANLYNHANSU] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QUANLYNHANSU] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QUANLYNHANSU] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QUANLYNHANSU] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QUANLYNHANSU] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QUANLYNHANSU] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QUANLYNHANSU] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QUANLYNHANSU] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QUANLYNHANSU] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QUANLYNHANSU] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QUANLYNHANSU] SET RECOVERY FULL 
GO
ALTER DATABASE [QUANLYNHANSU] SET  MULTI_USER 
GO
ALTER DATABASE [QUANLYNHANSU] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QUANLYNHANSU] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QUANLYNHANSU] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QUANLYNHANSU] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QUANLYNHANSU] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'QUANLYNHANSU', N'ON'
GO
ALTER DATABASE [QUANLYNHANSU] SET QUERY_STORE = OFF
GO
USE [QUANLYNHANSU]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [QUANLYNHANSU]
GO
/****** Object:  Table [dbo].[HoSo]    Script Date: 08-Jun-18 6:40:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoSo](
	[MaNhanVien] [int] IDENTITY(1,1) NOT NULL,
	[HoDem] [nvarchar](15) NOT NULL,
	[TenDem] [nvarchar](10) NOT NULL,
	[NgaySinh] [datetime] NOT NULL,
	[GioiTinh] [nvarchar](10) NOT NULL,
	[SoDienThoai] [nvarchar](12) NOT NULL,
	[Email] [nvarchar](25) NOT NULL,
	[NgayTuyenDung] [datetime] NOT NULL,
	[MaPhongBan] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrinhDoNgoaiNgu]    Script Date: 08-Jun-18 6:40:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrinhDoNgoaiNgu](
	[MaNhanVien] [int] NOT NULL,
	[NgoaiNgu] [nvarchar](25) NOT NULL,
	[TrinhDo] [nvarchar](25) NOT NULL,
 CONSTRAINT [pk_TrinhDoNgoaiNgu] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC,
	[NgoaiNgu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[View_ThongKeTrinhDoNgoaiNgu]    Script Date: 08-Jun-18 6:40:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_ThongKeTrinhDoNgoaiNgu]
AS
SELECT        dbo.HoSo.MaNhanVien, trim({ fn CONCAT(dbo.HoSo.HoDem + ' ', dbo.HoSo.TenDem) }) AS 'TenNhanVien', dbo.TrinhDoNgoaiNgu.NgoaiNgu, dbo.TrinhDoNgoaiNgu.TrinhDo
FROM            dbo.TrinhDoNgoaiNgu INNER JOIN
                         dbo.HoSo ON dbo.TrinhDoNgoaiNgu.MaNhanVien = dbo.HoSo.MaNhanVien
GO
/****** Object:  Table [dbo].[QuaTrinhCongTac]    Script Date: 08-Jun-18 6:40:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuaTrinhCongTac](
	[MaNhanVien] [int] NOT NULL,
	[TuNgay] [datetime] NOT NULL,
	[DenNgay] [datetime] NOT NULL,
	[NoiCongTac] [nvarchar](25) NOT NULL,
	[ChucVu] [nvarchar](25) NOT NULL,
 CONSTRAINT [pk_QuaTrinhCongTac] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC,
	[TuNgay] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrinhDoChuyenMon]    Script Date: 08-Jun-18 6:40:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrinhDoChuyenMon](
	[MaNhanVien] [int] NOT NULL,
	[Nganh] [nvarchar](25) NOT NULL,
	[TrinhDo] [nvarchar](25) NOT NULL,
	[LoaiHinhDaoTao] [nvarchar](25) NOT NULL,
	[TruongDaoTao] [nvarchar](25) NOT NULL,
 CONSTRAINT [pk_TrinhDoChuyenMon] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC,
	[Nganh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[V_HOSONV]    Script Date: 08-Jun-18 6:40:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_HOSONV]
as
	select h.MaNhanVien, (h.HoDem + ' ' + h.TenDem) as 'HoTen',h.NgaySinh,h.GioiTinh,h.SoDienThoai,h.Email,h.NgayTuyenDung,h.MaPhongBan,
	cm.Nganh,cm.TrinhDo,cm.LoaiHinhDaoTao,cm.TruongDaoTao,
	nn.NgoaiNgu,nn.TrinhDo as 'TrinhdoNN',
	ct.TuNgay,ct.DenNgay,ct.NoiCongTac,ct.ChucVu
	from ((HoSo h inner join TrinhDoChuyenMon cm
		on h.MaNhanVien = cm.MaNhanVien)inner join TrinhDoNgoaiNgu nn
		on h.MaNhanVien = nn.MaNhanVien)inner join QuaTrinhCongTac ct
		on h.MaNhanVien = ct.MaNhanVien 
GO
/****** Object:  View [dbo].[View_ThongKeTrinhDoCM]    Script Date: 08-Jun-18 6:40:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_ThongKeTrinhDoCM]
AS
SELECT        dbo.HoSo.MaNhanVien, { fn CONCAT(dbo.HoSo.HoDem + ' ', dbo.HoSo.TenDem) } AS 'HoTen', dbo.TrinhDoChuyenMon.TrinhDo, dbo.TrinhDoChuyenMon.LoaiHinhDaoTao, dbo.TrinhDoChuyenMon.TruongDaoTao
FROM            dbo.HoSo INNER JOIN
                         dbo.TrinhDoChuyenMon ON dbo.HoSo.MaNhanVien = dbo.TrinhDoChuyenMon.MaNhanVien
GO
/****** Object:  View [dbo].[Demo]    Script Date: 08-Jun-18 6:40:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[Demo]
as
	select hoso.MaNhanVien,HoSo.TenDem,TrinhDoChuyenMon.TrinhDo from HoSo inner join TrinhDoChuyenMon on HoSo.MaNhanVien=TrinhDoChuyenMon.MaNhanVien
GO
/****** Object:  View [dbo].[Test]    Script Date: 08-Jun-18 6:40:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Test]
AS
SELECT        dbo.TrinhDoChuyenMon.MaNhanVien, dbo.HoSo.HoDem, dbo.HoSo.TenDem, dbo.TrinhDoChuyenMon.TrinhDo, dbo.TrinhDoChuyenMon.LoaiHinhDaoTao, dbo.TrinhDoChuyenMon.TruongDaoTao
FROM            dbo.TrinhDoChuyenMon INNER JOIN
                         dbo.HoSo ON dbo.TrinhDoChuyenMon.MaNhanVien = dbo.HoSo.MaNhanVien
GO
/****** Object:  View [dbo].[View_InTrinhDoCM]    Script Date: 08-Jun-18 6:40:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_InTrinhDoCM]
AS
SELECT        dbo.TrinhDoChuyenMon.MaNhanVien, { fn CONCAT(dbo.HoSo.HoDem + ' ', dbo.HoSo.TenDem) } AS 'HoVaTen', dbo.TrinhDoChuyenMon.TrinhDo, dbo.TrinhDoChuyenMon.LoaiHinhDaoTao, 
                         dbo.TrinhDoChuyenMon.TruongDaoTao
FROM            dbo.HoSo INNER JOIN
                         dbo.TrinhDoChuyenMon ON dbo.HoSo.MaNhanVien = dbo.TrinhDoChuyenMon.MaNhanVien
GO
/****** Object:  Table [dbo].[ChucVu]    Script Date: 08-Jun-18 6:40:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChucVu](
	[MaChucVu] [int] IDENTITY(1,1) NOT NULL,
	[TenChucVu] [nvarchar](15) NOT NULL,
	[HeSoPhuCap] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaChucVu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien_ChucVu]    Script Date: 08-Jun-18 6:40:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien_ChucVu](
	[MaNhanVien] [int] NOT NULL,
	[MaChucVu] [int] NOT NULL,
	[TuNgay] [datetime] NOT NULL,
	[DenNgay] [datetime] NOT NULL,
 CONSTRAINT [pk_NhanVienChucVu] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC,
	[MaChucVu] ASC,
	[TuNgay] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhongBan]    Script Date: 08-Jun-18 6:40:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhongBan](
	[MaPhongBan] [int] IDENTITY(1,1) NOT NULL,
	[TenPhongBan] [nvarchar](25) NOT NULL,
	[NgayLap] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhongBan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ChucVu] ON 

INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [HeSoPhuCap]) VALUES (1, N'Giám đốc', 1)
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [HeSoPhuCap]) VALUES (2, N'Phó giám đốc', 0.8)
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [HeSoPhuCap]) VALUES (3, N'Kế toán trưởng', 0.5)
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [HeSoPhuCap]) VALUES (4, N'Kế toán viên', 0.4)
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [HeSoPhuCap]) VALUES (5, N'Bảo vệ', 0.3)
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [HeSoPhuCap]) VALUES (6, N'Trưởng phòng', 0.6)
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [HeSoPhuCap]) VALUES (7, N'Phó phòng', 0.5)
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [HeSoPhuCap]) VALUES (8, N'Quản lý ', 0.5)
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [HeSoPhuCap]) VALUES (9, N'Lao công', 0.2)
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [HeSoPhuCap]) VALUES (10, N'Quản trị dự án ', 0.7)
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [HeSoPhuCap]) VALUES (11, N'Lập trình viên', 0.5)
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [HeSoPhuCap]) VALUES (12, N'Tester', 0.5)
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [HeSoPhuCap]) VALUES (18, N'QA', 0.6)
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [HeSoPhuCap]) VALUES (19, N'Nhân viên', 0.4)
SET IDENTITY_INSERT [dbo].[ChucVu] OFF
SET IDENTITY_INSERT [dbo].[HoSo] ON 

INSERT [dbo].[HoSo] ([MaNhanVien], [HoDem], [TenDem], [NgaySinh], [GioiTinh], [SoDienThoai], [Email], [NgayTuyenDung], [MaPhongBan]) VALUES (10, N'Nguyễn Văn ', N'An', CAST(N'1992-02-12T00:00:00.000' AS DateTime), N'Nam', N'0985738794', N'nguyenvana@gmail.com', CAST(N'2015-02-12T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[HoSo] ([MaNhanVien], [HoDem], [TenDem], [NgaySinh], [GioiTinh], [SoDienThoai], [Email], [NgayTuyenDung], [MaPhongBan]) VALUES (11, N'Trần Vân', N'Anh', CAST(N'1995-10-18T00:00:00.000' AS DateTime), N'Nữ', N'0876345907', N'tranvananh@mail.com', CAST(N'2017-08-07T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[HoSo] ([MaNhanVien], [HoDem], [TenDem], [NgaySinh], [GioiTinh], [SoDienThoai], [Email], [NgayTuyenDung], [MaPhongBan]) VALUES (13, N'Lê Nguyệt', N'Ánh', CAST(N'1996-09-24T00:00:00.000' AS DateTime), N'Nữ', N'0162863758', N'lenguyetanh@gmail.com', CAST(N'2018-02-01T00:00:00.000' AS DateTime), 3)
INSERT [dbo].[HoSo] ([MaNhanVien], [HoDem], [TenDem], [NgaySinh], [GioiTinh], [SoDienThoai], [Email], [NgayTuyenDung], [MaPhongBan]) VALUES (17, N'Đỗ Xuân', N'Bắc', CAST(N'1989-11-20T00:00:00.000' AS DateTime), N'Nam', N'0123456789', N'doxuanbac@mail.com', CAST(N'2013-11-25T00:00:00.000' AS DateTime), 4)
INSERT [dbo].[HoSo] ([MaNhanVien], [HoDem], [TenDem], [NgaySinh], [GioiTinh], [SoDienThoai], [Email], [NgayTuyenDung], [MaPhongBan]) VALUES (18, N'Nguyễn Nam', N'Anh', CAST(N'1995-05-19T00:00:00.000' AS DateTime), N'Nam', N'01234567890', N'nguyennamanh@mail.com', CAST(N'2018-06-06T00:00:00.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[HoSo] OFF
INSERT [dbo].[NhanVien_ChucVu] ([MaNhanVien], [MaChucVu], [TuNgay], [DenNgay]) VALUES (10, 4, CAST(N'2015-02-12T00:00:00.000' AS DateTime), CAST(N'2016-07-25T00:00:00.000' AS DateTime))
INSERT [dbo].[NhanVien_ChucVu] ([MaNhanVien], [MaChucVu], [TuNgay], [DenNgay]) VALUES (11, 18, CAST(N'2017-08-07T00:00:00.000' AS DateTime), CAST(N'2018-01-02T00:00:00.000' AS DateTime))
INSERT [dbo].[NhanVien_ChucVu] ([MaNhanVien], [MaChucVu], [TuNgay], [DenNgay]) VALUES (13, 19, CAST(N'2018-02-01T00:00:00.000' AS DateTime), CAST(N'2018-04-05T00:00:00.000' AS DateTime))
INSERT [dbo].[NhanVien_ChucVu] ([MaNhanVien], [MaChucVu], [TuNgay], [DenNgay]) VALUES (17, 10, CAST(N'2016-11-26T00:00:00.000' AS DateTime), CAST(N'2018-02-05T00:00:00.000' AS DateTime))
INSERT [dbo].[NhanVien_ChucVu] ([MaNhanVien], [MaChucVu], [TuNgay], [DenNgay]) VALUES (17, 11, CAST(N'2013-11-25T00:00:00.000' AS DateTime), CAST(N'2016-11-25T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[PhongBan] ON 

INSERT [dbo].[PhongBan] ([MaPhongBan], [TenPhongBan], [NgayLap]) VALUES (1, N'Phòng kế toán', CAST(N'2012-02-02T00:00:00.000' AS DateTime))
INSERT [dbo].[PhongBan] ([MaPhongBan], [TenPhongBan], [NgayLap]) VALUES (2, N'Phòng kế hoạch', CAST(N'2013-05-05T00:00:00.000' AS DateTime))
INSERT [dbo].[PhongBan] ([MaPhongBan], [TenPhongBan], [NgayLap]) VALUES (3, N'Phòng nhân sự', CAST(N'2012-05-18T00:00:00.000' AS DateTime))
INSERT [dbo].[PhongBan] ([MaPhongBan], [TenPhongBan], [NgayLap]) VALUES (4, N'Phòng phát triển sản phẩm', CAST(N'2012-12-12T00:00:00.000' AS DateTime))
INSERT [dbo].[PhongBan] ([MaPhongBan], [TenPhongBan], [NgayLap]) VALUES (5, N'Ban giám đốc', CAST(N'2012-03-21T00:00:00.000' AS DateTime))
INSERT [dbo].[PhongBan] ([MaPhongBan], [TenPhongBan], [NgayLap]) VALUES (6, N'Phòng bảo vệ', CAST(N'2015-01-05T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[PhongBan] OFF
INSERT [dbo].[QuaTrinhCongTac] ([MaNhanVien], [TuNgay], [DenNgay], [NoiCongTac], [ChucVu]) VALUES (10, CAST(N'2015-02-12T00:00:00.000' AS DateTime), CAST(N'2016-07-25T00:00:00.000' AS DateTime), N'FPT software', N'Kế toán viên')
INSERT [dbo].[QuaTrinhCongTac] ([MaNhanVien], [TuNgay], [DenNgay], [NoiCongTac], [ChucVu]) VALUES (11, CAST(N'2017-08-07T00:00:00.000' AS DateTime), CAST(N'2018-01-02T00:00:00.000' AS DateTime), N'FPT IS', N'Quality Assurance')
INSERT [dbo].[QuaTrinhCongTac] ([MaNhanVien], [TuNgay], [DenNgay], [NoiCongTac], [ChucVu]) VALUES (13, CAST(N'2018-02-01T00:00:00.000' AS DateTime), CAST(N'2018-04-05T00:00:00.000' AS DateTime), N'FPT Telecom', N'Tuyển dụng')
INSERT [dbo].[QuaTrinhCongTac] ([MaNhanVien], [TuNgay], [DenNgay], [NoiCongTac], [ChucVu]) VALUES (17, CAST(N'2013-11-25T00:00:00.000' AS DateTime), CAST(N'2016-11-25T00:00:00.000' AS DateTime), N'FPT Software', N'Deverloper')
INSERT [dbo].[QuaTrinhCongTac] ([MaNhanVien], [TuNgay], [DenNgay], [NoiCongTac], [ChucVu]) VALUES (17, CAST(N'2016-11-26T00:00:00.000' AS DateTime), CAST(N'2018-02-05T00:00:00.000' AS DateTime), N'FPT IS', N'Project Manager ')
INSERT [dbo].[TrinhDoChuyenMon] ([MaNhanVien], [Nganh], [TrinhDo], [LoaiHinhDaoTao], [TruongDaoTao]) VALUES (10, N'aaaa', N'Cao đẳng', N'Chính quy', N'aaaaaaa')
INSERT [dbo].[TrinhDoChuyenMon] ([MaNhanVien], [Nganh], [TrinhDo], [LoaiHinhDaoTao], [TruongDaoTao]) VALUES (10, N'Công nghệ may', N'Thạc sĩ', N'Vừa học vừa làm', N'Đại học Bách Khoa Hà Nội')
INSERT [dbo].[TrinhDoChuyenMon] ([MaNhanVien], [Nganh], [TrinhDo], [LoaiHinhDaoTao], [TruongDaoTao]) VALUES (10, N'Kế toán', N'Đại học', N'Chính quy', N'Học viên tài chính')
INSERT [dbo].[TrinhDoChuyenMon] ([MaNhanVien], [Nganh], [TrinhDo], [LoaiHinhDaoTao], [TruongDaoTao]) VALUES (11, N'Công nghệ thông tin', N'Thạc sĩ', N'Vừa học vừa làm', N'Đại học FPT')
INSERT [dbo].[TrinhDoChuyenMon] ([MaNhanVien], [Nganh], [TrinhDo], [LoaiHinhDaoTao], [TruongDaoTao]) VALUES (11, N'Tự động hóa', N'Cao đẳng', N'Chính quy', N'Đại học bách khoa Hà Nội')
INSERT [dbo].[TrinhDoChuyenMon] ([MaNhanVien], [Nganh], [TrinhDo], [LoaiHinhDaoTao], [TruongDaoTao]) VALUES (13, N'Quản trị nhân lực', N'Tiến sĩ', N'Liên thông', N'Đại học ngoại thương')
INSERT [dbo].[TrinhDoChuyenMon] ([MaNhanVien], [Nganh], [TrinhDo], [LoaiHinhDaoTao], [TruongDaoTao]) VALUES (17, N'Công nghệ thông tin', N'Cao đẳng', N'Chính quy', N'Đại học công nghiệp ')
INSERT [dbo].[TrinhDoNgoaiNgu] ([MaNhanVien], [NgoaiNgu], [TrinhDo]) VALUES (10, N'Tiếng Anh', N'IELTS 7.0')
INSERT [dbo].[TrinhDoNgoaiNgu] ([MaNhanVien], [NgoaiNgu], [TrinhDo]) VALUES (11, N'Tiếng Anh', N'B2')
INSERT [dbo].[TrinhDoNgoaiNgu] ([MaNhanVien], [NgoaiNgu], [TrinhDo]) VALUES (11, N'Tiếng Nhật', N'N2')
INSERT [dbo].[TrinhDoNgoaiNgu] ([MaNhanVien], [NgoaiNgu], [TrinhDo]) VALUES (13, N'Tiếng Anh', N'TOEIC 820')
INSERT [dbo].[TrinhDoNgoaiNgu] ([MaNhanVien], [NgoaiNgu], [TrinhDo]) VALUES (17, N'Tiếng Trung', N'B1')
ALTER TABLE [dbo].[HoSo]  WITH CHECK ADD  CONSTRAINT [fk_HoSo_PhongBan] FOREIGN KEY([MaPhongBan])
REFERENCES [dbo].[PhongBan] ([MaPhongBan])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HoSo] CHECK CONSTRAINT [fk_HoSo_PhongBan]
GO
ALTER TABLE [dbo].[NhanVien_ChucVu]  WITH CHECK ADD  CONSTRAINT [fk_NhanVienChucVu_ChucVu] FOREIGN KEY([MaChucVu])
REFERENCES [dbo].[ChucVu] ([MaChucVu])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NhanVien_ChucVu] CHECK CONSTRAINT [fk_NhanVienChucVu_ChucVu]
GO
ALTER TABLE [dbo].[NhanVien_ChucVu]  WITH CHECK ADD  CONSTRAINT [fk_NhanVienChucVu_HoSo] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[HoSo] ([MaNhanVien])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NhanVien_ChucVu] CHECK CONSTRAINT [fk_NhanVienChucVu_HoSo]
GO
ALTER TABLE [dbo].[QuaTrinhCongTac]  WITH CHECK ADD  CONSTRAINT [fk_pk_QuaTrinhCongTac_HoSo] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[HoSo] ([MaNhanVien])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[QuaTrinhCongTac] CHECK CONSTRAINT [fk_pk_QuaTrinhCongTac_HoSo]
GO
ALTER TABLE [dbo].[TrinhDoChuyenMon]  WITH CHECK ADD  CONSTRAINT [fk_TrinhDoChuyenMon_HoSo] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[HoSo] ([MaNhanVien])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TrinhDoChuyenMon] CHECK CONSTRAINT [fk_TrinhDoChuyenMon_HoSo]
GO
ALTER TABLE [dbo].[TrinhDoNgoaiNgu]  WITH CHECK ADD  CONSTRAINT [fk_TrinhDoNgoaiNgu_HoSo] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[HoSo] ([MaNhanVien])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TrinhDoNgoaiNgu] CHECK CONSTRAINT [fk_TrinhDoNgoaiNgu_HoSo]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TrinhDoChuyenMon"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 216
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "HoSo"
            Begin Extent = 
               Top = 11
               Left = 514
               Bottom = 141
               Right = 693
            End
            DisplayFlags = 280
            TopColumn = 2
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Test'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Test'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[34] 4[4] 2[36] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "HoSo"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 217
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TrinhDoChuyenMon"
            Begin Extent = 
               Top = 16
               Left = 464
               Bottom = 146
               Right = 642
            End
            DisplayFlags = 280
            TopColumn = 1
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_InTrinhDoCM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_InTrinhDoCM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[27] 4[15] 2[28] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "HoSo"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 217
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TrinhDoChuyenMon"
            Begin Extent = 
               Top = 6
               Left = 255
               Bottom = 136
               Right = 433
            End
            DisplayFlags = 280
            TopColumn = 1
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_ThongKeTrinhDoCM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_ThongKeTrinhDoCM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[20] 2[17] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TrinhDoNgoaiNgu"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 119
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "HoSo"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 425
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 2565
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_ThongKeTrinhDoNgoaiNgu'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_ThongKeTrinhDoNgoaiNgu'
GO
USE [master]
GO
ALTER DATABASE [QUANLYNHANSU] SET  READ_WRITE 
GO
