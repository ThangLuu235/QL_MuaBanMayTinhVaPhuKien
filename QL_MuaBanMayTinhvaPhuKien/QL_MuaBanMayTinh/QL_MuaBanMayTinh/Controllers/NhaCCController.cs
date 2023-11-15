using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QL_MuaBanMayTinh.IRepositories;
using QL_MuaBanMayTinh.Models;

namespace QL_MuaBanMayTinh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhaCCController : ControllerBase
    {
        private readonly INhaCC _nhaCCRepo;

        public NhaCCController(INhaCC repo)
        {
            _nhaCCRepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllNhaCCs()
        {
            try
            {
                return Ok(await _nhaCCRepo.GetAllNhaCC());
            }
            catch (Exception ex) { return BadRequest(); }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNhaCCById(string id)
        {
            var sanpham = await _nhaCCRepo.GetNhaCC(id);
            return sanpham == null ? NotFound() : Ok(sanpham);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewNhaCC(NhaCCModel model)
        {
            try
            {
                var newSPid = await _nhaCCRepo.AddNhaCC(model);
                var sp = await _nhaCCRepo.GetNhaCC(newSPid);
                return sp == null ? NotFound() : Ok(sp);
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNhaCC(string id, NhaCCModel model)
        {
            if (id != model.MaNCC)
            {
                return NotFound();
            }
            await _nhaCCRepo.UpdateNhaCC(id, model);
            return Ok("Sửa thành công");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleTeNhaCC(string id)
        {
            try
            {
                await _nhaCCRepo.DeleteNhaCC(id);
                return Ok("Xoá thành công");
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
