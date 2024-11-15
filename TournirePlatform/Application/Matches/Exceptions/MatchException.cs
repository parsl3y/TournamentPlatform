using Domain.Countries;
using Domain.Matches;

namespace Application.Matches.Exceptions;

public class MatchException : Exception
{
    public MatchId Id {get;}

    protected MatchException(MatchId id, string message, Exception? innerException = null)
        : base(message, innerException)
    {
        Id = id;
    }
    
}

public class MatchNotFoundException : MatchException
{
    public MatchNotFoundException(MatchId id)
        : base(id, $"Match {id} not found") {}
}

public class MatchAlreadyExistsException : MatchException
{
    public MatchAlreadyExistsException(MatchId id)
        :base(id, $"Match {id} already exists") {}
}

public class MatchUknownException : MatchException
{
    public MatchUknownException(MatchId id, Exception exception)
        :base(id, $"Match {id} not found") {}
}
   public class MatchGameNotFoundException : MatchException
    {
        public MatchGameNotFoundException(GameId gameId)
            :base(MatchId.Empty(), $"Game with id {gameId} was not found.") { }
    }
public class MatchCannotBeDeletedException : MatchException
{
    public MatchCannotBeDeletedException(MatchId id)
        :base(id: id, $"Match {id} cannot be deleted because it has registered teams.") {}
}