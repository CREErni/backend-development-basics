using Bootcamp.Entities;

namespace Bootcamp.Repositories
{
    public interface IMentorRepository
    {
        Task<IEnumerable<Mentor>> GetAllMentorsAsync();
        Task<Mentor> GetMentorByIdAsync(int id);
        Task AddMentorAsync(Mentor mentor);
        Task UpdateMentorAsync(Mentor mentor);
        Task DeleteMentorAsync(int id);
    }
}
