using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QL_MuaBanMayTinh.IRepositories;
using QL_MuaBanMayTinh.Models;

namespace QL_MuaBanMayTinh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamTPController : ControllerBase
    {
        private readonly ISanPhamTPRepo _SanPhamTP;

        public SanPhamTPController(ISanPhamTPRepo repo)
        {
            _SanPhamTP = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSanPhamTPs()
        {
            try
            {
                return Ok(await _SanPhamTP.GetAllSPTP());
            }
            catch (Exception ex) { return BadRequest(); }
        }
        [HttpGet("{masp},{matp}")]
        public async Task<IActionResult> GetSanPhamTPById(string masp,string matp)
        {
            var sanpham = await _SanPhamTP.GetSPTP(masp,matp);
            return sanpham == null ? NotFound() : Ok(sanpham);
        }
        [HttpGet("SPTPByIdSP/{masp}")]
        public async Task<IActionResult> GetSanPhamTPByIdSP(string masp)
        {
            var sanpham = await _SanPhamTP.GetSPTPtheoSP(masp);
            return sanpham == null ? NotFound() : Ok(sanpham);
        }
        [HttpGet("SPTPByIdTP/{matp}")]
        public async Task<IActionResult> GetSanPhamTPByIdTP(string matp)
        {
            var sanpham = await _SanPhamTP.GetSPTPtheoTP(matp);
            return sanpham == null ? NotFound() : Ok(sanpham);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewSPTP(SanPhamThanhPhamModel model)
        {
            try
            {
                var newSPid = await _SanPhamTP.AddSPTP(model);
                //var sp = await _SanPhamTP.GetSPTPtheoSP(newSPid);
                //return sp == null ? NotFound() : Ok(sp);
                return Ok("Thêm thành công");
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpPut("{masp},{matp}")]
        public async Task<IActionResult> UpdateSPTP(string masp,string matp, SanPhamThanhPhamModel model)
        {
            if (masp != model.MaSP || matp != model.MaTP)
            {
                return NotFound();
            }
            await _SanPhamTP.UpdateSPTP(masp,matp, model);
            return Ok("Sửa thành công");
        }
        [HttpDelete("{masp},{matp}")]
        public async Task<IActionResult> DeleTeSPTP(string masp,string matp)
        {
            try
            {
                await _SanPhamTP.DeleteSPTP(masp,matp);
                return Ok("Xoá thành công");
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
