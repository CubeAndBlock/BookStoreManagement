using System.ComponentModel.DataAnnotations;
namespace BookStoreManagement.Models
{
    public class Sach
    {
        [Key]
        public int MaSach {  get; set; }
        public string? TenSach {  get; set; }
        public int? SoLuongTon {  get; set; }
        public DateTime NgayCapNhat {  get; set; }
        public string? AnhBia {  get; set; }
        public string? MoTa {  get; set; }
        public double GiaBan {  get; set; }
        public ICollection<ChuDe> ChuDes { get; set; }
        public ICollection<NhaXuatBan> NhaXuatBans { get; set; }
        public ICollection<TacGiaSach> TacGiaSaches { get; set; }
        public ICollection<DonHangSach> DonHangSaches { get; set; }
    }
}
