using Domain.Countries;

namespace Domain.Faculties;

public class GameImage
{
    public GameImageId Id { get; }

    public GameId GameId { get; } 
    public Game.Game? Game { get; } 
    

    private GameImage(GameImageId id, GameId gameId)
    {
        Id = id;
        GameId = gameId;
    }

    public static GameImage New(GameImageId id, GameId gameId) => new(id, gameId);

    public string FilePath => $"{GameId}/{Id}.jpeg";
}