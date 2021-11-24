using System.Runtime.InteropServices;
using MauiBlazor.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;

namespace MauiBlazor.Web
{
	public class DataSynchronizer
	{
		public const string SqliteDbFilename = "app.db";
		private readonly Task _firstTimeSetupTask;

		private readonly IDbContextFactory<MauiBlazorContext> _dbContextFactory;

		public DataSynchronizer(IJSRuntime js, IDbContextFactory<MauiBlazorContext> dbContextFactory)
		{
			_dbContextFactory = dbContextFactory;
			_firstTimeSetupTask = FirstTimeSetupAsync(js);
		}

		public async Task<MauiBlazorContext> GetPreparedDbContextAsync()
		{
			await _firstTimeSetupTask;
			return await _dbContextFactory.CreateDbContextAsync();
		}

		private async Task FirstTimeSetupAsync(IJSRuntime js)
		{
			var module =
				await js.InvokeAsync<IJSObjectReference>("import", "./_content/MauiBlazor.Components/dbstorage.js");

			if (RuntimeInformation.IsOSPlatform(OSPlatform.Create("browser")))
			{
				await module.InvokeVoidAsync("synchronizeFileWithIndexedDb", SqliteDbFilename);
			}

			await using var db = await _dbContextFactory.CreateDbContextAsync();
			await db.Database.EnsureCreatedAsync();
		}
	}
}