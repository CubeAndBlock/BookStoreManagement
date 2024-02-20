namespace BookStoreManagement.Dto
{
    public class SachDto
    {
        public int MaSach { get; set; }
        public string? TenSach { get; set; }
        public int SoLuongTon { get; set; }
        public DateOnly NgayCapNhat { get; set; }
        public string? AnhBia { get; set; }
        public string? MoTa { get; set; }
        public double GiaBan { get; set; }
    }
}
