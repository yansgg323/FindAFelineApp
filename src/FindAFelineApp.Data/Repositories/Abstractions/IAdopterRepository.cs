using FindAFelineApp.Data.Entities;
using FindAFelineApp.Data.Repositories.Abstractions;

namespace FindAFelineApp.Data.Repositories
{
    public interface IAdopterRepository : ICrudRepository<Adopter>
    {
        Task AdoptAsync(int adopterId, int catId);
    }
}