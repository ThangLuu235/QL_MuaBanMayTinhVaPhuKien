using AutoMapper;
using QL_MuaBanMayTinh.Data;
using QL_MuaBanMayTinh.Models;

namespace QL_MuaBanMayTinh.Helpers
{
    public class ApplicationMapper:Profile
    {
        public ApplicationMapper() 
        {
            CreateMap<SanPham,SanPhamModel>().ReverseMap();
            CreateMap<DanhMucSanPham,DanhMucSPModel>().ReverseMap();
            CreateMap<SanPhamThanhPhan,SanPhamThanhPhamModel>().ReverseMap();
            CreateMap<ThanhPhan,ThanhPhanModel>().ReverseMap();
            CreateMap<ChiTietDonNhapHang,CTDonNhapHangModel>().ReverseMap();

            CreateMap<ChiTietHoaDon,CTHoaDonModel>().ReverseMap();
            CreateMap<ChucVu,ChucVuModel>().ReverseMap();
            CreateMap<DonNhapHang,DonNhapModel>().ReverseMap();
            CreateMap<HoaDon, HoaDonModel>().ReverseMap();
            CreateMap<KhachHang,KhachHangModel>().ReverseMap();
            
            CreateMap<KhuyenMai,KhuyenMaiModel>().ReverseMap();
            CreateMap<NhaCungCap,NhaCCModel>().ReverseMap();
            CreateMap<NhanVien,NhanVienModel>().ReverseMap();
            CreateMap<ThongSoKyThuat,TSKyThuatModel>().ReverseMap();
            CreateMap<ThongSoSanPham,TSSanPhamModel>().ReverseMap();
            CreateMap<TinhTrangThanhToan,TTThanhToanModel>().ReverseMap();
        }
    }
}
