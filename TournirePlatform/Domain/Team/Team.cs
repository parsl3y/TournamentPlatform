using Domain.Players;
using Domain.services;

namespace Domain.Team;

public class Team
{
    public TeamId Id { get; init; }
    public string Name { get; set; }
    public byte[] Icon { get; set; }
    public int MatchCount { get; init; }
    public int WinCount { get; init; }
    public int WinRate { get; init; }  
    public DateTime CreationDate { get; init; }

    public List<PlayerTeam> PlayerTeams { get; private set; } = new List<PlayerTeam>();

    private Team(TeamId id, string name, byte[] icon, int matchCount, int winCount, int winRate, DateTime creationDate)
    {
        Id = id;
        Name = name;
        Icon = icon;
        MatchCount = matchCount;
        WinCount = winCount;
        WinRate = winRate;
        CreationDate = creationDate;
    }
    
    public static Team New(TeamId id, string name, byte[] icon, int matchCount, int winCount, int winRate, DateTime creationDate)
        => new Team(id, name, icon, matchCount, winCount, winRate, creationDate);

    public void UpdateDetails(string name, byte[] icon)
    {
        Name = name;
        Icon = icon;
    }
}