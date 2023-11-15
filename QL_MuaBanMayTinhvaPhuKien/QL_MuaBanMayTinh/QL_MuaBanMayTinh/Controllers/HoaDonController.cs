using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QL_MuaBanMayTinh.IRepositories;
using QL_MuaBanMayTinh.Models;

namespace QL_MuaBanMayTinh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonController : ControllerBase
    {
        private readonly IHoaDon _hoaDonRepo;

        public HoaDonController(IHoaDon repo)
        {
            _hoaDonRepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllHoaDons()
        {
            try
            {
                return Ok(await _hoaDonRepo.GetAllHoaDon());
            }
            catch (Exception ex) { return BadRequest(); }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHoaDonById(string id)
        {
            var sanpham = await _hoaDonRepo.GetHoaDon(id);
            return sanpham == null ? NotFound() : Ok(sanpham);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewHoaDon(HoaDonModel model)
        {
            try
            {
                var newSPid = await _hoaDonRepo.AddHoaDon(model);
                var sp = await _hoaDonRepo.GetHoaDon(newSPid);
                return sp == null ? NotFound() : Ok(sp);
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHoaDon(string id, HoaDonModel model)
        {
            if (id != model.MaHD)
            {
                return NotFound();
            }
            await _hoaDonRepo.UpdateHoaDon(id, model);
            return Ok("Sửa thành công");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleTeHoaDon(string id)
        {
            try
            {
                await _hoaDonRepo.DeleteHoaDon(id);
                return Ok("Xoá thành công");
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
