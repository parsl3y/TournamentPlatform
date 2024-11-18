using System.Security.Cryptography;
using Domain.Matches;
using Domain.TeamsMatch;

namespace Api.Dtos;

public record MatchGameDtoCreate(
    Guid? Id,
    string Name,
    Guid GameId,
    GameDto? Game,
    DateTime StartedAt,
    int MaxTeams,
    Guid TournamentId
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
            MaxTeams: matchGame.MaxTeams,
            TournamentId: matchGame.TournamentId.Value
        );
}

public record MatchGameDto(
    string Name, // лише name залишити
    Guid GameId,
    DateTime StartedAt,
    int MaxTeams
)
{
    public static MatchGameDto FromDomainModel(MatchGame matchGame)
        => new
        (
            Name: matchGame.Name,
            GameId: matchGame.GameId.Value,
            StartedAt: matchGame.StartAt,
            MaxTeams: matchGame.MaxTeams
        );
}

public record MatchGameDtoInTeam(
    string Name,
    List<TeamMatchDto>  Teams
)
{
    public static MatchGameDtoInTeam FromDomainModel(MatchGame matchGame)
        => new
        (
            Name: matchGame.Name,
            Teams: matchGame.TeamMatches.Select(TeamMatchDto.FromDomainModel).ToList()
            
        );
}