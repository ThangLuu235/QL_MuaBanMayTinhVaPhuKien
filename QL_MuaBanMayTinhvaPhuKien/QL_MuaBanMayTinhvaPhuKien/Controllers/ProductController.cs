﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using QL_MuaBanMayTinhvaPhuKien.Model;

namespace QL_MuaBanMayTinhvaPhuKien.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IConfiguration _configuration;
		private readonly string _sqlDataSource;

		public ProductController(IConfiguration configuration)
		{
			_configuration = configuration;
			_sqlDataSource = _configuration.GetConnectionString("DefaultConnection"); // Lấy chuỗi kết nối từ appsettings.json
		}

		[HttpGet]
		public IActionResult GetProducts()
		{
			List<SanPham> products = new List<SanPham>();
			string query = "select P.*, PC.TenTP, PPC.SoLuong " +
				"from SanPham as P join SanPhamThanhPhan as PPC on P.MaSP = PPC.MaSP join ThanhPhan as PC on PPC.MaTP = PC.MaTP\r\n";

			using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
			{
				sqlConnection.Open();
				using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
				{
					using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
					{
						while (sqlDataReader.Read())
						{
							SanPham product = new SanPham
							{
								MaSP = sqlDataReader.GetString(0),
								TenSanPham = sqlDataReader.GetString(1),
                                MaDM = sqlDataReader.GetString(3),
                                MaNSX = sqlDataReader.GetString(2),
                                MoTa = sqlDataReader.GetString(4),
								Gia = sqlDataReader.GetDecimal(5),
								HinhAnh = sqlDataReader.GetString(6),
								ThanhPhan = new ThanhPhan()
								{
									TenTP = sqlDataReader.GetString(7)
                                },
								SanPhamThanhPhan = new SanPhamThanhPhan()
								{
									SoLuong = sqlDataReader.GetInt32(8)
                                }
								
							};
							products.Add(product);
						}
					}
				}
			}

			return Ok(products);
		}

		[HttpPost]
		public IActionResult CreateProduct([FromBody] SanPham product)
		{
			if (product != null)
			{
				using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
				{
					sqlConnection.Open();
					string insertQuery = "INSERT INTO SanPham (MaSP, TenSanPham, MoTa, Gia, HinhAnh, MaDM, MaNSX) " +
						"VALUES (@MaSP, @TenSanPham, @MoTa, @Gia, @HinhAnh, @MaDM, @MaNSX)";

					using (SqlCommand sqlCommand = new SqlCommand(insertQuery, sqlConnection))
					{
						sqlCommand.Parameters.AddWithValue("@MaSP", product.MaSP);
						sqlCommand.Parameters.AddWithValue("@TenSanPham", product.TenSanPham);
						sqlCommand.Parameters.AddWithValue("@MoTa", product.MoTa);
						sqlCommand.Parameters.AddWithValue("@Gia", product.Gia);
						//sqlCommand.Parameters.AddWithValue("@SoLuongTrongKho", product.SoLuongTrongKho);
						sqlCommand.Parameters.AddWithValue("@HinhAnh", product.HinhAnh);
						sqlCommand.Parameters.AddWithValue("@MaDM", product.MaDM);
						//sqlCommand.Parameters.AddWithValue("@MaThongSo", product.MaThongSo);
						sqlCommand.Parameters.AddWithValue("@MaNSX", product.MaNSX);
						sqlCommand.ExecuteNonQuery();
					}
				}
				return Ok("Sản phẩm đã được tạo.");
			}
			return BadRequest("Sản phẩm không hợp lệ.");
		}

		[HttpPut("{maSP}")]
		public IActionResult UpdateProduct(string maSP, [FromBody] SanPham product)
		{
			using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
			{
				sqlConnection.Open();
				string updateQuery = "UPDATE SanPham SET TenSanPham = @TenSanPham, MoTa = @MoTa, Gia = @Gia, " +
					"HinhAnh = @HinhAnh, MaDM = @MaDM, MaNSX = @MaNSX " +
					"WHERE MaSP = @MaSP";

				using (SqlCommand sqlCommand = new SqlCommand(updateQuery, sqlConnection))
				{
					sqlCommand.Parameters.AddWithValue("@MaSP", maSP);
					sqlCommand.Parameters.AddWithValue("@TenSanPham", product.TenSanPham);
					sqlCommand.Parameters.AddWithValue("@MoTa", product.MoTa);
					sqlCommand.Parameters.AddWithValue("@Gia", product.Gia);
					sqlCommand.Parameters.AddWithValue("@HinhAnh", product.HinhAnh);
					sqlCommand.Parameters.AddWithValue("@MaDM", product.MaDM);
					sqlCommand.Parameters.AddWithValue("@MaNSX", product.MaNSX);
					int rowsAffected = sqlCommand.ExecuteNonQuery();

					if (rowsAffected > 0)
					{
						return Ok("Sản phẩm đã được cập nhật.");
					}
					return NotFound("Không tìm thấy sản phẩm hoặc dữ liệu không hợp lệ.");
				}
			}
		}

		[HttpDelete("{maSP}")]
		public IActionResult DeleteProduct(string maSP)
		{
			using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
			{
				sqlConnection.Open();
				string deleteQuery = "DELETE FROM SanPham WHERE MaSP = @MaSP";

				using (SqlCommand sqlCommand = new SqlCommand(deleteQuery, sqlConnection))
				{
					sqlCommand.Parameters.AddWithValue("@MaSP", maSP);
					int rowsAffected = sqlCommand.ExecuteNonQuery();

					if (rowsAffected > 0)
					{
						return Ok("Sản phẩm đã được xóa.");
					}
					return NotFound("Không tìm thấy sản phẩm.");
				}
			}
		}
	}
}
