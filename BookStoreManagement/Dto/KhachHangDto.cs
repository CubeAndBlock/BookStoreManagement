﻿namespace BookStoreManagement.Dto
{
    public class KhachHangDto
    {
        public int MaKH { get; set; }
        public string? TaiKhoan { get; set; }
        public string? MatKhau { get; set; }
        public string? Email { get; set; }
        public string? DiaChi { get; set; }
        public int DienThoai { get; set; }
        public string? GioiTinh { get; set; }
        public DateOnly NgaySinh { get; set; }
        public string? HoTen { get; set; }
    }
}