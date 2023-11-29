using muchik.market.web.Interfaces;
using muchik.market.web.Models;
using System.Text.Json;

namespace muchik.market.web.Services
{
    public class RickAndMortyService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public RickAndMortyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _jsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true};
        }

        public async Task<Characters> GetCharacters()
        {
            var response = await _httpClient.GetAsync("character");
            var content  = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode) { throw new ApplicationException(content); }

            return JsonSerializer.Deserialize<Characters>(content, _jsonSerializerOptions);
        }
    }
}
