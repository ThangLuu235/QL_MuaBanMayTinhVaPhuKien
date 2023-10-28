create database QL_CHMayTinh
go
use QL_CHMayTinh
go
-- Tạo bảng Danh mục sản phẩm
CREATE TABLE DanhMucSanPham (
    MaDM NVARCHAR(50) PRIMARY KEY NOT NULL,
    TenDanhMuc NVARCHAR(255)
);

-- Tạo bảng thông số kỹ thuật
CREATE TABLE ThongSoSanPham (
	MaThongSo NVARCHAR(50) PRIMARY KEY NOT NULL,
	CPU NVARCHAR(255),
	ManHinh NVARCHAR(255),
	Ram NVARCHAR(255),
	DoHoa NVARCHAR(50),
	LuuTru NVARCHAR(50),
	HeDieuHanh NVARCHAR(50),
	Pin NVARCHAR(50),
	KhoiLuong NVARCHAR(50),
	Mau NVARCHAR(50),
	SoSeri NVARCHAR(50),
	SoLuongTon INT
);

-- Tạo bảng Nhà sản xuất
CREATE TABLE NhaSanXuat (
    MaNSX NVARCHAR(50) PRIMARY KEY NOT NULL,
    TenNhaSanXuat NVARCHAR(255),
    DiaChi NVARCHAR(255),
    DienThoai NVARCHAR(20)
);

-- Tạo bảng Sản phẩm
CREATE TABLE SanPham (
    MaSP NVARCHAR(50) PRIMARY KEY NOT NULL,
    TenSanPham NVARCHAR(255),
    MaNSX NVARCHAR(50),
    MaDM NVARCHAR(50),
    MoTa NVARCHAR(150),
    Gia DECIMAL(10, 2),
    SoLuongTrongKho INT,
	HinhAnh nvarchar(50),
	MaThongSo NVARCHAR(50)
);

-- Tạo bảng Chức vụ
CREATE TABLE ChucVu (
    MaChucVu NVARCHAR(50) PRIMARY KEY NOT NULL,
    TenChucVu NVARCHAR(255)
);

-- Tạo bảng Nhân viên
CREATE TABLE NhanVien (
    MaNV NVARCHAR(50) PRIMARY KEY NOT NULL,
    HoTen NVARCHAR(255),
    DiaChi NVARCHAR(255),
    DienThoai NVARCHAR(20),
    Email NVARCHAR(255),
	MatKhau NVARCHAR(50),
    MaChucVu NVARCHAR(50)
);

-- Tạo bảng KhachHang
CREATE TABLE KhachHang (
    MaKH NVARCHAR(50) PRIMARY KEY NOT NULL,
    TenKhachHang NVARCHAR(255),
	GioiTinh NVARCHAR(50),
	NgaySinh DATE,
    DiaChi NVARCHAR(255),
    DienThoai NVARCHAR(20),
    Email NVARCHAR(255)
);

-- Tạo bảng Hóa đơn
CREATE TABLE HoaDon (
    MaHD NVARCHAR(50) PRIMARY KEY NOT NULL,
    NgayMua DATE,
    MaKH NVARCHAR(50),
    TongTien DECIMAL(10, 2),
    TinhTrangThanhToan NVARCHAR(50),
	NgayThanhToan DATE,
	NgayNhanHang DATE
);

-- Tạo bảng Chi tiết hóa đơn
CREATE TABLE ChiTietHoaDon (
    MaCTHD NVARCHAR(50) PRIMARY KEY NOT NULL,
    MaHD NVARCHAR(50),
    MaSP NVARCHAR(50),
    SoLuong INT,
    GiaBan DECIMAL(10, 2)
);

-- Tạo bảng Đơn hàng
CREATE TABLE DonHang (
    MaDH NVARCHAR(50) PRIMARY KEY NOT NULL,
    NgayDatHang DATE,
    MaKhachHang NVARCHAR(50)
);

-- Tạo bảng Chi tiết đơn hàng
CREATE TABLE ChiTietDonHang (
    MaCTDH NVARCHAR(50) PRIMARY KEY NOT NULL,
    MaDH NVARCHAR(50),
    MaSP NVARCHAR(50),
    SoLuong INT,
    GiaBan DECIMAL(10, 2)
);

-- Tạo bảng Nhà cung cấp
CREATE TABLE NhaCungCap (
    MaNCC NVARCHAR(50) PRIMARY KEY NOT NULL,
    TenNhaCungCap NVARCHAR(255),
    DiaChi NVARCHAR(255),
    DienThoai NVARCHAR(20)
);

-- Tạo bảng Cung ứng
CREATE TABLE CungUng (
	MaCungUng NVARCHAR(50) PRIMARY KEY NOT NULL,
	MaNCC NVARCHAR(50),
	MaSP NVARCHAR(50),
	SoLuong INT,
	GiaBan DECIMAL(10, 2),
	NgayDatHang DATE,
	NgayGiaoHang DATE
);

-- Tạo bảng Đơn đặt hàng
CREATE TABLE DonDatHang (
    MaDDH NVARCHAR(50) PRIMARY KEY NOT NULL,
    NgayDatHang DATE,
    MaNhaCungCap NVARCHAR(50)
);

-- Tạo bảng Chi tiết đơn đặt hàng
CREATE TABLE ChiTietDonDatHang (
    MaCTDDH NVARCHAR(50) PRIMARY KEY NOT NULL,
    MaDDH NVARCHAR(50),
    MaSP NVARCHAR(50),
    SoLuongDat INT,
    GiaDat DECIMAL(10, 2)
);

-- Tạo bảng Phiếu bảo hành
CREATE TABLE PhieuBaoHanh (
    MaPBH NVARCHAR(50) PRIMARY KEY NOT NULL,
    NgayYeuCau DATE,
    MaSP NVARCHAR(50),
    MoTaLoi NVARCHAR(150),
    TinhTrangXuLy NVARCHAR(50)
);

-- Tạo bảng Giỏ hàng
CREATE TABLE GioHang (
    MaGH NVARCHAR(50) PRIMARY KEY NOT NULL,
    MaKH NVARCHAR(50),
    ThoiGianThemVaoGio DATETIME
);

-- Tạo bảng Chi tiết giỏ hàng
CREATE TABLE ChiTietGioHang (
    MaCTGH NVARCHAR(50) PRIMARY KEY NOT NULL,
    MaGH NVARCHAR(50),
    MaSP NVARCHAR(50),
    SoLuong INT,
    GiaBan DECIMAL(10, 2)
);

-- Tạo ràng buộc khóa ngoại từ bảng SanPham đến DanhMucSanPham và NhaSanXuat
ALTER TABLE SanPham
ADD FOREIGN KEY (MaDM) REFERENCES DanhMucSanPham(MaDM);

ALTER TABLE SanPham
ADD FOREIGN KEY (MaThongSo) REFERENCES ThongSoSanPham(MaThongSo)  

ALTER TABLE SanPham
ADD FOREIGN KEY (MaNSX) REFERENCES NhaSanXuat(MaNSX);

-- Tạo ràng buộc khóa ngoại từ bảng NhanVien đến ChucVu
ALTER TABLE NhanVien
ADD FOREIGN KEY (MaChucVu) REFERENCES ChucVu(MaChucVu);

-- Tạo ràng buộc khóa ngoại từ bảng HoaDon đến KhachHang
ALTER TABLE HoaDon
ADD FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH);

-- Tạo ràng buộc khóa ngoại từ bảng ChiTietHoaDon đến HoaDon và SanPham
ALTER TABLE ChiTietHoaDon
ADD FOREIGN KEY (MaHD) REFERENCES HoaDon(MaHD);

ALTER TABLE ChiTietHoaDon
ADD FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP);

-- Tạo ràng buộc khóa ngoại từ bảng DonHang đến KhachHang
ALTER TABLE DonHang
ADD FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKH);

-- Tạo ràng buộc khóa ngoại từ bảng ChiTietDonHang đến DonHang và SanPham
ALTER TABLE ChiTietDonHang
ADD FOREIGN KEY (MaDH) REFERENCES DonHang(MaDH);

ALTER TABLE ChiTietDonHang
ADD FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP);

-- Tạo ràng buộc khoá ngoại từ bảng CungUng đến bảng NhaCungCap và SanPham
ALTER TABLE CungUng
ADD FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP);

ALTER TABLE CungUng
ADD FOREIGN KEY (MaNCC) REFERENCES NhaCungCap(MaNCC);

-- Tạo ràng buộc khóa ngoại từ bảng DonDatHang đến NhaCungCap
ALTER TABLE DonDatHang
ADD FOREIGN KEY (MaNhaCungCap) REFERENCES NhaCungCap(MaNCC);

-- Tạo ràng buộc khóa ngoại từ bảng ChiTietDonDatHang đến DonDatHang và SanPham
ALTER TABLE ChiTietDonDatHang
ADD FOREIGN KEY (MaDDH) REFERENCES DonDatHang(MaDDH);

ALTER TABLE ChiTietDonDatHang
ADD FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP);

-- Tạo ràng buộc khóa ngoại từ bảng PhieuBaoHanh đến SanPham
ALTER TABLE PhieuBaoHanh
ADD FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP);

-- Tạo ràng buộc khóa ngoại từ bảng GioHang đến KhachHang
ALTER TABLE GioHang
ADD FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH);

-- Tạo ràng buộc khóa ngoại từ bảng ChiTietGioHang đến GioHang và SanPham
ALTER TABLE ChiTietGioHang
ADD FOREIGN KEY (MaGH) REFERENCES GioHang(MaGH);

ALTER TABLE ChiTietGioHang
ADD FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP);


-- Nhập dữ liệu
-- Bảng danh mục sản phẩm
INSERT [dbo].[DanhMucSanPham] ([MaDM], [TenDanhMuc]) VALUES ('DM001', N'Laptop')
INSERT [dbo].[DanhMucSanPham] ([MaDM], [TenDanhMuc]) VALUES ('DM002', N'PC - Máy tính bộ')
INSERT [dbo].[DanhMucSanPham] ([MaDM], [TenDanhMuc]) VALUES ('DM003', N'Phụ kiện')

-- Bảng Thông số sản phẩm
INSERT [dbo].[ThongSoSanPham] ([MaThongSo], [CPU], [ManHinh], [Ram], [DoHoa], [LuuTru], [HeDieuHanh], [Pin], [KhoiLuong], [Mau], [SoSeri], [SoLuongTon]) VALUES ('TS01', N'AMD Ryzen 5 7520U', N'15.6 (1920 x 1080)', N'16GB Onboard LPDDR5 5500MHz', N'Onboard AMD Radeon 610M', N'512GB SSD M.2 NVMe /', N'Windows 11 Home', N'3 cell 42 Wh Pin liền', N'1.8kg', N'Đen', N'1458201A', 20)
INSERT [dbo].[ThongSoSanPham] ([MaThongSo], [CPU], [ManHinh], [Ram], [DoHoa], [LuuTru], [HeDieuHanh], [Pin], [KhoiLuong], [Mau], [SoSeri], [SoLuongTon]) VALUES ('TS02', N'Intel Core i5-13500HX', N'16 IPS (1920 x 1200),165Hz', N'2 x 8GB DDR5 4800MHz', N'RTX 4060 8GB GDDR6 / Intel UHD Graphics 710', N'512GB SSD M.2 NVMe /', N'Windows 11 Home', N'4 cell 90 Wh Pin liền', N'2.6kg', N'Đen', N'1478201A', 30)
INSERT [dbo].[ThongSoSanPham] ([MaThongSo], [CPU], [ManHinh], [Ram], [DoHoa], [LuuTru], [HeDieuHanh], [Pin], [KhoiLuong], [Mau], [SoSeri], [SoLuongTon]) VALUES ('TS03', N'Intel Core i5-1335U', N'15.6 WVA (1920 x 1080),120Hz', N'1 x 8GB DDR4 2666MHz', N'Onboard Intel Iris Xe Graphics', N'256GB SSD M.2 NVMe /', N'Windows 11 Home SL + Office Home & Student 2021', N'3 cell 41 Wh Pin liền', N'1.6kg', N'Đen', N'1458101A', 10)

-- Bảng nhà sản xuất
INSERT [dbo].[NhaSanXuat] ([MaNSX], [TenNhaSanXuat], [DiaChi], [DienThoai]) VALUES ('NSX01', N'Nhà sản xuất ASUS', N'TP.HCM', N'02856974895')
INSERT [dbo].[NhaSanXuat] ([MaNSX], [TenNhaSanXuat], [DiaChi], [DienThoai]) VALUES ('NSX02', N'Nhà sản xuất ACER', N'TP.HCM', N'02857974895')
INSERT [dbo].[NhaSanXuat] ([MaNSX], [TenNhaSanXuat], [DiaChi], [DienThoai]) VALUES ('NSX03', N'Nhà sản xuất DELL', N'TP.HCM', N'02856978895')

-- Bảng sản phẩm
INSERT [dbo].[SanPham] ([MaSP], [TenSanPham], [MaNSX], [MaDM], [MoTa], [Gia], [SoLuongTrongKho], [HinhAnh], [MaThongSo]) VALUES ('SP001', N'Laptop ASUS Vivobook Go 15', N'NSX01', N'DM001', N'Asus VivoBook Go 15 siêu mỏng nhẹ', 13490000, 20, N'Anh1', 'TS01')
INSERT [dbo].[SanPham] ([MaSP], [TenSanPham], [MaNSX], [MaDM], [MoTa], [Gia], [SoLuongTrongKho], [HinhAnh], [MaThongSo]) VALUES ('SP002', N'Laptop ACER', N'NSX02', N'DM001', N'Siêu Nhanh', 15490000, 30, N'Anh1', 'TS02')
INSERT [dbo].[SanPham] ([MaSP], [TenSanPham], [MaNSX], [MaDM], [MoTa], [Gia], [SoLuongTrongKho], [HinhAnh], [MaThongSo]) VALUES ('SP003', N'Laptop Dell Vostro 3530', N'NSX03', N'DM001', N'Siêu nhẹ, siêu mỏng', 30000000, 10, N'Anh1', 'TS03')

-- Bảng chức vụ
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu]) VALUES ('CVBH', N'Nhân viên bán hàng')
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu]) VALUES ('CVTN', N'Nhân viên thu ngân')
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu]) VALUES ('CVK', N'Nhân viên kho')

-- Bảng nhân viên
INSERT [dbo].[NhanVien] ([MaNV], [HoTen], [DiaChi], [DienThoai], [Email], [MatKhau], [MaChucVu]) VALUES ('NV001', N'Lê Huy', N'TP.HCM', '0378952014', 'huyle@gmail.com', '12345678N', 'CVTN')
INSERT [dbo].[NhanVien] ([MaNV], [HoTen], [DiaChi], [DienThoai], [Email], [MatKhau], [MaChucVu]) VALUES ('NV002', N'Nguyễn Văn Thông', N'TP.HCM', '0387652014', 'thongthai@gmail.com', '12345678N', 'CVBH')
INSERT [dbo].[NhanVien] ([MaNV], [HoTen], [DiaChi], [DienThoai], [Email], [MatKhau], [MaChucVu]) VALUES ('NV003', N'Trần Hoàng Lâm', N'TP.HCM', '0878952074', 'lamhoang@gmail.com', '12345678N', 'CVK')

-- Bảng khách hàng
SET DATEFORMAT DMY
INSERT [dbo].[KhachHang] ([MaKH], [TenKhachHang], [GioiTinh], [NgaySinh], [DiaChi], [DienThoai], [Email]) VALUES ('KH001', N'Trần Ngọc Đài', N'Nữ', '16/01/2001', N'TP.HCM', '0247896547', 'daingoctran@gmail.com')
INSERT [dbo].[KhachHang] ([MaKH], [TenKhachHang], [GioiTinh], [NgaySinh], [DiaChi], [DienThoai], [Email]) VALUES ('KH002', N'Nguyễn Thị Bích Thuỷ', N'Nữ', '26/12/2012', N'TP.HCM', '0847896547', 'bichthuy@gmail.com')
INSERT [dbo].[KhachHang] ([MaKH], [TenKhachHang], [GioiTinh], [NgaySinh], [DiaChi], [DienThoai], [Email]) VALUES ('KH003', N'Đào Văn Lưu', N'Nam', '18/11/1999', N'TP.HCM', '0247896790', 'cyberfort@gmail.com')

-- Bảng hoá đơn
SET DATEFORMAT DMY
INSERT [dbo].[HoaDon] ([MaHD], [NgayMua], [MaKH], [TongTien], [TinhTrangThanhToan], [NgayThanhToan], [NgayNhanHang]) VALUES ('HD001', '14/05/2022', 'KH001', 13490000, N'Đã thanh toán', '14/05/2022', '20/05/2022')
INSERT [dbo].[HoaDon] ([MaHD], [NgayMua], [MaKH], [TongTien], [TinhTrangThanhToan], [NgayThanhToan], [NgayNhanHang]) VALUES ('HD002', '14/06/2022', 'KH002', 15490000, N'Đã thanh toán', '20/06/2022', '20/06/2022')
INSERT [dbo].[HoaDon] ([MaHD], [NgayMua], [MaKH], [TongTien], [TinhTrangThanhToan], [NgayThanhToan], [NgayNhanHang]) VALUES ('HD003', '21/04/2022', 'KH003', 30000000, N'Đã thanh toán', '21/04/2022', '21/04/2022')


-- Bảng chi tiết hoá dơn
INSERT [dbo].[ChiTietHoaDon] ([MaCTHD], [MaHD], [MaSP], [SoLuong], [GiaBan]) VALUES ('CTHD001', 'HD001', 'SP001', 1, 13490000)
INSERT [dbo].[ChiTietHoaDon] ([MaCTHD], [MaHD], [MaSP], [SoLuong], [GiaBan]) VALUES ('CTHD002', 'HD002', 'SP002', 1, 15490000)
INSERT [dbo].[ChiTietHoaDon] ([MaCTHD], [MaHD], [MaSP], [SoLuong], [GiaBan]) VALUES ('CTHD003', 'HD003', 'SP003', 1, 30000000)


-- Bảng đơn hàng
INSERT [dbo].[DonHang] ([MaDH], [NgayDatHang], [MaKhachHang]) VALUES ('DH001', '14/05/2022', 'KH001')
INSERT [dbo].[DonHang] ([MaDH], [NgayDatHang], [MaKhachHang]) VALUES ('DH002', '14/06/2022', 'KH002')
INSERT [dbo].[DonHang] ([MaDH], [NgayDatHang], [MaKhachHang]) VALUES ('DH003', '21/04/2022', 'KH003')

-- Bảng chi tiết đơn hàng
INSERT [dbo].[ChiTietDonHang] ([MaCTDH], [MaDH], [MaSP], [SoLuong], [GiaBan]) VALUES ('CTDH001', 'DH001', 'SP001', 1, 13490000)
INSERT [dbo].[ChiTietDonHang] ([MaCTDH], [MaDH], [MaSP], [SoLuong], [GiaBan]) VALUES ('CTDH002', 'DH002', 'SP002', 1, 15490000)
INSERT [dbo].[ChiTietDonHang] ([MaCTDH], [MaDH], [MaSP], [SoLuong], [GiaBan]) VALUES ('CTDH003', 'DH003', 'SP003', 1, 30000000)

-- Bảng nhà cung cấp
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNhaCungCap], [DiaChi], [DienThoai]) VALUES ('NCC001', N'Công Ty Phân Phối A', N'TP.HCM', '0287896244')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNhaCungCap], [DiaChi], [DienThoai]) VALUES ('NCC002', N'Công Ty Điện Tử', N'Hà Nội', '0287896250')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNhaCungCap], [DiaChi], [DienThoai]) VALUES ('NCC003', N'Công Ty Cung Cấp Máy Tính', N'TP.HCM', '0287996290')

-- Bảng cung ứng
SET DATEFORMAT DMY
INSERT [dbo].[CungUng] ([MaCungUng], [MaNCC], [MaSP], [SoLuong], [GiaBan], [NgayDatHang], [NgayGiaoHang]) VALUES ('CUNG001','NCC001', 'SP001', 20, 13490000, '20/02/2022', '03/03/2022')
INSERT [dbo].[CungUng] ([MaCungUng], [MaNCC], [MaSP], [SoLuong], [GiaBan], [NgayDatHang], [NgayGiaoHang]) VALUES ('CUNG002','NCC002', 'SP002', 20, 15490000, '20/02/2022', '01/03/2022')
INSERT [dbo].[CungUng] ([MaCungUng], [MaNCC], [MaSP], [SoLuong], [GiaBan], [NgayDatHang], [NgayGiaoHang]) VALUES ('CUNG003','NCC003', 'SP003', 20, 30000000, '20/02/2022', '09/03/2022')

-- Bảng đơn đặt hàng
SET DATEFORMAT DMY
INSERT [dbo].[DonDatHang] ([MaDDH], [NgayDatHang], [MaNhaCungCap]) VALUES ('DDH001', '20/02/2022', 'NCC001')
INSERT [dbo].[DonDatHang] ([MaDDH], [NgayDatHang], [MaNhaCungCap]) VALUES ('DDH002', '20/02/2022', 'NCC002')
INSERT [dbo].[DonDatHang] ([MaDDH], [NgayDatHang], [MaNhaCungCap]) VALUES ('DDH003', '20/02/2022', 'NCC003')

-- Bảng chi tiết đơn đăt hàng
INSERT [dbo].[ChiTietDonDatHang] ([MaCTDDH], [MaDDH], [MaSP], [SoLuongDat], [GiaDat]) VALUES ('CTDDH001', 'DDH001', 'SP001', 20, 13000000)
INSERT [dbo].[ChiTietDonDatHang] ([MaCTDDH], [MaDDH], [MaSP], [SoLuongDat], [GiaDat]) VALUES ('CTDDH002', 'DDH002', 'SP002', 20, 15000000)
INSERT [dbo].[ChiTietDonDatHang] ([MaCTDDH], [MaDDH], [MaSP], [SoLuongDat], [GiaDat]) VALUES ('CTDDH003', 'DDH003', 'SP003', 20, 29000000)

-- Bảng phiếu bảo hành
SET DATEFORMAT DMY
INSERT [dbo].[PhieuBaoHanh] ([MaPBH], [NgayYeuCau], [MaSP], [MoTaLoi], [TinhTrangXuLy]) VALUES ('PBH001', '14/07/2022', 'SP001', N'Lỗi phần loa ngoài nhỏ', 'Đã xong')
INSERT [dbo].[PhieuBaoHanh] ([MaPBH], [NgayYeuCau], [MaSP], [MoTaLoi], [TinhTrangXuLy]) VALUES ('PBH002', '12/08/2022', 'SP002', N'Lỗi phần mềm', 'Đã xong')
INSERT [dbo].[PhieuBaoHanh] ([MaPBH], [NgayYeuCau], [MaSP], [MoTaLoi], [TinhTrangXuLy]) VALUES ('PBH003', '19/06/2022', 'SP003', N'Lỗi dây sạc', 'Đã xong')

-- Bảng giỏ hàng
SET DATEFORMAT DMY
INSERT [dbo].[GioHang] ([MaGH], [MaKH], [ThoiGianThemVaoGio]) VALUES ('GH001', 'KH001','20/04/2022')
INSERT [dbo].[GioHang] ([MaGH], [MaKH], [ThoiGianThemVaoGio]) VALUES ('GH002', 'KH002','19/04/2022')
INSERT [dbo].[GioHang] ([MaGH], [MaKH], [ThoiGianThemVaoGio]) VALUES ('GH003', 'KH003','10/04/2022')

-- Bảng chi tiết giỏ hàng
INSERT [dbo].[ChiTietGioHang] ([MaCTGH], [MaGH], [MaSP], [SoLuong], [GiaBan]) VALUES ('CTGH001', 'GH001','SP001', 1, 13490000)
INSERT [dbo].[ChiTietGioHang] ([MaCTGH], [MaGH], [MaSP], [SoLuong], [GiaBan]) VALUES ('CTGH002', 'GH002','SP001', 1, 15490000)
INSERT [dbo].[ChiTietGioHang] ([MaCTGH], [MaGH], [MaSP], [SoLuong], [GiaBan]) VALUES ('CTGH003', 'GH003','SP001', 1, 30000000)




