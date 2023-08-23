using API.Models;
using API.Persistences.Repositories.Interfaces;

namespace API.Persistences.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private static IList<Player> _players => new List<Player>
            {
                new Player("Lúcia", 10, true),
                new Player("Rita", 10, true),
                new Player("Agostinho", 8),
                new Player("David",10),
                new Player("Estágio", 7),
                new Player("Filipe", 6),
                new Player("Freitas", 6),
                new Player("João", 6),
                new Player("Márcio", 8),
                new Player("Nelson", 7),
                new Player("Rui", 6),
                new Player("Telmo AKA Amigo da Montanha", 10),
            };

        public async Task<IList<Player>> GetAll()
        {
            return await Task.FromResult(_players);
        }
    }
}