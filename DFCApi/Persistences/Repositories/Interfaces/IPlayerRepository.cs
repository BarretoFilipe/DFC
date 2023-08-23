using API.Models;

namespace API.Persistences.Repositories.Interfaces
{
    public interface IPlayerRepository
    {
        Task<IList<Player>> GetAll();
    }
}