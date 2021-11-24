using MauiBlazor.Components;
using MauiBlazor.Components.Data;
using MauiBlazor.Data;
using MauiBlazor.Shared.Services;
using MauiBlazor.Shared.ViewModels;
using MauiBlazor.Web;
using MauiBlazor.Web.Services;
using MauiBlazor.Web.ViewModels;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<Main>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<PersonViewModel>();
builder.Services.AddScoped<INativeStuffViewModel,NativeStuffViewModel>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();
builder.Services.AddDbContextFactory<MauiBlazorContext>(
	options => options.UseSqlite($"Filename={DataSynchronizer.SqliteDbFilename}"));
builder.Services.AddScoped<DataSynchronizer>();
await builder.Build().RunAsync();
