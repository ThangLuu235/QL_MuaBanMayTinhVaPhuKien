using QL_MuaBanMayTinh.Models;

namespace QL_MuaBanMayTinh.IRepositories
{
    public interface ITTThanhToan
    {
        public Task<List<TTThanhToanModel>> GetAllTTThanhToan();
        public Task<TTThanhToanModel> GetTTThanhToan(string id);
        public Task<string> AddTTThanhToan(TTThanhToanModel model);
        public Task UpdateTTThanhToan(string id, TTThanhToanModel model);
        public Task DeleteTTThanhToan(string id);
    }
}
