using Blazored.SessionStorage;
using muchik.market.web.Helper;
using muchik.market.web.Interfaces;
using muchik.market.web.Models;
using muchik.market.web.Utilities;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace muchik.market.web.Services
{
    public class MuchikMarketService : IMuchikMarketService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        private readonly ISessionStorageService _sessionStorageService;

        public MuchikMarketService(IHttpClientFactory httpClientFactory, ISessionStorageService sessionStorageService)
        {
            _httpClientFactory = httpClientFactory;
            _jsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true};
            _sessionStorageService = sessionStorageService;
        }

        public async Task<List<Product>> GetProducts()
        {
            try
            {			
				var httpClient = _httpClientFactory.CreateClient(Constants.MuchikMarketClient);
                var response = await httpClient.GetAsync("common/getProducts");
                var content = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode) { throw new ApplicationException(content); }

                var getProductsResponse = JsonSerializer.Deserialize<GetProductsResponse>(content, _jsonSerializerOptions);
                return getProductsResponse!.Data;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task AddProduct(NewProduct newProduct)
		{
			try
			{
				var httpClient = _httpClientFactory.CreateClient(Constants.MuchikMarketClient);
				var response = await httpClient.PostAsync("common/addProduct", JsonContent.Create(newProduct));
				var content = await response.Content.ReadAsStringAsync();
				if (!response.IsSuccessStatusCode) { throw new ApplicationException(content); }
			}
			catch (Exception ex)
			{
				throw new Exception();
			}
		}

		public async Task<List<Brand>> GetBrands()
		{
			try
			{
				var httpClient = _httpClientFactory.CreateClient(Constants.MuchikMarketClient);
				var response = await httpClient.GetAsync("common/getBrands");
				var content = await response.Content.ReadAsStringAsync();
				if (!response.IsSuccessStatusCode) { throw new ApplicationException(content); }

				var getBrandsResponse = JsonSerializer.Deserialize<GetBrandsResponse>(content, _jsonSerializerOptions);
				return getBrandsResponse!.Data;
			}
			catch (Exception ex)
			{
				throw new Exception();
			}
		}

		public async Task<List<Category>> GetCategories()
		{
			try
			{
				var httpClient = _httpClientFactory.CreateClient(Constants.MuchikMarketClient);
				var response = await httpClient.GetAsync("common/getCategories");
				var content = await response.Content.ReadAsStringAsync();
				if (!response.IsSuccessStatusCode) { throw new ApplicationException(content); }

				var getCategoriesResponse = JsonSerializer.Deserialize<GetCategoriesResponse>(content, _jsonSerializerOptions);
				return getCategoriesResponse!.Data;
			}
			catch (Exception ex)
			{
				throw new Exception();
			}
		}

        public async Task<User?> SignIn(SignInRequest signInRequest)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient(Constants.MuchikMarketClient);
                var response = await httpClient.PostAsync("security/signIn", JsonContent.Create(signInRequest));
                var content = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode) { throw new ApplicationException(content); }

                var postSignInResponse = JsonSerializer.Deserialize<PostSignInResponse>(content, _jsonSerializerOptions);
                return postSignInResponse!.Data;
            }
            catch (Exception ex)
            {
				return null;
            }
        }

        public async Task<List<Role>> GetRoles()
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient(Constants.MuchikMarketClient);
                var response = await httpClient.GetAsync("security/getRoles");
                var content = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode) { throw new ApplicationException(content); }

                var getRolesResponse = JsonSerializer.Deserialize<GetRolesResponse>(content, _jsonSerializerOptions);
                return getRolesResponse!.Data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task SignUp(NewUser newUser)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient(Constants.MuchikMarketClient);
                var response = await httpClient.PostAsync("security/signUp", JsonContent.Create(newUser));
                var content = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode) { throw new ApplicationException(content); }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
