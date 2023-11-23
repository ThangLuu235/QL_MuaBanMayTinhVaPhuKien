namespace QL_MuaBanMayTinh.Data
{
    public class ChiTietHoaDon
    {
        public string? MaHD { get; set; }
        public string? MaSP { get; set; }
        public int SoLuong { get; set; }

        public SanPham SanPham { get; set; }
        public HoaDon HoaDon { get; set; }
    }
}
