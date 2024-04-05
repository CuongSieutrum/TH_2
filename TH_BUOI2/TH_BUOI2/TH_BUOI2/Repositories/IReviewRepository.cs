using TH_BUOI2.Models;

namespace TH_BUOI2.Repositories
{
	public interface IReviewRepository
	{
		Task<IEnumerable<Review>> GetByProductIdAsync(int productId);
		Task AddAsync(Review review);
		Task DeleteAsync(int id);
	}
}
