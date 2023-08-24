using API.Models;
using API.Persistences.Repositories.Interfaces;
using API.Services;
using FluentAssertions;
using NSubstitute;

namespace DFCTest.Services
{
    public class DrawTeamServiceTests
    {
        private static IList<Player> _players => new List<Player>
            {
                new Player("Captain", 1, true),
                new Player("Player Level 5", 5),
                new Player("Player Level 10",10),
                new Player("Player Level 10", 10),
                new Player("Player Level 5", 5),
                new Player("Captain", 1, true),
            };

        [Fact]
        public async void MustHaveTwoTeams()
        {
            IList<Player> nonPlayers = new List<Player>();
            IPlayerRepository playerRepository = Substitute.For<IPlayerRepository>();
            playerRepository.GetAll().Returns(nonPlayers);

            DrawTeamService drawTeamservice = new(playerRepository);
            var teams = await drawTeamservice.Draw();

            teams.Should().NotBeEmpty()
                .And.HaveCount(2)
                .And.ContainItemsAssignableTo<Team>();
        }

        [Fact]
        public async void MustHaveTwoTeamsWithNonNullPlayers()
        {
            IList<Player> nonPlayers = new List<Player>();
            IPlayerRepository playerRepository = Substitute.For<IPlayerRepository>();
            playerRepository.GetAll().Returns(nonPlayers);

            DrawTeamService drawTeamservice = new(playerRepository);
            var teams = await drawTeamservice.Draw();

            foreach (var team in teams)
            {
                team.Players.Should().NotBeNull()
                    .And.HaveCount(0);
            }
        }

        [Fact]
        public async void EachTeamMustHaveACaptain()
        {
            IPlayerRepository playerRepository = Substitute.For<IPlayerRepository>();
            playerRepository.GetAll().Returns(_players);

            DrawTeamService drawTeamservice = new(playerRepository);
            var teams = await drawTeamservice.Draw();

            foreach (var team in teams)
            {
                team.Players.Where(x => x.Captain)
                    .Should().NotBeNull()
                    .And.HaveCount(1)
                    .And.ContainItemsAssignableTo<Player>();
            }
        }

        [Fact]
        public async void MustHaveBalancedTeams()
        {
            IPlayerRepository playerRepository = Substitute.For<IPlayerRepository>();
            playerRepository.GetAll().Returns(_players);

            DrawTeamService drawTeamservice = new(playerRepository);
            var teams = await drawTeamservice.Draw();

            foreach (var team in teams)
            {
                team.Players.Sum(x => x.Level)
                     .Should().Be(16);
            }
        }
    }
}