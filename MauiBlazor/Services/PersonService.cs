using System;
using MauiBlazor.Models;
using MauiBlazor.Shared.Models;
using MauiBlazor.Shared.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MauiBlazor.Services
{
	public class PersonService : IPersonService
	{
		public async Task<List<IPerson>> GetAllPersons()
		{
			return await App.Database.AllPersons();
		}

		public async Task AddPerson()
		{
			var person = new Person
			{
				Name = $"NyPerson {DateTime.Now}"
			};

			await App.Database.AddPerson(person);
		}
	}
}