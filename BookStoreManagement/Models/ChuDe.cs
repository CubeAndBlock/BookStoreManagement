using System.ComponentModel.DataAnnotations;

namespace BookStoreManagement.Models
{
    public class ChuDe
    {
        [Key]
        public int MaChuDe {  get; set; }
        public string TenChuDe {  get; set; }
        public Sach Sach { get; set; }
    }
}
