
namespace Domain.Game;
using Domain.Countries;

public class Game
{
    public GameId Id { get; }

    public string Name { get; private set; }

    public Game(GameId id, string name)
    {
        Id = id;
        Name = name;
    }
    public static Game New(GameId id, string name)
        => new Game(id, name);
    public void UpdateDetails(string name)
    {
        Name = name;
    }
}
