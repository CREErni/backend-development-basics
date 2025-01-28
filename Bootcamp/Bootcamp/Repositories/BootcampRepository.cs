using Bootcamp.Data;
using Bootcamp.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bootcamp.Repositories
{
    public class BootcampRepository : IBootcampRepository
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

        public async Task<IEnumerable<Mentor>> GetAllMentorsAsync() =>
            await _context.Mentors.Include(m => m.Bootcampers).ToListAsync();

        public async Task<Mentor> GetMentorByIdAsync(int id) =>
            await _context.Mentors.Include(m => m.Bootcampers).FirstOrDefaultAsync(m => m.Id == id);

        public async Task AddMentorAsync(Mentor mentor)
        {
            _context.Mentors.Add(mentor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMentorAsync(Mentor mentor)
        {
            _context.Mentors.Update(mentor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMentorAsync(int id)
        {
            var mentor = await _context.Mentors.FindAsync(id);
            if (mentor != null)
            {
                _context.Mentors.Remove(mentor);
                await _context.SaveChangesAsync();
            }
        }
    }
}