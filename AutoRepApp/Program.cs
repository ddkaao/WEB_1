using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using AutoRepApp.Services;
using AutoRepApp;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(@"https://localhost:8007") });
builder.Services.AddScoped<IServicesProvider, ServicesProvider>();
builder.Services.AddScoped<IClientProvider, ClientsProvider>();

await builder.Build().RunAsync();
