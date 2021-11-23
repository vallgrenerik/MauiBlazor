using MauiBlazor.Models;
using MauiBlazor.Shared.Models;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MauiBlazor.Data
{
	public class SqliteDatabase
	{
		private readonly SQLiteAsyncConnection _database;

		public SqliteDatabase(string path)
		{
			_database = new SQLiteAsyncConnection(path);
			_database.CreateTableAsync<Person>();
		}

		public async Task<List<IPerson>> AllPersons()
		{
			var temp = await _database.Table<Person>().ToListAsync();
			return temp.Cast<IPerson>().ToList();

		}

		public async Task AddPerson(IPerson person)
		{
			
			await _database.InsertAsync(person);
		}

	}
}