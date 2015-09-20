using System;
using FileService.Droid; 
using SQLite.Net.Async;
using SQLite.Net.Platform.XamarinAndroid;
using Xamarin.Forms;
using SQLite.Net;

[assembly: Dependency((typeof (AndroidSQLiteConnection)))]
namespace FileService.Droid
{
	
	public class AndroidSQLiteConnection : IPlatformSQLiteConnection, IDisposable
	{
		readonly string DATABASE_PATH;

		SQLiteAsyncConnection _databaseConnection;

		public AndroidSQLiteConnection ()
		{
			DATABASE_PATH = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "FileServer.db";

			_databaseConnection = new SQLiteAsyncConnection 
				(()=>new SQLiteConnectionWithLock(new SQLitePlatformAndroid(),
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

