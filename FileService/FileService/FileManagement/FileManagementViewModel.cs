using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using PropertyChanged;
using System.Windows.Input;

namespace FileService
{
	public class FileManagementViewModel : ViewModelBase
	{
		public ObservableCollection<File> FilesSyncronized { get; set; }

		public ObservableCollection<File> FilesNotSynchronized { get; set; }

		public File FileSelected { get; set; }

		public string WindowTitle { get; set; }

		public string BackgroundColor { get; set; }

		public string HeaderTileBackground { get; set; }

		public string BottomTileBackground { get; set; }

		public string WarningIcon { get; set; }

		public string FilesRemainingToBeUploaded { get; set; }

		public string UploadAllOptionText { get; set; }

		public ICommand UploadAllSelected { get; set; }

		public FileManagementViewModel ()
		{
			NavigatedTo();
		}

		void NavigatedTo ()
		{
			WindowTitle = "File Service";

			BackgroundColor = "#FFFFFF";

			WarningIcon = "warning_icon";

			HeaderTileBackground = "59ABE3";

			BottomTileBackground = "ECF0F1";

			FilesSyncronized = new ObservableCollection<File> { 
				
			};

			FilesNotSynchronized = new ObservableCollection<File> {
				
			};

			FilesRemainingToBeUploaded = string.Format ("{0} files remaining to upload", FilesNotSynchronized.Count);

			UploadAllOptionText = "Upload All";
		}
	}
}

