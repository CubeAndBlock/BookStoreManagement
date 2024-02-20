namespace BookStoreManagement.Dto
{
    public class DonHangDto
    {
        public int MaDonHang { get; set; }
        public bool DaThanhToan { get; set; }
        public DateOnly NgayGiao { get; set; }
        public DateOnly NgayDat { get; set; }
        public string? TinhTrangDH { get; set; }
    }
}
