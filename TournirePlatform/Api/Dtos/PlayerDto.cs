using System.Runtime.CompilerServices;

namespace Api.Dtos;
using Domain.Countries;
using Domain.Players;
using Domain.Game;

public record PlayerDto(
    Guid? Id,
    string Nickname,
    int rating,
    Guid CountryId,
    CountryDto? Country,
    Guid GameId,
    GameDto? Game,
    byte[] Photo,
    DateTime? UpdateAt
)
{
   

    public static PlayerDto FromDomainModel(Player player)
        => new
    (
    Id: player.Id.Value,
    Nickname: player.NickName,
    rating: player.Rating,
    CountryId: player.CountryId.Value,
    Country: player.Country == null ? null : CountryDto.FromDomainModel(player.Country),
    GameId: player.GameId.Value,
    Game: player.Game == null ? null : GameDto.FromDomainModel(player.Game),
    Photo: player.Photo,
    UpdateAt: player.UpdatedAt
    );
}