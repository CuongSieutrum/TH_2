using System.ComponentModel.DataAnnotations;

namespace TH_BUOI2.Models
{
    public class DonHangChiTiet
    {
        public int Id { get; set; }
        [Required, StringLength(100)]
        public int SoLuong { get; set; }
        public int TongDonHang { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int DonHangId { get; set; }
        public virtual DonHang DonHang{ get; set; }
    }
}
