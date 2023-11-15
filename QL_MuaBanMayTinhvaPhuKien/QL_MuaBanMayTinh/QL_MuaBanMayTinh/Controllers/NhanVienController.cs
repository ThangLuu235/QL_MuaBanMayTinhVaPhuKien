using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QL_MuaBanMayTinh.IRepositories;
using QL_MuaBanMayTinh.Models;

namespace QL_MuaBanMayTinh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        private readonly INhanVien _nhanVienRepo;

        public NhanVienController(INhanVien repo)
        {
            _nhanVienRepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllNhanViens()
        {
            try
            {
                return Ok(await _nhanVienRepo.GetAllNhanVien());
            }
            catch (Exception ex) { return BadRequest(); }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNhanVienById(string id)
        {
            var sanpham = await _nhanVienRepo.GetNhanVien(id);
            return sanpham == null ? NotFound() : Ok(sanpham);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewNhanVien(NhanVienModel model)
        {
            try
            {
                var newSPid = await _nhanVienRepo.AddNhanVien(model);
                var sp = await _nhanVienRepo.GetNhanVien(newSPid);
                return sp == null ? NotFound() : Ok(sp);
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNhanVien(string id, NhanVienModel model)
        {
            if (id != model.MaNV)
            {
                return NotFound();
            }
            await _nhanVienRepo.UpdateNhanVien(id, model);
            return Ok("Sửa thành công");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleTeNhanVien(string id)
        {
            try
            {
                await _nhanVienRepo.DeleteNhanVien(id);
                return Ok("Xoá thành công");
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
