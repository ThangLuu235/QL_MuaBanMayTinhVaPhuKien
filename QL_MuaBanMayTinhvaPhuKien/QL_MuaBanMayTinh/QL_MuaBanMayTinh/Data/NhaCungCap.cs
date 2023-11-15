using System.ComponentModel.DataAnnotations.Schema;

namespace QL_MuaBanMayTinh.Data
{
    [Table("NhaCungCap")]
    public class NhaCungCap
    {
        public string? MaNCC { get; set; }
        public string? TenNCC { get; set; }
        public string? DiaChi { get; set; }
        public string? DienThoai { get; set; }
        public ICollection<DonNhapHang> DonNhapHangs { get; set; }
        public NhaCungCap()
        {
            DonNhapHangs = new List<DonNhapHang>();
        }
    }
}
