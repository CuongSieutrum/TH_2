using TH_BUOI2.Models;

namespace TH_BUOI2.Repositories
{
    public interface IThuongHieuRepository
    {
        Task<IEnumerable<ThuongHieu>> GetAllAsync();
        Task<ThuongHieu> GetByIdAsync(int id);
        Task AddAsync(ThuongHieu ThuongHieu);
        Task UpdateAsync(ThuongHieu ThuongHieu);
        Task DeleteAsync(int id);
    }
}
