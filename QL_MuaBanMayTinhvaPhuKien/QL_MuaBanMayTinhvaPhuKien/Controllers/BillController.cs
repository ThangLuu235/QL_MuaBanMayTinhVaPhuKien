using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using QL_MuaBanMayTinhvaPhuKien.DDbContext;
using QL_MuaBanMayTinhvaPhuKien.Model;

namespace QL_MuaBanMayTinhvaPhuKien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly MBDbContext dbContext;
        private readonly IConfiguration _configuration;
        private readonly string _sqlDataSource;

        public BillController(IConfiguration configuration)
        {
            _configuration = configuration;
            _sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
        }
        [HttpGet]
        public IActionResult GetBill()
        {
            List<HoaDon> bills = new List<HoaDon>();
            string query = "SELECT MaHD, NgayMua, MaKH, TongTien, TinhTrangThanhToan, NgayThanhToan, NgayNhanHang FROM HoaDon";

            using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            HoaDon bill = new HoaDon
                            {
                                MaHD = sqlDataReader.GetString(0),
                                NgayMua = sqlDataReader.GetDateTime(1),
                                MaKH = sqlDataReader.GetString(2),
                                TongTien = sqlDataReader.GetDecimal(3),
                                TinhTrangThanhToan = sqlDataReader.GetString(4),
                                NgayThanhToan = sqlDataReader.GetDateTime(5),
                                NgayNhanHang = sqlDataReader.GetDateTime(6)

                            };
                            bills.Add(bill);
                        }
                    }
                }
            }

            return Ok(bills);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBill([FromBody] HoaDon bill)
        {
            if (bill != null)
            {
                using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
                {
                    sqlConnection.Open();
                    string insertQuery = "INSERT INTO HOADON (MaHD, NgayMua, MaKH, TongTien, TinhTrangThanhToan, NgayThanhToan, NgayNhanHang) " +
                        "VALUES (@MaHD, @NgayMua, @MaKH, @TongTien, @TinhTrangThanhToan, @NgayThanhToan, @NgayNhanHang)";

                    using (SqlCommand sqlCommand = new SqlCommand(insertQuery, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@MaHD", bill.MaHD);
                        sqlCommand.Parameters.AddWithValue("@NgayMua", bill.NgayMua);
                        sqlCommand.Parameters.AddWithValue("@MaKH", bill.MaKH);
                        sqlCommand.Parameters.AddWithValue("@TongTien", bill.TongTien);
                        sqlCommand.Parameters.AddWithValue("@TinhTrangThanhToan", bill.TinhTrangThanhToan);
                        sqlCommand.Parameters.AddWithValue("@NgayThanhToan", bill.NgayThanhToan);
                        sqlCommand.Parameters.AddWithValue("@NgayNhanHang", bill.NgayNhanHang);
                        sqlCommand.ExecuteNonQuery();
                    }
                }
                return Ok("Hoá đơn đã được tạo.");
            }
            return BadRequest("Hoá đơn không hợp lệ.");

        }
        [HttpPut("{maHD}")]
        public IActionResult UpdateBill(string maHD, [FromBody] HoaDon hoaDon)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
            {
                sqlConnection.Open();
                string updateQuery = "UPDATE HoaDon SET MaHD = @MaHD, NgayMua = @NgayMua, MaKH = @MaKH, " +
                    "TongTien = @TongTien, TinhTrangThanhToan = @TinhTrangThanhToan, NgayThanhToan = @NgayThanhToan, NgayNhanHang = @NgayNhanHang " +
                    "WHERE MaHD = @MaHD";

                using (SqlCommand sqlCommand = new SqlCommand(updateQuery, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@MaHD", maHD);
                    sqlCommand.Parameters.AddWithValue("@NgayMua", hoaDon.NgayMua);
                    sqlCommand.Parameters.AddWithValue("@MaKH", hoaDon.MaKH);
                    sqlCommand.Parameters.AddWithValue("@TongTien", hoaDon.TongTien);
                    sqlCommand.Parameters.AddWithValue("@TinhTrangThanhToan", hoaDon.TinhTrangThanhToan);
                    sqlCommand.Parameters.AddWithValue("@NgayThanhToan", hoaDon.NgayThanhToan);
                    sqlCommand.Parameters.AddWithValue("@NgayNhanHang", hoaDon.NgayNhanHang);
                    int rowsAffected = sqlCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return Ok("Thông tin hoá đơn đã được cập nhật.");
                    }
                    return NotFound("Không tìm thấy danh mục thông tin hoá đơn hoặc dữ liệu không hợp lệ.");
                }
            }
        }
        [HttpDelete("{maHD}")]
        public IActionResult DeleteApply(string maHD)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
            {
                sqlConnection.Open();
                string deleteQuery = "DELETE FROM HoaDon WHERE MaHD = @MaHD";

                using (SqlCommand sqlCommand = new SqlCommand(deleteQuery, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@MaHD", maHD);
                    int rowsAffected = sqlCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return Ok("Thông tin hoá đơn đã được xóa.");
                    }
                    return NotFound("Không tìm thấy thông tin hoá đơn.");
                }
            }
        }
    }
}
