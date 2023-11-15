using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QL_MuaBanMayTinh.IRepositories;
using QL_MuaBanMayTinh.Models;

namespace QL_MuaBanMayTinh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhuyenMaiController : ControllerBase
    {
        private readonly IKhuyenMai _khuyenMaiRepo;

        public KhuyenMaiController(IKhuyenMai repo)
        {
            _khuyenMaiRepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllKhuyenMais()
        {
            try
            {
                return Ok(await _khuyenMaiRepo.GetAllKhuyenMai());
            }
            catch (Exception ex) { return BadRequest(); }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetKhuyenMaiById(string id)
        {
            var sanpham = await _khuyenMaiRepo.GetKhuyenMai(id);
            return sanpham == null ? NotFound() : Ok(sanpham);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewKhuyenMai(KhuyenMaiModel model)
        {
            try
            {
                var newSPid = await _khuyenMaiRepo.AddKhuyenMai(model);
                var sp = await _khuyenMaiRepo.GetKhuyenMai(newSPid);
                return sp == null ? NotFound() : Ok(sp);
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateKhuyenMai(string id, KhuyenMaiModel model)
        {
            if (id != model.MaKhuyenMai)
            {
                return NotFound();
            }
            await _khuyenMaiRepo.UpdateKhuyenMai(id, model);
            return Ok("Sửa thành công");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleTeKhuyenMai(string id)
        {
            try
            {
                await _khuyenMaiRepo.DeleteKhuyenMai(id);
                return Ok("Xoá thành công");
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
