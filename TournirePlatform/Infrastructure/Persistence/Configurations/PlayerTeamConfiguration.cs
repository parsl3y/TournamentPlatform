using Domain.Players;
using Domain.services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PlayerTeamConfiguration : IEntityTypeConfiguration<PlayerTeam>
{
    public void Configure(EntityTypeBuilder<PlayerTeam> builder)
    {
        builder.HasKey(pt => pt.Id);
        builder.Property(pt => pt.PlayerId).HasConversion(x => x.Value, x => new PlayerId(x)).IsRequired();
        builder.Property(pt => pt.TeamId).HasConversion(x => x.Value, x => new TeamId(x)).IsRequired();
        builder.Property(pt => pt.PlayerAddedDate).IsRequired();
        
        builder.HasOne(pt => pt.Team)
            .WithMany(t => t.PlayerTeams)
            .HasForeignKey(pt => pt.TeamId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(pt => pt.Player)
            .WithOne(p => p.PlayerTeams) 
            .HasForeignKey<PlayerTeam>(pt => pt.PlayerId) 
            .OnDelete(DeleteBehavior.Restrict);
    }
}