using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace FileService
{
	public class FileViewModel : ViewModelBase
	{
		public string FileName { get; set; }

		public string FileSize { get; set; }

		public string FileTypeIcon { get; set; }

		public string LastDateModified { get; set; }

		public float Progress { get; set; } = 0;

		public string ProgressStatusImage { get; set; }

		public ICommand UploadCommand { get; set; }
	}
}

