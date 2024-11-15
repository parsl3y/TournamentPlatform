using Domain.Countries;
using Domain.Players;
using Domain.TeamsMatch;
using Domain.Teams;
using Domain.TeamsMatch;

namespace Domain.Matches;

public class MatchGame
{
    public MatchId Id { get; private set; }
    public string Name { get; private set; }

    public GameId GameId { get; private set; } 
    public Game.Game Game { get; private set; }
    public DateTime StartAt { get; private set; }
    public string? Winner { get; private set; }// тут команда яка виграла і потім в team
    // додавати їй +1 до матчів та до перемог, а нішій команді лише до матчів
    public int MaxTeams { get; private set; }
    
    public ICollection<TeamMatch> TeamMatches { get; private set; } = [];

    private MatchGame(MatchId id, string name, GameId gameId, DateTime startAt, int maxTeams)
    {
        Id = id;
        Name = name;
        GameId = gameId;
        StartAt = startAt;
        MaxTeams  = maxTeams;
    }
    
    public static MatchGame New(MatchId id, string name ,GameId gameId, DateTime startAt, int maxTeams)
        => new MatchGame(id, name, gameId, startAt, maxTeams);

    public void UpdateDetails(string winner)
    {
        Winner = winner;
    }

 
}