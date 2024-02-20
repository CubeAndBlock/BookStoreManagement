using BookStoreManagement.Models;

namespace BookStoreManagement.Interfaces
{
    public interface IKhachHangRepository
    {
        ICollection<KhachHang> GetKhachHangs();
        KhachHang GetKhachHangByMaKH(int MaKH);
        KhachHang GetKhachHangByTenKH(string TenKH);
        bool KhachHangExists(int MaKH);
        bool KhachHangCreate(KhachHang KhachHang);
        bool KhachHangDelete(KhachHang KhachHang);
        bool KhachHangUpdate(KhachHang KhachHang);
        bool Save();
    }
}
