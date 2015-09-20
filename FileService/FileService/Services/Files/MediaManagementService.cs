using System;
using PCLStorage;
using System.Threading.Tasks;

namespace FileService
{

	public class MediaManagementService : IMediaManagementService
	{
		IFolder _rootFolder;

		public MediaManagementService ()
		{
			_rootFolder = FileSystem.Current.LocalStorage;
		}

		public async Task<string> ReadFile (string fileName)
		{ 
			var file = await _rootFolder.GetFileAsync (fileName);

			return await file.ReadAllTextAsync ();
		}

		public async Task SaveFile (string content, string fileName)
		{
			var _file = await _rootFolder.CreateFileAsync (fileName,
				CreationCollisionOption.FailIfExists);

			await _file.WriteAllTextAsync (content);
		}  

		public async Task MoveFile(string fileName, string toPath)
		{
			var _file = await _rootFolder.CreateFileAsync (fileName,
				CreationCollisionOption.OpenIfExists);

			await _file.MoveAsync(toPath);
		}

		public async Task DeleteFile(string fileName)
		{
			var _file = await _rootFolder.CreateFileAsync (fileName,
				CreationCollisionOption.OpenIfExists);

			await _file.DeleteAsync();
		}
	}
}