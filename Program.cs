using Blazored.Modal;
using Blazored.SessionStorage;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using muchik.market.web;
using muchik.market.web.Helper;
using muchik.market.web.HttpHandlers;
using muchik.market.web.Interfaces;
using muchik.market.web.Services;
using muchik.market.web.Utilities;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var muchikMarketApiUrl = builder.Configuration.GetValue<string>("MuchikMarketApiUrl");
var rickAndMortyApiUrl = builder.Configuration.GetValue<string>("RamApiUrl");

builder.Services.AddBlazoredModal();
builder.Services.AddBlazoredToast();

builder.Services.AddHttpClient(Constants.RickAndMortyClient, client =>
{
	client.BaseAddress = new Uri(rickAndMortyApiUrl!);
});

builder.Services.AddHttpClient(Constants.MuchikMarketClient, client =>
{
	client.BaseAddress = new Uri(muchikMarketApiUrl!);
}).AddHttpMessageHandler<CustomHeaderHandler>();

builder.Services.AddScoped<IMuchikMarketService, MuchikMarketService>();
builder.Services.AddScoped<IRickAndMortyService, RickAndMortyService>();

builder.Services.AddBlazoredSessionStorage();
builder.Services.AddScoped<AuthenticationStateProvider, AuthenticationHelper>();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<CustomHeaderHandler>();

await builder.Build().RunAsync();
