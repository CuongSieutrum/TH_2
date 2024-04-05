using Microsoft.EntityFrameworkCore;
using TH_BUOI2.DataAcess;
using TH_BUOI2.Models;

namespace TH_BUOI2.Repositories
{
    public class EFImageRepository : IImageRepository
    {
        private readonly ApplicationDbContext _context;
        public EFImageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Image Image)
        {
            _context.Images.Add(Image);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var Image = await _context.Images.FindAsync(id);
            _context.Images.Remove(Image);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Image>> GetAllAsync()
        {
            return await _context.Images.ToListAsync();
        }

        public async Task<Image> GetByIdAsync(int id)
        {
            return await _context.Images.FindAsync(id);
        }

        public async Task UpdateAsync(Image Image)
        {
            _context.Images.Update(Image);
            await _context.SaveChangesAsync();
        }
    }
}
