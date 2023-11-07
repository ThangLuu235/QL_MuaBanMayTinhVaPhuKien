using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using QL_MuaBanMayTinhvaPhuKien.DDbContext;
using QL_MuaBanMayTinhvaPhuKien.Model;

namespace QL_MuaBanMayTinhvaPhuKien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : Controller
    {
       
        private readonly MBDbContext dbContext;
        private readonly IConfiguration _configuration;
        private readonly string _sqlDataSource;
        public IngredientController(IConfiguration configuration)
        {
            _configuration = configuration;
            _sqlDataSource = _configuration.GetConnectionString("DefaultConnection"); // Lấy chuỗi kết nối từ appsettings.json
        }
        [HttpGet]
        public IActionResult GetIngredient()
        {
            List<ThanhPhan> ingredients = new List<ThanhPhan>();
            string query = "SELECT MaTP, TenTP, SoLuongTonKho, SoSeri, GiaTP FROM ThanhPhan";

            using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            ThanhPhan ingredient = new ThanhPhan
                            {
                                MaTP = sqlDataReader.GetString(0),
                                TenTP = sqlDataReader.GetString(1),
                                SLTonKho = sqlDataReader.GetInt32(2),
                                SoSeri = sqlDataReader.GetString(3),
                                GiaTP=sqlDataReader.GetDecimal(4)

                            };
                            ingredients.Add(ingredient);
                        }
                    }
                }
            }

            return Ok(ingredients);
        }
        [HttpPost]
        public async Task<IActionResult> CreateIngredient([FromBody] ThanhPhan ingredient)
        {
            if (ingredient != null)
            {
                using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
                {
                    sqlConnection.Open();
                    string insertQuery = "INSERT INTO ThanhPhan (MaTP, TenTP, SoLuongTonKho,SoSeri,GiaTP) " +
                        "VALUES (@MaTP, @TenTP, @SoLuongTonKho, @SoSeri, @GiaTP)";

                    using (SqlCommand sqlCommand = new SqlCommand(insertQuery, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@MaTP", ingredient.MaTP);
                        sqlCommand.Parameters.AddWithValue("@TenTP", ingredient.TenTP);
                        sqlCommand.Parameters.AddWithValue("@SoLuongTonKho", ingredient.SLTonKho);
                        sqlCommand.Parameters.AddWithValue("@SoSeri", ingredient.SoSeri);
                        sqlCommand.Parameters.AddWithValue("@GiaTP", ingredient.GiaTP);

                        sqlCommand.ExecuteNonQuery();
                    }
                }
                return Ok("Thông tin thành phần đã được tạo.");
            }
            return BadRequest("Thông tin thành phần không hợp lệ.");

        }
        [HttpPut("{maTP}")]
        public IActionResult UpdateApply(string maTP, [FromBody] ThanhPhan thanhPhan)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
            {
                sqlConnection.Open();
                string updateQuery = "UPDATE ThanhPhan SET TenTP = @TenTP, SoLuongTonKho = @SoLuongTonKho"+
                    "SoSeri = @SoSeri, GiaTP = @GiaTP"+
                    "WHERE MaTP = @MaTP";

                using (SqlCommand sqlCommand = new SqlCommand(updateQuery, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@MaTP", maTP);
                    sqlCommand.Parameters.AddWithValue("@TenTP", thanhPhan.TenTP);
                    sqlCommand.Parameters.AddWithValue("@SoLuongTonKho", thanhPhan.SLTonKho);
                    sqlCommand.Parameters.AddWithValue("@SoSeri", thanhPhan.SoSeri);
                    sqlCommand.Parameters.AddWithValue("@GiaTP", thanhPhan.GiaTP);

                    int rowsAffected = sqlCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return Ok("Danh mục thông tin thành phần đã được cập nhật.");
                    }
                    return NotFound("Không tìm thấy danh mục thông tin thành phần hoặc dữ liệu không hợp lệ.");
                }
            }
        }
        [HttpDelete("{maTP}")]
        public IActionResult DeleteApply(string maTP)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
            {
                sqlConnection.Open();
                string deleteQuery = "DELETE FROM ThanhPhan WHERE MaTP = @MaTP";

                using (SqlCommand sqlCommand = new SqlCommand(deleteQuery, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@MaTP", maTP);
                    int rowsAffected = sqlCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return Ok("Thông tin thành phần đã được xóa.");
                    }
                    return NotFound("Không tìm thấy thông tin thành phần.");
                }
            }
        }
    }
}
