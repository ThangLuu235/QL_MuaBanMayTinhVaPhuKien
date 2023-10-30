using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using QL_MuaBanMayTinhvaPhuKien.Model;
using System.Data;

namespace QL_MuaBanMayTinhvaPhuKien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OderController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly string _sqlDataSource;
        public OderController(IConfiguration configuration)
        {
            _configuration = configuration;
            _sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
        }
        [HttpGet]
        public IActionResult GetOder()
        {
            string query = "SELECT MaDH, NgayDatHang, MaKhachHang FROM DonHang";
            List<DonHang> orders = new List<DonHang>();

            using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            DonHang order = new DonHang
                            {
                                MaDH = sqlDataReader.GetString(0),
                                NgayDatHang = sqlDataReader.GetDateTime(1),
                                MaKhachHang = sqlDataReader.GetString(2)
                            };
                            orders.Add(order);
                        }
                    }
                }
            }

            return Ok(orders);
        }
        [HttpPost]
        public IActionResult CreateOrder([FromBody] DonHang donHang)
        {
            if (donHang != null)
            {
                using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
                {
                    sqlConnection.Open();
                    string insertQuery = "INSERT INTO DonHang (MaDH, NgayDatHang,MaKhachHang) VALUES (@MaDH, @NgayDatHang,@MaKhachHang)";

                    using (SqlCommand sqlCommand = new SqlCommand(insertQuery, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@MaDH", donHang.MaDH);
                        sqlCommand.Parameters.AddWithValue("@NgayDatHang", donHang.NgayDatHang);
                        sqlCommand.Parameters.AddWithValue("@MaKhachHang", donHang.MaKhachHang);
                        sqlCommand.ExecuteNonQuery();
                    }
                }
                return Ok("Đơn hàng đã được tạo.");
            }
            return BadRequest("Đơn hàng không hợp lệ.");
        }
        [HttpPut("{maDH}")]
        public IActionResult UpdateDanhMucSanPham(string maDH, [FromBody] DonHang donHang)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
            {
                sqlConnection.Open();
                string updateQuery = "UPDATE DonHang SET NgayDatHang = @NgayDatHang, MaKhachHang = @MaKhachHang WHERE MaDH = @MaDH";

                using (SqlCommand sqlCommand = new SqlCommand(updateQuery, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@MaDH", maDH);
                    sqlCommand.Parameters.AddWithValue("@NgayDatHang", donHang.NgayDatHang);
                    sqlCommand.Parameters.AddWithValue("@MaKhachHang", donHang.MaKhachHang);
                    int rowsAffected = sqlCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return Ok("Danh mục đơn hàng đã được cập nhật.");
                    }
                    return NotFound("Không tìm thấy danh mục đơn hàng hoặc dữ liệu không hợp lệ.");
                }
            }
        }
        [HttpDelete("{maDH}")]
        public IActionResult DeleteDanhMucSanPham(string maDH)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
            {
                sqlConnection.Open();
                string deleteQuery = "DELETE FROM DonHang WHERE MaDH = @MaDH";

                using (SqlCommand sqlCommand = new SqlCommand(deleteQuery, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@MaDH", maDH);
                    int rowsAffected = sqlCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return Ok("Đơn hàng đã được xóa.");
                    }
                    return NotFound("Không tìm thấy đơn hàng.");
                }
            }
        }
    }
}
