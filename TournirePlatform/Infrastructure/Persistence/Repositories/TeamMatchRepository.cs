using Application.Common.Interfaces.Repositories;
using Domain.Matches;
using Domain.Players;
using Domain.TeamsMatch;
using Domain.Teams;

namespace Infrastructure.Persistence.Repositories;

public class TeamMatchRepository : ITeamMatchRepository
{
    private readonly ApplicationDbContext _conntext;

    public TeamMatchRepository(ApplicationDbContext conntext)
    {
        _conntext = conntext;
    }

    public async Task<TeamMatch> Add(TeamId teamId, MatchId matchId, CancellationToken cancellationToken)
    {
        var newTeammatch = TeamMatch.New(teamId, matchId);
        await _conntext.TeamMatches.AddAsync(newTeammatch, cancellationToken);
        await _conntext.SaveChangesAsync(cancellationToken);
        
        return newTeammatch;
    }
}