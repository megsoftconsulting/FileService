using System;
using SQLite.Net;
using SQLite.Net.Async;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace FileService
{
	public interface IDatabaseClient<TEntity> where TEntity : class
	{
		Task<int> InsertAsync(TEntity data);

		Task<IList<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> queryFunction);
	}
}

