using muchik.market.web.Interfaces;
using muchik.market.web.Models;
using System.Text.Json;

namespace muchik.market.web.Services
{
    public class MuchikMarketService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public MuchikMarketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _jsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true};
        }

        public async Task<Products> GetProducts()
        {
            try {
				var response = await _httpClient.GetAsync("common/getProducts");
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
