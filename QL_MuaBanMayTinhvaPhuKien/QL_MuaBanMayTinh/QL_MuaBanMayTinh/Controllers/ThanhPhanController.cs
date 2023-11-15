using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QL_MuaBanMayTinh.IRepositories;
using QL_MuaBanMayTinh.Models;

namespace QL_MuaBanMayTinh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThanhPhanController : ControllerBase
    {
        private readonly IThanhPhanRepo _thanhPhanRepo;

        public ThanhPhanController(IThanhPhanRepo repo)
        {
            _thanhPhanRepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllThanhPhans()
        {
            try
            {
                return Ok(await _thanhPhanRepo.GetAllThanhPhan());
            }
            catch (Exception ex) { return BadRequest(); }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetThanhPhanById(string id)
        {
            var sanpham = await _thanhPhanRepo.GetThanhPhan(id);
            return sanpham == null ? NotFound() : Ok(sanpham);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewThanhPhan(ThanhPhanModel model)
        {
            try
            {
                var newSPid = await _thanhPhanRepo.AddThanhPhan(model);
                var sp = await _thanhPhanRepo.GetThanhPhan(newSPid);
                return sp == null ? NotFound() : Ok(sp);
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateThanhPhan(string id, ThanhPhanModel model)
        {
            if (id != model.MaTP)
            {
                return NotFound();
            }
            await _thanhPhanRepo.UpdateThanhPhan(id, model);
            return Ok("Sửa thành công");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleTeThanhPhan(string id)
        {
            try
            {
                await _thanhPhanRepo.DeleteThanhPhan(id);
                return Ok("Xoá thành công");
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
