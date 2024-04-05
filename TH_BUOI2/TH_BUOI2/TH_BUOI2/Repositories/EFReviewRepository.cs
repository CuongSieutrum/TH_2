using Microsoft.EntityFrameworkCore;
using TH_BUOI2.DataAcess;
using TH_BUOI2.Models;

namespace TH_BUOI2.Repositories
{
	public class EFReviewRepository : IReviewRepository
	{
		private readonly ApplicationDbContext _context;
		public EFReviewRepository(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task AddAsync(Review review)
		{
			_context.Reviews.Add(review);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var review = await _context.Reviews.FindAsync(id);
			_context.Reviews.Remove(review);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Review>> GetByProductIdAsync(int productId)
		{
			return await _context.Reviews.Where(r => r.ProductId == productId).ToListAsync();
		}
	}
}
