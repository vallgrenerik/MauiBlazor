using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiBlazor.Shared.ViewModels
{
	public abstract class BaseViewModel : IBaseViewModel
	{
		private bool _isBusy;

		public bool IsBusy
		{
			get => _isBusy;
			set => SetValue(ref _isBusy, value);
		}

		public event PropertyChangedEventHandler PropertyChanged;
		

		public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public void SetValue<T>(ref T backingFiled, T value, [CallerMemberName] string propertyName = null)
		{
			if (EqualityComparer<T>.Default.Equals(backingFiled, value)) return;
			backingFiled = value;
			OnPropertyChanged(propertyName);
		}
	}
}
