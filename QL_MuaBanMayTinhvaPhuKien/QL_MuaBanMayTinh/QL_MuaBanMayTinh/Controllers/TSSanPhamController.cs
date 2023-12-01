using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QL_MuaBanMayTinh.IRepositories;
using QL_MuaBanMayTinh.Models;

namespace QL_MuaBanMayTinh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TSSanPhamController : ControllerBase
    {
        private readonly ITSSanPham _TSSanPham;

        public TSSanPhamController(ITSSanPham repo)
        {
            _TSSanPham = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTSSanPhams()
        {
            try
            {
                return Ok(await _TSSanPham.GetAllTSSanPham());
            }
            catch (Exception ex) { return BadRequest(); }
        }
        [HttpGet("{masp},{mats}")]
        public async Task<IActionResult> GetDanhMucSPById(string masp, string mats)
        {
            var sanpham = await _TSSanPham.GetTSSanPham(masp, mats);
            return sanpham == null ? NotFound() : Ok(sanpham);
        }
        [HttpGet("TSSanPhamByIdSP/{masp}")]
        public async Task<IActionResult> GetTSSanPhamByIdSP(string masp)
        {
            var sanpham = await _TSSanPham.GetTSSanPhamByIdSP(masp);
            return sanpham == null ? NotFound() : Ok(sanpham);
        }
        [HttpGet("TSSanPhamByIdTS/{mats}")]
        public async Task<IActionResult> GetTSSanPhamById(string mats)
        {
            var sanpham = await _TSSanPham.GetTSSanPhamByIdThongSo( mats);
            return sanpham == null ? NotFound() : Ok(sanpham);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewTSSanPham(TSSanPhamModel model)
        {
            try
            {
                var newSPid = await _TSSanPham.AddTSSanPham(model);
                //var sp = await _TSSanPham.GetTSSanPhamByIdSP(newSPid);
                //return sp == null ? NotFound() : Ok(sp);
                return Ok("Thêm thành công");
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpPut("{masp},{matp}")]
        public async Task<IActionResult> UpdateTSSanPham(string masp, string matp, TSSanPhamModel model)
        {
            if (masp != model.MaSP || matp != model.MaThongSo)
            {
                return NotFound();
            }
            await _TSSanPham.UpdateTSSanPham(masp, matp, model);
            return Ok("Sửa thành công");
        }
        [HttpDelete("{masp},{matp}")]
        public async Task<IActionResult> DeleTeTSSanPham(string masp, string matp)
        {
            try
            {
                await _TSSanPham.DeleteTSSanPham(masp, matp);
                return Ok("Xoá thành công");
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
