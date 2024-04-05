using System.ComponentModel.DataAnnotations;

namespace TH_BUOI2.Models
{
    public class ThuongHieu
    {
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public List<Product> Products { get; set; }
    }
}
