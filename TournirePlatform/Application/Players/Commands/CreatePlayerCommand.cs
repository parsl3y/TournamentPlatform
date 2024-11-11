using Application.Common;
using Application.Common.Interfaces.Queries;
using Application.Common.Interfaces.Repositories;
using Application.Countries.Exceptions;
using Application.Players.Exceptions;
using Application.Games.Exceptions;
using Domain.Countries;
using Domain.Players;
using MediatR;

namespace Application.Players.Commands;

public record CreatePlayerCommand : IRequest<Result<Player, PlayerException>>
{
    public required string NickName { get; init; }
    public required int Rating { get; init; }
    public required Guid CountryId { get; init; }
    public required Guid GameId { get; init; }
}

public class CreatePlayerCommandHandler : IRequestHandler<CreatePlayerCommand, Result<Player, PlayerException>>
{
    private readonly ICountryQueries _countryQueries;
    private readonly IGameQueries _gameQueries;
    private readonly IPlayerRepositories _playerRepository;
    private readonly IPlayerQueries _playerQueries;

    public CreatePlayerCommandHandler(
        ICountryQueries countryQueries,
        IGameQueries gameQueries,
        IPlayerRepositories playerRepository,
        IPlayerQueries playerQueries)
    {
        _countryQueries = countryQueries;
        _gameQueries = gameQueries;
        _playerRepository = playerRepository;
        _playerQueries = playerQueries;
    }

    public async Task<Result<Player, PlayerException>> Handle(CreatePlayerCommand request,
        CancellationToken cancellationToken)
    {
        var countryId = new CountryId(request.CountryId);
        var gameId = new GameId(request.GameId);

        var country = await _countryQueries.GetById(countryId, cancellationToken);
        return await country.Match(
            async c =>
            {
                var game = await _gameQueries.GetById(gameId, cancellationToken);
                return await game.Match(
                    async g =>
                    {
                        var existingPlayer = await _playerQueries.GetByNickname(request.NickName, cancellationToken);
                        return await existingPlayer.Match(
                            p => Task.FromResult<Result<Player, PlayerException>>(new PlayerAlreadyExistsException(p.Id)),
                            async () => await CreateEntity(request.NickName, c.Id, request.Rating, g.Id, cancellationToken));
                    },
                    () => Task.FromResult<Result<Player, PlayerException>>(new PlayerGameNotFoundException(gameId)));
            },
            () => Task.FromResult<Result<Player, PlayerException>>(new PlayerCountryNotFoundException(countryId)));
    }

    private async Task<Result<Player, PlayerException>> CreateEntity(
            string nickName,
            CountryId countryId,
            int rating,
            GameId gameId,
            CancellationToken cancellationToken)
    {
        try
        {
            var entity = Player.New(PlayerId.New(), nickName, rating, countryId, gameId);

            return await _playerRepository.Add(entity, cancellationToken);
        }
        catch (Exception ex)
        {
            return new PlayerUknownException(PlayerId.Empty(), ex);
        }
    }
}
