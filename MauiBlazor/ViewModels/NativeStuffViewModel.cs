using MauiBlazor.Shared.ViewModels;
using Microsoft.Maui.Essentials;

namespace MauiBlazor.ViewModels
{
	public class NativeStuffViewModel : ViewModelBase, INativeStuffViewModel
	{
		private string _stuff ="";

		public NativeStuffViewModel()
		{
			Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
			Accelerometer.Start(SensorSpeed.UI);
		}

		private void Accelerometer_ReadingChanged(object? sender, AccelerometerChangedEventArgs e)
		{
			var data = e.Reading;
			var message = $"Reading: X: {data.Acceleration.X}, Y: {data.Acceleration.Y}, Z: {data.Acceleration.Z}";
			Stuff = message;

		}

		public string Stuff
		{
			get => _stuff;
			set => SetValue(ref _stuff, value);
		}
	}
}