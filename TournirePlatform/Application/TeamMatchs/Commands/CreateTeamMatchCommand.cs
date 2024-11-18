using Application.Common;
using Application.Common.Interfaces.Queries;
using Application.Common.Interfaces.Repositories;
using Application.TeamMatch.Exceptions;
using Domain.Matches;
using Domain.Teams;
using MediatR;

namespace Application.TeamMatchs.Commands;

public class CreateTeamMatchCommand : IRequest<Result<Domain.TeamsMatch.TeamMatch, TeamMatchException>>
{
    public TeamId TeamId { get; set; }
    public MatchId MatchId { get; set; }

    public CreateTeamMatchCommand(TeamId teamId, MatchId matchId)
    {
        TeamId = teamId;
        MatchId = matchId;
    }
    
    public class CreateTeamMatchCommandHandler : IRequestHandler<CreateTeamMatchCommand,
        Result<Domain.TeamsMatch.TeamMatch, TeamMatchException>>
    {
        private readonly ITeamMatchRepository _teamMatchRepository;
        private readonly IMatchQueries _matchQueries;

        public CreateTeamMatchCommandHandler(ITeamMatchRepository teamMatchRepository, IMatchQueries matchQueries)
        {
            _teamMatchRepository = teamMatchRepository;
            _matchQueries = matchQueries;
        }

        public async Task<Result<Domain.TeamsMatch.TeamMatch, TeamMatchException>> Handle(
            CreateTeamMatchCommand request, CancellationToken cancellationToken)
        {
            var existingTeamMatch =
                await _teamMatchRepository.ChekIfTeamMatchExists(request.TeamId, request.MatchId, cancellationToken);
            if (existingTeamMatch)
                throw new TeamAlreadyJoinInMatchException(Guid.NewGuid(), request.TeamId, request.MatchId);

            var matchOption = await _matchQueries.GetById(request.MatchId, cancellationToken);

            return await matchOption.Match<Task<Result<Domain.TeamsMatch.TeamMatch, TeamMatchException>>>(
                async tm =>
                {
                    if (tm.TeamMatches.Count >= tm.MaxTeams)
                    {
                        throw new MatchIsAlreadyFullException(Guid.NewGuid(), request.MatchId);
                    }

                    return await _teamMatchRepository.Add(request.TeamId, request.MatchId, cancellationToken);
                },
                () => Task.FromResult<Result<Domain.TeamsMatch.TeamMatch, TeamMatchException>>(
                    new MatchNotFoundException(Guid.NewGuid(), request.MatchId)));
        }
    
}
}

