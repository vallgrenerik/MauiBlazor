using MauiBlazor.Data;
using System;
using System.IO;
using Application = Microsoft.Maui.Controls.Application;

namespace MauiBlazor
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new MainPage();
		}

		private static SqliteDatabase _database;

		public static SqliteDatabase Database
		{
			get
			{
				if (_database == null)
				{
					_database = new SqliteDatabase(Path.Combine(
						Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3"));
				}

				return _database;
			}
		}
	}
}