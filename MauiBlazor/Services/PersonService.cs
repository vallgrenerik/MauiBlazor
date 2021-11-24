using MauiBlazor.Data;
using MauiBlazor.Shared.Models;
using MauiBlazor.Shared.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MauiBlazor.Services
{
	public class PersonService : IPersonService
	{
		private readonly MauiBlazorContext _context;

		public PersonService(MauiBlazorContext context)
		{
			_context = context;
		}

		public async Task<List<Person>> GetAllPersons()
		{
			return await _context.Persons.ToListAsync();
		}

		public async Task AddPerson()
		{
			var person = new Person
			{
				Name = $"NyPerson {DateTime.Now}"
			};
			await _context.Persons.AddAsync(person);
			await _context.SaveChangesAsync();
		}
	}
}