using System.Reflection;
using Domain.Countries;
using Domain.Game;
using Domain.Matches;
using Domain.Players;

using Domain.TeamsMatch;
using Domain.Teams;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Country> Countries { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<MatchGame> Matches { get; set; }
    public DbSet<TeamMatch> TeamMatches { get; set; }
    

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}