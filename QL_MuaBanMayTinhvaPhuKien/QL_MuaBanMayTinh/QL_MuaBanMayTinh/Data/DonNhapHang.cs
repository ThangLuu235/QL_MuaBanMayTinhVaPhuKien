using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_MuaBanMayTinh.Data
{
    [Table("DonNhapHang")]
    public class DonNhapHang
    {
        [Key]
        public string? MaDNH { get; set; }
        public string? MaNCC { get; set; }
        public DateTime NgayDat { get; set; }
        public NhaCungCap NhaCungCap { get; set; }
        public ICollection<ChiTietDonNhapHang> ChiTietDonNhapHangs { get; set; }    
        public DonNhapHang()
        {
            ChiTietDonNhapHangs = new List<ChiTietDonNhapHang>();
        }
    }
}
