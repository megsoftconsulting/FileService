using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FileService
{
	public interface IServerClient
	{
		Task Upload(string id);

		event EventHandler<ProgressArgs> ProgressEvent;

		event EventHandler<ProgressArgs> FinishedEvent;
	}

}