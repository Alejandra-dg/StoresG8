using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using StoresG8.WEB;
using StoresG8.WEB.Repositories;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<IRepository , Repository>();
// Se debe inyectar el servicio de Alert Para que funcione luego ir a INDEX HTML en www.root
builder.Services.AddSweetAlert2();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7094/")


});

await builder.Build().RunAsync();
