using API.Models;

namespace API.Services.Interface
{
    public interface IDrawTeamService
    {
        Task<IList<Team>> Draw();
    }
}