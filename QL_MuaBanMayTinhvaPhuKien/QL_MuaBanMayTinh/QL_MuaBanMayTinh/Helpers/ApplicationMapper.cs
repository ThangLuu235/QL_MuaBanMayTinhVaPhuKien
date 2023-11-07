using AutoMapper;
using QL_MuaBanMayTinh.Data;
using QL_MuaBanMayTinh.Models;

namespace QL_MuaBanMayTinh.Helpers
{
    public class ApplicationMapper:Profile
    {
        public ApplicationMapper() 
        {
            CreateMap<SanPham,SanPhamModel>().ReverseMap();
        }
    }
}
