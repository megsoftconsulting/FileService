using System;
using System.Threading.Tasks;
using System.Diagnostics;

namespace FileService
{

	public class Logger : ILogger
	{
		public async Task LogAsync (string message)
		{
			
			await Task.Factory.StartNew (() => Debug.WriteLine (message));
		}
	}
}
