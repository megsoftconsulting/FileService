using System;
using PCLStorage;
using System.Threading.Tasks;

namespace FileService
{
	public interface IMediaManagement
	{
		Task<string> ReadFile(string fileName);

		Task SaveFile(string content, string fileName);

		Task MoveFile(string fileName, string toPath);

		Task DeleteFile(string fileName);
	}

	public class MediaManagement : IMediaManagement
	{
		IFolder _rootFolder;

		IFolder _folder;

		public MediaManagement ()
		{
			_rootFolder = FileSystem.Current.LocalStorage;
		}

		public async Task<string> ReadFile (string fileName)
		{
			_folder = await _rootFolder.CreateFolderAsync (fileName,
				CreationCollisionOption.OpenIfExists);
			
			var file = await _rootFolder.GetFileAsync (fileName);

			return await file.ReadAllTextAsync ();
		}

		public async Task SaveFile (string content, string fileName)
		{
			var _file = await _folder.CreateFileAsync (fileName,
				CreationCollisionOption.FailIfExists);

			await _file.WriteAllTextAsync (content);
		}  

		public async Task MoveFile(string fileName, string toPath)
		{
			var _file = await _folder.CreateFileAsync (fileName,
				CreationCollisionOption.OpenIfExists);

			await _file.MoveAsync(toPath);
		}

		public async Task DeleteFile(string fileName)
		{
			var _file = await _folder.CreateFileAsync (fileName,
				CreationCollisionOption.OpenIfExists);

			await _file.DeleteAsync();
		}
	}
}