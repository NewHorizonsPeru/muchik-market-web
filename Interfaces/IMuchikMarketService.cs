using muchik.market.web.Models;

namespace muchik.market.web.Interfaces
{
	public interface IMuchikMarketService
	{
		Task<Products> GetProducts();
		Task AddProduct(NewProduct newProduct);
		Task<List<Brand>> GetBrands();
		Task<List<Category>> GetCategories();

	}
}
