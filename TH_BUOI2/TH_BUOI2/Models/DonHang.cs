using System.ComponentModel.DataAnnotations;

namespace TH_BUOI2.Models
{
    public class DonHang
    {
        public int Id { get; set; }
        [Required, StringLength(100)]
        public int TongDonHang { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; } 
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string NgayDatHang { get;set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
