using System.ComponentModel.DataAnnotations;

namespace TH_BUOI2.Models
{
    public class Image
    {
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
