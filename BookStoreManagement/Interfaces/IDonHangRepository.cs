using BookStoreManagement.Models;

namespace BookStoreManagement.Interfaces
{
    public interface IDonHangRepository
    {
        ICollection<DonHang> GetDonHangs();
        DonHang GetDonHangByMaDH(int MaDH);
        DonHang GetDonHangByTenDH(string TenDH);
        bool DonHangExists(int MaDH);
        bool DonHangCreate(DonHang donHang);
        bool DonHangUpdate(DonHang donHang);
        bool DonHangDelete(DonHang donHang);
        bool Save();
    }
}
