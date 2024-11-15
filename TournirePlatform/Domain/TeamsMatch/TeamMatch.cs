using Domain.Matches;
using Domain.Players;
using Domain.Teams;

namespace Domain.TeamsMatch;

public class TeamMatch
{
    public Guid Id { get; private set; }
    public TeamId TeamId { get; private set; }
    public Team Team { get; set; }
    public MatchId MatchId { get; private set; }
    public MatchGame MatchGame { get; set; }
    public int Score { get; set; }
    public bool IsWinner { get; set; }

    private TeamMatch(TeamId teamId, MatchId matchId, int score, bool isWinner)
    {
        TeamId = teamId;
        MatchId = matchId;
        Score = score;
    }

    public static TeamMatch New(TeamId teamId, MatchId matchId)
        => new TeamMatch(teamId, matchId, 0, false);
}