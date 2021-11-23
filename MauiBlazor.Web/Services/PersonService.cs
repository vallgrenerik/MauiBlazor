using MauiBlazor.Shared;
using MauiBlazor.Web.Models;

namespace MauiBlazor.Web.Services
{
	public class PersonService : IPersonService
	{
		public async Task<List<IPerson>> GetAllPersons()
		{
			await Task.Delay(0);
			var persons = new List<IPerson>
			{
				new Person
				{
					Name = "FromWeb"
				}
			};
			return persons;
		}

		public async Task AddPerson(IPerson person)
		{
			await Task.Delay(0);
		}
	}
}