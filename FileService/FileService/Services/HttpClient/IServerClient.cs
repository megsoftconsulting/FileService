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

	public class ServerClient : IServerClient 
	{
		
		public event EventHandler<ProgressArgs> ProgressEvent;

		public event EventHandler<ProgressArgs> FinishedEvent;

		IProgress<ProgressArgs> _progressReporter;

		public ServerClient ()
		{

			_progressReporter = new Progress<ProgressArgs> (OnProgressReport);	
		}

		public async Task Upload (string id)
		{
			//http://stackoverflow.com/a/24777502

			await Task.Run (
				async () => {
					for (int x = 0; x <= 100; x++) {
						
						await Task.Delay (50);

						var nextProgress = x / 100f;

						var args = new ProgressArgs 
						{
							Progress = nextProgress,
							FileName = id
						};

						if(nextProgress == 1f)
						{
							OnFinishedEvent(args);
						}else
						{
							_progressReporter.Report (args);
						}
					}
				});
		}

		void OnProgressReport (ProgressArgs args)
		{
			RaiseOnProgressChanged (args);
		}

		void OnFinishedEvent(ProgressArgs args)
		{
			RaiseFinishedProgress (args);
		}

		void RaiseOnProgressChanged (ProgressArgs e)
		{
			var eventHandler = ProgressEvent;

			if (eventHandler != null)
				eventHandler (this, e);
		}

		void RaiseFinishedProgress (ProgressArgs e)
		{
			var eventHandler = FinishedEvent;

			if (eventHandler != null)
				eventHandler (this, e);
		}
	}
}