using Domain.Players;
using Domain.Team;

namespace Api.Dtos;

public record TeamDto(
    Guid Id,
    string Name,
    byte[] Icon,
    int MatchCount,
    int WinCount,
    int WinRate,
    DateTime CreateionDate
    )
{
    public static TeamDto FromDomainModel(Team team)
    {
        var playersInTeam = team.PlayerTeams
            .Select(pt => PlayerDto.FromDomainModel(pt.Player))
            .ToList();

        return new TeamDto(
            Id: team.Id.Value,
            Name: team.Name,
            Icon: team.Icon,
            MatchCount: team.MatchCount,
            WinCount: team.WinCount,
            WinRate: team.WinRate,
            CreateionDate: team.CreationDate
            );
    }

}