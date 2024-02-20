namespace BookStoreManagement.Models
{
    public class DonHangSach
    {
        public int MaDonHang {  get; set; }
        public int MaSach {  get; set; }
        public int SoLuong {  get; set; }
        public double DonGia {  get; set; }
        public DonHang DonHang { get; set; }
        public Sach Sach { get; set; }
    }
}
