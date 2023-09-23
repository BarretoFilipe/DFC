using API.Models;
using API.Persistences.Repositories.Interfaces;
using DFCApi.Persistences;
using Microsoft.EntityFrameworkCore;

namespace API.Persistences.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly DFCContext _context;

        public PlayerRepository(DFCContext context)
        {
            _context = context;
        }

        public async Task<IList<Player>> GetAll()
        {
            return await _context.Players.ToListAsync();
        }
    }
}