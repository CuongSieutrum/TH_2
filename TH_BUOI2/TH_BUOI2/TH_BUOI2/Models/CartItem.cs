namespace TH_BUOI2.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int SoLuong { get; set; }
        public decimal TongTien => SoLuong * Price;
    }
}
