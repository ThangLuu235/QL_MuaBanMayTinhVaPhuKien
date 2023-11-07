using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using QL_MuaBanMayTinhvaPhuKien.Model;

namespace QL_MuaBanMayTinhvaPhuKien.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductSpecificationsController : ControllerBase
	{
		private readonly IConfiguration _configuration;
		private readonly string _sqlDataSource;

		public ProductSpecificationsController(IConfiguration configuration)
		{
			_configuration = configuration;
			_sqlDataSource = _configuration.GetConnectionString("DefaultConnection"); // Lấy chuỗi kết nối từ appsettings.json
		}

		[HttpGet]
		public IActionResult GetProductSpecifications()
		{
			List<ThongSoSanPham> specs = new List<ThongSoSanPham>();
			string query = "SELECT MaSP, MaThongSo, GiaTriThongSo FROM ThongSoSanPham";

			using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
			{
				sqlConnection.Open();
				using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
				{
					using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
					{
						while (sqlDataReader.Read())
						{
							ThongSoSanPham spec = new ThongSoSanPham
							{
								MaSP = sqlDataReader.GetString(0),
                                MaThongSo = sqlDataReader.GetString(1),
                                GiaTriThongSo = sqlDataReader.GetString(2),
                            };
							specs.Add(spec);
						}
					}
				}
			}

			return Ok(specs);
		}

		[HttpPost]
		public IActionResult CreateProductSpecifications([FromBody] ThongSoSanPham spec)
		{
			if (spec != null)
			{
				using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
				{
					sqlConnection.Open();
					string insertQuery = "INSERT INTO ThongSoSanPham (MaThongSo, CPU, ManHinh, Ram, DoHoa, LuuTru, HeDieuHanh, Pin, KhoiLuong, Mau, SoSeri, SoLuongTon) " +
						"VALUES (@MaThongSo, @CPU, @ManHinh, @Ram, @DoHoa, @LuuTru, @HeDieuHanh, @Pin, @KhoiLuong, @Mau, @SoSeri, @SoLuongTon)";

					using (SqlCommand sqlCommand = new SqlCommand(insertQuery, sqlConnection))
					{
						sqlCommand.Parameters.AddWithValue("@MaThongSo", spec.MaThongSo);
						//sqlCommand.Parameters.AddWithValue("@CPU", spec.CPU);
						//sqlCommand.Parameters.AddWithValue("@ManHinh", spec.ManHinh);
						//sqlCommand.Parameters.AddWithValue("@Ram", spec.Ram);
						//sqlCommand.Parameters.AddWithValue("@DoHoa", spec.DoHoa);
						//sqlCommand.Parameters.AddWithValue("@LuuTru", spec.LuuTru);
						//sqlCommand.Parameters.AddWithValue("@HeDieuHanh", spec.HeDieuHanh);
						//sqlCommand.Parameters.AddWithValue("@Pin", spec.Pin);
						//sqlCommand.Parameters.AddWithValue("@KhoiLuong", spec.KhoiLuong);
						//sqlCommand.Parameters.AddWithValue("@Mau", spec.Mau);
						//sqlCommand.Parameters.AddWithValue("@SoSeri", spec.SoSeri);
						//sqlCommand.Parameters.AddWithValue("@SoLuongTon", spec.SoLuongTon);
						sqlCommand.ExecuteNonQuery();
					}
				}
				return Ok("Thông số sản phẩm đã được tạo.");
			}
			return BadRequest("Thông số sản phẩm không hợp lệ.");
		}

		[HttpPut("{maThongSo}")]
		public IActionResult UpdateProductSpecifications(string maThongSo, [FromBody] ThongSoSanPham spec)
		{
			using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
			{
				sqlConnection.Open();
				string updateQuery = "UPDATE ThongSoSanPham SET CPU = @CPU, ManHinh = @ManHinh, Ram = @Ram, " +
					"DoHoa = @DoHoa, LuuTru = @LuuTru, HeDieuHanh = @HeDieuHanh, Pin = @Pin, KhoiLuong = @KhoiLuong, " +
					"Mau = @Mau, SoSeri = @SoSeri, SoLuongTon = @SoLuongTon " +
					"WHERE MaThongSo = @MaThongSo";

				using (SqlCommand sqlCommand = new SqlCommand(updateQuery, sqlConnection))
				{
					sqlCommand.Parameters.AddWithValue("@MaThongSo", maThongSo);
					//sqlCommand.Parameters.AddWithValue("@CPU", spec.CPU);
					//sqlCommand.Parameters.AddWithValue("@ManHinh", spec.ManHinh);
					//sqlCommand.Parameters.AddWithValue("@Ram", spec.Ram);
					//sqlCommand.Parameters.AddWithValue("@DoHoa", spec.DoHoa);
					//sqlCommand.Parameters.AddWithValue("@LuuTru", spec.LuuTru);
					//sqlCommand.Parameters.AddWithValue("@HeDieuHanh", spec.HeDieuHanh);
					//sqlCommand.Parameters.AddWithValue("@Pin", spec.Pin);
					//sqlCommand.Parameters.AddWithValue("@KhoiLuong", spec.KhoiLuong);
					//sqlCommand.Parameters.AddWithValue("@Mau", spec.Mau);
					//sqlCommand.Parameters.AddWithValue("@SoSeri", spec.SoSeri);
					//sqlCommand.Parameters.AddWithValue("@SoLuongTon", spec.SoLuongTon);
					int rowsAffected = sqlCommand.ExecuteNonQuery();

					if (rowsAffected > 0)
					{
						return Ok("Thông số sản phẩm đã được cập nhật.");
					}
					return NotFound("Không tìm thấy thông số sản phẩm hoặc dữ liệu không hợp lệ.");
				}
			}
		}

		[HttpDelete("{maThongSo}")]
		public IActionResult DeleteProductSpecifications(string maThongSo)
		{
			using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
			{
				sqlConnection.Open();
				string deleteQuery = "DELETE FROM ThongSoSanPham WHERE MaThongSo = @MaThongSo";

				using (SqlCommand sqlCommand = new SqlCommand(deleteQuery, sqlConnection))
				{
					sqlCommand.Parameters.AddWithValue("@MaThongSo", maThongSo);
					int rowsAffected = sqlCommand.ExecuteNonQuery();

					if (rowsAffected > 0)
					{
						return Ok("Thông số sản phẩm đã được xóa.");
					}
					return NotFound("Không tìm thấy thông số sản phẩm.");
				}
			}
		}
	}
}
