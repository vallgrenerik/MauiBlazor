using System.Timers;
using MauiBlazor.Shared.ViewModels;

namespace MauiBlazor.Web.ViewModels
{
	public class NativeStuffViewModel : ViewModelBase, INativeStuffViewModel
	{
		private string _stuff = "Not working on web";

		public NativeStuffViewModel()
		{

		}
		public string Stuff
		{
			get => _stuff;
			set => SetValue(ref _stuff,value);
		}
	}
}
