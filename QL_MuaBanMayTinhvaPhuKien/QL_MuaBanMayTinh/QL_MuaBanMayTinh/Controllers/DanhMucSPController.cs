using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QL_MuaBanMayTinh.IRepositories;
using QL_MuaBanMayTinh.Models;

namespace QL_MuaBanMayTinh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhMucSPController : ControllerBase
    {
        private readonly IDanhMucSPRepo _danhMucSP;

        public DanhMucSPController(IDanhMucSPRepo repo)
        {
            _danhMucSP = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDanhMucSPs()
        {
            try
            {
                return Ok(await _danhMucSP.GetAllDanhMucSP());
            }
            catch (Exception ex) { return BadRequest(); }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDanhMucSPById(string id)
        {
            var sanpham = await _danhMucSP.GetDanhMucSP(id);
            return sanpham == null ? NotFound() : Ok(sanpham);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewDanhMucSP(DanhMucSPModel model)
        {
            try
            {
                var newSPid = await _danhMucSP.AddDanhMucSP(model);
                var sp = await _danhMucSP.GetDanhMucSP(newSPid);
                return sp == null ? NotFound() : Ok(sp);
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDanhMucSP(string id, DanhMucSPModel model)
        {
            if (id != model.MaDM)
            {
                return NotFound();
            }
            await _danhMucSP.UpdateDanhMucSP(id, model);
            return Ok("Sửa thành công");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleTeDanhMucSP(string id)
        {
            try
            {
                await _danhMucSP.DeleteDanhMucSP(id);
                return Ok("Xoá thành công");
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
