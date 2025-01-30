using Bootcamp.Data;
using Bootcamp.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bootcamp.Repositories
{
    public class MentorRepository : IMentorRepository
    {
        private readonly AppDbContext _context;

        public MentorRepository(AppDbContext context)
        {
            _context = context;
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
