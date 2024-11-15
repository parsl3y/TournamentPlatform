using System.Text.RegularExpressions;
using Application.Common;
using Application.Common.Interfaces.Queries;
using Application.Common.Interfaces.Repositories;
using Application.Matches.Exceptions;
using Domain.Countries;
using Domain.Game;
using Domain.Matches;
using Domain.Players;
using FluentValidation;
using MediatR;

namespace Application.Matches.Commands;

public class CreateMatchCommand :  IRequest<Result<MatchGame, MatchException>>
{
    public required string Name { get; set; }
    public required Guid GameId { get; set; }
    public required DateTime StartAt { get; set; }
    public required int MaxTeams { get; set; }
}

public class CreateMatchCommandHandler(
    IMatchQueries _matchQueries,
    IMatchRepository _matchRepository,
    IGameQueries _gameQueries
) : IRequestHandler<CreateMatchCommand, Result<MatchGame, MatchException>>

{
public async Task<Result<MatchGame, MatchException>> Handle(
    CreateMatchCommand request,
    CancellationToken cancellationToken)
{
    var gameId = new GameId(request.GameId);
    
    var game = await _gameQueries.GetById(gameId,cancellationToken);
    return await game.Match(
        async g =>
        {
            var existingMatchGame =
                await _matchQueries.GetMatchByName(request.Name, cancellationToken);
            return await existingMatchGame.Match(
                m => Task.FromResult<Result<MatchGame, MatchException>>(
                    new MatchAlreadyExistsException(m.Id)),
                async () => await CreateEntity(request.Name, g.Id, request.StartAt, request.MaxTeams,
                    cancellationToken));
        },
        () => Task.FromResult<Result<MatchGame, MatchException>>(
            new MatchGameNotFoundException(gameId))); 
}


private async Task<Result<MatchGame, MatchException>> CreateEntity(
    string name,
    GameId gameId, 
    DateTime startAt,
    int maxTeams,
    CancellationToken cancellationToken)
{
    try
    {
        var entity = MatchGame.New(
            MatchId.New(),
            name,
            gameId,
            DateTime.UtcNow,
            maxTeams
        );

        return await _matchRepository.Add(entity, cancellationToken);
    }
    catch (Exception exception)
    {
        return new MatchUknownException(MatchId.Empty(), exception);
    }
}
}