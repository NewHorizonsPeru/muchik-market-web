using Blazored.SessionStorage;
using System.Text.Json;

namespace muchik.market.web.Helper
{
    public static class SessionStorageHelper
    {
        public static async Task AddValueToSessionStorage<T>(this ISessionStorageService sessionStorageService, string key, T value) where T : class
        {
            var valueToJson = JsonSerializer.Serialize(value);
            await sessionStorageService.SetItemAsStringAsync(key, valueToJson);
        }

        public static async Task<T?> GetValueFromSessionStorage<T>(this ISessionStorageService sessionStorageService, string key) where T : class
        {
            var valueJson = await sessionStorageService.GetItemAsStringAsync(key);

            if(valueJson == null) {
                return null;
            }

            return JsonSerializer.Deserialize<T>(valueJson);
        }
    }
}
