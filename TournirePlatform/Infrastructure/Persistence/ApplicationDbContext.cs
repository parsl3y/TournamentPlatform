using System.Reflection;
using Domain.Countries;
using Domain.Game;
using Domain.Players;
using Domain.services;
using Domain.Team;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Country> Countries { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<Player> Players { get; set; }
    
    public DbSet<Team> Teams { get; set; }
    
    public DbSet<PlayerTeam> PlayerTeams { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}