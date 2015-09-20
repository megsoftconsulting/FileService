using System;
using System.Threading.Tasks;
using System.Diagnostics;

namespace FileService
{
	public interface ILogger
	{
		Task LogAsync(string message);
	}

}

