using TH_BUOI2.Models;

namespace TH_BUOI2.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task AddAsync(User User);
        Task UpdateAsync(User User);
        Task DeleteAsync(int id);
    }
}
