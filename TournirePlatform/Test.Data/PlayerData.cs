using Domain.Countries;
using Domain.Players;

namespace Test.Data;

public static class PlayerData
{
    public static Player MainPlayer(CountryId countryId, GameId gameId)
        => Player.New(PlayerId.New(), "Player Nick Name", 100,countryId, gameId);
    
    public static Player ExtraPlayer(CountryId countryId, GameId gameId)
        => Player.New(PlayerId.New(), "Player Nick Name", 100,countryId, gameId);
}