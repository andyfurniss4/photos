using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Photos.Web;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var apiBaseAddress = builder.Configuration.GetValue<string>("ApiBaseAddress");
builder.Services.AddScoped(sp => new HttpClient 
{
    BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiBaseAddress"))
});

await builder.Build().RunAsync();
