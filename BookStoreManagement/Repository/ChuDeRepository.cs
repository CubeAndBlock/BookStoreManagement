using BookStoreManagement.Data;
using BookStoreManagement.Interfaces;
using BookStoreManagement.Models;

namespace BookStoreManagement.Repository
{
    public class ChuDeRepository : IChuDeRepository
    {
        private DataContext _context;
        public ChuDeRepository(DataContext context)
        {
            _context = context;
        }

        public bool ChuDeCreate(ChuDe ChuDe)
        {
            _context.Add(ChuDe);
            return Save();
        }

        public bool ChuDeDelete(ChuDe ChuDe)
        {
            _context.Remove(ChuDe);
            return Save();
        }

        public bool ChuDeExists(int MaCD)
        {
            return _context.ChuDes.Any(c => c.MaChuDe == MaCD);
        }

        public bool ChuDeUpdate(ChuDe ChuDe)
        {
            _context.Update(ChuDe);
            return Save();
        }

        public ChuDe GetChuDeByMaCD(int MaCD)
        {
            return _context.ChuDes.Where(c => c.MaChuDe == MaCD).FirstOrDefault();
        }

        public ChuDe GetChuDeByTenCD(string TenCD)
        {
            return _context.ChuDes.Where(c => c.TenChuDe == TenCD).FirstOrDefault();
        }

        public ICollection<ChuDe> GetChuDes()
        {
            return _context.ChuDes.ToList();
        }

        public ICollection<Sach> GetSachByChuDe(int MaCB)
        {
            return _context.ChuDes.Where(c => c.MaChuDe == MaCB).Select(c => c.Sach).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
