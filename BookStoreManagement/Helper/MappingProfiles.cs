using AutoMapper;
using BookStoreManagement.Dto;
using BookStoreManagement.Models;

namespace BookStoreManagement.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<KhachHang, KhachHangDto>();
            CreateMap<KhachHangDto, KhachHang>();
            CreateMap<DonHang, DonHangDto>();
            CreateMap<DonHangDto, DonHang>();
            CreateMap<Sach, SachDto>();
            CreateMap<SachDto, Sach>();
            CreateMap<NhaXuatBan, NhaXuatBanDto>();
            CreateMap<NhaXuatBanDto, NhaXuatBan>();
            CreateMap<ChuDe, ChuDeDto>();
            CreateMap<ChuDeDto, ChuDe>();
            CreateMap<TacGia, TacGiaDto>();
            CreateMap<TacGiaDto, TacGia>();
        }
    }
}
