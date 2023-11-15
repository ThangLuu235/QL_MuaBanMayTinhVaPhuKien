using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_MuaBanMayTinh.Data
{
    [Table("ChucVu")]
    public class ChucVu
    {
        [Key]
        public string MaChucVu { get; set; }
        public string TenChucVu { get; set; }
        public ICollection<NhanVien> NhanViens { get; set; }
        public ChucVu() { 
            NhanViens=new List<NhanVien>();
        }
    }
}
