using System.ComponentModel.DataAnnotations;

namespace BookStoreManagement.Models
{
    public class TacGia
    {
        [Key]
        public int MaTacGia {  get; set; }
        public string TenTacGia {  set; get; }
        public int DienThoai {  get; set; }
        public string TieuSu {  get; set; }
        public string DiaChi {  get; set; }
        public ICollection<TacGiaSach> TacGiaSaches { get; set; }
    }
}
