using MauiBlazor.Components;
using MauiBlazor.Data;
using MauiBlazor.Shared.Models;
using MauiBlazor.Shared.Services;
using Microsoft.EntityFrameworkCore;


namespace MauiBlazor.Web.Services
{
	public class PersonService : IPersonService
	{
		private readonly DataSynchronizer _sync;
		private MauiBlazorContext _preparedDbContextAsync;


		public PersonService(DataSynchronizer sync)
		{
			_sync = sync;
		}

		public async Task<List<Person>> GetAllPersons()
		{
			await SetDbContext();
			return await _preparedDbContextAsync.Persons.ToListAsync();
		}

		public async Task AddPerson()
		{
			await SetDbContext();

			var person = new Person
			{
				Name = $"NyPerson {DateTime.Now}"
			};
			await _preparedDbContextAsync.Persons.AddAsync(person);
			await _preparedDbContextAsync.SaveChangesAsync();
			var listAsync = await _preparedDbContextAsync.Persons.ToListAsync();

			Console.WriteLine($"number of persons: {listAsync.Count}");
		}

		private async Task SetDbContext()
		{
			if (_preparedDbContextAsync == null)
			{
				_preparedDbContextAsync = await _sync.GetPreparedDbContextAsync();
			}
		}
	}
}