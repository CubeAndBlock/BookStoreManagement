using BookStoreManagement.Models;

namespace BookStoreManagement.Interfaces
{
    public interface ISachRepository
    {
        ICollection<Sach> GetSaches();
        Sach GetSachByMaSach(int MaSach);
        Sach GetSachByTenSach(string TenSach);
        bool SachExists(int MaSach);
        bool SachCreate(Sach sach);
        bool SachUpdate(Sach sach);
        bool SachDelete(int MaSach);
        bool Save();
    }
}
