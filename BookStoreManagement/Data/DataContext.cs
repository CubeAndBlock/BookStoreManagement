using BookStoreManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BookStoreManagement.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { 
            
        }
        public DbSet<KhachHang> KhachHangs {  get; set; }
        public DbSet<DonHang> DonHangs { get; set;}
        public DbSet<Sach> Sachs { get; set;}
        public DbSet<ChuDe> ChuDes { get; set;}
        public DbSet<TacGia> TacGias { get; set;}
        public DbSet<NhaXuatBan> NhaXuatBans { get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TacGiaSach>()
                .HasKey(ts => new { ts.MaTacGia, ts.MacSach });
            modelBuilder.Entity<TacGiaSach>()
                .HasOne(t => t.TacGia)
                .WithMany(ts => ts.TacGiaSaches)
                .HasForeignKey(t => t.MaTacGia)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<TacGiaSach>()
                .HasOne(s => s.Sach)
                .WithMany(ts => ts.TacGiaSaches)
                .HasForeignKey(s => s.MacSach)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DonHangSach>()
                .HasKey(ds => new { ds.MaDonHang, ds.MaSach });
            modelBuilder.Entity<DonHangSach>()
                .HasOne(d => d.DonHang)
                .WithMany(ds => ds.DonHangSaches)
                .HasForeignKey(d => d.MaDonHang)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<DonHangSach>()
                .HasOne(s => s.Sach)
                .WithMany(ds => ds.DonHangSaches)
                .HasForeignKey(s => s.MaSach)
                .OnDelete(DeleteBehavior.Cascade);
                
        }
    }
}
