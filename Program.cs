using Blazored.Toast;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using muchik.market.web;
using muchik.market.web.Interfaces;
using muchik.market.web.Services;
using muchik.market.web.Utilities;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var muchikMarketApiUrl = builder.Configuration.GetValue<string>("MuchikMarketApiUrl");
var rickAndMortyApiUrl = builder.Configuration.GetValue<string>("RamApiUrl");

builder.Services.AddBlazoredToast();

builder.Services.AddHttpClient(Constants.RickAndMortyClient, client =>
{
	client.BaseAddress = new Uri(rickAndMortyApiUrl!);
});

builder.Services.AddHttpClient(Constants.MuchikMarketClient, client =>
{
	client.BaseAddress = new Uri(muchikMarketApiUrl!);
});

builder.Services.AddScoped<IMuchikMarketService, MuchikMarketService>();
builder.Services.AddScoped<IRickAndMortyService, RickAndMortyService>();

await builder.Build().RunAsync();
