using Domain.Countries;

namespace Domain.Players;

public class Player
{
    public PlayerId Id { get; }
    public string NickName { get; private set; }
    public int Rating { get; private set; }
    public CountryId CountryId { get; }
    public Country? Country { get; }
    public GameId GameId { get; }
    public  Game.Game?  Game { get; }
    public byte[] Photo { get; set; }
    public DateTime UpdatedAt { get; private set; }

    private Player(PlayerId id, string nickName, int rating, CountryId countryId, GameId gameId, byte[] photo, DateTime updatedAt)
    {
        Id = id;
        NickName = nickName;
        Rating = rating;
        CountryId = countryId;
        GameId = gameId;
        Photo = photo;
        UpdatedAt = updatedAt;
    }

    public static Player New(PlayerId id, string nickName, int rating, CountryId countryId, GameId gameId, byte[] photo) 
        => new(id,nickName,rating,countryId,gameId,photo, DateTime.UtcNow);

    public void UpdateDetails(string nickName, int rating, byte[] photo)
    {
        NickName = nickName;
        Rating = rating;
        Photo = photo;
        UpdatedAt = DateTime.Now;
    }
    
}