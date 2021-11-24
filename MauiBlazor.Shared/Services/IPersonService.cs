using MauiBlazor.Shared.Models;

namespace MauiBlazor.Shared.Services
{
	public interface IPersonService
	{
		public Task<List<Person>> GetAllPersons();
		public Task AddPerson();
	}
}
