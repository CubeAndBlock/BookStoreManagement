using BookStoreManagement.Models;

namespace BookStoreManagement.Interfaces
{
    public interface INhaXuatBanRepository
    {
        ICollection<NhaXuatBan> GetNhaXuatBans();
        NhaXuatBan GetNhaXuatBanByMaNXB(int MaNXB);
        NhaXuatBan GetNhaXuatBanByTenNXB(string TenNXB);
        ICollection<Sach> GetSachByNXB(int MaNXB);
        bool NhaXUatBanExists(int MaNXB);
        bool NhaXuatBanCreate(NhaXuatBan nhaXuatBan);
        bool NhaXuatBanUpdate(NhaXuatBan nhaXuatBan);
        bool NhaXuatBanDelete(NhaXuatBan nhaXuatBan);
        bool Save();
    }
}
