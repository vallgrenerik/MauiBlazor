using MauiBlazor.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace MauiBlazor.Data;

public class MauiBlazorContext : DbContext
{
	public DbSet<Person> Persons { get; set; } = default!;

	public MauiBlazorContext(DbContextOptions<MauiBlazorContext> options) : base(options)
	{
		//Database.EnsureCreated();
	}
} 