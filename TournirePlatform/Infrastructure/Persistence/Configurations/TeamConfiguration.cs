using Domain.Players;
using Domain.Team;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasConversion(x => x.Value, x => new TeamId(x));
        
        builder.Property(x => x.Name).IsRequired().HasColumnType("varchar(225)");
        builder.Property(x => x.Icon).IsRequired();
        builder.Property(x => x.MatchCount).IsRequired();
        builder.Property(x => x.WinCount).IsRequired();
        builder.Property(x => x.WinRate).IsRequired();
        builder.Property(x => x.CreationDate).IsRequired();
    }
}