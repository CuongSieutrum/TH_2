using Microsoft.EntityFrameworkCore;
using TH_BUOI2.DataAcess;
using TH_BUOI2.Models;

namespace TH_BUOI2.Repositories
{
    public class EFThuongHieuRepository : IThuongHieuRepository
    {

        private readonly ApplicationDbContext _context;
        public EFThuongHieuRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ThuongHieu ThuongHieu)
        {
            _context.Set<ThuongHieu>().Add(ThuongHieu);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ThuongHieu = await _context.ThuongHieus.FindAsync(id);
            _context.ThuongHieus.Remove(ThuongHieu);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ThuongHieu>> GetAllAsync()
        {
            return await _context.ThuongHieus.ToListAsync();
        }

        public async Task<ThuongHieu> GetByIdAsync(int id)
        {
            return await _context.ThuongHieus.FindAsync(id);
        }

        public async Task UpdateAsync(ThuongHieu ThuongHieu)
        {
            _context.Set<ThuongHieu>().Update(ThuongHieu);
            await _context.SaveChangesAsync();
        }

    }
}
