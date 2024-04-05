using TH_BUOI2.Models;

namespace TH_BUOI2.Repositories
{
    public interface IDonHangRepository
    {
        Task<IEnumerable<DonHang>> GetAllAsync();
        Task<DonHang> GetByIdAsync(int id);
        Task AddAsync(DonHang DonHang);
        Task UpdateAsync(DonHang DonHang);
        Task DeleteAsync(int id);
    }
}
