using System.ComponentModel.DataAnnotations;

namespace TH_BUOI2.Models
{
	public class Review
	{
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		public string Content { get; set; }

		[Range(1, 5)]
		public int Rating { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.Now;

		public int ProductId { get; set; }
		public virtual Product Product{get; set;}
	}
}
