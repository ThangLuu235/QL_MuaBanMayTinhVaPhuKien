using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using QL_MuaBanMayTinhvaPhuKien.Model;

namespace QL_MuaBanMayTinhvaPhuKien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly string _sqlDataSource;

        public PositionController(IConfiguration configuration)
        {
            _configuration = configuration;
            _sqlDataSource = _configuration.GetConnectionString("DefaultConnection"); // Lấy chuỗi kết nối từ appsettings.json
        }
        [HttpGet]
        public IActionResult GetPosition()
        {
            List<ChucVu> positions = new List<ChucVu>();
            string query = "SELECT MaChucVu, TenChucVu FROM ChucVu";

            using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            ChucVu position = new ChucVu
                            {
                                MaChucVu = sqlDataReader.GetString(0),
                                TenChucVu = sqlDataReader.GetString(1)
                            };
                            positions.Add(position);
                        }
                    }
                }
            }

            return Ok(positions);
        }

        [HttpPost]
        public IActionResult CreatePosition([FromBody] ChucVu position)
        {
            if (position != null)
            {
                using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
                {
                    sqlConnection.Open();
                    string insertQuery = "INSERT INTO ChucVu (MaChucVu, TenChucVu) " + "VALUES (@MaChucVu, @TenChucVu)";

                    using (SqlCommand sqlCommand = new SqlCommand(insertQuery, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@MaChucVu", position.MaChucVu);
                        sqlCommand.Parameters.AddWithValue("@TenChucVu", position.TenChucVu);
                        sqlCommand.ExecuteNonQuery();
                    }
                }
                return Ok("Chức vụ đã được tạo.");
            }
            return BadRequest("Chức vụ không hợp lệ.");
        }

        [HttpPut("{maChucVu}")]
        public IActionResult UpdatePosition(string maChucVu, [FromBody] ChucVu position)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
            {
                sqlConnection.Open();
                string updateQuery = "UPDATE ChucVu SET TenChucVu = @TenChucVu " + "WHERE MaChucVu = @MaChucVu";

                using (SqlCommand sqlCommand = new SqlCommand(updateQuery, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@MaChucVU", maChucVu);
                    sqlCommand.Parameters.AddWithValue("@TenChucVu", position.TenChucVu);               
                    int rowsAffected = sqlCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return Ok("Thông tin chức vụ đã được cập nhật.");
                    }
                    return NotFound("Không tìm thấy thông tin chức vụ hoặc dữ liệu không hợp lệ.");
                }
            }
        }

        [HttpDelete("{maChucVu}")]
        public IActionResult DeletePosition(string maChucVu)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
            {
                sqlConnection.Open();
                string deleteQuery = "DELETE FROM ChucVu WHERE MaChucVu = @MaChucVu";

                using (SqlCommand sqlCommand = new SqlCommand(deleteQuery, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@MaChucVu", maChucVu);
                    int rowsAffected = sqlCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return Ok("Thông tin chức vụ đã được xóa.");
                    }
                    return NotFound("Không tìm thấy thông tin chức vụ.");
                }
            }
        }
    }
}
