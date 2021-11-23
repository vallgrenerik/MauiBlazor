using System.Collections.Generic;
using System.Threading.Tasks;
using MauiBlazor.Models;
using MauiBlazor.Shared;

namespace MauiBlazor.Services
{
	public class PersonService : IPersonService
	{
		public async Task<List<IPerson>> GetAllPersons()
		{

			var person = new Person
			{
				Name = "NyPerson"
			};
			await AddPerson(person);

			var temp = await App.Database.AllPersons();
			return temp;
		}

		public async Task AddPerson(IPerson person)
		{
			await App.Database.AddPerson(person);
		}
	}
}