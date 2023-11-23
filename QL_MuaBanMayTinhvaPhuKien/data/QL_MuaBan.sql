CREATE DATABASE QL_CHMayTinh
GO

USE QL_CHMayTinh
GO

-- Tạo bảng Danh mục sản phẩm
CREATE TABLE DanhMucSanPham (
    MaDM NVARCHAR(50) PRIMARY KEY NOT NULL,
    TenDanhMuc NVARCHAR(255)
);


-- Tạo bảng Sản phẩm
CREATE TABLE SanPham (
    MaSP NVARCHAR(50) PRIMARY KEY NOT NULL,
    TenSanPham NVARCHAR(255),
    
    MoTa NVARCHAR(150),
    Gia DECIMAL(10, 2),
	HinhAnh NVARCHAR(50),
);

-- Tạo bảng thông số kỹ thuật
CREATE TABLE ThongSoKyThuat (
	MaThongSo NVARCHAR(50) PRIMARY KEY NOT NULL,
	TenThongSo NVARCHAR(100),
);

-- Tạo bảng thông số - sản phẩm
CREATE TABLE ThongSoSanPham (
	MaTP NVARCHAR(50),
	MaThongSo NVARCHAR(50),
	GiaTriThongSo NVARCHAR(100),
	PRIMARY KEY (MaTP, MaThongSo)
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

-- Tạo bảng tình trạng thanh toán
CREATE TABLE TinhTrangThanhToan (
	MaTinhTrangTT NVARCHAR(50) PRIMARY KEY NOT NULL,
	MaNV NVARCHAR(50),
	DatHang NVARCHAR(50),
	XacNhanDonHang NVARCHAR(50),
	NgayThanhToan DATE,
	TinhTrang NVARCHAR(50),
	GiaoHang NVARCHAR(50)
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

-- Tạo bảng Khuyến mãi
CREATE TABLE KhuyenMai (
	MaKhuyenMai NVARCHAR(50) PRIMARY KEY NOT NULL,
	MaSP NVARCHAR(50),
	TenKhuyenMai NVARCHAR(100),
	PhanTramGiamGia DECIMAL(5, 2)
);

-- Tạo bảng Hóa đơn
CREATE TABLE HoaDon (
    MaHD NVARCHAR(50) PRIMARY KEY NOT NULL,
    NgayMua DATE,
    MaKH NVARCHAR(50),
    TongTien DECIMAL(10, 2),
	HinhThucThanhToan NVARCHAR(30),
    MaTinhTrangTT NVARCHAR(50),
	NgayNhanHang DATE
);

-- Tạo bảng Chi tiết hóa đơn
CREATE TABLE ChiTietHoaDon (
    MaCTHD NVARCHAR(50) PRIMARY KEY NOT NULL,
    MaHD NVARCHAR(50),
    MaSP NVARCHAR(50),
    SoLuong INT,
    GiaBan DECIMAL(10, 2),
	MaKhuyenMai NVARCHAR(50)
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
	MaTP NVARCHAR(50),
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
    MaTP NVARCHAR(50),
    SoLuongDat INT,
    GiaDat DECIMAL(10, 2)
);
CREATE TABLE ThanhPhan
(
	MaTP nvarchar(50) primary key NOT NULL,
	TenTP nvarchar(300),
	SoLuongTonKho int,
	SoSeri nvarchar(100),
	GiaTP decimal(10,2),
	MaDM NVARCHAR(50),
)

CREATE TABLE SanPhamThanhPhan
(
	MaSP nvarchar(50),
	MaTP nvarchar(50),
	SoLuong int,
	primary key (MaSP,MaTP)
)

-- Tạo ràng buộc khóa ngoại từ bảng SanPham đến DanhMucSanPham và NhaSanXuat
ALTER TABLE ThanhPhan
ADD FOREIGN KEY (MaDM) REFERENCES DanhMucSanPham(MaDM);


-- Tạo ràng buộc khoá ngoại từ bảng Thông số - sản phẩm đến SanPham và Thông số kỹ thuật
ALTER TABLE ThongSoSanPham
ADD FOREIGN KEY (MaTP) REFERENCES ThanhPhan(MaTP);

ALTER TABLE ThongSoSanPham
ADD FOREIGN KEY (MaThongSo) REFERENCES ThongSoKyThuat(MaThongSo);

-- Tạo ràng buộc khóa ngoại từ bảng NhanVien đến ChucVu
ALTER TABLE NhanVien
ADD FOREIGN KEY (MaChucVu) REFERENCES ChucVu(MaChucVu);

-- Tạo ràng buộc khóa ngoại từ bảng HoaDon đến KhachHang
ALTER TABLE HoaDon
ADD FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH);

ALTER TABLE HoaDon
ADD FOREIGN KEY (MaTinhTrangTT) REFERENCES TinhTrangThanhToan(MaTinhTrangTT);

-- Tạo ràng buộc khoá ngoại từ bảng Tình trạng thanh toán đến Nhân viên
ALTER TABLE TinhTrangThanhToan
ADD FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV);

-- Tạo ràng buộc khóa ngoại từ bảng ChiTietHoaDon đến HoaDon và SanPham và KhuyenMai
ALTER TABLE ChiTietHoaDon
ADD FOREIGN KEY (MaHD) REFERENCES HoaDon(MaHD);

ALTER TABLE ChiTietHoaDon
ADD FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP);

ALTER TABLE ChiTietHoaDon
ADD FOREIGN KEY (MaKhuyenMai) REFERENCES KhuyenMai(MaKhuyenMai);

-- Tạo ràng buộc khoá ngoại từ bảng CungUng đến bảng NhaCungCap và SanPham
ALTER TABLE CungUng
ADD FOREIGN KEY (MaTP) REFERENCES ThanhPhan(MaTP);

ALTER TABLE CungUng
ADD FOREIGN KEY (MaNCC) REFERENCES NhaCungCap(MaNCC);

-- Tạo ràng buộc khóa ngoại từ bảng DonDatHang đến NhaCungCap
ALTER TABLE DonDatHang
ADD FOREIGN KEY (MaNhaCungCap) REFERENCES NhaCungCap(MaNCC);

-- Tạo ràng buộc khóa ngoại từ bảng ChiTietDonDatHang đến DonDatHang và SanPham
ALTER TABLE ChiTietDonDatHang
ADD FOREIGN KEY (MaDDH) REFERENCES DonDatHang(MaDDH);

ALTER TABLE ChiTietDonDatHang
ADD FOREIGN KEY (MaTP) REFERENCES ThanhPhan(MaTP);
-- Tạo ràng buộc khóa ngoại từ bảng SanPhamThanhPhan đến ThanhPhan và SanPham
ALTER TABLE SanPhamThanhPhan
ADD FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP);
ALTER TABLE SanPhamThanhPhan
ADD FOREIGN KEY (MaTP) REFERENCES ThanhPhan(MaTP);


-- Nhập dữ liệu
-- Bảng danh mục sản phẩm
INSERT [dbo].[DanhMucSanPham] ([MaDM], [TenDanhMuc]) VALUES ('DM001', N'Laptop')
INSERT [dbo].[DanhMucSanPham] ([MaDM], [TenDanhMuc]) VALUES ('DM002', N'PC - Máy tính bộ')
INSERT [dbo].[DanhMucSanPham] ([MaDM], [TenDanhMuc]) VALUES ('DM003', N'Phụ kiện')

-- Bảng nhà sản xuất
--INSERT [dbo].[NhaSanXuat] ([MaNSX], [TenNhaSanXuat], [DiaChi], [DienThoai]) VALUES ('NSX01', N'Nhà sản xuất ASUS', N'TP.HCM', N'02856974895')
--INSERT [dbo].[NhaSanXuat] ([MaNSX], [TenNhaSanXuat], [DiaChi], [DienThoai]) VALUES ('NSX02', N'Nhà sản xuất ACER', N'TP.HCM', N'02857974895')
--INSERT [dbo].[NhaSanXuat] ([MaNSX], [TenNhaSanXuat], [DiaChi], [DienThoai]) VALUES ('NSX03', N'Nhà sản xuất DELL', N'TP.HCM', N'02856978895')
select * from SanPham
-- Bảng sản phẩm
INSERT SanPham VALUES ('SP001', N'Laptop ASUS Vivobook Go 15', N'Asus VivoBook Go 15 siêu mỏng nhẹ', 13490000, N'Anh1','DM001','LAP-AS-VI-123123')
INSERT SanPham VALUES ('SP002', N'Laptop ACER Aspire 3 A315-59-51X8', N'Siêu Nhanh', 15490000, N'Anh2','DM001','LAP-AC-AS-565423')
INSERT SanPham VALUES ('SP003', N'Laptop Dell Vostro 3530', N'Siêu nhẹ, siêu mỏng', 30000000, N'Anh3','DM001','LAP-DE-VO-342645')

-- Bảng Thông số kỹ thuật
INSERT [dbo].[ThongSoKyThuat] ([MaThongSo], [TenThongSo]) VALUES ('TS01', N'CPU')
INSERT [dbo].[ThongSoKyThuat] ([MaThongSo], [TenThongSo]) VALUES ('TS02', N'Màn hình')
INSERT [dbo].[ThongSoKyThuat] ([MaThongSo], [TenThongSo]) VALUES ('TS03', N'RAM')

--Bảng thành phần
insert into ThanhPhan values ('LAPTOP001',N'Laptop ASUS Vivobook Go 15',30)
insert into ThanhPhan values ('LAPTOP002',N'Laptop ACER Aspire 3 A315-59-51X8',40)
insert into ThanhPhan values ('LAPTOP003',N'Laptop Dell Vostro 3530',50)
insert into ThanhPhan values ('CHUOT001',N'Chuột Logitech B100',200)
insert into ThanhPhan values ('BANPHIM001',N'Bàn phím HP',100)
insert into ThanhPhan values ('PHUKIEN001',N'Bao chống sốc laptop',500)
-- Bảng Thông số - sản phẩm
INSERT ThongSoSanPham VALUES ('SP001', 'TS01', N'AMD Ryzen 5 7520U')
INSERT ThongSoSanPham VALUES ('SP001', 'TS02', N'15.6" (1920 x 1080)')
INSERT ThongSoSanPham VALUES ('SP001', 'TS03', N'16GB Onboard LPDDR5 5500MHz')
INSERT ThongSoSanPham VALUES ('SP002', 'TS01', N'Intel Core i5-1235U')
INSERT ThongSoSanPham VALUES ('SP002', 'TS02', N'15.6" (1920 x 1080)')
INSERT ThongSoSanPham VALUES ('SP002', 'TS03', N'1 x 8GB DDR4 2400MHz')
INSERT ThongSoSanPham VALUES ('SP003', 'TS01', N'Intel Core i5-1335U')
INSERT ThongSoSanPham VALUES ('SP003', 'TS02', N'15.6" WVA (1920 x 1080),120Hz')
INSERT ThongSoSanPham VALUES ('SP003', 'TS03', N'1 x 8GB DDR4 2666MHz')

-- Bảng chức vụ
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu]) VALUES ('CVBH', N'Nhân viên bán hàng')
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu]) VALUES ('CVTN', N'Nhân viên thu ngân')
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu]) VALUES ('CVK', N'Nhân viên kho')

-- Bảng nhân viên
INSERT [dbo].[NhanVien] ([MaNV], [HoTen], [DiaChi], [DienThoai], [Email], [MatKhau], [MaChucVu]) VALUES ('NV001', N'Lê Huy', N'TP.HCM', '0378952014', 'huyle@gmail.com', '12345678N', 'CVTN')
INSERT [dbo].[NhanVien] ([MaNV], [HoTen], [DiaChi], [DienThoai], [Email], [MatKhau], [MaChucVu]) VALUES ('NV002', N'Nguyễn Văn Thông', N'TP.HCM', '0387652014', 'thongthai@gmail.com', '12345678N', 'CVBH')
INSERT [dbo].[NhanVien] ([MaNV], [HoTen], [DiaChi], [DienThoai], [Email], [MatKhau], [MaChucVu]) VALUES ('NV003', N'Trần Hoàng Lâm', N'TP.HCM', '0878952074', 'lamhoang@gmail.com', '12345678N', 'CVK')

-- Bảng hoá đơn
SET DATEFORMAT DMY
INSERT HoaDon VALUES ('HD001', '14/05/2022', '20/05/2022', 13490000, N'Thẻ tín dụng', 'KH001',NULL,'16/05/2022',3000000)
INSERT HoaDon VALUES ('HD002', '14/06/2022', '20/06/2022',13490000, N'Tiền mặt','KH001',NULL,'15/06/2022',2000000)
INSERT HoaDon VALUES ('HD003', '21/06/2022', '21/06/2022',13490000,  N'Thẻ tín dụng', 'KH001',NULL,'21/06/2022',13490000)
-- Bảng tình trạng thanh toán
SET DATEFORMAT DMY
INSERT TinhTrangThanhToan VALUES ('TT001',   N'Đã xác nhận', '14/05/2022',N'Đã Nhận hàng','NV002','HD001', N'Đã Thanh Toán')
INSERT TinhTrangThanhToan VALUES ('TT002', N'Đã xác nhận', '14/06/2022',N'Đã Nhận hàng', 'NV002','HD002', N'Đã Thanh Toán')
INSERT TinhTrangThanhToan VALUES ('TT003',  N'Đã xác nhận', '21/06/2022',N'Đã Nhận hàng','NV002','HD003', N'Đã Thanh Toán')

-- Bảng khách hàng
SET DATEFORMAT DMY
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [GioiTinh], [NgaySinh], [DiaChi], [DienThoai], [Email]) VALUES ('KH001', N'Trần Ngọc Đài', N'Nữ', '16/01/2001', N'TP.HCM', '0247896547', 'daingoctran@gmail.com')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [GioiTinh], [NgaySinh], [DiaChi], [DienThoai], [Email]) VALUES ('KH002', N'Nguyễn Thị Bích Thuỷ', N'Nữ', '26/12/2012', N'TP.HCM', '0847896547', 'bichthuy@gmail.com')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [GioiTinh], [NgaySinh], [DiaChi], [DienThoai], [Email]) VALUES ('KH003', N'Đào Văn Lưu', N'Nam', '18/11/1999', N'TP.HCM', '0247896790', 'cyberfort@gmail.com')

-- Bảng khuyến mãi

INSERT KhuyenMai VALUES ('KM001', N'Khuyến mãi thành viên',10)



-- Bảng chi tiết hoá dơn
INSERT ChiTietHoaDon VALUES ( 'HD001', 'SP001', 1, 13490000)
INSERT ChiTietHoaDon VALUES ( 'HD002', 'SP002', 1, 15490000)
INSERT ChiTietHoaDon VALUES ( 'HD003', 'SP003', 1, 30000000)

-- Bảng nhà cung cấp
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [DienThoai]) VALUES ('NCC001', N'Công Ty Phân Phối A', N'TP.HCM', '0287896244')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [DienThoai]) VALUES ('NCC002', N'Công Ty Điện Tử', N'Hà Nội', '0287896250')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [DienThoai]) VALUES ('NCC003', N'Công Ty Cung Cấp Máy Tính', N'TP.HCM', '0287996290')

-- Bảng cung ứng

-- Bảng đơn đặt hàng
SET DATEFORMAT DMY
INSERT into DonNhapHang VALUES ('DDH001', 'NCC001', '20/02/2022','NV001')
INSERT into DonNhapHang VALUES ('DDH002',  'NCC002', '20/02/2022','NV001')
INSERT into DonNhapHang VALUES ('DDH003', 'NCC003', '20/02/2022','NV001')

-- Bảng chi tiết đơn đăt hàng
INSERT into ChiTietDonNhapHang VALUES ( 'DDH001', 'SP001', 20, 13000000)
INSERT into ChiTietDonNhapHang VALUES ('DDH002', 'SP002', 20, 15000000)
INSERT into ChiTietDonNhapHang VALUES ( 'DDH003', 'SP003', 20, 29000000)


--Bảng Sản phầm thành phần
insert into SanPhamThanhPhan values('LAPTOP001','SP001',1)
insert into SanPhamThanhPhan values('CHUOT001','SP001',1)
insert into SanPhamThanhPhan values('PHUKIEN001','SP001',1)
insert into SanPhamThanhPhan values('LAPTOP002','SP002',1)
insert into SanPhamThanhPhan values('LAPTOP003','SP003',1)
insert into SanPhamThanhPhan values('BANPHIM001','SP003',1)

select P.*, PC.TenTP, PPC.SoLuong 
from SanPham as P
join SanPhamThanhPhan as PPC on P.MaSP = PPC.MaSP
join ThanhPhan as PC on PPC.MaTP = PC.MaTP
where P.MaSP = 'SP001'




