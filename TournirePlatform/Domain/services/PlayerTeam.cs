using Domain.Players;

namespace Domain.services;

public class PlayerTeam
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public PlayerId PlayerId { get; set; }
    public Player Player { get; set;}
    public TeamId TeamId { get; set; }
    public Team.Team Team { get; set; }
    public DateTime PlayerAddedDate { get; set; }

    private PlayerTeam(PlayerId playerId, TeamId teamId, DateTime playerAddedDate)
    {
        PlayerId = playerId;
        TeamId = teamId;
        PlayerAddedDate = playerAddedDate;
    }
    
    public static PlayerTeam New(PlayerId playerId, TeamId teamId, DateTime playerAddedDate)
        => new PlayerTeam(playerId, teamId, playerAddedDate);
    
}