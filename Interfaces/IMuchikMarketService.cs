using muchik.market.web.Models;

namespace muchik.market.web.Interfaces
{
	public interface IMuchikMarketService
	{
		Task<List<Product>> GetProducts();
		Task AddProduct(NewProduct newProduct);
		Task<List<Brand>> GetBrands();
		Task<List<Category>> GetCategories();
		Task<User?> SignIn(SignInRequest signInRequest);
		Task<List<Role>> GetRoles();
		Task SignUp(NewUser newUser);
    }
}
