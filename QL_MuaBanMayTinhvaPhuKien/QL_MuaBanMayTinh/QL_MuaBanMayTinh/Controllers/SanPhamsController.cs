using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QL_MuaBanMayTinh.IRepositories;
using QL_MuaBanMayTinh.Models;

namespace QL_MuaBanMayTinh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamsController : ControllerBase
    {
        private readonly ISanPhamRepositories _sanPhamRepo;

        public SanPhamsController(ISanPhamRepositories repo) { 
            _sanPhamRepo=repo;
        }
        //[HttpGet]
        //public async Task<IActionResult> GetAllSanPhams()
        //{
        //    try
        //    {
        //        return Ok(await _sanPhamRepo.GetAllSanPham());
        //    }
        //    catch (Exception ex) { return BadRequest(); }
        //}
        [HttpGet]
        public async Task<IActionResult> GetAllSanPhams()
        {
            try
            {
                return Ok(await _sanPhamRepo.GetAllCTSanPham());
            }
            catch (Exception ex) { return BadRequest(); }
        }
        [HttpGet("{from},{to}")]
        public async Task<IActionResult> GetAllSanPhamsTheoGia(decimal? from, decimal? to)
        {
            try
            {
                return Ok(await _sanPhamRepo.GetAllCTSanPhamTheoGia(from,to));
            }
            catch (Exception ex) { return BadRequest(); }
        }
        [HttpGet("{sort}")]
        public async Task<IActionResult> SortSanPham(string sort)
        {
            try
            {
                return Ok(await _sanPhamRepo.SortSanPhams(sort));
            }
            catch (Exception ex) { return BadRequest(); }
        }
        [HttpGet("sanphambyname /{name}")]
        public async Task<IActionResult> GetSanPhamByName(string name)
        {
            var sanpham = await _sanPhamRepo.GetCTSanPham(name);
            return sanpham == null ? NotFound() : Ok(sanpham);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewSanPham(SanPhamModel model)
        {
            try
            {
                var newSPid = await _sanPhamRepo.AddSanPham(model);
                var sp =  await _sanPhamRepo.GetSanPham(newSPid);
                return sp == null ? NotFound():Ok(sp);
            }
            catch
            {
                return BadRequest();
            }
            
        }
        [HttpPut("{id}")]
        public async Task <IActionResult> UpdateSanPham(string id, SanPhamModel model)
        {
            if(id != model.MaSP)
            {
                return NotFound();
            }
            await _sanPhamRepo.UpdateSanPham(id, model);
            return Ok("Sửa thành công");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleTeSanPham(string id)
        {
            try
            {
                await _sanPhamRepo.DeleteSanPham(id);
                return Ok("Xoá thành công");
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
