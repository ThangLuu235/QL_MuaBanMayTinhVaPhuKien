using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using QL_MuaBanMayTinhvaPhuKien.DDbContext;
using QL_MuaBanMayTinhvaPhuKien.Model;

namespace QL_MuaBanMayTinhvaPhuKien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly MBDbContext dbContext;
        private readonly IConfiguration _configuration;
        private readonly string _sqlDataSource;
        public StaffController(MBDbContext _dbContext, IConfiguration _configuration)
        {

            this.dbContext = _dbContext;
            this._configuration = _configuration;
            _sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            //this._sqlDataSource = _sqlDataSource;
        }
        [HttpGet]
        public IActionResult GetStaff()
        {
            List<NhanVien> staffs = new List<NhanVien>();
            string query = "SELECT MaNV, HoTen, DiaChi, DienThoai, Email, MatKhau, MaChucVu FROM NhanVien";

            using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            NhanVien staff = new NhanVien
                            {
                                MaNV = sqlDataReader.GetString(0),
                                HoTen = sqlDataReader.GetString(1),
                                DiaChi = sqlDataReader.GetString(2),
                                DienThoai = sqlDataReader.GetString(3),
                                Email = sqlDataReader.GetString(4),
                                MatKhau = sqlDataReader.GetString(5),
                                MaChucVu = sqlDataReader.GetString(6),

                            };
                            staffs.Add(staff);
                        }
                    }
                }
            }

            return Ok(staffs);
        }
        [HttpPost]
        public async Task<IActionResult> CreateStaff([FromBody] NhanVien staff)
        {
            if (staff != null)
            {
                using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
                {
                    sqlConnection.Open();
                    string insertQuery = "INSERT INTO NhanVien (MaNV, HoTen, DiaChi, DienThoai, Email, MatKhau, MaChucVu) " +
                        "VALUES (@MaNV, @HoTen, @DiaChi, @DienThoai, @Email, @MatKhau, @MaChucVu)";

                    using (SqlCommand sqlCommand = new SqlCommand(insertQuery, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@MaNV", staff.MaNV);
                        sqlCommand.Parameters.AddWithValue("@HoTen", staff.HoTen);
                        sqlCommand.Parameters.AddWithValue("@DiaChi", staff.DiaChi);
                        sqlCommand.Parameters.AddWithValue("@DienThoai", staff.DienThoai);
                        sqlCommand.Parameters.AddWithValue("@Email", staff.Email);
                        sqlCommand.Parameters.AddWithValue("@MatKhau", staff.MatKhau);
                        sqlCommand.Parameters.AddWithValue("@MaChucVu", staff.MaChucVu);
                        sqlCommand.ExecuteNonQuery();
                    }
                }
                return Ok("Nhân viên đã được tạo.");
            }
            return BadRequest("Nhân viên không hợp lệ.");

        }
        [HttpPut("{maNV}")]
        public IActionResult UpdateStaff(string maNV, [FromBody] NhanVien nhanVien)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
            {
                sqlConnection.Open();
                string updateQuery = "UPDATE NhanVien SET HoTen = @HoTen, DiaChi = @DiaChi, DienThoai = @DienThoai, " +
                    "Email = @Email, MatKhau = @MatKhau, MaChucVu = @MaChucVu " +
                    "WHERE MaNV = @MaNV";

                using (SqlCommand sqlCommand = new SqlCommand(updateQuery, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@MaNV", maNV);
                    sqlCommand.Parameters.AddWithValue("@HoTen", nhanVien.HoTen);
                    sqlCommand.Parameters.AddWithValue("@DiaChi", nhanVien.DiaChi);
                    sqlCommand.Parameters.AddWithValue("@DienThoai", nhanVien.DienThoai);
                    sqlCommand.Parameters.AddWithValue("@Email", nhanVien.Email);
                    sqlCommand.Parameters.AddWithValue("@MatKhau", nhanVien.MatKhau);
                    sqlCommand.Parameters.AddWithValue("@MaChucVu", nhanVien.MaChucVu);
                    int rowsAffected = sqlCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return Ok("Danh mục thông tin nhân viên đã được cập nhật.");
                    }
                    return NotFound("Không tìm thấy danh mục nhân viên hoặc dữ liệu không hợp lệ.");
                }
            }
        }
        [HttpDelete("{maNV}")]
        public IActionResult DeleteStaff(string maNV)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
            {
                sqlConnection.Open();
                string deleteQuery = "DELETE FROM NhanVien WHERE MaNV = @MaNV";

                using (SqlCommand sqlCommand = new SqlCommand(deleteQuery, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@MaNV", maNV);
                    int rowsAffected = sqlCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return Ok("Nhân viên đã được xóa.");
                    }
                    return NotFound("Không tìm thấy nhân viên.");
                }
            }
        }
    }
}
