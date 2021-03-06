using System;
using System.IO;
using MauiBlazor.Components.Data;
using MauiBlazor.Data;
using MauiBlazor.Services;
using MauiBlazor.Shared.Services;
using MauiBlazor.Shared.ViewModels;
using MauiBlazor.ViewModels;
using Microsoft.AspNetCore.Components.WebView.Maui;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using MudBlazor.Services;

namespace MauiBlazor
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.RegisterBlazorMauiWebView()
				.UseMauiApp<App>()
				.ConfigureFonts(fonts => { fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"); });

			builder.Services.AddBlazorWebView();
			builder.Services.AddSingleton<WeatherForecastService>();
			builder.Services.AddScoped<IPersonService, PersonService>();
			builder.Services.AddScoped<PersonViewModel>();
			builder.Services.AddScoped<INativeStuffViewModel, NativeStuffViewModel>();
			builder.Services.AddMudServices();
			var combine = Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "katte.db");
			builder.Services.AddEntityFrameworkSqlite()
				.AddDbContextFactory<MauiBlazorContext>(
					opt => opt.UseSqlite($"Data Source={combine}"));
			return builder.Build();
		}
	}
}