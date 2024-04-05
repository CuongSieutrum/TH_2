using System.ComponentModel.DataAnnotations;

namespace TH_BUOI2.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }
        [Range(0, 1000000000)]
        public decimal Price { get; set; }
        public decimal Sale_price { get; set; }
        public string HeDieuHanh { get; set; }
        public string CPU { get; set; }
        public string RAM { get; set; }
        public string OCung { get; set; }
        public string  CardDoHoa { get; set; }
        public string? ImageUrl { get; set; }
        public string Ngay_nhap { get;set; }
        public string? Mo_ta { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int ThuongHieuId { get; set; }
        public virtual ThuongHieu ThuongHieu { get; set; }
    }
}
