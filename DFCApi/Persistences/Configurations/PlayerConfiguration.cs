using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace DFCApi.Persistences.Configurations
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.ToTable(nameof(Player));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Level)
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(x => x.Captain)
                .IsRequired();

            builder.Property(x => x.Active)
                .IsRequired();
        }
    }
    
    /*
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.Property(x => x.PlayerId)
                .HasMaxLength(50)
                .IsRequired();

        }
    }*/
}