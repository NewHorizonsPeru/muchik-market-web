using muchik.market.web.Models;

namespace muchik.market.web.Interfaces
{
    public interface IRamService
    {
        Task<Characters> GetCharacters();
    }
}
