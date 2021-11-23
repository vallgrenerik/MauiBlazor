using MauiBlazor.Shared;
using SQLite;

namespace MauiBlazor.Models
{
	public class Person : IPerson
	{
		[PrimaryKey, AutoIncrement] public int Id { get; set; }
		public string Name { get; set; }
	}
}