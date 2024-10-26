using Domain.Countries;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Queries;

public interface ICountryQueries
{
    Task<IReadOnlyList<Country>> GetAll(CancellationToken cancellationToken);
}