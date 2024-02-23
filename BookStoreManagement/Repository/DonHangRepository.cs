using BookStoreManagement.Data;
using BookStoreManagement.Interfaces;
using BookStoreManagement.Models;

namespace BookStoreManagement.Repository
{
    public class DonHangRepository : IDonHangRepository
    {
        private DataContext _context;
        public DonHangRepository(DataContext context)
        {
            _context = context;
        }

        public bool DonHangCreate(DonHang donHang)
        {
            _context.Add(donHang);
            return Save();
        }

        public bool DonHangDelete(DonHang donHang)
        {
            
            _context.Remove(donHang);
            return Save();
        }

        public bool DonHangExists(int MaDH)
        {
            return _context.DonHangs.Any(d => d.MaDonHang == MaDH);
        }

        public bool DonHangUpdate(DonHang donHang)
        {
            _context.Update(donHang);
            return Save();
        }

        public DonHang GetDonHangByMaDH(int MaDH)
        {
            return _context.DonHangs.Where(d => d.MaDonHang == MaDH).FirstOrDefault();
        }

        public ICollection<DonHang> GetDonHangs()
        {
            return _context.DonHangs.ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
