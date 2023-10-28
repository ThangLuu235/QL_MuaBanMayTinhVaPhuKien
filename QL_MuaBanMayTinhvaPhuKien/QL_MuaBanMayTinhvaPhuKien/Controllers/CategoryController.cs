using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using QL_MuaBanMayTinhvaPhuKien.DDbContext;
using QL_MuaBanMayTinhvaPhuKien.Model;

namespace QL_MuaBanMayTinhvaPhuKien.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly IConfiguration _configuration;
		private readonly string _sqlDataSource;

		public CategoryController(IConfiguration configuration)
		{
			_configuration = configuration;
			_sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
		}

		[HttpGet("checkconnection")]
		public IActionResult CheckConnection()
		{
			using (SqlConnection connection = new SqlConnection(_sqlDataSource))
			{
				try
				{
					connection.Open();
					connection.Close(); // Đóng kết nối sau khi kiểm tra thành công.
					return Ok("Kết nối đến SQL Server thành công!");
				}
				catch (Exception ex)
				{
					return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi khi kết nối đến SQL Server: " + ex.Message);
				}
			}
		}


		[HttpGet]
		public IActionResult GetLoaiHang()
		{
			string query = "SELECT MaDM, TenDanhMuc FROM DanhMucSanPham";
			List<DanhMucSanPham> categories = new List<DanhMucSanPham>();

			using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
			{
				sqlConnection.Open();
				using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
				{
					using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
					{
						while (sqlDataReader.Read())
						{
							DanhMucSanPham category = new DanhMucSanPham
							{
								MaDM = sqlDataReader.GetString(0),
								TenDanhMuc = sqlDataReader.GetString(1)
							};
							categories.Add(category);
						}
					}
				}
			}

			return Ok(categories);
		}

		[HttpPost]
		public IActionResult CreateDanhMucSanPham([FromBody] DanhMucSanPham danhMuc)
		{
			if (danhMuc != null)
			{
				using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
				{
					sqlConnection.Open();
					string insertQuery = "INSERT INTO DanhMucSanPham (MaDM, TenDanhMuc) VALUES (@MaDM, @TenDanhMuc)";

					using (SqlCommand sqlCommand = new SqlCommand(insertQuery, sqlConnection))
					{
						sqlCommand.Parameters.AddWithValue("@MaDM", danhMuc.MaDM);
						sqlCommand.Parameters.AddWithValue("@TenDanhMuc", danhMuc.TenDanhMuc);
						sqlCommand.ExecuteNonQuery();
					}
				}
				return Ok("Danh mục sản phẩm đã được tạo.");
			}
			return BadRequest("Danh mục sản phẩm không hợp lệ.");
		}
		[HttpPut("{maDM}")]
		public IActionResult UpdateDanhMucSanPham(string maDM, [FromBody] DanhMucSanPham danhMuc)
		{
			using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
			{
				sqlConnection.Open();
				string updateQuery = "UPDATE DanhMucSanPham SET TenDanhMuc = @TenDanhMuc WHERE MaDM = @MaDM";

				using (SqlCommand sqlCommand = new SqlCommand(updateQuery, sqlConnection))
				{
					sqlCommand.Parameters.AddWithValue("@MaDM", maDM);
					sqlCommand.Parameters.AddWithValue("@TenDanhMuc", danhMuc.TenDanhMuc);
					int rowsAffected = sqlCommand.ExecuteNonQuery();

					if (rowsAffected > 0)
					{
						return Ok("Danh mục sản phẩm đã được cập nhật.");
					}
					return NotFound("Không tìm thấy danh mục sản phẩm hoặc dữ liệu không hợp lệ.");
				}
			}
		}

		[HttpDelete("{maDM}")]
		public IActionResult DeleteDanhMucSanPham(string maDM)
		{
			using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
			{
				sqlConnection.Open();
				string deleteQuery = "DELETE FROM DanhMucSanPham WHERE MaDM = @MaDM";

				using (SqlCommand sqlCommand = new SqlCommand(deleteQuery, sqlConnection))
				{
					sqlCommand.Parameters.AddWithValue("@MaDM", maDM);
					int rowsAffected = sqlCommand.ExecuteNonQuery();

					if (rowsAffected > 0)
					{
						return Ok("Danh mục sản phẩm đã được xóa.");
					}
					return NotFound("Không tìm thấy danh mục sản phẩm.");
				}
			}
		}



	}
}
