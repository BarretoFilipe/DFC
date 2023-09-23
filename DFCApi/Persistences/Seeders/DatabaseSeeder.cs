using API.Models;
using Microsoft.AspNetCore.Identity;

namespace DFCApi.Persistences.Seeders
{
    public static class DatabaseSeeder
    {
        public static void Initialize(DFCContext context, UserManager<User> userManager)
        {
            if (context.Players.Any())
            {
                return;
            }

            var players = new Player[]
            {
                new Player("Lúcia", 0, true),
                new Player("Rita", 0, true),
                new Player("Agostinho", 0),
                new Player("David",0),
                new Player("Estágio", 0),
                new Player("Filipe", 0),
                new Player("Freitas", 0),
                new Player("João", 0),
                new Player("Márcio", 0),
                new Player("Nelson", 0),
                new Player("Rui", 0),
                new Player("Telmo AKA Amigo da Montanha", 0),
            };

            context.Players.AddRange(players);
            context.SaveChanges();

            foreach (var player in context.Players)
            {
                User user = new()
                {
                    UserName = player.Name?.ToLower(),

                    PlayerId = player.Id,
                };
                //userManager.CreateAsync()
            }
        }
    }
}