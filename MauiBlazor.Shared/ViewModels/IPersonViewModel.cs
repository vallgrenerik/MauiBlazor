using MauiBlazor.Shared.Models;

namespace MauiBlazor.Shared.ViewModels
{
	public interface IPersonViewModel
	{
		public List<IPerson> AllPersons { get; set; }
	}
}