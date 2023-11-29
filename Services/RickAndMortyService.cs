using muchik.market.web.Interfaces;
using muchik.market.web.Models;
using muchik.market.web.Utilities;
using System.Text.Json;

namespace muchik.market.web.Services
{
    public class RickAndMortyService : IRickAndMortyService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public RickAndMortyService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _jsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true};
        }

        public async Task<Characters> GetCharacters()
        {
            var httpClient = _httpClientFactory.CreateClient(Constants.RickAndMortyClient);
            var response = await httpClient.GetAsync("character");
            var content  = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode) { throw new ApplicationException(content); }

            return JsonSerializer.Deserialize<Characters>(content, _jsonSerializerOptions);
        }
    }
}
