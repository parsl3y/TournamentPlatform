using System.Security.Cryptography;
using Domain.Matches;

namespace Api.Dtos;

public record MatchGameDtoCreate(
    Guid? Id,
    string Name,
    Guid GameId,
    GameDto? Game,
    DateTime StartedAt,
    int MaxTeams
    )
{
    public static MatchGameDtoCreate FromDomainModel(MatchGame matchGame)
        => new
        (
            Id: matchGame.Id.Value,
            Name: matchGame.Name,
            GameId: matchGame.GameId.Value,
            Game: matchGame.Game == null ? null : GameDto.FromDomainModel(matchGame.Game),
            StartedAt: matchGame.StartAt,
            MaxTeams: matchGame.MaxTeams
        );
}

public record MatchGameDto(
    string Name,
    Guid GameId,
    GameDto? Game,
    DateTime StartedAt,
    int MaxTeams
)
{
    public static MatchGameDto FromDomainModel(MatchGame matchGame)
        => new
        (
            Name: matchGame.Name,
            GameId: matchGame.GameId.Value,
            Game: matchGame.Game == null ? null : GameDto.FromDomainModel(matchGame.Game),
            StartedAt: matchGame.StartAt,
            MaxTeams: matchGame.MaxTeams
        );
}