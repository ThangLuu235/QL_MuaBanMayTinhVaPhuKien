
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_MuaBanMayTinh.Data
{
    [Table("DanhMucSanPham")]
    public class DanhMucSanPham
    {
        [Key]
        public string MaDM { get; set; } // khóa chính
        public string TenDanhMuc { get; set; }
        public ICollection<ThanhPhan> ThanhPhans { get; set; }
        public DanhMucSanPham()
        {
            ThanhPhans= new List<ThanhPhan>();
        }
    }
}
