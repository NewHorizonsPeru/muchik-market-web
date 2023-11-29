using muchik.market.web.Interfaces;
using muchik.market.web.Models;
using muchik.market.web.Utilities;
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
    }
}
