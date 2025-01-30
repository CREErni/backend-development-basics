using Bootcamp.Data;
using Bootcamp.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bootcamp.Repositories
{
    public class BootcampRepository : IBootcamperRepository
    {
        private readonly AppDbContext _context;

        public BootcampRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Bootcamper>> GetAllBootcampersAsync() =>
            await _context.Bootcampers.Include(b => b.Mentor).ToListAsync();

        public async Task<Bootcamper> GetBootcamperByIdAsync(int id) =>
            await _context.Bootcampers.Include(b => b.Mentor).FirstOrDefaultAsync(b => b.Id == id);

        public async Task AddBootcamperAsync(Bootcamper bootcamper)
        {
            _context.Bootcampers.Add(bootcamper);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBootcamperAsync(Bootcamper bootcamper)
        {
            _context.Bootcampers.Update(bootcamper);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBootcamperAsync(int id)
        {
            var bootcamper = await _context.Bootcampers.FindAsync(id);
            if (bootcamper != null)
            {
                _context.Bootcampers.Remove(bootcamper);
                await _context.SaveChangesAsync();
            }
        }

    }
}