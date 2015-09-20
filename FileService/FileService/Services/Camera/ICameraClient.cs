using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Media.Plugin.Abstractions;
using Media.Plugin;
using System.IO;

namespace FileService
{
	public interface ICameraClient
	{
		Task<PhotoRecordTable> TakePhotoAsync(string directory, string name);
	}
}