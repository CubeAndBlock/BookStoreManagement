namespace BookStoreManagement.Models
{
    public class TacGiaSach
    {
        public int MaTacGia {  get; set; }
        public int MacSach { get; set;}
        public string VaiTro {  get; set; }
        public string ViTri {  get; set; }
        public TacGia TacGia { get; set;}
        public Sach Sach { get; set;}
    }
}
