using System.ComponentModel.DataAnnotations;

namespace BookStoreManagement.Models
{
    public class NhaXuatBan
    {
        [Key]
        public int MaNXB {  get; set; }
        public string TenNXB {  get; set; }
        public int DienThoai {  get; set; }
        public string DiaChi {  get; set; }
        public Sach Sach { get; set; }
    }
}
