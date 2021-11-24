using MauiBlazor.Shared.Models;
using MauiBlazor.Shared.Services;

namespace MauiBlazor.Shared.ViewModels;

public class PersonViewModel : ViewModelBase
{
	private readonly IPersonService _personService;

	public PersonViewModel(IPersonService personService)
	{
		_personService = personService;
	}

	private List<Person> _allPersons = new();

	public List<Person> AllPersons
	{
		get => _allPersons;
		set => SetValue(ref _allPersons, value);
	}

	public async Task AddPerson()
	{
		await _personService.AddPerson();
		_allPersons = await _personService.GetAllPersons();
	}

	public async Task Init()
	{
		_allPersons = await _personService.GetAllPersons();
	}
}