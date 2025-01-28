using Bootcamp.Entities;

namespace Bootcamp.Repositories
{
    public interface IBootcampRepository
    {
        Task<IEnumerable<Bootcamper>> GetAllBootcampersAsync();
        Task<Bootcamper> GetBootcamperByIdAsync(int id);
        Task AddBootcamperAsync(Bootcamper bootcamper);
        Task UpdateBootcamperAsync(Bootcamper bootcamper);
        Task DeleteBootcamperAsync(int id);

 
        Task<IEnumerable<Mentor>> GetAllMentorsAsync();
        Task<Mentor> GetMentorByIdAsync(int id);
        Task AddMentorAsync(Mentor mentor);
        Task UpdateMentorAsync(Mentor mentor);
        Task DeleteMentorAsync(int id);
    }
}
