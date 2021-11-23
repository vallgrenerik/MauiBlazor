namespace MauiBlazor.Shared
{
	public interface IPersonService
	{
		public Task<List<IPerson>> GetAllPersons();
		public Task AddPerson(IPerson person);
	}
}
