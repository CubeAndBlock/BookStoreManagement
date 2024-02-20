using BookStoreManagement.Models;

namespace BookStoreManagement.Interfaces
{
    public interface IChuDeRepository
    {
        ICollection<ChuDe> GetChuDes();
        ChuDe GetChuDeByMaCD(int MaCD);
        ChuDe GetChuDeByTenCD(string TenCD);
        bool ChuDeExists(int MaCD);
        bool ChuDeCreate(ChuDe ChuDe);
        bool ChuDeDelete(ChuDe ChuDe);
        bool ChuDeUpdate(ChuDe ChuDe);
        bool Save();
    }
}
