using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiBlazor.Shared.ViewModels
{
	public interface IBaseViewModel : INotifyPropertyChanged
	{
		void OnPropertyChanged([CallerMemberName] string? propertyName = null);
		void SetValue<T>(ref T backingFiled, T value, [CallerMemberName] string? propertyName = null);
	}
}