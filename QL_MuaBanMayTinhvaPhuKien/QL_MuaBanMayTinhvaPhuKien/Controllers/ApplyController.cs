using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using QL_MuaBanMayTinhvaPhuKien.DDbContext;
using QL_MuaBanMayTinhvaPhuKien.Model;

namespace QL_MuaBanMayTinhvaPhuKien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplyController : ControllerBase
    {
        private readonly MBDbContext dbContext;
        private readonly IConfiguration _configuration;
        private readonly string _sqlDataSource;
        public ApplyController(IConfiguration configuration)
        {
            _configuration = configuration;
            _sqlDataSource = _configuration.GetConnectionString("DefaultConnection"); // Lấy chuỗi kết nối từ appsettings.json
        }

        [HttpGet]
        public IActionResult GetApply()
        {
            List<CungUng> applys = new List<CungUng>();
            string query = "SELECT MaCungUng, MaNCC, MaSP, SoLuong, GiaBan, NgayDatHang, NgayGiaoHang FROM CungUng";

            using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            CungUng apply = new CungUng
                            {
                                MaCungUng = sqlDataReader.GetString(0),
                                MaNCC = sqlDataReader.GetString(1),
                                MaSP = sqlDataReader.GetString(2),
                                SoLuong = sqlDataReader.GetInt32(3),
                                GiaBan = sqlDataReader.GetDecimal(4),
                                NgayDatHang = sqlDataReader.GetDateTime(5),
                                NgayGiaoHang = sqlDataReader.GetDateTime(6),
                                
                            };
                            applys.Add(apply);
                        }
                    }
                }
            }

            return Ok(applys);
        }
        [HttpPost]
        public  async Task<IActionResult> CreateApply([FromBody] CungUng apply)
        {
            if (apply != null)
            {
                using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
                {
                    sqlConnection.Open();
                    string insertQuery = "INSERT INTO CungUng (MaCungUng, MaNCC, MaSP, SoLuong, GiaBan, NgayDatHang, NgayGiaoHang) " +
                        "VALUES (@MaCungUng, @MaNCC, @MaSP, @SoLuong, @GiaBan, @NgayDatHang, @NgayGiaoHang)";

                    using (SqlCommand sqlCommand = new SqlCommand(insertQuery, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@MaCungUng", apply.MaCungUng);
                        sqlCommand.Parameters.AddWithValue("@MaNCC", apply.MaNCC);
                        sqlCommand.Parameters.AddWithValue("@MaSP", apply.MaSP);
                        sqlCommand.Parameters.AddWithValue("@SoLuong", apply.SoLuong);
                        sqlCommand.Parameters.AddWithValue("@GiaBan", apply.GiaBan);
                        sqlCommand.Parameters.AddWithValue("@NgayDatHang", apply.NgayDatHang);
                        sqlCommand.Parameters.AddWithValue("@NgayGiaoHang", apply.NgayGiaoHang);
                        sqlCommand.ExecuteNonQuery();
                    }
                }
                return Ok("Thông tin cung ứng đã được tạo.");
            }
            return BadRequest("Thông tin cung ứng không hợp lệ.");
            
        }
        [HttpPut("{maCungUng}")]
        public IActionResult UpdateApply(string maCungUng, [FromBody] CungUng cungUng)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
            {
                sqlConnection.Open();
                string updateQuery = "UPDATE CungUng SET MaNCC = @MaNCC, MaSP = @MaSP, SoLuong = @SoLuong, " +
                    "GiaBan = @GiaBan, NgayDatHang = @NgayDatHang, NgayGiaoHang = @NgayGiaoHang " +
                    "WHERE MaCungUng = @MaCungUng";

                using (SqlCommand sqlCommand = new SqlCommand(updateQuery, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@MaCungUng", maCungUng);
                    sqlCommand.Parameters.AddWithValue("@MaNCC", cungUng.MaNCC);
                    sqlCommand.Parameters.AddWithValue("@MaSP", cungUng.MaSP);
                    sqlCommand.Parameters.AddWithValue("@SoLuong", cungUng.SoLuong);
                    sqlCommand.Parameters.AddWithValue("@GiaBan", cungUng.GiaBan);
                    sqlCommand.Parameters.AddWithValue("@NgayDatHang", cungUng.NgayDatHang);
                    sqlCommand.Parameters.AddWithValue("@NgayGiaoHang", cungUng.NgayGiaoHang);
                    int rowsAffected = sqlCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return Ok("Danh mục thông tin cung ứng đã được cập nhật.");
                    }
                    return NotFound("Không tìm thấy danh mục thông tin cung ứng hoặc dữ liệu không hợp lệ.");
                }
            }
        }
        [HttpDelete("{maCungUng}")]
        public IActionResult DeleteApply(string maCungUng)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
            {
                sqlConnection.Open();
                string deleteQuery = "DELETE FROM CungUng WHERE MaCungUng = @MaCungUng";

                using (SqlCommand sqlCommand = new SqlCommand(deleteQuery, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@MaCungUng", maCungUng);
                    int rowsAffected = sqlCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return Ok("Thông tin cung ứng đã được xóa.");
                    }
                    return NotFound("Không tìm thấy thông tin cung ứng.");
                }
            }
        }
    }
}
