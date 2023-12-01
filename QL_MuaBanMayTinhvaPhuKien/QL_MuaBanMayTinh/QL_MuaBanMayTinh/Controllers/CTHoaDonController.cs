using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QL_MuaBanMayTinh.IRepositories;
using QL_MuaBanMayTinh.Models;

namespace QL_MuaBanMayTinh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CTHoaDonController : ControllerBase
    {
        private readonly ICTHoaDon _CTHoaDon;

        public CTHoaDonController(ICTHoaDon repo)
        {
            _CTHoaDon = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCTHoaDons()
        {
            try
            {
                return Ok(await _CTHoaDon.GetAllCTHoaDon());
            }
            catch (Exception ex) { return BadRequest(); }
        }
        [HttpGet("{masp},{mahd}")]
        public async Task<IActionResult> GetCTHoaDonById(string masp, string mahd)
        {
            var sanpham = await _CTHoaDon.GetCTHoaDon(masp, mahd);
            return sanpham == null ? NotFound() : Ok(sanpham);
        }
        [HttpGet("CTHDByIdSP/{masp}")]
        public async Task<IActionResult> GetCTHoaDonByIdSP(string masp)
        {
            var sanpham = await _CTHoaDon.GetCTHoaDontheoSP(masp);
            return sanpham == null ? NotFound() : Ok(sanpham);
        }
        [HttpGet("CTHDByIdHD/{mahd}")]
        public async Task<IActionResult> GetCTHoaDonByIdHD(string mahd)
        {
            var sanpham = await _CTHoaDon.GetCTHoaDontheoHD(mahd);
            return sanpham == null ? NotFound() : Ok(sanpham);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewCTHoaDon(CTHoaDonModel model)
        {
            try
            {
                var newSPid = await _CTHoaDon.AddCTHoaDon(model);
                //var sp = await _SanPhamTP.GetSPTPtheoSP(newSPid);
                //return sp == null ? NotFound() : Ok(sp);
                return Ok("Thêm thành công");
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpPut("{masp},{mahd}")]
        public async Task<IActionResult> UpdateCTHoaDon(string masp, string mahd, CTHoaDonModel model)
        {
            if (masp != model.MaSP || mahd != model.MaHD)
            {
                return NotFound();
            }
            await _CTHoaDon.UpdateCTHoaDon(masp, mahd, model);
            return Ok("Sửa thành công");
        }
        [HttpDelete("{masp},{mahd}")]
        public async Task<IActionResult> DeleTeCTHoaDon(string masp, string mahd)
        {
            try
            {
                await _CTHoaDon.DeleteCTHoaDon(masp, mahd);
                return Ok("Xoá thành công");
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
