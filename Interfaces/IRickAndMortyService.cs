using muchik.market.web.Models;

namespace muchik.market.web.Interfaces
{
    public interface IRickAndMortyService
    {
        Task<Characters> GetCharacters();
    }
}
