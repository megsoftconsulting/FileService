using System;
using PCLStorage;
using System.Threading.Tasks;

namespace FileService
{
	public interface IMediaManagementService
	{
		Task<string> ReadFile(string fileName);

		Task SaveFile(string content, string fileName);

		Task MoveFile(string fileName, string toPath);

		Task DeleteFile(string fileName);
	}

}