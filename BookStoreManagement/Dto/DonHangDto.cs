namespace BookStoreManagement.Dto
{
    public class DonHangDto
    {
        public int MaDonHang { get; set; }
        public bool DaThanhToan { get; set; }
        public DateTime NgayGiao { get; set; }
        public DateTime NgayDat { get; set; }
        public string? TinhTrangDH { get; set; }
    }
}
