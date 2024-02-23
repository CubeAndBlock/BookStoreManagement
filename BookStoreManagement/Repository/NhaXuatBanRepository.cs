using BookStoreManagement.Data;
using BookStoreManagement.Interfaces;
using BookStoreManagement.Models;

namespace BookStoreManagement.Repository
{
    public class NhaXuatBanRepository : INhaXuatBanRepository
    {
        private DataContext _context;
        public NhaXuatBanRepository(DataContext context)
        {
            _context = context;
        }
        public NhaXuatBan GetNhaXuatBanByMaNXB(int MaNXB)
        {
            return _context.NhaXuatBans.Where(n => n.MaNXB == MaNXB).FirstOrDefault(); 
        }

        public NhaXuatBan GetNhaXuatBanByTenNXB(string TenNXB)
        {
            return _context.NhaXuatBans.Where(n => n.TenNXB == TenNXB).FirstOrDefault();
        }

        public ICollection<NhaXuatBan> GetNhaXuatBans()
        {
            return _context.NhaXuatBans.ToList();
        }

        public ICollection<Sach> GetSachByNXB(int MaNXB)
        {
            return _context.NhaXuatBans.Where(n => n.MaNXB == MaNXB).Select(n => n.Sach).ToList();
        }
        public bool NhaXuatBanCreate(NhaXuatBan nhaXuatBan)
        {
            _context.NhaXuatBans.Add(nhaXuatBan);
            return Save();
        }

        public bool NhaXuatBanDelete(NhaXuatBan nhaXuatBan)
        {
            _context.NhaXuatBans.Remove(nhaXuatBan);
            return Save();
        }

        public bool NhaXUatBanExists(int MaNXB)
        {
            return _context.NhaXuatBans.Any(n => n.MaNXB == MaNXB);
        }

        public bool NhaXuatBanUpdate(NhaXuatBan nhaXuatBan)
        {
            _context.NhaXuatBans.Update(nhaXuatBan);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
