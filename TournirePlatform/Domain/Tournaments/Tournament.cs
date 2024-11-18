using Domain.Countries;
using Domain.Matches;
using Domain.Teams;

namespace Domain.Tournaments;

public class Tournament
{
    public TournamentId Id { get; private set; }
    public string Name { get; set; }
    public DateTime StartDate { get; private set; }
    public CountryId CountryId { get; private set; }
    public Country Country { get; private set; }
    public GameId GameId { get; private set; }
    public Game.Game Game { get; private set; }
    public int PrizePool { get; set; }
    public ICollection<MatchGame> matchGames { get; private set; } = [];
    public string FormatTournament { get; private set; } //Online or Ofline

    public Tournament(TournamentId id, string name, DateTime startDate, CountryId countryId, GameId gameId,int prizePool,string formatTournament)
    {
        Id = id;
        Name = name;
        StartDate = startDate;
        CountryId = countryId;
        GameId = gameId;
        PrizePool = prizePool;
        FormatTournament = formatTournament;
    }
    
    public static Tournament New(TournamentId id,  string name, DateTime startDate, CountryId countryId, GameId gameId, int prizePool,string formatTournamet)
        => new Tournament(id,name, startDate, countryId, gameId, prizePool, formatTournamet);

    public void UpdateDetails(DateTime startDate, int prizePool, string formatTournamet)
    {
        StartDate = startDate.Date;
        PrizePool = prizePool;
        FormatTournament = formatTournamet; 
    }

}