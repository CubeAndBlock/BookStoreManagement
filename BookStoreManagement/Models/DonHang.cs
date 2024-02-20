using System.ComponentModel.DataAnnotations;

namespace BookStoreManagement.Models
{
    public class DonHang
    {
        [Key]
        public int MaDonHang {  get; set; }
        public bool DaThanhToan {  get; set; }
        public DateOnly NgayGiao { get; set; }
        public DateOnly NgayDat { get; set; }
        public string TinhTrangDH {  get; set; }
        public ICollection<KhachHang> KhachHangs { get; set; }
        public ICollection<DonHangSach> DonHangSaches { get; set; }
    }
}
