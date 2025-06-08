using GSDrones.Data;
using GSDrones.Models;
using GSDrones.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace GSDrones.Repositories
{
    public class DroneRepository
    {
        private readonly AppDbContext _context;
        public DroneRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Drone>> GetAllAsync() => await _context.Set<Drone>().ToListAsync();
        public async Task<Drone?> GetByIdAsync(long id) =>
            await _context.Set<Drone>()
            .Include(d => d.Missoes.Where(m => m.Status == StatusMissao.EM_ANDAMENTO))
            .FirstOrDefaultAsync(d => d.Id == id);
        public async Task AddAsync(Drone drone)
        {
            _context.Set<Drone>().Add(drone);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Drone drone)
        {
            _context.Set<Drone>().Update(drone);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Drone drone)
        {
            _context.Set<Drone>().Remove(drone);
            await _context.SaveChangesAsync();
        }
    }
}