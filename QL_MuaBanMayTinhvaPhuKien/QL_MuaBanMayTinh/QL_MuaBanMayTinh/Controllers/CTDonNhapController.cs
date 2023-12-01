using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QL_MuaBanMayTinh.IRepositories;
using QL_MuaBanMayTinh.Models;

namespace QL_MuaBanMayTinh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CTDonNhapController : ControllerBase
    {
        private readonly ICTDonNhap _CTDonNhap;

        public CTDonNhapController(ICTDonNhap repo)
        {
            _CTDonNhap = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCTDonNhaps()
        {
            try
            {
                return Ok(await _CTDonNhap.GetAllCTDonNhap());
            }
            catch (Exception ex) { return BadRequest(); }
        }
        [HttpGet("{masp},{madn}")]
        public async Task<IActionResult> GetCTDonNhapById(string masp, string madn)
        {
            var sanpham = await _CTDonNhap.GetCTDonNhap(masp, madn);
            return sanpham == null ? NotFound() : Ok(sanpham);
        }
        [HttpGet("CTHDByIdSP/{masp}")]
        public async Task<IActionResult> GetCTDonNhapByIdSP(string masp)
        {
            var sanpham = await _CTDonNhap.GetCTDonNhaptheoSP(masp);
            return sanpham == null ? NotFound() : Ok(sanpham);
        }
        [HttpGet("CTHDByIdDN/{madn}")]
        public async Task<IActionResult> GetCTDonNhapByIdDN(string madn)
        {
            var sanpham = await _CTDonNhap.GetCTDonNhaptheoDN(madn);
            return sanpham == null ? NotFound() : Ok(sanpham);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewCTDonNhap(CTDonNhapHangModel model)
        {
            try
            {
                var newSPid = await _CTDonNhap.AddCTDonNhap(model);
                //var sp = await _SanPhamTP.GetSPTPtheoSP(newSPid);
                //return sp == null ? NotFound() : Ok(sp);
                return Ok("Thêm thành công");
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpPut("{masp},{madn}")]
        public async Task<IActionResult> UpdateCTDonNhap(string masp, string madn, CTDonNhapHangModel model)
        {
            if (masp != model.MaSP || madn != model.MaDDH)
            {
                return NotFound();
            }
            await _CTDonNhap.UpdateCTDonNhap(masp, madn, model);
            return Ok("Sửa thành công");
        }
        [HttpDelete("{masp},{madn}")]
        public async Task<IActionResult> DeleTeCTDonNhap(string masp, string madn)
        {
            try
            {
                await _CTDonNhap.GetCTDonNhap(masp, madn);
                return Ok("Xoá thành công");
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
