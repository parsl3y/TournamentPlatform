using Domain.Countries;
using Domain.Tournaments;

namespace Api.Dtos;

public record TournamentDto(
    string Name,
    DateTime? startDate,
    CountryId CountryId, 
    int prizePool,
    string formatTournament,
    List<MatchGameDtoInTeam> Matches
    )
{
    public static TournamentDto FromDomainModel (Tournament tournament)
            => new
        (
            Name: tournament.Name,
            startDate: tournament.StartDate,
            CountryId: tournament.CountryId,
            prizePool: tournament.PrizePool,
            formatTournament: tournament.FormatTournament,
            Matches: tournament.matchGames.Select(MatchGameDtoInTeam.FromDomainModel).ToList()
        );
    
}
public record TournamentCreateDto(  
    string Name,
    DateTime startDate,
    CountryId CountryId, 
    int prizePool,
    string formatTournament
    )
{

    public static TournamentCreateDto FromDomainModel (Tournament tournament)
       => new (
           Name: tournament.Name,
           startDate: tournament.StartDate,
           CountryId: tournament.CountryId,
           prizePool: tournament.PrizePool,
           formatTournament: tournament.FormatTournament
        );
    
}