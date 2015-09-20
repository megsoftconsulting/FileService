using System;
using System.ComponentModel;
using PropertyChanged;

namespace FileService
{
	[ImplementPropertyChanged]
	public class ViewModelBase : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged (PropertyChangedEventArgs e)
		{
			var handler = PropertyChanged;
			if (handler != null)
				handler (this, e);
			
		}
	}
}

