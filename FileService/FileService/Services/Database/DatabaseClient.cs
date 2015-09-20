using System;
using SQLite.Net;
using SQLite.Net.Async;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Xamarin.Forms;

namespace FileService
{
	public class DatabaseClient<TEntity> : IDatabaseClient<TEntity> where TEntity : class
	{ 
		SQLiteAsyncConnection _databaseConnection;

		IPlatformSQLiteConnection _platformConnection;

		ILogger _logger;

		public DatabaseClient (ILogger logger)
		{
			_logger = logger;

			_platformConnection = DependencyService.Get<IPlatformSQLiteConnection>();

			_databaseConnection = _platformConnection.OpenConnection ();

			Init ();
		}

		async void Init ()
		{
			await CreateTable ();
		}

		async Task CreateTable ()
		{
			 await _databaseConnection.CreateTableAsync<TEntity> ().ContinueWith (async (results) => {

				if (results.IsFaulted || results.IsCanceled)
				{
					var exception = results.Exception.InnerException ?? new Exception();

					await _logger.LogAsync (exception.ToString());
				}
				else
					await _logger.LogAsync ("Table created");
			});
		}

		public async Task<int> InsertAsync(TEntity data)
		{
			return await _databaseConnection.InsertAsync (data);
		}

		public async Task<IList<TEntity>> ReadAsync (Expression<Func<TEntity, bool>> queryFunction)
		{
			
			var query = _databaseConnection.Table<TEntity>().Where(queryFunction);

			return await query.ToListAsync ();
		}
	}
}
