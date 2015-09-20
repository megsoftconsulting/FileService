using System;
using Xamarin.Forms;
using SQLite.Net.Async;
using FileService.iOS;
using SQLite.Net.Platform.XamarinIOS;
using SQLite.Net;

[assembly: Dependency (typeof (IOsSQLiteConnection))]
namespace FileService.iOS
{
	public class IOsSQLiteConnection : IPlatformSQLiteConnection, IDisposable
	{
		const string DATABASE_PATH = "FileServer.db";

		SQLiteAsyncConnection _databaseConnection;

		public IOsSQLiteConnection ()
		{
			_databaseConnection = new SQLiteAsyncConnection 
				(()=>new SQLiteConnectionWithLock(new SQLitePlatformIOS(),
					new SQLiteConnectionString(DATABASE_PATH,
						storeDateTimeAsTicks: false)));
		}

		public SQLiteAsyncConnection OpenConnection ()
		{
			return _databaseConnection;
		}

		public void Dispose ()
		{
			Dispose (true);
		}

		public void Dispose(bool disposing)
		{

			if (disposing) {

				_databaseConnection = null;
			}
		}
	}
}

