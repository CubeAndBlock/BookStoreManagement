using BookStoreManagement.Models;

namespace BookStoreManagement.Interfaces
{
    public interface ITacGiaRepository
    {
        ICollection<TacGia> GetTacGias();
        TacGia GetTacGiaByMaTG(int MaTG);
        TacGia GetTacGiaByTenTG(string  TenTG);
        bool TacGiaExists (int MaTG);
        bool TacGiaCreate(TacGia tacGia);
        bool TacGiaUpdate(TacGia tacGia);
        bool TacGiaDelete(TacGia tacGia);
        bool Save();
    }
}
