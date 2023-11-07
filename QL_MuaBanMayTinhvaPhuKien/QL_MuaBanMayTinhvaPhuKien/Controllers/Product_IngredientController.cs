using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using QL_MuaBanMayTinhvaPhuKien.DDbContext;
using QL_MuaBanMayTinhvaPhuKien.Model;

namespace QL_MuaBanMayTinhvaPhuKien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Product_IngredientController : ControllerBase
    {
        private readonly MBDbContext dbContext;
        private readonly IConfiguration _configuration;
        private readonly string _sqlDataSource;
        
        public Product_IngredientController(IConfiguration configuration)
        {
            _configuration = configuration;
            _sqlDataSource = _configuration.GetConnectionString("DefaultConnection"); // Lấy chuỗi kết nối từ appsettings.json
        }
        [HttpGet("maSP")]
        public IActionResult GetProduct_Ingredient(string maSP)
        {
            List<SanPhamThanhPhan> pd_ingredients = new List<SanPhamThanhPhan>();
            string query = "select P.MaSP , P.TenSanPham, PC.TenTP, P.Gia, PPC.SoLuong " +
                "from SanPham as P join SanPhamThanhPhan as PPC on P.MaSP = PPC.MaSP join ThanhPhan as PC on PPC.MaTP = PC.MaTP where P.MaSP = @MaSP";


            using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@MaSP", maSP);
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {

                        while (sqlDataReader.Read())
                        {
                            SanPhamThanhPhan pd_ingredient = new SanPhamThanhPhan()
                            {
                                MaSP = sqlDataReader.GetString(0),
                                SanPham = new SanPham()
                                {
                                    TenSanPham = sqlDataReader.GetString(1),
                                    Gia = sqlDataReader.GetDecimal(3)
                                },

                                ThanhPhan =new ThanhPhan()
                                {
                                    TenTP=sqlDataReader.GetString(2),
                                },
                                SoLuong = sqlDataReader.GetInt32(4),

                            };
                            pd_ingredients.Add(pd_ingredient);
                        }
                    }
                }
            }

            return Ok(pd_ingredients);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct_Ingredient([FromBody] SanPhamThanhPhan pd_ingredient)
        {
            if (pd_ingredient != null)
            {
                using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
                {
                    sqlConnection.Open();
                    string insertQuery = "INSERT INTO SanPhamThanhPhan (MaSP, MaTP, SoLuong) " +
                        "VALUES (@MaSP, @MaTP, @SoLuong)";

                    using (SqlCommand sqlCommand = new SqlCommand(insertQuery, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@MaSP", pd_ingredient.MaSP);
                        sqlCommand.Parameters.AddWithValue("@MaTP", pd_ingredient.MaTP);
                        sqlCommand.Parameters.AddWithValue("@SoLuong", pd_ingredient.SoLuong);

                        sqlCommand.ExecuteNonQuery();
                    }
                }
                return Ok("Thông tin sản phẩm thành phần đã được tạo.");
            }
            return BadRequest("Thông tin sản phẩm thành phần không hợp lệ.");

        }
        [HttpPut("{maSP,maTP}")]
        public IActionResult UpdateProduct_Ingredient(string maTP, string maSP,[FromBody] SanPhamThanhPhan sp_thanhPhan)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
            {
                sqlConnection.Open();
                string updateQuery = "UPDATE SanPhamThanhPhan SET SoLuong = @SoLuong" +
                    "WHERE MaTP = @MaTP and MaSP = @MaSP";

                using (SqlCommand sqlCommand = new SqlCommand(updateQuery, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@MaTP", maTP);
                    sqlCommand.Parameters.AddWithValue("@MaSP", maSP);
                    sqlCommand.Parameters.AddWithValue("@SoLuong", sp_thanhPhan.SoLuong);

                    int rowsAffected = sqlCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return Ok("Danh mục thông tin sản phẩm thành phần đã được cập nhật.");
                    }
                    return NotFound("Không tìm thấy danh mục thông tin sản phẩm thành phần hoặc dữ liệu không hợp lệ.");
                }
            }
        }
        [HttpDelete("{maTP,maSP}")]
        public IActionResult DeleteProduct_Ingredient(string maTP,string maSP)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_sqlDataSource))
            {
                sqlConnection.Open();
                string deleteQuery = "DELETE FROM ThanhPhan WHERE MaTP = @MaTP and MaSP = @MaSP";

                using (SqlCommand sqlCommand = new SqlCommand(deleteQuery, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@MaTP", maTP);
                    sqlCommand.Parameters.AddWithValue("@MaSP", maSP);
                    int rowsAffected = sqlCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return Ok("Thông tin sản phẩm thành phần đã được xóa.");
                    }
                    return NotFound("Không tìm thấy thông tin sản phẩm thành phần.");
                }
            }
        }
    }
}
