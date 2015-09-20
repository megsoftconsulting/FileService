using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Media.Plugin.Abstractions;
using Media.Plugin;
using System.IO;

namespace FileService
{

	public class CameraClient : ICameraClient {

		public async Task<PhotoRecordTable> TakePhotoAsync (string directory, string name)
		{
			
			if (!CrossMedia.Current.IsCameraAvailable)
			{
				//No camera?
				return null;
			}

			var configuration = new StoreCameraMediaOptions 
			{
				Directory = directory,
				Name = name
			};

			var photo = await CrossMedia.Current.TakePhotoAsync (configuration);

			var pictureTaken = new PhotoRecordTable
			{
				PicturePath = photo.Path,
				PictureStream = photo.GetStream()
			};

			return pictureTaken;
		}
	}
}
