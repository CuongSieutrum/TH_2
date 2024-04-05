using Microsoft.EntityFrameworkCore;
using TH_BUOI2.DataAcess;
using TH_BUOI2.Models;

namespace TH_BUOI2.Repositories
{
    public class EFDonHangChiTietRepository : IDonHangChiTietRepository
    {
        private readonly ApplicationDbContext _context;
        public EFDonHangChiTietRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(DonHangChiTiet DonHangChiTiet)
        {
            _context.DonHangChiTiets.Add(DonHangChiTiet);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var DonHangChiTiet = await _context.DonHangChiTiets.FindAsync(id);
            _context.DonHangChiTiets.Remove(DonHangChiTiet);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DonHangChiTiet>> GetAllAsync()
        {
            return await _context.DonHangChiTiets.ToListAsync();
        }

        public async Task<DonHangChiTiet> GetByIdAsync(int id)
        {
            return await _context.DonHangChiTiets.FindAsync(id);
        }

        public async Task UpdateAsync(DonHangChiTiet DonHangChiTiet)
        {
            _context.DonHangChiTiets.Update(DonHangChiTiet);
            await _context.SaveChangesAsync();
        }
    }
}
