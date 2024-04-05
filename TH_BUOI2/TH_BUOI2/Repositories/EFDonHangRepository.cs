using Microsoft.EntityFrameworkCore;
using TH_BUOI2.DataAcess;
using TH_BUOI2.Models;

namespace TH_BUOI2.Repositories
{
    public class EFDonHangRepository : IDonHangRepository
    {
        private readonly ApplicationDbContext _context;
        public EFDonHangRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(DonHang DonHang)
        {
            _context.DonHangs.Add(DonHang);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var DonHang = await _context.DonHangs.FindAsync(id);
            _context.DonHangs.Remove(DonHang);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DonHang>> GetAllAsync()
        {
            return await _context.DonHangs.ToListAsync();
        }

        public async Task<DonHang> GetByIdAsync(int id)
        {
            return await _context.DonHangs.FindAsync(id);
        }

        public async Task UpdateAsync(DonHang DonHang)
        {
            _context.DonHangs.Update(DonHang);
            await _context.SaveChangesAsync();
        }
    }
}
