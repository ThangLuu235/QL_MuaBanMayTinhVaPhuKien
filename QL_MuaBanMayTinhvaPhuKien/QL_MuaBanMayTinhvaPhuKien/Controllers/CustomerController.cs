using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using QL_MuaBanMayTinhvaPhuKien.DDbContext;
using QL_MuaBanMayTinhvaPhuKien.Model;

namespace QL_MuaBanMayTinhvaPhuKien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly MBDbContext dbContext;
        private readonly IConfiguration _configuration;
        private readonly string _sqlDataSource;

        public CustomerController(IConfiguration configuration)
        {
            _configuration = configuration;
            _sqlDataSource = _configuration.GetConnectionString("DefaultConnection"); // Lấy chuỗi kết nối từ appsettings.json
        }

        [HttpGet]
        public IActionResult GetCustomer()
        {
            List<KhachHang> customers = new List<KhachHang>();
            string query = "SELECT MaKH, TenKhachHang, GioiTinh, NgaySinh, DiaChi, DienThoai, Email FROM KhachHang";

            using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            KhachHang customer = new KhachHang
                            {
                                MaKH = sqlDataReader.GetString(0),
                                TenKhachHang = sqlDataReader.GetString(1),
                                GioiTinh = sqlDataReader.GetString(2),
                                NgaySinh = sqlDataReader.GetDateTime(3),
                                DiaChi = sqlDataReader.GetString(4),
                                DienThoai = sqlDataReader.GetString(5),
                                Email = sqlDataReader.GetString(6),
                            };
                            customers.Add(customer);
                        }
                    }
                }
            }

            return Ok(customers);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] KhachHang customer)
        {
            if (customer != null)
            {
                using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
                {
                    sqlConnection.Open();
                    string insertQuery = "INSERT INTO KhachHang (MaKH, TenKhachHang, GioiTinh, NgaySinh, DiaChi, DienThoai, Email) " +
                        "VALUES (@MaKH, @TenKhachHang, @GioiTinh, @NgaySinh, @DiaChi, @DienThoai, @Email)";

                    using (SqlCommand sqlCommand = new SqlCommand(insertQuery, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@MaKH", customer.MaKH);
                        sqlCommand.Parameters.AddWithValue("@TenKhachHang", customer.TenKhachHang);
                        sqlCommand.Parameters.AddWithValue("@GioiTinh", customer.GioiTinh);
                        sqlCommand.Parameters.AddWithValue("@NgaySinh", customer.NgaySinh);
                        sqlCommand.Parameters.AddWithValue("@DiaChi", customer.DiaChi);
                        sqlCommand.Parameters.AddWithValue("@DienThoai", customer.DienThoai);
                        sqlCommand.Parameters.AddWithValue("@Email", customer.Email);
                        sqlCommand.ExecuteNonQuery();
                    }
                }
                return Ok("Khách hàng đã được tạo.");
            }
            return BadRequest("Khách hàng không hợp lệ.");

        }
        [HttpPut("{maKH}")]
        public IActionResult UpdateCustomer(string maKH, [FromBody] KhachHang khachHang)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
            {
                sqlConnection.Open();
                string updateQuery = "UPDATE KhachHang SET TenKhachHang = @TenKhachHang, GioiTinh = @GioiTinh, NgaySinh = @NgaySinh, DiaChi = @DiaChi, DienThoai = @DienThoai, " +
                    "Email = @Email " + "WHERE MaKH = @MaKH";

                using (SqlCommand sqlCommand = new SqlCommand(updateQuery, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@MaKH", maKH);
                    sqlCommand.Parameters.AddWithValue("@TenKhachHang", khachHang.TenKhachHang);
                    sqlCommand.Parameters.AddWithValue("@GioiTinh", khachHang.GioiTinh);
                    sqlCommand.Parameters.AddWithValue("@NgaySinh", khachHang.TenKhachHang);
                    sqlCommand.Parameters.AddWithValue("@DiaChi", khachHang.DiaChi);
                    sqlCommand.Parameters.AddWithValue("@DienThoai", khachHang.DienThoai);
                    sqlCommand.Parameters.AddWithValue("@Email", khachHang.Email);
                    int rowsAffected = sqlCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return Ok("Danh mục thông tin khách hàng đã được cập nhật.");
                    }
                    return NotFound("Không tìm thấy danh mục khách hàng hoặc dữ liệu không hợp lệ.");
                }
            }
        }
        [HttpDelete("{maKH}")]
        public IActionResult DeleteCustomer(string maKH)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
            {
                sqlConnection.Open();
                string deleteQuery = "DELETE FROM KhachHang WHERE MaKH = @MaKH";

                using (SqlCommand sqlCommand = new SqlCommand(deleteQuery, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@MaKH", maKH);
                    int rowsAffected = sqlCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return Ok("Khách hàng đã được xóa.");
                    }
                    return NotFound("Không tìm thấy khách hàng.");
                }
            }
        }
    }
}
