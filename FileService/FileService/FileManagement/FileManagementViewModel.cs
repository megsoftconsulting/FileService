using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using PropertyChanged;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;

namespace FileService
{
	public class FileManagementViewModel : ViewModelBase
	{
		public ObservableCollection<FileViewModel> FilesSyncronized { get; set; }

		public ObservableCollection<FileViewModel> FilesNotSynchronized { get; set; }

		public FileViewModel FileSelected { get; set; }

		public string WindowTitle { get; set; }

		public Color BackgroundColor { get; set; }

		public string WarningIcon { get; set; }

		public string FilesRemainingToBeUploaded { get; set; }

		public string UploadAllOptionText { get; set; }

		public ICommand UploadAllSelected { get; set; }

		public Command<FileViewModel> UploadToServerCommand { get; set; }

		IFileViewModelFactory _fileViewModelFactory;

		IServerClient _serverClient;

		public FileManagementViewModel (IFileViewModelFactory fileViewModelFactory,
			IServerClient serverClient)
		{
			_fileViewModelFactory = fileViewModelFactory;

			_serverClient = serverClient;

			_serverClient.ProgressEvent += OnProgressChanged;

			_serverClient.FinishedEvent += OnFinishedEvent;

			NavigatedTo();

			UploadToServerCommand = new Command<FileViewModel>(ExecuteUploadToServer);
		}

		void OnFinishedEvent (object sender, ProgressArgs args)
		{
			var file = FindFile (args);

			if (file != null) {

				file.ProgressStatusImage = "uploaded";
			}
		}

		void OnProgressChanged (object sender, ProgressArgs args)
		{
			var file = FindFile (args);

			if (file != null) {

				file.Progress = args.Progress;
			}
		}

		FileViewModel FindFile(ProgressArgs args)
		{
			var fileIdentifier = args.FileName;

			var file = FilesNotSynchronized.FirstOrDefault (e => e.FileName == fileIdentifier);

			return file;
		}

		void ExecuteUploadToServer (FileViewModel file)
		{
			_serverClient.Upload (file.FileName);
		}

		void NavigatedTo ()
		{
			WindowTitle = "File Service";

			BackgroundColor = Color.FromHex("FFFFFF");

			WarningIcon = "warning_icon";

			FilesSyncronized = new ObservableCollection<FileViewModel> { 
				
			};

			var item1 = _fileViewModelFactory.Build ();

			item1.FileName = "File00001";  
			item1.FileSize = "8.0mb";
			item1.FileTypeIcon = "placeholder";
			item1.LastDateModified = "12/12/15";
			item1.ProgressStatusImage = "upload";

			var item2 = _fileViewModelFactory.Build ();

			item2.FileName = "File00002";  
			item2.FileSize = "16.0mb";
			item2.FileTypeIcon = "placeholder";
			item2.LastDateModified = "9/12/15";
			item2.ProgressStatusImage = "upload";

			var item3 = _fileViewModelFactory.Build ();

			item3.FileName = "File00003";  
			item3.FileSize = "1.0mb";
			item3.FileTypeIcon = "placeholder";
			item3.LastDateModified = "4/12/15";
			item3.ProgressStatusImage = "upload";
 
			FilesNotSynchronized = new ObservableCollection<FileViewModel> {
				item1, item2, item3
			};

			FilesRemainingToBeUploaded = string.Format ("{0} files remaining to be uploaded", FilesNotSynchronized.Count);

			UploadAllOptionText = "Upload All";
		}
	}
}

