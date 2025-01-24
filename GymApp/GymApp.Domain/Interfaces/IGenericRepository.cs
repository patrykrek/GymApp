using System.Linq.Expressions;

namespace GymApp.GymApp.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);

        Task<IEnumerable<T>> GetAllWithIncludeAsync(
            Expression<Func<T, bool>> predicate = null,
            params Expression<Func<T, object>>[] includeProperties);

        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetSingleAsync(Expression<Func<T, bool>> predicate);

        Task AddAsync(T entity);

        Task EditAsync(T entity);

        Task DeleteAsync(int id);

        Task<bool> ExistsAsync(int id);

    }
}
