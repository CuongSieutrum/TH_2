using Microsoft.EntityFrameworkCore;
using TH_BUOI2.DataAcess;
using TH_BUOI2.Models;

namespace TH_BUOI2.Repositories
{
    public class EFUserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public EFUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User User)
        {
            _context.Set<User>().Add(User);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var User = await _context.Users.FindAsync(id);
            _context.Users.Remove(User);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task UpdateAsync(User User)
        {
            _context.Set<User>().Update(User);
            await _context.SaveChangesAsync();
        }
    }
}
