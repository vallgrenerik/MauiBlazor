using MauiBlazor.Data;
using Microsoft.EntityFrameworkCore;
using Application = Microsoft.Maui.Controls.Application;

namespace MauiBlazor
{
	public partial class App : Application
	{
		public App(IDbContextFactory<MauiBlazorContext> dbContextFactory)
		{
			var mauiBlazorContext =  dbContextFactory.CreateDbContext();
			mauiBlazorContext.Database.EnsureCreated();
			InitializeComponent();

			MainPage = new MainPage();
		}
		
	}
}