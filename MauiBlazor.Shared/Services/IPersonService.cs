using MauiBlazor.Shared.Models;

namespace MauiBlazor.Shared.Services
{
	public interface IPersonService
	{
		public Task<List<IPerson>> GetAllPersons();
		public Task AddPerson();
	}
}
