using System;
using SQLite.Net.Async;

namespace FileService
{
	/// <summary>
	/// Each platform will implement this interface to provide their own platform configuration
	/// </summary>
	public interface IPlatformSQLiteConnection
	{
		SQLiteAsyncConnection OpenConnection();
	}
}

