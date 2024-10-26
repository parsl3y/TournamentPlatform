using Domain.Countries;
using Domain.Game;
using Optional;
namespace Application.Common.Interfaces.Repositories
{
    public interface ICountryRepositories
    {
        Task<Option<Country>> SearchByName(string name, CancellationToken cancellationToken);
        Task<Country> Add(Country country, CancellationToken cancellationToken);
        Task<Option<Country>> GetById(CountryId id, CancellationToken cancellationToken);
        Task<IReadOnlyList<Country>> GetAll(CancellationToken cancellationToken);
        Task<Country> Update(Country country, CancellationToken cancellationToken);
    }
}