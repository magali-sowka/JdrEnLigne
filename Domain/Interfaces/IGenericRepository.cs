using System.Linq.Expressions;

namespace Domain.Interfaces
{
	public interface IGenericRepository<T> where T : class
	{
		void Add(T entity);
		void AddRange(IEnumerable<T> entities);
		void Update(T entity);
		IQueryable<T> GetAllIQ(string? includeProperties = null);
		Task<IEnumerable<T>> GetAllAsync(string? includeProperties = null);
		Task<T?> GetAsync(Expression<Func<T, bool>> expression, string? includeProperties = null);
		Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression, string? includeProperties = null);
		ValueTask<T?> GetByIdAsync(params object?[]? id);
		void Remove(T entity);
		void RemoveRange(IEnumerable<T> entities);
		
	}
}
