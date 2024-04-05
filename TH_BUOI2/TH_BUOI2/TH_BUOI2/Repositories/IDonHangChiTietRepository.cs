using TH_BUOI2.Models;

namespace TH_BUOI2.Repositories
{
    public interface IDonHangChiTietRepository
    {
        Task<IEnumerable<DonHangChiTiet>> GetAllAsync();
        Task<DonHangChiTiet> GetByIdAsync(int id);
        Task AddAsync(DonHangChiTiet DonHangChiTiet);
        Task UpdateAsync(DonHangChiTiet DonHangChiTiet);
        Task DeleteAsync(int id);
    }
}
