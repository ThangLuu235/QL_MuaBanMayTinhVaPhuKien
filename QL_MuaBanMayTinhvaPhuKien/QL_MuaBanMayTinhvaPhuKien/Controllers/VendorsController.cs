using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using QL_MuaBanMayTinhvaPhuKien.Model;

namespace QL_MuaBanMayTinhvaPhuKien.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class VendorsController : ControllerBase
	{
		private readonly IConfiguration _configuration;
		private readonly string _sqlDataSource;

		public VendorsController(IConfiguration configuration)
		{
			_configuration = configuration;
			_sqlDataSource = _configuration.GetConnectionString("DefaultConnection"); // Lấy chuỗi kết nối từ appsettings.json
		}

		[HttpGet]
		public IActionResult GetVendors()
		{
			List<NhaCungCap> vendors = new List<NhaCungCap>();
			string query = "SELECT MaNCC, TenNhaCungCap, DiaChi, DienThoai FROM NhaCungCap";

			using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
			{
				sqlConnection.Open();
				using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
				{
					using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
					{
						while (sqlDataReader.Read())
						{
							NhaCungCap vendor = new NhaCungCap
							{
								MaNCC = sqlDataReader.GetString(0),
								TenNhaCungCap = sqlDataReader.GetString(1),
								DiaChi = sqlDataReader.GetString(2),
								DienThoai = sqlDataReader.GetString(3)
							};
							vendors.Add(vendor);
						}
					}
				}
			}

			return Ok(vendors);
		}
		[HttpPost]
		public IActionResult CreateVendor([FromBody] NhaCungCap vendor)
		{
			if (vendor != null)
			{
				using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
				{
					sqlConnection.Open();
					string insertQuery = "INSERT INTO NhaCungCap (MaNCC, TenNhaCungCap, DiaChi, DienThoai) " +
						"VALUES (@MaNCC, @TenNhaCungCap, @DiaChi, @DienThoai)";

					using (SqlCommand sqlCommand = new SqlCommand(insertQuery, sqlConnection))
					{
						sqlCommand.Parameters.AddWithValue("@MaNCC", vendor.MaNCC);
						sqlCommand.Parameters.AddWithValue("@TenNhaCungCap", vendor.TenNhaCungCap);
						sqlCommand.Parameters.AddWithValue("@DiaChi", vendor.DiaChi);
						sqlCommand.Parameters.AddWithValue("@DienThoai", vendor.DienThoai);
						sqlCommand.ExecuteNonQuery();
					}
				}
				return Ok("Nhà cung cấp đã được tạo.");
			}
			return BadRequest("Nhà cung cấp không hợp lệ.");
		}

		[HttpPut("{maNCC}")]
		public IActionResult UpdateVendor(string maNCC, [FromBody] NhaCungCap vendor)
		{
			using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
			{
				sqlConnection.Open();
				string updateQuery = "UPDATE NhaCungCap SET TenNhaCungCap = @TenNhaCungCap, DiaChi = @DiaChi, " +
					"DienThoai = @DienThoai WHERE MaNCC = @MaNCC";

				using (SqlCommand sqlCommand = new SqlCommand(updateQuery, sqlConnection))
				{
					sqlCommand.Parameters.AddWithValue("@MaNCC", maNCC);
					sqlCommand.Parameters.AddWithValue("@TenNhaCungCap", vendor.TenNhaCungCap);
					sqlCommand.Parameters.AddWithValue("@DiaChi", vendor.DiaChi);
					sqlCommand.Parameters.AddWithValue("@DienThoai", vendor.DienThoai);
					int rowsAffected = sqlCommand.ExecuteNonQuery();

					if (rowsAffected > 0)
					{
						return Ok("Nhà cung cấp đã được cập nhật.");
					}
					return NotFound("Không tìm thấy nhà cung cấp hoặc dữ liệu không hợp lệ.");
				}
			}
		}

		[HttpDelete("{maNCC}")]
		public IActionResult DeleteVendor(string maNCC)
		{
			using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
			{
				sqlConnection.Open();
				string deleteQuery = "DELETE FROM NhaCungCap WHERE MaNCC = @MaNCC";

				using (SqlCommand sqlCommand = new SqlCommand(deleteQuery, sqlConnection))
				{
					sqlCommand.Parameters.AddWithValue("@MaNCC", maNCC);
					int rowsAffected = sqlCommand.ExecuteNonQuery();

					if (rowsAffected > 0)
					{
						return Ok("Nhà cung cấp đã được xóa.");
					}
					return NotFound("Không tìm thấy nhà cung cấp.");
				}
			}
		}
	}
}
