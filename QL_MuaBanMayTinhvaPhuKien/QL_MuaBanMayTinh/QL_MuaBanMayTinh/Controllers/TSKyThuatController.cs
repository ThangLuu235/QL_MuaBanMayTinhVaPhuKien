using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QL_MuaBanMayTinh.IRepositories;
using QL_MuaBanMayTinh.Models;

namespace QL_MuaBanMayTinh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TSKyThuatController : ControllerBase
    {
        private readonly ITSKyThuat _TSKyThuatRepo;

        public TSKyThuatController(ITSKyThuat repo)
        {
            _TSKyThuatRepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTSKyThuats()
        {
            try
            {
                return Ok(await _TSKyThuatRepo.GetAllTKKyThuat());
            }
            catch (Exception ex) { return BadRequest(); }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTSKyThuatById(string id)
        {
            var sanpham = await _TSKyThuatRepo.GetTKKyThuat(id);
            return sanpham == null ? NotFound() : Ok(sanpham);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewTSKyThuat(TSKyThuatModel model)
        {
            try
            {
                var newSPid = await _TSKyThuatRepo.AddTKKyThuat(model);
                var sp = await _TSKyThuatRepo.GetTKKyThuat(newSPid);
                return sp == null ? NotFound() : Ok(sp);
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTSKyThuat(string id, TSKyThuatModel model)
        {
            if (id != model.MaThongSo)
            {
                return NotFound();
            }
            await _TSKyThuatRepo.UpdateTKKyThuat(id, model);
            return Ok("Sửa thành công");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleTeTSKyThuat(string id)
        {
            try
            {
                await _TSKyThuatRepo.DeleteTKKyThuat(id);
                return Ok("Xoá thành công");
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
