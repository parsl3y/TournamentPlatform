using Domain.Game;

namespace Application.Common.Interfaces.Queries;

public interface IGameQueries
{
    Task<IReadOnlyList<Game>> GetAll(CancellationToken cancellationToken);
}