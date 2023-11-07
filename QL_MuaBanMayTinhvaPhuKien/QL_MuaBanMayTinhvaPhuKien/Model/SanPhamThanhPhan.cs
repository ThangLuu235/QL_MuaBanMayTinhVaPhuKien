namespace QL_MuaBanMayTinhvaPhuKien.Model
{
    public class SanPhamThanhPhan
    {
        public SanPhamThanhPhan() { }   
        public string MaSP { get; set; }
        public string MaTP { get; set; }
        public int SoLuong { get; set; }

        public SanPham SanPham { get; set; }
        public ThanhPhan ThanhPhan { get; set; }
    }
}
