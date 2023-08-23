using API.Models;
using API.Persistences.Repositories.Interfaces;
using API.Services.Interface;

namespace API.Services
{
    public class DrawTeamService : IDrawTeamService
    {
        private readonly IPlayerRepository _playerRepository;

        public DrawTeamService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<IList<Team>> Draw()
        {
            var players = await _playerRepository.GetAll();
            Team teamA = new("Team A");
            Team teamB = new("Team B");

            var captainPlayers = players.Where(player => player.Captain).ToList();
            var captains = Shuffle(captainPlayers);
            foreach (var captain in captains)
            {
                if (teamA.Players.Count == 0)
                    teamA.Players.Add(captain);
                else
                    teamB.Players.Add(captain);
            }

            var nonCaptainPlayers = players.Where(player => !player.Captain).ToList();
            var shuffledPlayers = Shuffle(nonCaptainPlayers);
            var sortedByLevel = shuffledPlayers.OrderBy(player => player.Level).ToList();
            for (int index = 0; index < sortedByLevel.Count; index++)
            {
                if (index % 2 == 0)
                {
                    teamA.Players.Add(sortedByLevel[index]);
                }
                else
                {
                    teamB.Players.Add(sortedByLevel[index]);
                }
            }

            IList<Team> teams = new List<Team>
            {
                teamA,
                teamB,
            };
            return teams.ToList();
        }

        private static List<Player> Shuffle(IList<Player> list)
        {
            Random random = new Random();
            int count = list.Count;
            while (count > 1)
            {
                count--;
                int randomIndex = random.Next(count + 1);
                Player value = list[randomIndex];
                list[randomIndex] = list[count];
                list[count] = value;
            }
            return list.ToList();
        }
    }
}