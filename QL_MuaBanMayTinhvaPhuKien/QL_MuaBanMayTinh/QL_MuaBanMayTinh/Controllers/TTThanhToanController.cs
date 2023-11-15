using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QL_MuaBanMayTinh.IRepositories;
using QL_MuaBanMayTinh.Models;

namespace QL_MuaBanMayTinh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TTThanhToanController : ControllerBase
    {
        private readonly ITTThanhToan _TTThanhToanRepo;

        public TTThanhToanController(ITTThanhToan repo)
        {
            _TTThanhToanRepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTTThanhToans()
        {
            try
            {
                return Ok(await _TTThanhToanRepo.GetAllTTThanhToan());
            }
            catch (Exception ex) { return BadRequest(); }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTTThanhToanById(string id)
        {
            var sanpham = await _TTThanhToanRepo.GetTTThanhToan(id);
            return sanpham == null ? NotFound() : Ok(sanpham);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewTTThanhToan(TTThanhToanModel model)
        {
            try
            {
                var newSPid = await _TTThanhToanRepo.AddTTThanhToan(model);
                var sp = await _TTThanhToanRepo.GetTTThanhToan(newSPid);
                return sp == null ? NotFound() : Ok(sp);
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTTThanhToan(string id, TTThanhToanModel model)
        {
            if (id != model.MaTTTT)
            {
                return NotFound();
            }
            await _TTThanhToanRepo.UpdateTTThanhToan(id, model);
            return Ok("Sửa thành công");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleTeTTThanhToan(string id)
        {
            try
            {
                await _TTThanhToanRepo.DeleteTTThanhToan(id);
                return Ok("Xoá thành công");
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
