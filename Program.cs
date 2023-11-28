using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using muchik.market.web;
using muchik.market.web.Interfaces;
using muchik.market.web.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var muchikMarketApiUrl = builder.Configuration.GetValue<string>("MuchikMarketApiUrl");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(muchikMarketApiUrl!) });
builder.Services.AddScoped<IMuchikMarketService, MuchikMarketService>();
builder.Services.AddScoped<IRamService, RamService>();

await builder.Build().RunAsync();
