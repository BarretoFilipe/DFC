using API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DFCApi.Persistences
{
    public class DFCContext : IdentityDbContext<User>
    {
        public DbSet<Player> Players { get; set; }

        public DFCContext(DbContextOptions<DFCContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(x =>
            {
                x.HasOne(e => e.Player)
                    .WithOne(e => e.User)
                    .HasForeignKey<User>(e => e.PlayerId)
                    .IsRequired();
            });

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DFCContext).Assembly);
        }
    }
}