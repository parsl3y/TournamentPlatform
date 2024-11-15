using Domain.Matches;
using Domain.TeamsMatch;
using Domain.Teams;

namespace Application.Common.Interfaces.Repositories;

public interface ITeamMatchRepository
{
    Task<Domain.TeamsMatch.TeamMatch> Add(TeamId teamId, MatchId matchId, CancellationToken cancellationToken);
}