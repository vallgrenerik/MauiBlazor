using MauiBlazor.Shared;
using MauiBlazor.Shared.Models;
using MauiBlazor.Shared.Services;
using MauiBlazor.Web.Models;

namespace MauiBlazor.Web.Services
{
	public class PersonService : IPersonService
	{
		private List<Person> _allPersons = new();

		public async Task<List<IPerson>> GetAllPersons()
		{
			await Task.Delay(0);
			_allPersons.Add(new Person
			{
				Name = "FromWeb"
			});
			return _allPersons.Cast<IPerson>().ToList();
		}

		public async Task AddPerson()
		{
			await Task.Delay(0);
			_allPersons.Add(new Person
			{
				Name = $"Another name {DateTime.Now}"
			});
		}
	}
}