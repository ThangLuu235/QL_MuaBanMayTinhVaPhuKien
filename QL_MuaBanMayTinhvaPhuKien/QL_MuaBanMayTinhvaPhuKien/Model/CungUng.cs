using System.ComponentModel.DataAnnotations;

namespace QL_MuaBanMayTinhvaPhuKien.Model
{
	public class CungUng
	{
        
        public string MaCungUng { get; set; }  //khoá chính
        public string MaNCC { get; set; } //khoá chính
        public string MaSP { get; set; }
        public int SoLuong { get; set; }
        public decimal GiaBan { get; set; } 
        public DateTime NgayDatHang { get; set; }   
        public DateTime NgayGiaoHang { get; set; }
    }
}
