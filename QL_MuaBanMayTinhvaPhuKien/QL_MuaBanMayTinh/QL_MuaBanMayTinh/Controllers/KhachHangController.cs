using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QL_MuaBanMayTinh.IRepositories;
using QL_MuaBanMayTinh.Models;

namespace QL_MuaBanMayTinh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        private readonly IKhachHang _khachHangRepo;

        public KhachHangController(IKhachHang repo)
        {
            _khachHangRepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllKhachHangs()
        {
            try
            {
                return Ok(await _khachHangRepo.GetAllKhachHang());
            }
            catch (Exception ex) { return BadRequest(); }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetKhachHangById(string id)
        {
            var sanpham = await _khachHangRepo.GetKhachHang(id);
            return sanpham == null ? NotFound() : Ok(sanpham);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewKhachHang(KhachHangModel model)
        {
            try
            {
                var newSPid = await _khachHangRepo.AddKhachHang(model);
                var sp = await _khachHangRepo.GetKhachHang(newSPid);
                return sp == null ? NotFound() : Ok(sp);

            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateKhachHang(string id, KhachHangModel model)
        {
            if (id != model.MaKH)
            {
                return NotFound();
            }
            await _khachHangRepo.UpdateKhachHang(id, model);
            return Ok("Sửa thành công");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleTeKhachHang(string id)
        {
            try
            {
                await _khachHangRepo.DeleteKhachHang(id);
                return Ok("Xoá thành công");
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
