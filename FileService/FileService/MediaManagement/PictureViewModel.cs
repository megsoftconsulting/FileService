using System;
using System.Windows.Input;
using Xamarin.Forms;
using System.IO;

namespace FileService
{
	public class PictureViewModel : ViewModelBase
	{
		ICameraClient _cameraClient;

		IDatabaseClient<PhotoRecordTable> _databaseClient;

		ILogger _loggerService;

		IMediaManagementService _mediaManagementService;

		public ICommand TakePictureSelected { get; set; }

		public ICommand SavePicture { get; set; }

		public ImageSource PictureTaken { get; set; }

		public string PicturePath { get; set; }

		public string WindowTitle { get; set; }

		public string HeaderLabel { get; set; }

		public PhotoRecordTable Picture { get; set; }

		public bool Saved { get; set; } = false;



		public PictureViewModel 
			(ICameraClient cameraClient,
			IDatabaseClient<PhotoRecordTable> databaseClient,
			ILogger loggerService,
			IMediaManagementService mediaManagementService)
		{
			_mediaManagementService = mediaManagementService;

			_loggerService = loggerService;

			_databaseClient = databaseClient;

			_cameraClient = cameraClient;

			TakePictureSelected = new Command (ExecuteTakePicture);

			SavePicture = new Command (ExecuteSavePicture);

			Init ();
		}

		void Init ()
		{
			WindowTitle = "Picture";

			HeaderLabel = "Let's take a picture";
		}

		public async void ExecuteTakePicture()
		{
			var randomName = Guid.NewGuid ().ToString();

			Picture = await _cameraClient.TakePhotoAsync ("FileService", randomName);

			PicturePath = Picture.PicturePath;

			PictureTaken = ImageSource.FromStream (() => Picture.PictureStream);
		}

		public async void ExecuteSavePicture()
		{
			var result = await _databaseClient.InsertAsync(Picture);

			//TODO: Implement NotificationService to show Feedback
			if (result == 1) {

				Saved = true;
			}

			await _loggerService.LogAsync (string.Format("Result returned {0}", result));
		}
	}
}