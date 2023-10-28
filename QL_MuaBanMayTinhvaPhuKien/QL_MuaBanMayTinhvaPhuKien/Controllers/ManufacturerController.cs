using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using QL_MuaBanMayTinhvaPhuKien.Model;

namespace QL_MuaBanMayTinhvaPhuKien.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ManufacturerController : ControllerBase
	{
		private readonly IConfiguration _configuration;
		private readonly string _sqlDataSource;

		public ManufacturerController(IConfiguration configuration)
		{
			_configuration = configuration;
			_sqlDataSource = _configuration.GetConnectionString("DefaultConnection"); // Lấy chuỗi kết nối từ appsettings.json
		}

		[HttpGet]
		public IActionResult GetManufacturers()
		{
			List<NhaSanXuat> manufacturers = new List<NhaSanXuat>();
			string query = "SELECT MaNSX, TenNhaSanXuat, DiaChi, DienThoai FROM NhaSanXuat";

			using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
			{
				sqlConnection.Open();
				using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
				{
					using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
					{
						while (sqlDataReader.Read())
						{
							NhaSanXuat manufacturer = new NhaSanXuat
							{
								MaNSX = sqlDataReader.GetString(0),
								TenNhaSanXuat = sqlDataReader.GetString(1),
								DiaChi = sqlDataReader.GetString(2),
								DienThoai = sqlDataReader.GetString(3)
							};
							manufacturers.Add(manufacturer);
						}
					}
				}
			}

			return Ok(manufacturers);
		}
		[HttpPost]
		public IActionResult CreateManufacturer([FromBody] NhaSanXuat manufacturer)
		{
			if (manufacturer != null)
			{
				using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
				{
					sqlConnection.Open();
					string insertQuery = "INSERT INTO NhaSanXuat (MaNSX, TenNhaSanXuat, DiaChi, DienThoai) " +
						"VALUES (@MaNSX, @TenNhaSanXuat, @DiaChi, @DienThoai)";

					using (SqlCommand sqlCommand = new SqlCommand(insertQuery, sqlConnection))
					{
						sqlCommand.Parameters.AddWithValue("@MaNSX", manufacturer.MaNSX);
						sqlCommand.Parameters.AddWithValue("@TenNhaSanXuat", manufacturer.TenNhaSanXuat);
						sqlCommand.Parameters.AddWithValue("@DiaChi", manufacturer.DiaChi);
						sqlCommand.Parameters.AddWithValue("@DienThoai", manufacturer.DienThoai);
						sqlCommand.ExecuteNonQuery();
					}
				}
				return Ok("Nhà sản xuất đã được tạo.");
			}
			return BadRequest("Nhà sản xuất không hợp lệ.");
		}

		[HttpPut("{maNSX}")]
		public IActionResult UpdateManufacturer(string maNSX, [FromBody] NhaSanXuat manufacturer)
		{
			using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
			{
				sqlConnection.Open();
				string updateQuery = "UPDATE NhaSanXuat SET TenNhaSanXuat = @TenNhaSanXuat, DiaChi = @DiaChi, DienThoai = @DienThoai " +
					"WHERE MaNSX = @MaNSX";

				using (SqlCommand sqlCommand = new SqlCommand(updateQuery, sqlConnection))
				{
					sqlCommand.Parameters.AddWithValue("@MaNSX", maNSX);
					sqlCommand.Parameters.AddWithValue("@TenNhaSanXuat", manufacturer.TenNhaSanXuat);
					sqlCommand.Parameters.AddWithValue("@DiaChi", manufacturer.DiaChi);
					sqlCommand.Parameters.AddWithValue("@DienThoai", manufacturer.DienThoai);
					int rowsAffected = sqlCommand.ExecuteNonQuery();

					if (rowsAffected > 0)
					{
						return Ok("Nhà sản xuất đã được cập nhật.");
					}
					return NotFound("Không tìm thấy nhà sản xuất hoặc dữ liệu không hợp lệ.");
				}
			}
		}

		[HttpDelete("{maNSX}")]
		public IActionResult DeleteManufacturer(string maNSX)
		{
			using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
			{
				sqlConnection.Open();
				string deleteQuery = "DELETE FROM NhaSanXuat WHERE MaNSX = @MaNSX";

				using (SqlCommand sqlCommand = new SqlCommand(deleteQuery, sqlConnection))
				{
					sqlCommand.Parameters.AddWithValue("@MaNSX", maNSX);
					int rowsAffected = sqlCommand.ExecuteNonQuery();

					if (rowsAffected > 0)
					{
						return Ok("Nhà sản xuất đã được xóa.");
					}
					return NotFound("Không tìm thấy nhà sản xuất.");
				}
			}
		}
	}
}
