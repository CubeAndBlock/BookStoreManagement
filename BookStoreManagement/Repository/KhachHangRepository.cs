using BookStoreManagement.Data;
using BookStoreManagement.Interfaces;
using BookStoreManagement.Models;

namespace BookStoreManagement.Repository
{
    public class KhachHangRepository : IKhachHangRepository
    {
        private DataContext _context;
        public KhachHangRepository(DataContext context)
        {
            _context = context;
        }

        public KhachHang GetKhachHangByMaKH(int MaKH)
        {
            return _context.KhachHangs.Where(k => k.MaKH == MaKH).FirstOrDefault();
        }

        public KhachHang GetKhachHangByTenKH(string TenKH)
        {
            return _context.KhachHangs.Where(k => k.HoTen == TenKH).FirstOrDefault();
        }

        public ICollection<KhachHang> GetKhachHangs()
        {
            return _context.KhachHangs.ToList();
        }

        public bool KhachHangCreate(KhachHang KhachHang)
        {
            _context.Add(KhachHang);
            return Save();
        }

        public bool KhachHangDelete(KhachHang KhachHang)
        {
            _context.Remove(KhachHang);
            return Save();
        }

        public bool KhachHangExists(int MaKH)
        {
            return _context.KhachHangs.Any(k => k.MaKH == MaKH);
        }

        public bool KhachHangUpdate(KhachHang KhachHang)
        {
            _context.Update(KhachHang);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
