using Bootcamp.Entities;

namespace Bootcamp.Repositories
{
    public interface IBootcamperRepository
    {
        Task<IEnumerable<Bootcamper>> GetAllBootcampersAsync();
        Task<Bootcamper> GetBootcamperByIdAsync(int id);
        Task AddBootcamperAsync(Bootcamper bootcamper);
        Task UpdateBootcamperAsync(Bootcamper bootcamper);
        Task DeleteBootcamperAsync(int id);

    }
}
