namespace QL_MuaBanMayTinhvaPhuKien.Model
{
	public class SanPham
	{
		public string MaSP { get; set; } // Khóa chính
		public string TenSanPham { get; set; }
		public string MoTa { get; set; }
		public decimal Gia { get; set; }
		public int SoLuongTrongKho { get; set; }
		public string HinhAnh { get; set; }
		public string MaDM { get; set; } // Khóa ngoại
		public string MaThongSo { get; set; } // Khóa ngoại
		public string MaNSX { get; set; } // Khóa ngoại


		
	}
}
