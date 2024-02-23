using BookStoreManagement.Data;
using BookStoreManagement.Interfaces;
using BookStoreManagement.Models;

namespace BookStoreManagement.Repository
{
    public class SachRepository : ISachRepository
    {
        private DataContext _context;
        public SachRepository(DataContext context)
        {
            _context = context;
        }

        public Sach GetSachByMaSach(int MaSach)
        {
            return _context.Sachs.Where(s => s.MaSach == MaSach).FirstOrDefault();
        }

        public Sach GetSachByTenSach(string TenSach)
        {
            return _context.Sachs.Where(s => s.TenSach == TenSach).FirstOrDefault();
        }

        public ICollection<Sach> GetSaches()
        {
            return _context.Sachs.ToList();
        }

        public bool SachCreate(Sach sach)
        {
            _context.Sachs.Add(sach);
            return Save();
        }

        public bool SachDelete(Sach sach)
        {
            _context.Sachs.Remove(sach);
            return Save();
        }

        public bool SachExists(int MaSach)
        {
            return _context.Sachs.Any(s => s.MaSach == MaSach);
        }

        public bool SachUpdate(Sach sach)
        {
            _context.Sachs.Update(sach);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
