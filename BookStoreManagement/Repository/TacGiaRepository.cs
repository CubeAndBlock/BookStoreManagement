using BookStoreManagement.Data;
using BookStoreManagement.Interfaces;
using BookStoreManagement.Models;

namespace BookStoreManagement.Repository
{
    public class TacGiaRepository : ITacGiaRepository
    {
        private DataContext _context;
        public TacGiaRepository(DataContext context)
        {
            _context = context;
        }
        public TacGia GetTacGiaByMaTG(int MaTG)
        {
            return _context.TacGias.Where(t => t.MaTacGia == MaTG).FirstOrDefault();
        }

        public TacGia GetTacGiaByTenTG(string TenTG)
        {
            return _context.TacGias.Where(t => t.TenTacGia == TenTG).FirstOrDefault();
        }

        public ICollection<TacGia> GetTacGias()
        {
            return _context.TacGias.ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool TacGiaCreate(TacGia tacGia)
        {
            _context.Add(tacGia);
            return Save();
        }

        public bool TacGiaDelete(TacGia tacGia)
        {
            _context.Remove(tacGia);
            return Save();
        }

        public bool TacGiaExists(int MaTG)
        {
            return _context.TacGias.Any(t => t.MaTacGia == MaTG);
        }

        public bool TacGiaUpdate(TacGia tacGia)
        {
            _context.Update(tacGia);
            return Save();
        }
    }
}
