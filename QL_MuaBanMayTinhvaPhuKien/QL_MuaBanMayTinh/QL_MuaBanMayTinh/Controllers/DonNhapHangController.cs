using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QL_MuaBanMayTinh.IRepositories;
using QL_MuaBanMayTinh.Models;

namespace QL_MuaBanMayTinh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonNhapHangController : ControllerBase
    {
        private readonly IDonNhapHang _donNhapRepo;

        public DonNhapHangController(IDonNhapHang repo)
        {
            _donNhapRepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDonNhapHangs()
        {
            try
            {
                return Ok(await _donNhapRepo.GetAllDonNhapHang());
            }
            catch (Exception ex) { return BadRequest(); }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDonNhapHangById(string id)
        {
            var sanpham = await _donNhapRepo.GetDonNhapHang(id);
            return sanpham == null ? NotFound() : Ok(sanpham);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewDonNhapHang(DonNhapModel model)
        {
            try
            {
                var newSPid = await _donNhapRepo.AddDonNhapHang(model);
                var sp = await _donNhapRepo.GetDonNhapHang(newSPid);
                return sp == null ? NotFound() : Ok(sp);
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDonNhapHang(string id, DonNhapModel model)
        {
            if (id != model.MaDNH)
            {
                return NotFound();
            }
            await _donNhapRepo.UpdateDonNhapHang(id, model);
            return Ok("Sửa thành công");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleTeDonNhapHang(string id)
        {
            try
            {
                await _donNhapRepo.DeleteDonNhapHang(id);
                return Ok("Xoá thành công");
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
