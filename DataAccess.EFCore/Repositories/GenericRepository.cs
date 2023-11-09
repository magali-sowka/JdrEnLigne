using DataAccess.EFCore.Data;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.EFCore.Repositories
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		protected readonly JdrContext _context;
		protected DbSet<T> dbSet;

		public GenericRepository(JdrContext context)
		{
			_context = context;
			dbSet = _context.Set<T>();
		}
		public void Add(T entity)
		{
			dbSet.Add(entity);
		}

		public void AddRange(IEnumerable<T> entities)
		{
			dbSet.AddRange(entities);
		}

		public void Update(T entity)
		{
			dbSet.Update(entity);
		}

		public IQueryable<T> GetAllIQ(string? includeProperties = null)
		{
			return Query(null, includeProperties);
		}
		public async Task<IEnumerable<T>> GetAllAsync(string? includeProperties = null)
		{
			return await Query(null, includeProperties).ToListAsync();
		}

		public async Task<T?> GetAsync(Expression<Func<T, bool>> expression, string? includeProperties = null)
		{
			return await Query(expression, includeProperties).FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression, string? includeProperties = null)
		{
			return await Query(expression, includeProperties).ToListAsync();
		}

		public ValueTask<T?> GetByIdAsync(params object?[]? id)
		{
			return dbSet.FindAsync(id);
		}

		public void Remove(T entity)
		{
			dbSet.Remove(entity);
		}

		public void RemoveRange(IEnumerable<T> entities)
		{
			dbSet.RemoveRange(entities);
		}

		private IQueryable<T> Query(Expression<Func<T, bool>>? expression = null, string? includeProperties = null)
		{
			IQueryable<T> query = dbSet;

			if (expression != null)
			{
				query = query.Where(expression);
			}

			if (!string.IsNullOrEmpty(includeProperties))
			{
				foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
				{
					query = query.Include(property);
				}
			}

			return query;
		}
	}
}
