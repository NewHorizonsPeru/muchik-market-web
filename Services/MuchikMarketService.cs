using muchik.market.web.Interfaces;
using muchik.market.web.Models;
using muchik.market.web.Utilities;
using System.Net.Http.Json;
using System.Text.Json;

namespace muchik.market.web.Services
{
    public class MuchikMarketService : IMuchikMarketService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public MuchikMarketService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _jsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true};
        }

        public async Task<Products> GetProducts()
        {
            try {
				var httpClient = _httpClientFactory.CreateClient(Constants.MuchikMarketClient);
				var response = await httpClient.GetAsync("common/getProducts");
				var content = await response.Content.ReadAsStringAsync();
				if (!response.IsSuccessStatusCode) { throw new ApplicationException(content); }

				return JsonSerializer.Deserialize<Products>(content, _jsonSerializerOptions);
			}
			catch (Exception ex) {
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
	}
}
