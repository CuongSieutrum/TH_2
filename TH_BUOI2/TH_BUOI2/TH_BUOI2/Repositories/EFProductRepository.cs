using Microsoft.EntityFrameworkCore;
using TH_BUOI2.DataAcess;
using TH_BUOI2.Models;
using System.Linq;

namespace TH_BUOI2.Repositories
{
    public class EFProductRepository : IProductRepository
    {

        private readonly ApplicationDbContext _context;
        public EFProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Product product)
        {
			_context.Products.Add(product);
			await _context.SaveChangesAsync();
			/*_context.Set<Product>().Add(product);
            await _context.SaveChangesAsync();*/
        }

        public async Task DeleteAsync(int id)
        {
			var product = await _context.Products.FindAsync(id);
			if (product != null)
			{
				_context.Products.Remove(product);
				await _context.SaveChangesAsync();
			}
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task UpdateAsync(Product product)
        {
			_context.Entry(product).State = EntityState.Modified;
			await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetByLapTopsAsync()
        {
            return await _context.Products.FromSqlRaw("SELECT * FROM Products WHERE CategoryId = {0}", 1).ToListAsync();
        }

		public async Task<IEnumerable<Product>> GetBySmartphonesAsync()
		{
			return await _context.Products.FromSqlRaw("SELECT * FROM Products WHERE CategoryId = {0}", 2).ToListAsync();
		}

		public async Task<IEnumerable<Product>> GetHotDealsAsync()
		{
			return await _context.Products.FromSqlRaw("SELECT * FROM Products WHERE (Price - Sale_price) / Price >= 0.1").ToListAsync();
		}

		public async Task<IEnumerable<Product>> GetCamerasAsync()
		{
			return await _context.Products.FromSqlRaw("SELECT * FROM Products WHERE CategoryId = {0}", 3).ToListAsync();
		}

		public async Task AddAsync(Review review)
		{
			_context.Reviews.Add(review);
			await _context.SaveChangesAsync();
		}
	}
}
