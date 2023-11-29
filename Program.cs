using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using muchik.market.web;
using muchik.market.web.Interfaces;
using muchik.market.web.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var muchikMarketApiUrl = builder.Configuration.GetValue<string>("MuchikMarketApiUrl");
var rickAndMortyApiUrl = builder.Configuration.GetValue<string>("RamApiUrl");

builder.Services.AddHttpClient<RickAndMortyService>(client =>
{
	client.BaseAddress = new Uri(rickAndMortyApiUrl!);
});

builder.Services.AddHttpClient<MuchikMarketService>(client =>
{
	client.BaseAddress = new Uri(muchikMarketApiUrl!);
});

await builder.Build().RunAsync();
