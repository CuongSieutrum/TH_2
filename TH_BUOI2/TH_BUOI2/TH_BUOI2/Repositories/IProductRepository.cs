﻿using TH_BUOI2.Models;

namespace TH_BUOI2.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
        Task<IEnumerable<Product>> GetByLapTopsAsync();
		Task<IEnumerable<Product>> GetBySmartphonesAsync();
        Task<IEnumerable<Product>> GetHotDealsAsync();
		Task<IEnumerable<Product>> GetCamerasAsync();
		Task AddAsync(Review review);
	}
}
