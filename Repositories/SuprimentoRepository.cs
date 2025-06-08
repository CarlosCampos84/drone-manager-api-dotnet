using GSDrones.Data;
using GSDrones.Models;
using Microsoft.EntityFrameworkCore;

namespace GSDrones.Repositories
{
    public class SuprimentoRepository
    {
        private readonly AppDbContext _context;

        public SuprimentoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Suprimento>> GetAllAsync() => await _context.Set<Suprimento>().ToListAsync();
        public async Task<Suprimento?> GetByIdAsync(long id) => await _context.Set<Suprimento>().FindAsync(id);
        public async Task AddAsync(Suprimento suprimento)
        {
            _context.Set<Suprimento>().Add(suprimento);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Suprimento suprimento)
        {
            _context.Set<Suprimento>().Update(suprimento);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Suprimento suprimento)
        {
            _context.Set<Suprimento>().Remove(suprimento);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Suprimento>> GetSuprimentosByIdsAsync(List<long> ids)
        {
            return await _context.Suprimentos.Where(s => ids.Contains(s.Id)).ToListAsync();
        }
    }
}