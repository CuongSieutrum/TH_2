using TH_BUOI2.Models;

namespace TH_BUOI2.Repositories
{
    public interface IImageRepository
    {
        Task<IEnumerable<Image>> GetAllAsync();
        Task<Image> GetByIdAsync(int id);
        Task AddAsync(Image Image);
        Task UpdateAsync(Image Image);
        Task DeleteAsync(int id);
    }
}
