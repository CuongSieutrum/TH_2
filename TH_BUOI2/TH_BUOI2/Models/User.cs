using System.ComponentModel.DataAnnotations;

namespace TH_BUOI2.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string VaiTro { get; set; }
    }
}
