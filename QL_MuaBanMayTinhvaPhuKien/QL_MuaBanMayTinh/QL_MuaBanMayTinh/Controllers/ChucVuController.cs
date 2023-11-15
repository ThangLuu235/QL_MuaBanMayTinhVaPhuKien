using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QL_MuaBanMayTinh.IRepositories;
using QL_MuaBanMayTinh.Models;

namespace QL_MuaBanMayTinh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChucVuController : ControllerBase
    {
        private readonly IChucVu _chucVuRepo;

        public ChucVuController(IChucVu repo)
        {
            _chucVuRepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllChucVus()
        {
            try
            {
                return Ok(await _chucVuRepo.GetAllChucVu());
            }
            catch (Exception ex) { return BadRequest(); }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetChucVuById(string id)
        {
            var sanpham = await _chucVuRepo.GetChucVu(id);
            return sanpham == null ? NotFound() : Ok(sanpham);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewChucVu(ChucVuModel model)
        {
            try
            {
                var newSPid = await _chucVuRepo.AddChucVu(model);
                var sp = await _chucVuRepo.GetChucVu(newSPid);
                return sp == null ? NotFound() : Ok(sp);
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateChucVu(string id, ChucVuModel model)
        {
            if (id != model.MaChucVu)
            {
                return NotFound();
            }
            await _chucVuRepo.UpdateChucVu(id, model);
            return Ok("Sửa thành công");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleTeChucVu(string id)
        {
            try
            {
                await _chucVuRepo.DeleteChucVu(id);
                return Ok("Xoá thành công");
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
