using GSDrones.Data;
using GSDrones.Models;
using Microsoft.EntityFrameworkCore;

namespace GSDrones.Repositories
{
    public class MissaoRepository
    {
        private readonly AppDbContext _context;

        public MissaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Missao>> GetAllAsync()
        {
            return await _context.Missoes
                .Include(m => m.Drone)
                .Include(m => m.Suprimentos)
                    .ThenInclude(sm => sm.Suprimento)
                .ToListAsync();
        }

        public async Task<Missao?> GetByIdAsync(long id)
        {
            return await _context.Missoes
                .Include(m => m.Drone)
                .Include(m => m.Suprimentos)
                    .ThenInclude(sm => sm.Suprimento)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task AddAsync(Missao missao)
        {
            _context.Missoes.Add(missao);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Missao missao)
        {
            _context.Missoes.Update(missao);
            await _context.SaveChangesAsync();
        }
    }
}