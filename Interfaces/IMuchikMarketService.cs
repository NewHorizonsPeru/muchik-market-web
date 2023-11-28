using muchik.market.web.Models;

namespace muchik.market.web.Interfaces
{
	public interface IMuchikMarketService
	{
		Task<Products> GetProducts();
	}
}
